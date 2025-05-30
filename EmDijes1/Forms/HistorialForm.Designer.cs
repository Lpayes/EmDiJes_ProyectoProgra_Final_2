namespace EmDijes1
{
    partial class HistorialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialForm));
            dateTimePicker1 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            textBoxId = new TextBox();
            buttonObtenerTodo = new Button();
            buttonObtenerPorFecha = new Button();
            buttonObtenerPorId = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonVerResumen2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(337, 129);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(288, 27);
            dateTimePicker1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(330, 282);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(305, 87);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(161, 129);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(125, 27);
            textBoxId.TabIndex = 2;
            // 
            // buttonObtenerTodo
            // 
            buttonObtenerTodo.BackColor = SystemColors.GradientActiveCaption;
            buttonObtenerTodo.Location = new Point(508, 186);
            buttonObtenerTodo.Name = "buttonObtenerTodo";
            buttonObtenerTodo.Size = new Size(127, 76);
            buttonObtenerTodo.TabIndex = 4;
            buttonObtenerTodo.Text = "Obtener Todo";
            buttonObtenerTodo.UseVisualStyleBackColor = false;
            buttonObtenerTodo.Click += buttonObtenerTodo_Click;
            // 
            // buttonObtenerPorFecha
            // 
            buttonObtenerPorFecha.BackColor = SystemColors.GradientActiveCaption;
            buttonObtenerPorFecha.Location = new Point(337, 186);
            buttonObtenerPorFecha.Name = "buttonObtenerPorFecha";
            buttonObtenerPorFecha.Size = new Size(127, 76);
            buttonObtenerPorFecha.TabIndex = 5;
            buttonObtenerPorFecha.Text = "Obtener Por Fecha";
            buttonObtenerPorFecha.UseVisualStyleBackColor = false;
            buttonObtenerPorFecha.Click += buttonObtenerPorFecha_Click;
            // 
            // buttonObtenerPorId
            // 
            buttonObtenerPorId.BackColor = SystemColors.GradientActiveCaption;
            buttonObtenerPorId.Location = new Point(159, 186);
            buttonObtenerPorId.Name = "buttonObtenerPorId";
            buttonObtenerPorId.Size = new Size(127, 76);
            buttonObtenerPorId.TabIndex = 6;
            buttonObtenerPorId.Text = "Obtener Por Fecha";
            buttonObtenerPorId.UseVisualStyleBackColor = false;
            buttonObtenerPorId.Click += buttonObtenerPorId_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(185, 92);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 7;
            label1.Text = "lngresar Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(330, 92);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 8;
            label2.Text = "Ingresar Fecha";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(296, 20);
            label3.Name = "label3";
            label3.Size = new Size(197, 43);
            label3.TabIndex = 9;
            label3.Text = "Historial";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(291, 387);
            label4.Name = "label4";
            label4.Size = new Size(245, 43);
            label4.TabIndex = 10;
            label4.Text = "Sigue a Jesus";
            // 
            // buttonVerResumen2
            // 
            buttonVerResumen2.BackColor = SystemColors.GradientActiveCaption;
            buttonVerResumen2.Location = new Point(161, 282);
            buttonVerResumen2.Name = "buttonVerResumen2";
            buttonVerResumen2.Size = new Size(127, 76);
            buttonVerResumen2.TabIndex = 11;
            buttonVerResumen2.Text = "Ver Resumen po Id";
            buttonVerResumen2.UseVisualStyleBackColor = false;
            buttonVerResumen2.Click += buttonVerResumen2_Click;
            // 
            // HistorialForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(810, 450);
            Controls.Add(buttonVerResumen2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonObtenerPorId);
            Controls.Add(buttonObtenerPorFecha);
            Controls.Add(buttonObtenerTodo);
            Controls.Add(textBoxId);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker1);
            Name = "HistorialForm";
            Text = "HistorialForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
        private TextBox textBoxId;
        private Button buttonObtenerTodo;
        private Button buttonObtenerPorFecha;
        private Button buttonObtenerPorId;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonVerResumen2;
    }
}