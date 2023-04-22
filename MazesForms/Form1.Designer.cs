namespace MazesForms
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
            drawPanel = new Panel();
            button_exportToImage = new Button();
            SuspendLayout();
            // 
            // drawPanel
            // 
            drawPanel.Location = new Point(12, 12);
            drawPanel.Name = "drawPanel";
            drawPanel.Size = new Size(776, 381);
            drawPanel.TabIndex = 0;
            drawPanel.Paint += drawPanel_Paint;
            // 
            // button_exportToImage
            // 
            button_exportToImage.Location = new Point(17, 414);
            button_exportToImage.Name = "button_exportToImage";
            button_exportToImage.Size = new Size(75, 23);
            button_exportToImage.TabIndex = 1;
            button_exportToImage.Text = "PNG";
            button_exportToImage.UseVisualStyleBackColor = true;
            button_exportToImage.Click += button_exportToImage_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_exportToImage);
            Controls.Add(drawPanel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Panel drawPanel;
        private Button button_exportToImage;
    }
}