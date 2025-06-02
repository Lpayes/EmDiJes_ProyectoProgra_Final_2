using EmDijes1.Forms;
using EmDijes1.Models;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmDijes1.Services;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Linq;
using EmDijes1.Utils;

namespace EmDijes1
{
    public partial class HistorialForm : Form
    {
        private readonly ResumenUsuarioService _service;
        private Chart chartEmociones;

        public HistorialForm()
        {
            InitializeComponent();
            InicializarChart();
            string connectionString = DatabaseService.ObtenerConnectionString();
            _service = new ResumenUsuarioService(connectionString);
        }

        private void InicializarChart()
        {
            chartEmociones = new Chart();
            chartEmociones.Dock = DockStyle.Fill;
            chartEmociones.Name = "chartEmociones";
            chartEmociones.ChartAreas.Add(new ChartArea());

            if (panelGrafica != null)
                panelGrafica.Controls.Add(chartEmociones);
        }

        private void MostrarGraficaEmociones(DataTable dt)
        {
            var conteo = dt.AsEnumerable()
                .GroupBy(row => EmocionHelper.MapearEmocion(row["Emocion"]?.ToString()))
                .Select(g => new { Emocion = g.Key, Cantidad = g.Count() })
                .ToList();

            chartEmociones.Series.Clear();
            chartEmociones.Titles.Clear();
            if (chartEmociones.Legends.Count == 0)
                chartEmociones.Legends.Add(new Legend());

            var serie = new Series
            {
                Name = "Emociones",
                ChartType = SeriesChartType.Pie
            };

            var colores = new Dictionary<string, Color>
            {
                { "feliz", Color.Yellow },
                { "triste", Color.Blue },
                { "enojado", Color.Red },
                { "sorprendido", Color.Orange },
                { "disgustado", Color.MediumVioletRed },
                { "neutral", Color.LightGreen },
                { "desconocido", Color.LightGray }
            };

            foreach (var item in conteo)
            {
                int idx = serie.Points.AddY(item.Cantidad);
                serie.Points[idx].LegendText = $"{item.Emocion} ({item.Cantidad})";
                if (colores.TryGetValue(item.Emocion, out var color))
                    serie.Points[idx].Color = color;
            }

            chartEmociones.Series.Add(serie);
            chartEmociones.Titles.Add("Distribución de Emociones");
            chartEmociones.Legends[0].Docking = Docking.Bottom;
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dt = await _service.ObtenerTodosAsync();
            dataGridView1.DataSource = dt;
            MostrarGraficaEmociones(dt);
        }

        private async void buttonObtenerPorId_Click(object sender, EventArgs e)
        {
            var dt = await _service.ObtenerTodosAsync();
            dataGridView1.DataSource = dt;
            MostrarGraficaEmociones(dt);
        }

        private async void buttonObtenerPorFecha_Click(object sender, EventArgs e)
        {
            var dt = await _service.ObtenerPorFechaAsync(dateTimePicker1.Value);
            dataGridView1.DataSource = dt;
            MostrarGraficaEmociones(dt);
        }

        private async void buttonObtenerTodo_Click(object sender, EventArgs e)
        {
            var dt = await _service.ObtenerTodosAsync();
            dataGridView1.DataSource = dt;
            MostrarGraficaEmociones(dt);
        }

        private async void buttonVerResumen2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxId.Text, out int id))
            {
                var dt = await _service.ObtenerPorIdAsync(id);

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    var resumen = new ResumenUsuario
                    {
                        FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]),
                        Emocion = row["Emocion"]?.ToString() ?? "",
                        Versiculo = row["Versiculo"]?.ToString() ?? "",
                        Reflexion = row["Reflexion"]?.ToString() ?? "",
                        Consejo = row["Consejo"]?.ToString() ?? "",
                        Oracion = row["Oracion"]?.ToString() ?? "",
                        Canciones = row["Canciones"]?.ToString() ?? ""
                    };

                    var formResumen = new FormularioResumen(resumen);
                    formResumen.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encontró un resumen con ese ID.");
                }
            }
            else
            {
                MessageBox.Show("Introduce un ID válido.");
            }
        }

        private void panelGrafica_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}