namespace Cambios
{
    partial class Form1
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
            label1 = new Label();
            TextBoxValor = new TextBox();
            label2 = new Label();
            label3 = new Label();
            ComboBoxOrigem = new ComboBox();
            ComboBoxDestino = new ComboBox();
            ButtonConverter = new Button();
            LabelResultado = new Label();
            LabelStatus = new Label();
            progressBar1 = new ProgressBar();
            ButtonTroca = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(69, 55);
            label1.Name = "label1";
            label1.Size = new Size(66, 28);
            label1.TabIndex = 0;
            label1.Text = "Valor:";
            // 
            // TextBoxValor
            // 
            TextBoxValor.Location = new Point(141, 59);
            TextBoxValor.Name = "TextBoxValor";
            TextBoxValor.Size = new Size(499, 27);
            TextBoxValor.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(69, 129);
            label2.Name = "label2";
            label2.Size = new Size(187, 28);
            label2.TabIndex = 2;
            label2.Text = "Moeda de Origem:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(69, 206);
            label3.Name = "label3";
            label3.Size = new Size(190, 28);
            label3.TabIndex = 4;
            label3.Text = "Moeda de Destino:";
            // 
            // ComboBoxOrigem
            // 
            ComboBoxOrigem.FormattingEnabled = true;
            ComboBoxOrigem.Location = new Point(262, 129);
            ComboBoxOrigem.Name = "ComboBoxOrigem";
            ComboBoxOrigem.Size = new Size(378, 28);
            ComboBoxOrigem.TabIndex = 5;
            // 
            // ComboBoxDestino
            // 
            ComboBoxDestino.FormattingEnabled = true;
            ComboBoxDestino.Location = new Point(265, 206);
            ComboBoxDestino.Name = "ComboBoxDestino";
            ComboBoxDestino.Size = new Size(375, 28);
            ComboBoxDestino.TabIndex = 6;
            // 
            // ButtonConverter
            // 
            ButtonConverter.Enabled = false;
            ButtonConverter.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonConverter.Location = new Point(691, 55);
            ButtonConverter.Name = "ButtonConverter";
            ButtonConverter.Size = new Size(136, 57);
            ButtonConverter.TabIndex = 7;
            ButtonConverter.Text = "Converter";
            ButtonConverter.UseVisualStyleBackColor = true;
            ButtonConverter.Click += ButtonConverter_Click;
            // 
            // LabelResultado
            // 
            LabelResultado.AutoSize = true;
            LabelResultado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelResultado.Location = new Point(262, 273);
            LabelResultado.Name = "LabelResultado";
            LabelResultado.Size = new Size(441, 28);
            LabelResultado.TabIndex = 8;
            LabelResultado.Text = "Escolha um valor, moeda de origem e destino";
            // 
            // LabelStatus
            // 
            LabelStatus.AutoSize = true;
            LabelStatus.Location = new Point(69, 352);
            LabelStatus.Name = "LabelStatus";
            LabelStatus.Size = new Size(47, 20);
            LabelStatus.TabIndex = 9;
            LabelStatus.Text = "status";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(597, 352);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(230, 29);
            progressBar1.TabIndex = 10;
            // 
            // ButtonTroca
            // 
            ButtonTroca.Enabled = false;
            ButtonTroca.Image = Properties.Resources.icons8_replace_50;
            ButtonTroca.Location = new Point(691, 153);
            ButtonTroca.Name = "ButtonTroca";
            ButtonTroca.Size = new Size(136, 53);
            ButtonTroca.TabIndex = 11;
            ButtonTroca.UseVisualStyleBackColor = true;
            ButtonTroca.Click += ButtonTroca_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 409);
            Controls.Add(ButtonTroca);
            Controls.Add(progressBar1);
            Controls.Add(LabelStatus);
            Controls.Add(LabelResultado);
            Controls.Add(ButtonConverter);
            Controls.Add(ComboBoxDestino);
            Controls.Add(ComboBoxOrigem);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TextBoxValor);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Câmbios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TextBoxValor;
        private Label label2;
        private Label label3;
        private ComboBox ComboBoxOrigem;
        private ComboBox ComboBoxDestino;
        private Button ButtonConverter;
        private Label LabelResultado;
        private Label LabelStatus;
        private ProgressBar progressBar1;
        private Button ButtonTroca;
    }
}
