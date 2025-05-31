using EmDijes1.Models;
using EmDijes1.Services;
using OpenCvSharp.Extensions;
using OpenCvSharp;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using DrawingImage = System.Drawing.Image;

namespace EmDijes1
{
    public partial class MainForm : Form
    {
        private VideoCapture camara;
        private Mat fotograma;
        private DrawingImage imagenActual;
        private Thread hiloCamara;
        private bool camaraActiva = false;

        private readonly ConfiguracionAWS configAWS;
        private readonly OpenAISettings configOpenAI;

        private string emocionDetectada = "neutral";

        public MainForm(ConfiguracionAWS configAWS, OpenAISettings configOpenAI)
        {
            InitializeComponent();
            this.configAWS = configAWS;
            this.configOpenAI = configOpenAI;
            this.FormClosed += MainForm_FormClosed;
        }

        private void buttonIniciarCamara_Click(object sender, EventArgs e)
        {
            camara = new VideoCapture(0);
            if (!camara.IsOpened())
            {
                MessageBox.Show("No se pudo abrir la cámara.");
                return;
            }

            fotograma = new Mat();
            camaraActiva = true;

            hiloCamara = new Thread(() =>
            {
                try
                {
                    while (camaraActiva)
                    {
                        camara.Read(fotograma);
                        if (!fotograma.Empty())
                        {
                            imagenActual = BitmapConverter.ToBitmap(fotograma);
                            pictureBoxCamara.Invoke(() => pictureBoxCamara.Image = imagenActual);
                        }
                        Thread.Sleep(30);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la cámara: " + ex.Message);
                }
            });

            hiloCamara.IsBackground = true;
            hiloCamara.Start();
        }

        private async void buttonAnalizarEmocion_Click(object sender, EventArgs e)
        {

            if (imagenActual == null)
            {
                MessageBox.Show("⚠️ No hay imagen de la cámara para analizar.");
                return;
            }

            try
            {
                using var imagenParaAnalizar = (Bitmap)imagenActual.Clone();
                using var ms = new MemoryStream();
                imagenParaAnalizar.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Position = 0;

                var servicio = new ServicioRekognition(configAWS.AccessKey, configAWS.SecretKey, configAWS.Region);
                var emociones = await servicio.DetectarEmocionesDesdeStreamAsync(ms);

                if (emociones == null || emociones.Count == 0)
                {
                    MessageBox.Show("No se detectaron emociones.");
                    emocionDetectada = "neutral";
                    return;
                }

                const float UMBRAL = 0.75f;
                var top = emociones
                    .Where(e => e.Confidence >= UMBRAL)
                    .OrderByDescending(e => e.Confidence)
                    .FirstOrDefault();

                emocionDetectada = top?.Type.ToString().ToLower() ?? "neutral";

                if (top != null)
                {
                    MessageBox.Show($"😀 Emoción: {MapearEmocionAWS(emocionDetectada)} ({top.Confidence * 100:F2}%)");
                }
                else
                {
                    MessageBox.Show("No hay emoción con suficiente confianza.");
                }
            }
            catch (Exception ex)
            {
                emocionDetectada = "neutral";
                MessageBox.Show("❌ Error al analizar: " + ex.Message);
            }
        }

        private void buttonUsarEmocionManual_Click(object sender, EventArgs e)
        {
            var emocionManual = textBoxEmocionManual.Text.Trim().ToLower();

            // Normaliza la emoción para aceptar inglés o español
            var emocionNormalizada = emocionManual switch
            {
                "happy" or "feliz" => "feliz",
                "sad" or "triste" => "triste",
                "angry" or "enojado" => "enojado",
                "surprised" or "sorprendido" => "sorprendido",
                "disgusted" or "disgustado" => "disgustado",
                _ => "neutral"
            };

            using var frm = new FormularioPreguntas(emocionNormalizada);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var respuestas = frm.Respuestas;
            }
        }


        private async void buttonAbrirPreguntas_Click_1(object sender, EventArgs e)
        {
            string emocionParaPreguntas;

            if (!string.IsNullOrWhiteSpace(textBoxEmocionManual.Text))
            {
                var emocionManual = textBoxEmocionManual.Text.Trim().ToLower();
                emocionParaPreguntas = emocionManual switch
                {
                    "happy" or "feliz" => "feliz",
                    "sad" or "triste" => "triste",
                    "angry" or "enojado" => "enojado",
                    "surprised" or "sorprendido" => "sorprendido",
                    "disgusted" or "disgustado" => "disgustado",
                    _ => "neutral"
                };
            }
            // Si no, usa la emoción detectada por la cámara
            else if (emocionDetectada != "neutral")
            {
                emocionParaPreguntas = MapearEmocionAWS(emocionDetectada);
            }
            else
            {
                MessageBox.Show("⚠️ Analiza la emoción o ingresa una manual antes de continuar.");
                return;
            }

            using var frm = new FormularioPreguntas(emocionParaPreguntas);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var respuestas = frm.Respuestas;
            }
        }

        private string MapearEmocionAWS(string emocionAWS)
        {
            return emocionAWS switch
            {
                "happy" => "feliz",
                "sad" => "triste",
                "angry" => "enojado",
                "surprised" => "sorprendido",
                "disgusted" => "disgustado",
                _ => "neutral"
            };
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            camaraActiva = false;
            if (hiloCamara?.IsAlive == true) hiloCamara.Join();
            camara?.Release();
            camara?.Dispose();
            fotograma?.Dispose();
        }

        private void buttonHistorial_Click(object sender, EventArgs e)
        {
            var historialForm = new HistorialForm();
            historialForm.ShowDialog();
        }

        private void buttonUsarEmocionManual_Click_1(object sender, EventArgs e)
        {
            var emocionManual = textBoxEmocionManual.Text.Trim().ToLower();

            // Normaliza la emoción para aceptar inglés o español
            var emocionNormalizada = emocionManual switch
            {
                "happy" or "feliz" => "feliz",
                "sad" or "triste" => "triste",
                "angry" or "enojado" => "enojado",
                "surprised" or "sorprendido" => "sorprendido",
                "disgusted" or "disgustado" => "disgustado",
                _ => "neutral"
            };

            using var frm = new FormularioPreguntas(emocionNormalizada);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var respuestas = frm.Respuestas;
            }
        }
    }
}