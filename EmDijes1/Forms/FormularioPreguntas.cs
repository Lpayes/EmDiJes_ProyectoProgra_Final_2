using System;
using System.Windows.Forms;
using EmDijes1.Forms;
using EmDijes1.Models;
using EmDijes1.Services;
using EmDijes1.Utils;

namespace EmDijes1
{
    public partial class FormularioPreguntas : Form
    {
        public RespuestasUsuario Respuestas { get; private set; }

        private readonly string[] preguntas;
        private int indicePreguntaActual = 0;
        private readonly ServicioOpenAI servicioOpenAI;
        private readonly string emocionRecibida;

        public FormularioPreguntas(string emocion)
        {
            InitializeComponent();

            emocionRecibida = emocion?.ToLower() ?? "neutral";

            string apiKey = Configuracion.ObtenerApiKeyOpenAI();
            string modelo = Configuracion.ObtenerModeloOpenAI();

            servicioOpenAI = new ServicioOpenAI(apiKey, modelo);

            Respuestas = new RespuestasUsuario
            {
                EmocionDetectada = emocionRecibida
            };

            preguntas = EmocionHelper.ObtenerPreguntasSegunEmocion(emocionRecibida);
            labelPregunta.Text = preguntas[indicePreguntaActual];

            ConfigurarControles();

            buttonCancelar.Click += (_, __) => DialogResult = DialogResult.Cancel;
            buttonSiguiente.Click += async (s, e) => await ButtonSiguiente_ClickAsync(s, e);
        }

        private void ConfigurarControles()
        {
            textBoxRespuesta.Text = string.Empty;
            textBoxRespuestaIA.Visible = true;
            textBoxRespuestaIA.ReadOnly = true;
            textBoxRespuestaIA.Text = string.Empty;
        }

        private async System.Threading.Tasks.Task ButtonSiguiente_ClickAsync(object sender, EventArgs e)
        {
            string respuestaUsuario = textBoxRespuesta.Text.Trim();

            if (string.IsNullOrEmpty(respuestaUsuario))
            {
                MessageBox.Show("Por favor, responde la pregunta antes de continuar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GuardarRespuesta(indicePreguntaActual, respuestaUsuario);

            // Mostrar respuesta de la IA
            textBoxRespuestaIA.Visible = true;
            textBoxRespuestaIA.Text = "Cargando respuesta de apoyo...";
            string respuestaIA = await ObtenerRespuestaEmpaticaAsync(
                preguntas[indicePreguntaActual],
                respuestaUsuario,
                emocionRecibida
            );
            textBoxRespuestaIA.Text = respuestaIA;

            indicePreguntaActual++;

            if (indicePreguntaActual < preguntas.Length)
            {
                labelPregunta.Text = preguntas[indicePreguntaActual];
                textBoxRespuesta.Text = string.Empty;
            }
            else
            {
                // Guardar las respuestas SOLO cuando todas han sido contestadas
                string connectionString = DatabaseService.ObtenerConnectionString();
                var dbService = new DatabaseService(connectionString);
                await dbService.GuardarRespuestasUsuarioAsync(Respuestas);

                var resumenForm = new FormularioResumen(Respuestas, emocionRecibida, servicioOpenAI);
                Hide();
                resumenForm.ShowDialog();
                Close();
            }
        }

        private async System.Threading.Tasks.Task<string> ObtenerRespuestaEmpaticaAsync(string pregunta, string respuestaUsuario, string emocion)
        {
            string prompt = $@"
Eres un acompañante espiritual cristiano. El usuario se siente {emocion}.
La pregunta fue: {pregunta}
El usuario respondió: {respuestaUsuario}

Responde de forma empática, espiritual y clara, en máximo 2 párrafos (puede ser menos si es suficiente), animando al usuario, dándole un consejo o palabra de ánimo según su respuesta y la emoción detectada. No hagas preguntas, solo acompaña y anima.
";
            return await servicioOpenAI.ObtenerRespuestaAsync(prompt);
        }

        private void GuardarRespuesta(int indice, string respuesta)
        {
            switch (indice)
            {
                case 0: Respuestas.Respuesta1 = respuesta; break;
                case 1: Respuestas.Respuesta2 = respuesta; break;
                case 2: Respuestas.Respuesta3 = respuesta; break;
                case 3: Respuestas.Respuesta4 = respuesta; break;
                case 4: Respuestas.Respuesta5 = respuesta; break;
                case 5: Respuestas.Respuesta6 = respuesta; break;
                case 6: Respuestas.Respuesta7 = respuesta; break;
            }
        }

        private void labelPregunta_Click(object sender, EventArgs e)
        {

        }
    }
}