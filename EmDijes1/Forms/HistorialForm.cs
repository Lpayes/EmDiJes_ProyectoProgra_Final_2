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
    }
}