using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmDijes1.Models;
using EmDijes1.Services;
using EmDijes1.Utils;

namespace EmDijes1.Forms
{
    public partial class FormularioResumen : Form
    {
        private readonly RespuestasUsuario respuestas;
        private readonly string emocion;
        private readonly ServicioOpenAI servicioOpenAI;

        public FormularioResumen(RespuestasUsuario respuestasUsuario, string emocionRecibida, ServicioOpenAI servicio)
        {
            InitializeComponent();

            respuestas = respuestasUsuario ?? throw new ArgumentNullException(nameof(respuestasUsuario));
            emocion = emocionRecibida ?? throw new ArgumentNullException(nameof(emocionRecibida));
            servicioOpenAI = servicio ?? throw new ArgumentNullException(nameof(servicio));

            Shown += async (_, __) => await GenerarResumenAsync();

            buttonCerrar.Click += (_, __) => Close();
            buttonVerVideo.Click += buttonVerVideo_Click;
            buttonBuscarEnYouTube.Click += buttonBuscarEnYouTube_Click;
            webViewVideo.Dock = DockStyle.Fill;
        }

        public FormularioResumen(ResumenUsuario resumen)
        {
            InitializeComponent();

            labelEmocion.Text = $"Emoción detectada: {Capitalizar(resumen.Emocion)}";
            textBoxVersiculo.Text = resumen.Versiculo;
            textBoxReflexion.Text = resumen.Reflexion;
            textBoxConsejo.Text = resumen.Consejo;
            textBoxOracion.Text = resumen.Oracion;
            textBoxCanciones.Text = resumen.Canciones;

            buttonCerrar.Click += (_, __) => Close();
            buttonVerVideo.Click += buttonVerVideo_Click;
            buttonBuscarEnYouTube.Click += buttonBuscarEnYouTube_Click;
            webViewVideo.Dock = DockStyle.Fill;
        }

        private async Task GenerarResumenAsync()
        {
            labelEmocion.Text = $"Emoción detectada: {Capitalizar(emocion)}";
            DeshabilitarControles();

            string prompt = ConstruirPromptResumen(respuestas, emocion);

            try
            {
                string respuestaIA = await servicioOpenAI.ObtenerRespuestaAsync(prompt);
                ProcesarRespuestaIA(respuestaIA);

                var resumen = new ResumenUsuario
                {
                    FechaRegistro = DateTime.Now,
                    Emocion = string.IsNullOrWhiteSpace(emocion) ? "desconocido" : emocion,
                    Versiculo = textBoxVersiculo.Text,
                    Reflexion = textBoxReflexion.Text,
                    Consejo = textBoxConsejo.Text,
                    Oracion = textBoxOracion.Text,
                    Canciones = textBoxCanciones.Text
                };

                string connectionString = DatabaseService.ObtenerConnectionString();
                var dbService = new DatabaseService(connectionString);
                await dbService.GuardarResumenAsync(resumen);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el resumen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HabilitarControles();
            }
        }

        private void ProcesarRespuestaIA(string texto)
        {
            textBoxVersiculo.Text = ExtraerSeccion(texto, "versículo");
            textBoxReflexion.Text = ExtraerSeccion(texto, "reflexión");
            textBoxConsejo.Text = ExtraerSeccion(texto, "consejo");
            textBoxOracion.Text = ExtraerSeccion(texto, "oración");
            textBoxCanciones.Text = ExtraerSeccion(texto, "canciones recomendadas");
        }

