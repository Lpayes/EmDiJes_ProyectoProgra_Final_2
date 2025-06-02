namespace EmDijes1.Models
{
    public class RespuestasUsuario
    {
        public int Id { get; set; } 
        public int ResumenId { get; set; } 
        public DateTime FechaRegistro { get; set; } 
        public string EmocionDetectada { get; set; }
        public string Respuesta1 { get; set; }
        public string Respuesta2 { get; set; }
        public string Respuesta3 { get; set; }
        public string Respuesta4 { get; set; }
        public string Respuesta5 { get; set; }
        public string Respuesta6 { get; set; }
        public string Respuesta7 { get; set; }
    }
}