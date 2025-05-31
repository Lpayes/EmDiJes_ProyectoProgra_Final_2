namespace EmDijes1
{
    partial class MainForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pictureBoxCamara = new PictureBox();
            buttonIniciarCamara = new Button();
            buttonAbrirPreguntas = new Button();
            buttonAnalizarEmocion = new Button();
            buttonHistorial = new Button();
            label1 = new Label();
            textBoxEmocionManual = new TextBox();
            label2 = new Label();
            buttonUsarEmocionManual = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamara).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxCamara
            // 
            pictureBoxCamara.Location = new Point(166, 93);
            pictureBoxCamara.Name = "pictureBoxCamara";
            pictureBoxCamara.Size = new Size(629, 491);
            pictureBoxCamara.TabIndex = 0;
            pictureBoxCamara.TabStop = false;
            // 
            // buttonIniciarCamara
            // 
            buttonIniciarCamara.BackColor = SystemColors.ControlDarkDark;
            buttonIniciarCamara.Font = new Font("Arial", 10.8F, FontStyle.Bold);
            buttonIniciarCamara.Location = new Point(238, 598);
            buttonIniciarCamara.Name = "buttonIniciarCamara";
            buttonIniciarCamara.Size = new Size(136, 65);
            buttonIniciarCamara.TabIndex = 2;
            buttonIniciarCamara.Text = "Iniciar Camara";
            buttonIniciarCamara.UseVisualStyleBackColor = false;
            buttonIniciarCamara.Click += buttonIniciarCamara_Click;
            // 
            // buttonAbrirPreguntas
            // 
            buttonAbrirPreguntas.AccessibleRole = AccessibleRole.Sound;
            buttonAbrirPreguntas.BackColor = SystemColors.ControlDarkDark;
            buttonAbrirPreguntas.Font = new Font("Arial", 10.8F, FontStyle.Bold);
            buttonAbrirPreguntas.Location = new Point(594, 598);
            buttonAbrirPreguntas.Name = "buttonAbrirPreguntas";
            buttonAbrirPreguntas.Size = new Size(136, 65);
            buttonAbrirPreguntas.TabIndex = 7;
            buttonAbrirPreguntas.Text = "Siguiente";
            buttonAbrirPreguntas.UseVisualStyleBackColor = false;
            buttonAbrirPreguntas.Click += buttonAbrirPreguntas_Click_1;
            // 
            // buttonAnalizarEmocion
            // 
            buttonAnalizarEmocion.BackColor = SystemColors.ControlDarkDark;
            buttonAnalizarEmocion.Font = new Font("Arial", 10.8F, FontStyle.Bold);
            buttonAnalizarEmocion.Location = new Point(412, 598);
            buttonAnalizarEmocion.Name = "buttonAnalizarEmocion";
            buttonAnalizarEmocion.Size = new Size(136, 65);
            buttonAnalizarEmocion.TabIndex = 4;
            buttonAnalizarEmocion.Text = "Analizar Emoción";
            buttonAnalizarEmocion.UseVisualStyleBackColor = false;
            buttonAnalizarEmocion.Click += buttonAnalizarEmocion_Click;
            // 
            // buttonHistorial
            // 
            buttonHistorial.BackColor = SystemColors.ControlDarkDark;
            buttonHistorial.Font = new Font("Arial", 10.8F, FontStyle.Bold);
            buttonHistorial.Location = new Point(245, 669);
            buttonHistorial.Name = "buttonHistorial";
            buttonHistorial.Size = new Size(129, 88);
            buttonHistorial.TabIndex = 8;
            buttonHistorial.Text = "Historial";
            buttonHistorial.UseVisualStyleBackColor = false;
            buttonHistorial.Click += buttonHistorial_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.MenuHighlight;
            label1.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(331, 9);
            label1.Name = "label1";
            label1.Size = new Size(257, 68);
            label1.TabIndex = 9;
            label1.Text = "EmDiJes";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxEmocionManual
            // 
            textBoxEmocionManual.Location = new Point(412, 701);
            textBoxEmocionManual.Name = "textBoxEmocionManual";
            textBoxEmocionManual.Size = new Size(150, 27);
            textBoxEmocionManual.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(404, 669);
            label2.Name = "label2";
            label2.Size = new Size(184, 20);
            label2.TabIndex = 11;
            label2.Text = "Ingrese Su EmocionActual:";
            // 
            // buttonUsarEmocionManual
            // 
            buttonUsarEmocionManual.BackColor = SystemColors.ControlDarkDark;
            buttonUsarEmocionManual.Font = new Font("Arial", 10.8F, FontStyle.Bold);
            buttonUsarEmocionManual.Location = new Point(594, 681);
            buttonUsarEmocionManual.Name = "buttonUsarEmocionManual";
            buttonUsarEmocionManual.Size = new Size(136, 65);
            buttonUsarEmocionManual.TabIndex = 12;
            buttonUsarEmocionManual.Text = "Iniciar Camara";
            buttonUsarEmocionManual.UseVisualStyleBackColor = false;
            buttonUsarEmocionManual.Click += buttonUsarEmocionManual_Click_1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(967, 783);
            Controls.Add(buttonUsarEmocionManual);
            Controls.Add(label2);
            Controls.Add(textBoxEmocionManual);
            Controls.Add(label1);
            Controls.Add(buttonHistorial);
            Controls.Add(buttonAbrirPreguntas);
            Controls.Add(buttonAnalizarEmocion);
            Controls.Add(buttonIniciarCamara);
            Controls.Add(pictureBoxCamara);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamara).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxCamara;
        private Button buttonIniciarCamara;
        private Button buttonAbrirPreguntas;
        private Button buttonAnalizarEmocion;
        private Button buttonHistorial;
        private Label label1;
        private TextBox textBoxEmocionManual;
        private Label label2;
        private Button buttonUsarEmocionManual;
    }
}
