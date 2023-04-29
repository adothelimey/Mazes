namespace MazesForms.Forms
{
    partial class AlgorithmSettingsForm
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
            panel1 = new Panel();
            trkBias = new TrackBar();
            comboBox1 = new ComboBox();
            label1 = new Label();
            btnOK = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkBias).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(trkBias);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(8, 7);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(509, 155);
            panel1.TabIndex = 0;
            // 
            // trkBias
            // 
            trkBias.Location = new Point(11, 53);
            trkBias.Maximum = 100;
            trkBias.Name = "trkBias";
            trkBias.Size = new Size(104, 45);
            trkBias.TabIndex = 2;
            trkBias.TickFrequency = 25;
            trkBias.TickStyle = TickStyle.TopLeft;
            trkBias.Value = 50;
            trkBias.Scroll += trkBias_Scroll;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "NorthEast", "NorthWest", "SouthEast", "SouthWest" });
            comboBox1.Location = new Point(7, 25);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(129, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 8);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Binary Tree settings";
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(450, 229);
            btnOK.Margin = new Padding(2);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(78, 20);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // AlgorithmSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(btnOK);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(2);
            Name = "AlgorithmSettingsForm";
            Text = "AlgorithmSettingsForm";
            Load += AlgorithmSettingsForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkBias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox comboBox1;
        private Button btnOK;
        private TrackBar trkBias;
    }
}