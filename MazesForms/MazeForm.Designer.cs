namespace MazesForms
{
    partial class MazeForm
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
            controlPanel = new Panel();
            chkShowCoordinates = new CheckBox();
            cboAlgoSelector = new ComboBox();
            numCellHeight = new NumericUpDown();
            numCellWidth = new NumericUpDown();
            label1 = new Label();
            lblCellWidth = new Label();
            num_GridHeight = new NumericUpDown();
            lbl_GridHeight = new Label();
            lbl_GridWidth = new Label();
            numGridWidth = new NumericUpDown();
            button_Export = new Button();
            btn_New = new Button();
            panel_Draw = new Panel();
            statusStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lnkMazeAlgoSettings = new LinkLabel();
            controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCellHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCellWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_GridHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGridWidth).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // controlPanel
            // 
            controlPanel.Controls.Add(lnkMazeAlgoSettings);
            controlPanel.Controls.Add(chkShowCoordinates);
            controlPanel.Controls.Add(cboAlgoSelector);
            controlPanel.Controls.Add(numCellHeight);
            controlPanel.Controls.Add(numCellWidth);
            controlPanel.Controls.Add(label1);
            controlPanel.Controls.Add(lblCellWidth);
            controlPanel.Controls.Add(num_GridHeight);
            controlPanel.Controls.Add(lbl_GridHeight);
            controlPanel.Controls.Add(lbl_GridWidth);
            controlPanel.Controls.Add(numGridWidth);
            controlPanel.Controls.Add(button_Export);
            controlPanel.Controls.Add(btn_New);
            controlPanel.Location = new Point(1536, 0);
            controlPanel.Margin = new Padding(4, 5, 4, 5);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(266, 388);
            controlPanel.TabIndex = 0;
            // 
            // chkShowCoordinates
            // 
            chkShowCoordinates.AutoSize = true;
            chkShowCoordinates.Location = new Point(92, 344);
            chkShowCoordinates.Margin = new Padding(4, 5, 4, 5);
            chkShowCoordinates.Name = "chkShowCoordinates";
            chkShowCoordinates.Size = new Size(160, 29);
            chkShowCoordinates.TabIndex = 2;
            chkShowCoordinates.Text = "Show Co-ords?";
            chkShowCoordinates.UseVisualStyleBackColor = true;
            chkShowCoordinates.CheckedChanged += chkShowCoordinates_CheckedChanged;
            // 
            // cboAlgoSelector
            // 
            cboAlgoSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAlgoSelector.FormattingEnabled = true;
            cboAlgoSelector.Items.AddRange(new object[] { "Binary Tree", "Sidewinder", "Aldous-Broder" });
            cboAlgoSelector.Location = new Point(76, 265);
            cboAlgoSelector.Margin = new Padding(4, 5, 4, 5);
            cboAlgoSelector.Name = "cboAlgoSelector";
            cboAlgoSelector.Size = new Size(171, 33);
            cboAlgoSelector.TabIndex = 10;
            // 
            // numCellHeight
            // 
            numCellHeight.Location = new Point(186, 217);
            numCellHeight.Margin = new Padding(4, 5, 4, 5);
            numCellHeight.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            numCellHeight.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            numCellHeight.Name = "numCellHeight";
            numCellHeight.Size = new Size(63, 31);
            numCellHeight.TabIndex = 9;
            numCellHeight.Value = new decimal(new int[] { 32, 0, 0, 0 });
            // 
            // numCellWidth
            // 
            numCellWidth.Location = new Point(186, 168);
            numCellWidth.Margin = new Padding(4, 5, 4, 5);
            numCellWidth.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            numCellWidth.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            numCellWidth.Name = "numCellWidth";
            numCellWidth.Size = new Size(63, 31);
            numCellWidth.TabIndex = 8;
            numCellWidth.Value = new decimal(new int[] { 32, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 220);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 25);
            label1.TabIndex = 7;
            label1.Text = "Cell Height:";
            // 
            // lblCellWidth
            // 
            lblCellWidth.AutoSize = true;
            lblCellWidth.Location = new Point(84, 172);
            lblCellWidth.Margin = new Padding(4, 0, 4, 0);
            lblCellWidth.Name = "lblCellWidth";
            lblCellWidth.Size = new Size(97, 25);
            lblCellWidth.TabIndex = 6;
            lblCellWidth.Text = "Cell Width:";
            // 
            // num_GridHeight
            // 
            num_GridHeight.Location = new Point(186, 120);
            num_GridHeight.Margin = new Padding(4, 5, 4, 5);
            num_GridHeight.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            num_GridHeight.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            num_GridHeight.Name = "num_GridHeight";
            num_GridHeight.Size = new Size(63, 31);
            num_GridHeight.TabIndex = 5;
            num_GridHeight.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // lbl_GridHeight
            // 
            lbl_GridHeight.AutoSize = true;
            lbl_GridHeight.Location = new Point(17, 123);
            lbl_GridHeight.Margin = new Padding(4, 0, 4, 0);
            lbl_GridHeight.Name = "lbl_GridHeight";
            lbl_GridHeight.Size = new Size(167, 25);
            lbl_GridHeight.TabIndex = 4;
            lbl_GridHeight.Text = "Grid Height in Cells:";
            // 
            // lbl_GridWidth
            // 
            lbl_GridWidth.AutoSize = true;
            lbl_GridWidth.Location = new Point(23, 75);
            lbl_GridWidth.Margin = new Padding(4, 0, 4, 0);
            lbl_GridWidth.Name = "lbl_GridWidth";
            lbl_GridWidth.Size = new Size(162, 25);
            lbl_GridWidth.TabIndex = 3;
            lbl_GridWidth.Text = "Grid Width in Cells:";
            // 
            // numGridWidth
            // 
            numGridWidth.Location = new Point(186, 72);
            numGridWidth.Margin = new Padding(4, 5, 4, 5);
            numGridWidth.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numGridWidth.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numGridWidth.Name = "numGridWidth";
            numGridWidth.Size = new Size(63, 31);
            numGridWidth.TabIndex = 2;
            numGridWidth.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // button_Export
            // 
            button_Export.Location = new Point(154, 7);
            button_Export.Margin = new Padding(4, 5, 4, 5);
            button_Export.Name = "button_Export";
            button_Export.Size = new Size(107, 38);
            button_Export.TabIndex = 1;
            button_Export.Text = "Export";
            button_Export.UseVisualStyleBackColor = true;
            button_Export.Click += button_Export_Click;
            // 
            // btn_New
            // 
            btn_New.Location = new Point(17, 7);
            btn_New.Margin = new Padding(4, 5, 4, 5);
            btn_New.Name = "btn_New";
            btn_New.Size = new Size(107, 38);
            btn_New.TabIndex = 0;
            btn_New.Text = "New Grid";
            btn_New.UseVisualStyleBackColor = true;
            btn_New.Click += btn_New_Click;
            // 
            // panel_Draw
            // 
            panel_Draw.AutoScroll = true;
            panel_Draw.Location = new Point(17, 20);
            panel_Draw.Margin = new Padding(4, 5, 4, 5);
            panel_Draw.Name = "panel_Draw";
            panel_Draw.Size = new Size(1493, 985);
            panel_Draw.TabIndex = 1;
            panel_Draw.Paint += panel_Draw_Paint;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip.Location = new Point(0, 1026);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 20, 0);
            statusStrip.Size = new Size(1801, 32);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(179, 25);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // lnkMazeAlgoSettings
            // 
            lnkMazeAlgoSettings.AutoSize = true;
            lnkMazeAlgoSettings.Location = new Point(171, 303);
            lnkMazeAlgoSettings.Name = "lnkMazeAlgoSettings";
            lnkMazeAlgoSettings.Size = new Size(76, 25);
            lnkMazeAlgoSettings.TabIndex = 11;
            lnkMazeAlgoSettings.TabStop = true;
            lnkMazeAlgoSettings.Text = "Settings";
            lnkMazeAlgoSettings.LinkClicked += lnkMazeAlgoSettings_LinkClicked;
            // 
            // MazeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1801, 1058);
            Controls.Add(statusStrip);
            Controls.Add(panel_Draw);
            Controls.Add(controlPanel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MazeForm";
            Text = "A-Maze-ing";
            controlPanel.ResumeLayout(false);
            controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCellHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCellWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_GridHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGridWidth).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel controlPanel;
        private Button btn_New;
        private Panel panel_Draw;
        private Button button_Export;
        private NumericUpDown num_GridHeight;
        private Label lbl_GridHeight;
        private Label lbl_GridWidth;
        private NumericUpDown numGridWidth;
        private NumericUpDown numCellHeight;
        private NumericUpDown numCellWidth;
        private Label label1;
        private Label lblCellWidth;
        private CheckBox chkShowCoordinates;
        private ComboBox cboAlgoSelector;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private LinkLabel lnkMazeAlgoSettings;
    }
}