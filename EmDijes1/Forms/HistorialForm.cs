using EmDijes1.Forms;
using EmDijes1.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace EmDijes1
{
    public partial class HistorialForm : Form
    {
        private readonly ResumenUsuarioService _service;

        public HistorialForm()
        {
            InitializeComponent();
            string connectionString = DatabaseService.ObtenerConnectionString();
            _service = new ResumenUsuarioService(connectionString);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = _service.ObtenerTodos();
            dataGridView1.DataSource = dt;
        }

        private void buttonObtenerPorId_Click(object sender, EventArgs e)
        {
            DataTable dt = _service.ObtenerTodos();
            dataGridView1.DataSource = dt;
        }

        private void buttonObtenerPorFecha_Click(object sender, EventArgs e)
        {
            DataTable dt = _service.ObtenerPorFecha(dateTimePicker1.Value);
            dataGridView1.DataSource = dt;
        }

        private void buttonObtenerTodo_Click(object sender, EventArgs e)
        {
            DataTable dt = _service.ObtenerTodos();
            dataGridView1.DataSource = dt;
        }

        private void buttonVerResumen2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxId.Text, out int id))
            {
                var dt = _service.ObtenerPorId(id);

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
    }
}