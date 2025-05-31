using System;
using System.Windows.Forms;
using EmDijes1.Forms;
using EmDijes1.Models;
using EmDijes1.Services;

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

            preguntas = ObtenerPreguntasSegunEmocion(emocionRecibida);
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

        private string[] ObtenerPreguntasSegunEmocion(string emocion)
        {
            switch (emocion)
            {
                case "feliz":
                    return new[]
                    {
                        "¿Por qué te sientes feliz hoy?",
                        "¿Qué situación o persona ha influido más en tu felicidad?",
                        "¿Has agradecido a Dios por este momento de alegría?",
                        "¿Cómo describirías tu paz interior en este momento?",
                        "¿Con quién te gustaría compartir tu felicidad?",
                        "¿Qué te ayuda a mantenerte positivo y animado?",
                        "¿Sientes que tu relación con Dios fortalece tu alegría? ¿Por qué?"
                    };
                case "triste":
                    return new[]
                    {
                        "¿Qué te ha hecho sentir triste hoy?",
                        "¿Hay alguien con quien puedas hablar sobre cómo te sientes?",
                        "¿Qué te ayudaría a sentirte un poco mejor en este momento?",
                        "¿Sientes que tienes paz interior a pesar de la tristeza?",
                        "¿Has buscado apoyo en Dios o en personas cercanas?",
                        "¿Qué cosas te han ayudado antes a superar momentos difíciles?",
                        "¿Sientes que tu relación con Dios te da consuelo en la tristeza?"
                    };
                case "enojado":
                    return new[]
                    {
                        "¿Qué situación te ha provocado enojo?",
                        "¿Cómo sueles manejar el enojo en tu vida diaria?",
                        "¿Hay alguien con quien puedas hablar para desahogarte?",
                        "¿Qué te ayudaría a encontrar paz en este momento?",
                        "¿Has intentado buscar calma o apoyo en Dios?",
                        "¿Qué actividades te ayudan a liberar el enojo de forma saludable?",
                        "¿Sientes que tu relación con Dios te ayuda a controlar el enojo?"
                    };
                case "sorprendido":
                    return new[]
                    {
                        "¿Qué te ha sorprendido recientemente?",
                        "¿Cómo te sentiste al recibir esa sorpresa?",
                        "¿Crees que esta sorpresa ha cambiado tu estado de ánimo?",
                        "¿Has compartido esta experiencia con alguien cercano?",
                        "¿Sientes que Dios tiene un propósito en lo inesperado?",
                        "¿Qué te ayuda a adaptarte a los cambios inesperados?",
                        "¿Cómo influye tu relación con Dios cuando enfrentas sorpresas?"
                    };
                case "disgustado":
                    return new[]
                    {
                        "¿Por qué te sientes disgustado hoy?",
                        "¿Qué situación o persona ha generado este disgusto?",
                        "¿Cómo te afecta emocionalmente este disgusto?",
                        "¿Qué te ayudaría a sentirte mejor ahora?",
                        "¿Has buscado apoyo en Dios o en alguien de confianza?",
                        "¿Qué estrategias usas para recuperar la paz interior?",
                        "¿Sientes que tu relación con Dios te ayuda a superar el disgusto?"
                    };
                default:
                    return new[]
                    {
                        "¿Cómo te sientes hoy y qué palabra describe mejor tu estado de ánimo?",
                        "¿Qué situación o persona ha influido más en cómo te sientes ahora?",
                        "¿Sientes que tienes paz interior en este momento? ¿Por qué?",
                        "¿Hay algo que te gustaría cambiar o mejorar en tu vida emocional o espiritual?",
                        "¿A quién puedes acudir cuando necesitas apoyo o ánimo?",
                        "¿Qué cosas te ayudan a sentirte mejor cuando enfrentas momentos difíciles?",
                        "¿Sientes que tu relación con Dios te da fortaleza o consuelo? ¿Por qué?"
                    };
            }
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
                case 5: if (Respuestas.GetType().GetProperty("Respuesta6") != null) Respuestas.GetType().GetProperty("Respuesta6").SetValue(Respuestas, respuesta); break;
                case 6: if (Respuestas.GetType().GetProperty("Respuesta7") != null) Respuestas.GetType().GetProperty("Respuesta7").SetValue(Respuestas, respuesta); break;
            }
        }
    }
}