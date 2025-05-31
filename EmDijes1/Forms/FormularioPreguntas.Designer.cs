namespace EmDijes1
{
    partial class FormularioPreguntas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioPreguntas));
            labelPregunta = new Label();
            textBoxRespuesta = new TextBox();
            buttonSiguiente = new Button();
            buttonCancelar = new Button();
            labelRespuestaIA = new Label();
            textBoxRespuestaIA = new TextBox();
            SuspendLayout();
            // 
            // labelPregunta
            // 
            labelPregunta.AutoSize = true;
            labelPregunta.BackColor = SystemColors.GrayText;
            labelPregunta.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPregunta.Location = new Point(329, 37);
            labelPregunta.Name = "labelPregunta";
            labelPregunta.Size = new Size(109, 28);
            labelPregunta.TabIndex = 0;
            labelPregunta.Text = "Pregunta";
            labelPregunta.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxRespuesta
            // 
            textBoxRespuesta.Location = new Point(188, 81);
            textBoxRespuesta.Multiline = true;
            textBoxRespuesta.Name = "textBoxRespuesta";
            textBoxRespuesta.Size = new Size(389, 143);
            textBoxRespuesta.TabIndex = 1;
            // 
            // buttonSiguiente
            // 
            buttonSiguiente.BackColor = Color.Red;
            buttonSiguiente.Location = new Point(268, 230);
            buttonSiguiente.Name = "buttonSiguiente";
            buttonSiguiente.Size = new Size(110, 48);
            buttonSiguiente.TabIndex = 2;
            buttonSiguiente.Text = "Enviar Respuesta";
            buttonSiguiente.UseVisualStyleBackColor = false;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.Red;
            buttonCancelar.Location = new Point(384, 230);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(110, 48);
            buttonCancelar.TabIndex = 3;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // labelRespuestaIA
            // 
            labelRespuestaIA.AutoSize = true;
            labelRespuestaIA.BackColor = SystemColors.GrayText;
            labelRespuestaIA.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelRespuestaIA.Location = new Point(252, 329);
            labelRespuestaIA.Name = "labelRespuestaIA";
            labelRespuestaIA.Size = new Size(253, 28);
            labelRespuestaIA.TabIndex = 4;
            labelRespuestaIA.Text = "Respuesta de Open IA";
            labelRespuestaIA.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxRespuestaIA
            // 
            textBoxRespuestaIA.Location = new Point(188, 382);
            textBoxRespuestaIA.Multiline = true;
            textBoxRespuestaIA.Name = "textBoxRespuestaIA";
            textBoxRespuestaIA.ReadOnly = true;
            textBoxRespuestaIA.ScrollBars = ScrollBars.Vertical;
            textBoxRespuestaIA.Size = new Size(389, 143);
            textBoxRespuestaIA.TabIndex = 5;
            // 
            // FormularioPreguntas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 603);
            Controls.Add(textBoxRespuestaIA);
            Controls.Add(labelRespuestaIA);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonSiguiente);
            Controls.Add(textBoxRespuesta);
            Controls.Add(labelPregunta);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormularioPreguntas";
            Text = "FormularioPreguntas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPregunta;
        internal TextBox textBoxRespuesta;
        private Button buttonSiguiente;
        private Button buttonCancelar;
        private Label labelRespuestaIA;
        internal TextBox textBoxRespuestaIA;
    }
}