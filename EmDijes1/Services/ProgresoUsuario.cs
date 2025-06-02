using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace EmDijes1.Services
{
    public class ResumenUsuarioService
    {
        private readonly string _connectionString;

        public ResumenUsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DataTable> ObtenerTodosAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            string query = "SELECT * FROM ResumenUsuario ORDER BY FechaRegistro DESC";
            using var cmd = new SqlCommand(query, conn);
            using var reader = await cmd.ExecuteReaderAsync();
            var dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        public async Task<DataTable> ObtenerPorFechaAsync(DateTime fecha)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            string query = "SELECT * FROM ResumenUsuario WHERE CAST(FechaRegistro AS DATE) = @Fecha";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Fecha", fecha.Date);
            using var reader = await cmd.ExecuteReaderAsync();
            var dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        public async Task<DataTable> ObtenerPorIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            string query = "SELECT * FROM ResumenUsuario WHERE Id = @Id";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = await cmd.ExecuteReaderAsync();
            var dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
    }
}