        private string ExtraerSeccion(string texto, string etiqueta)
        {
            etiqueta = etiqueta.ToLowerInvariant();

            string pattern = etiqueta switch
            {
                "canciones recomendadas" => $@"{etiqueta}[^:]*:\s*(.+?)(?=(versículo|reflexión|consejo|oración|\Z))",
                _ => $@"{etiqueta}[^:]*:\s*(.+?)(?=(versículo|reflexión|consejo|oración|canciones recomendadas|\Z))"
            };

            var match = Regex.Match(texto, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            return match.Success ? match.Groups[1].Value.Trim() : $"No se encontró la sección de {etiqueta}.";
        }

        private string ConstruirPromptResumen(RespuestasUsuario r, string emocion)
        {
            string emocionNormalizada = EmocionHelper.MapearEmocion(emocion);
            string[] preguntas = EmocionHelper.ObtenerPreguntasSegunEmocion(emocionNormalizada);

            string historial = "";
            for (int i = 0; i < 7; i++)
            {
                var prop = r.GetType().GetProperty($"Respuesta{i + 1}");
                string respuesta = prop != null ? prop.GetValue(r)?.ToString() ?? "" : "";
                historial += $"{i + 1}. Pregunta: {preguntas.ElementAtOrDefault(i)}\n   Respuesta: {respuesta}\n";
            }

            return
                $"El usuario expresó sentirse {emocionNormalizada} y respondió lo siguiente:\n\n" +
                historial +
                "\nCon base en estas respuestas y la emoción reportada, redacta lo siguiente en un solo bloque y cada parte claramente identificada:\n\n" +
                "**Versículo:**\n(Escribe aquí un versículo bíblico de la Reina Valera 1960 que consuele o anime según la emoción y las respuestas del usuario. Explica brevemente por qué lo elegiste.)\n\n" +
                "**Reflexión:**\n(Redacta una reflexión espiritual extensa, de al menos 10 líneas, que conecte con las respuestas del usuario. Si el usuario expresa lejanía de Dios, anímale a acercarse. Sé empático y profundo.)\n\n" +
                "**Consejo:**\n(Brinda un consejo cristiano, práctico y espiritual, personalizado según las respuestas. Si el usuario dice que no está cerca de Dios, anímale a buscarle y explícale cómo puede hacerlo.)\n\n" +
                "**Oración:**\n(Escribe una oración personalizada y extensa, de al menos 8 líneas, pidiendo a Dios consuelo, fortaleza, guía y cercanía para el usuario, mencionando detalles relevantes de sus respuestas. Sé cálido y profundo.)\n\n" +
                "**Canciones recomendadas:**\n(Escribe una lista de 6 canciones cristianas adecuadas para la emoción del usuario, cada una con su nombre y un enlace directo a YouTube. Ejemplo: 1. Nombre - https://...)\n\n";
        }

        private string Capitalizar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            return char.ToUpper(texto[0]) + texto[1..];
        }

        private void DeshabilitarControles()
        {
            textBoxVersiculo.Text = "Cargando...";
            textBoxReflexion.Text = "Cargando...";
            textBoxConsejo.Text = "Cargando...";
            textBoxOracion.Text = "Cargando...";
            textBoxCanciones.Text = "Cargando...";
            buttonCerrar.Enabled = false;
            buttonVerVideo.Enabled = false;
            buttonBuscarEnYouTube.Enabled = false;
        }

        private void HabilitarControles()
        {
            buttonCerrar.Enabled = true;
            buttonVerVideo.Enabled = true;
            buttonBuscarEnYouTube.Enabled = true;
        }

        private void buttonVerVideo_Click(object sender, EventArgs e)
        {
            string url = textBoxEnlaceVideo.Text.Trim();
            if (!string.IsNullOrEmpty(url) && url.Contains("youtube.com"))
            {
                webViewVideo.Source = new Uri(url);
            }
            else
            {
                MessageBox.Show("Por favor, introduce un enlace válido de YouTube.");
            }
        }

        private async void buttonBuscarEnYouTube_Click(object sender, EventArgs e)
        {
            string cancion = textBoxCanciones.SelectedText;
            if (string.IsNullOrWhiteSpace(cancion))
            {
                cancion = textBoxCanciones.Lines.FirstOrDefault();
            }

            if (!string.IsNullOrWhiteSpace(cancion))
            {
                var match = Regex.Match(cancion, @"\d+\.\s*(.+?)(?:\s*-\s*https?://[^\s]+)?$");
                string nombreCancion = match.Success ? match.Groups[1].Value : cancion;

                string query = Uri.EscapeDataString(nombreCancion + " canción cristiana");
                string searchUrl = $"https://www.youtube.com/results?search_query={query}";

                using var httpClient = new System.Net.Http.HttpClient();
                string html = await httpClient.GetStringAsync(searchUrl);

                var videoMatch = Regex.Match(html, @"\/watch\?v=([a-zA-Z0-9_\-]{11})");
                if (videoMatch.Success)
                {
                    string videoId = videoMatch.Groups[1].Value;
                    string videoUrl = $"https://www.youtube.com/watch?v={videoId}";
                    webViewVideo.Source = new Uri(videoUrl);
                }
                else
                {
                    MessageBox.Show("No se encontró un video para esa búsqueda.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona o copia el nombre de la canción a buscar.");
            }
        }
    }
}