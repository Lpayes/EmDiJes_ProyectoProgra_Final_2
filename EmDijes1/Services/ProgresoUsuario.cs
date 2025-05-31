using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class ResumenUsuarioService
{
    private readonly string _connectionString;

    public ResumenUsuarioService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable ObtenerTodos()
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        string query = "SELECT * FROM ResumenUsuario ORDER BY FechaRegistro DESC";
        using var da = new SqlDataAdapter(query, conn);
        var dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable ObtenerPorFecha(DateTime fecha)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        string query = "SELECT * FROM ResumenUsuario WHERE CAST(FechaRegistro AS DATE) = @Fecha";
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Fecha", fecha.Date);
        using var da = new SqlDataAdapter(cmd);
        var dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable ObtenerPorId(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        string query = "SELECT * FROM ResumenUsuario WHERE Id = @Id";
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        using var da = new SqlDataAdapter(cmd);
        var dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
}