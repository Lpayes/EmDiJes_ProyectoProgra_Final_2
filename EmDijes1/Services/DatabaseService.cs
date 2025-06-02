using EmDijes1.Models;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmDijes1.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        // Constructor que recibe la cadena de conexión
        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método estático para obtener la cadena de conexión desde appsettings.json
        public static string ObtenerConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connStr = config.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connStr))
                throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection' en appsettings.json.");

            return connStr;
        }

        // Guarda el resumen generado en la base de datos
        public async Task GuardarResumenAsync(ResumenUsuario resumen)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            string query = @"
        INSERT INTO ResumenUsuario 
        (FechaRegistro, Emocion, Versiculo, Reflexion, Consejo, Oracion, Canciones)
        VALUES 
        (@Fecha, @Emocion, @Versiculo, @Reflexion, @Consejo, @Oracion, @Canciones)";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Fecha", resumen.FechaRegistro);
            // Emocion es NOT NULL, así que nunca debe ser null ni DBNull.Value
            cmd.Parameters.AddWithValue("@Emocion", string.IsNullOrWhiteSpace(resumen.Emocion) ? "desconocido" : resumen.Emocion);
            cmd.Parameters.AddWithValue("@Versiculo", resumen.Versiculo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Reflexion", resumen.Reflexion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Consejo", resumen.Consejo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Oracion", resumen.Oracion ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Canciones", resumen.Canciones ?? (object)DBNull.Value);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task GuardarRespuestasUsuarioAsync(RespuestasUsuario respuestas)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            string query = @"
        INSERT INTO RespuestasUsuario
        (FechaRegistro, EmocionDetectada, Respuesta1, Respuesta2, Respuesta3, Respuesta4, Respuesta5, Respuesta6, Respuesta7)
        VALUES
        (@FechaRegistro, @EmocionDetectada, @Respuesta1, @Respuesta2, @Respuesta3, @Respuesta4, @Respuesta5, @Respuesta6, @Respuesta7)";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);
            cmd.Parameters.AddWithValue("@EmocionDetectada", string.IsNullOrWhiteSpace(respuestas.EmocionDetectada) ? "desconocido" : respuestas.EmocionDetectada);
            cmd.Parameters.AddWithValue("@Respuesta1", respuestas.Respuesta1 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Respuesta2", respuestas.Respuesta2 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Respuesta3", respuestas.Respuesta3 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Respuesta4", respuestas.Respuesta4 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Respuesta5", respuestas.Respuesta5 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Respuesta6", respuestas.Respuesta6 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Respuesta7", respuestas.Respuesta7 ?? (object)DBNull.Value);

            await cmd.ExecuteNonQueryAsync();
        }

    }
}