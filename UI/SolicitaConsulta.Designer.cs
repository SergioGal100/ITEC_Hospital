namespace UI
{
    partial class SolicitaConsulta
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
            TitlePage = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            SuspendLayout();
            // 
            // TitlePage
            // 
            TitlePage.AutoSize = true;
            TitlePage.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitlePage.Location = new Point(44, 25);
            TitlePage.Name = "TitlePage";
            TitlePage.Size = new Size(299, 30);
            TitlePage.TabIndex = 0;
            TitlePage.Text = "Solicitud de Consulta Médica";
            TitlePage.TextAlign = ContentAlignment.MiddleCenter;
            TitlePage.UseMnemonic = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F);
            label1.Location = new Point(51, 84);
            label1.Name = "label1";
            label1.Size = new Size(67, 13);
            label1.TabIndex = 1;
            label1.Text = "Especialidad";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(51, 100);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(299, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F);
            label2.Location = new Point(51, 140);
            label2.Name = "label2";
            label2.Size = new Size(39, 13);
            label2.TabIndex = 3;
            label2.Text = "Doctor";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(51, 156);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(299, 23);
            comboBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F);
            label3.Location = new Point(51, 197);
            label3.Name = "label3";
            label3.Size = new Size(135, 13);
            label3.TabIndex = 5;
            label3.Text = "Horario y fecha de solicitud";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(51, 213);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(205, 23);
            dateTimePicker1.TabIndex = 6;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(51, 270);
            button1.Name = "button1";
            button1.Size = new Size(292, 44);
            button1.TabIndex = 7;
            button1.Text = "ENVIAR SOLICITUD ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // SolicitaConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 356);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(TitlePage);
            Name = "SolicitaConsulta";
            Text = "SolicitaConsulta";
            Load += SolicitaConsulta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected internal Label TitlePage;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private ComboBox comboBox2;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Button button1;
    }
}
