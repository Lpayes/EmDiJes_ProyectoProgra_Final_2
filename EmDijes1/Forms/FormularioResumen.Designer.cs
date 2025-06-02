namespace EmDijes1.Forms
{
    partial class FormularioResumen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioResumen));
            labelTitulo = new Label();
            labelVersiculo = new Label();
            textBoxVersiculo = new TextBox();
            labelReflexion = new Label();
            labelConsejo = new Label();
            labelOracion = new Label();
            buttonCerrar = new Button();
            labelEmocion = new Label();
            textBoxReflexion = new TextBox();
            textBoxConsejo = new TextBox();
            textBoxOracion = new TextBox();
            textBoxEnlaceVideo = new TextBox();
            buttonVerVideo = new Button();
            webViewVideo = new Microsoft.Web.WebView2.WinForms.WebView2();
            textBoxCanciones = new TextBox();
            buttonBuscarEnYouTube = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            Enlace = new Label();
            ((System.ComponentModel.ISupportInitialize)webViewVideo).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
            labelTitulo.Location = new Point(240, 29);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(191, 18);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Tu Reflexión del Día";
            // 
            // labelVersiculo
            // 
            labelVersiculo.AutoSize = true;
            labelVersiculo.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
            labelVersiculo.Location = new Point(78, 125);
            labelVersiculo.Name = "labelVersiculo";
            labelVersiculo.Size = new Size(165, 18);
            labelVersiculo.TabIndex = 1;
            labelVersiculo.Text = "Versículo del día";
            // 
            // textBoxVersiculo
            // 
            textBoxVersiculo.BackColor = SystemColors.ControlDarkDark;
            textBoxVersiculo.Location = new Point(30, 148);
            textBoxVersiculo.Multiline = true;
            textBoxVersiculo.Name = "textBoxVersiculo";
            textBoxVersiculo.ReadOnly = true;
            textBoxVersiculo.ScrollBars = ScrollBars.Vertical;
            textBoxVersiculo.Size = new Size(267, 308);
            textBoxVersiculo.TabIndex = 2;
            // 
            // labelReflexion
            // 
            labelReflexion.AutoSize = true;
            labelReflexion.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
            labelReflexion.Location = new Point(414, 125);
            labelReflexion.Name = "labelReflexion";
            labelReflexion.Size = new Size(196, 18);
            labelReflexion.TabIndex = 3;
            labelReflexion.Text = "Reflexión espiritual";
            // 
            // labelConsejo
            // 
            labelConsejo.AutoSize = true;
            labelConsejo.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
            labelConsejo.Location = new Point(79, 504);
            labelConsejo.Name = "labelConsejo";
            labelConsejo.Size = new Size(164, 18);
            labelConsejo.TabIndex = 4;
            labelConsejo.Text = "Consejo práctico";
            // 
            // labelOracion
            // 
            labelOracion.AutoSize = true;
            labelOracion.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
            labelOracion.Location = new Point(452, 489);
            labelOracion.Name = "labelOracion";
            labelOracion.Size = new Size(80, 18);
            labelOracion.TabIndex = 5;
            labelOracion.Text = "Oración";
            // 
            // buttonCerrar
            // 
            buttonCerrar.BackColor = SystemColors.ActiveCaption;
            buttonCerrar.Location = new Point(57, 536);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(118, 54);
            buttonCerrar.TabIndex = 9;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = false;
            // 
            // labelEmocion
            // 
            labelEmocion.AutoSize = true;
            labelEmocion.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
            labelEmocion.Location = new Point(250, 69);
            labelEmocion.Name = "labelEmocion";
            labelEmocion.Size = new Size(83, 18);
            labelEmocion.TabIndex = 10;
            labelEmocion.Text = "Emoción";
            labelEmocion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxReflexion
            // 
            textBoxReflexion.BackColor = SystemColors.ControlDarkDark;
            textBoxReflexion.Location = new Point(381, 148);
            textBoxReflexion.Multiline = true;
            textBoxReflexion.Name = "textBoxReflexion";
            textBoxReflexion.ReadOnly = true;
            textBoxReflexion.ScrollBars = ScrollBars.Vertical;
            textBoxReflexion.Size = new Size(267, 308);
            textBoxReflexion.TabIndex = 11;
            // 
            // textBoxConsejo
            // 
            textBoxConsejo.BackColor = SystemColors.ControlDarkDark;
            textBoxConsejo.Location = new Point(30, 536);
            textBoxConsejo.Multiline = true;
            textBoxConsejo.Name = "textBoxConsejo";
            textBoxConsejo.ReadOnly = true;
            textBoxConsejo.ScrollBars = ScrollBars.Vertical;
            textBoxConsejo.Size = new Size(267, 308);
            textBoxConsejo.TabIndex = 12;
            // 
            // textBoxOracion
            // 
            textBoxOracion.BackColor = SystemColors.ControlDarkDark;
            textBoxOracion.Location = new Point(381, 536);
            textBoxOracion.Multiline = true;
            textBoxOracion.Name = "textBoxOracion";
            textBoxOracion.ReadOnly = true;
            textBoxOracion.ScrollBars = ScrollBars.Vertical;
            textBoxOracion.Size = new Size(267, 308);
            textBoxOracion.TabIndex = 13;
            // 
            // textBoxEnlaceVideo
            // 
            textBoxEnlaceVideo.BackColor = SystemColors.Highlight;
            textBoxEnlaceVideo.Location = new Point(27, 347);
            textBoxEnlaceVideo.Name = "textBoxEnlaceVideo";
            textBoxEnlaceVideo.Size = new Size(182, 27);
            textBoxEnlaceVideo.TabIndex = 15;
            // 
            // buttonVerVideo
            // 
            buttonVerVideo.BackColor = SystemColors.GradientActiveCaption;
            buttonVerVideo.Location = new Point(57, 462);
            buttonVerVideo.Name = "buttonVerVideo";
            buttonVerVideo.Size = new Size(118, 60);
            buttonVerVideo.TabIndex = 16;
            buttonVerVideo.Text = "Play";
            buttonVerVideo.UseVisualStyleBackColor = false;
            // 
            // webViewVideo
            // 
            webViewVideo.AllowExternalDrop = true;
            webViewVideo.CreationProperties = null;
            webViewVideo.DefaultBackgroundColor = Color.White;
            webViewVideo.Location = new Point(66, 29);
            webViewVideo.Name = "webViewVideo";
            webViewVideo.Size = new Size(425, 301);
            webViewVideo.TabIndex = 18;
            webViewVideo.ZoomFactor = 1D;
            // 
            // textBoxCanciones
            // 
            textBoxCanciones.Location = new Point(0, 637);
            textBoxCanciones.Multiline = true;
            textBoxCanciones.Name = "textBoxCanciones";
            textBoxCanciones.ReadOnly = true;
            textBoxCanciones.ScrollBars = ScrollBars.Both;
            textBoxCanciones.Size = new Size(250, 207);
            textBoxCanciones.TabIndex = 19;
            // 
            // buttonBuscarEnYouTube
            // 
            buttonBuscarEnYouTube.BackColor = SystemColors.GradientActiveCaption;
            buttonBuscarEnYouTube.Location = new Point(57, 402);
            buttonBuscarEnYouTube.Name = "buttonBuscarEnYouTube";
            buttonBuscarEnYouTube.Size = new Size(118, 54);
            buttonBuscarEnYouTube.TabIndex = 20;
            buttonBuscarEnYouTube.Text = "Buscar en youtube";
            buttonBuscarEnYouTube.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.OrangeRed;
            panel1.Controls.Add(webViewVideo);
            panel1.Location = new Point(944, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(594, 940);
            panel1.TabIndex = 21;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBoxCanciones);
            panel2.Controls.Add(Enlace);
            panel2.Controls.Add(buttonBuscarEnYouTube);
            panel2.Controls.Add(buttonVerVideo);
            panel2.Controls.Add(buttonCerrar);
            panel2.Controls.Add(textBoxEnlaceVideo);
            panel2.Location = new Point(699, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 914);
            panel2.TabIndex = 22;
            // 
            // Enlace
            // 
            Enlace.AutoSize = true;
            Enlace.Font = new Font("Showcard Gothic", 9F, FontStyle.Bold);
            Enlace.Location = new Point(81, 312);
            Enlace.Name = "Enlace";
            Enlace.Size = new Size(71, 18);
            Enlace.TabIndex = 23;
            Enlace.Text = "Buscar";
            // 
            // FormularioResumen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1539, 952);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(textBoxOracion);
            Controls.Add(textBoxConsejo);
            Controls.Add(textBoxReflexion);
            Controls.Add(labelEmocion);
            Controls.Add(labelOracion);
            Controls.Add(labelConsejo);
            Controls.Add(labelReflexion);
            Controls.Add(textBoxVersiculo);
            Controls.Add(labelVersiculo);
            Controls.Add(labelTitulo);
            Name = "FormularioResumen";
            Text = "FormularioResumen";
            ((System.ComponentModel.ISupportInitialize)webViewVideo).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitulo;
        private Label labelVersiculo;
        private TextBox textBoxVersiculo;
        private Label labelReflexion;
        private Label labelConsejo;
        private Label labelOracion;
        private Button buttonCerrar;
        private Label labelEmocion;
        private TextBox textBoxReflexion;
        private TextBox textBoxConsejo;
        private TextBox textBoxOracion;
        private TextBox textBoxEnlaceVideo;
        private Button buttonVerVideo;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewVideo;
        private TextBox textBoxCanciones;
        private Button buttonBuscarEnYouTube;
        private Panel panel1;
        private Panel panel2;
        private Label Enlace;
    }
}