namespace TriangleMesh
{
    partial class MainForm
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
            canvas = new PictureBox();
            divisionTrackBar = new TrackBar();
            alphaTrackBar = new TrackBar();
            betaTrackBar = new TrackBar();
            kdTrackBar = new TrackBar();
            ksTrackBar = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            changeLightColorToolStripMenuItem = new ToolStripMenuItem();
            colorRadioButton = new RadioButton();
            textureRadioButton = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)divisionTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)betaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.BackColor = SystemColors.ControlLight;
            canvas.Location = new Point(14, 52);
            canvas.Margin = new Padding(2);
            canvas.Name = "canvas";
            canvas.Size = new Size(1050, 608);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            // 
            // divisionTrackBar
            // 
            divisionTrackBar.Location = new Point(1105, 150);
            divisionTrackBar.Margin = new Padding(2);
            divisionTrackBar.Maximum = 30;
            divisionTrackBar.Minimum = 1;
            divisionTrackBar.Name = "divisionTrackBar";
            divisionTrackBar.Size = new Size(250, 69);
            divisionTrackBar.TabIndex = 1;
            divisionTrackBar.Value = 20;
            divisionTrackBar.Scroll += divisionTrackBar_Scroll;
            // 
            // alphaTrackBar
            // 
            alphaTrackBar.Location = new Point(31, 692);
            alphaTrackBar.Margin = new Padding(2);
            alphaTrackBar.Maximum = 180;
            alphaTrackBar.Minimum = -180;
            alphaTrackBar.Name = "alphaTrackBar";
            alphaTrackBar.Size = new Size(888, 69);
            alphaTrackBar.TabIndex = 2;
            alphaTrackBar.Scroll += alphaTrackBar_Scroll;
            // 
            // betaTrackBar
            // 
            betaTrackBar.Location = new Point(31, 768);
            betaTrackBar.Margin = new Padding(2);
            betaTrackBar.Maximum = 180;
            betaTrackBar.Minimum = -180;
            betaTrackBar.Name = "betaTrackBar";
            betaTrackBar.Size = new Size(886, 69);
            betaTrackBar.TabIndex = 3;
            betaTrackBar.Value = 1;
            betaTrackBar.Scroll += betaTrackBar_Scroll;
            // 
            // kdTrackBar
            // 
            kdTrackBar.Location = new Point(1105, 262);
            kdTrackBar.Margin = new Padding(2);
            kdTrackBar.Name = "kdTrackBar";
            kdTrackBar.Size = new Size(250, 69);
            kdTrackBar.TabIndex = 4;
            kdTrackBar.Value = 10;
            kdTrackBar.Scroll += kdTrackBar_Scroll;
            // 
            // ksTrackBar
            // 
            ksTrackBar.Location = new Point(1105, 375);
            ksTrackBar.Margin = new Padding(2);
            ksTrackBar.Name = "ksTrackBar";
            ksTrackBar.Size = new Size(250, 69);
            ksTrackBar.TabIndex = 5;
            ksTrackBar.Value = 10;
            ksTrackBar.Scroll += ksTrackBar_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(1105, 222);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 36);
            label1.TabIndex = 6;
            label1.Text = "kd";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(1105, 335);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(39, 36);
            label2.TabIndex = 7;
            label2.Text = "ks";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(1105, 110);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(161, 36);
            label3.TabIndex = 8;
            label3.Text = "triangulation";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 2, 0, 2);
            menuStrip1.Size = new Size(1390, 33);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menu";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeLightColorToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(92, 29);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // changeLightColorToolStripMenuItem
            // 
            changeLightColorToolStripMenuItem.Name = "changeLightColorToolStripMenuItem";
            changeLightColorToolStripMenuItem.Size = new Size(266, 34);
            changeLightColorToolStripMenuItem.Text = "Change Light Color";
            changeLightColorToolStripMenuItem.Click += changeLightColorToolStripMenuItem_Click;
            // 
            // colorRadioButton
            // 
            colorRadioButton.AutoSize = true;
            colorRadioButton.Checked = true;
            colorRadioButton.Font = new Font("Segoe UI", 13F);
            colorRadioButton.Location = new Point(1105, 490);
            colorRadioButton.Margin = new Padding(4);
            colorRadioButton.Name = "colorRadioButton";
            colorRadioButton.Size = new Size(97, 40);
            colorRadioButton.TabIndex = 10;
            colorRadioButton.TabStop = true;
            colorRadioButton.Text = "color";
            colorRadioButton.UseVisualStyleBackColor = true;
            colorRadioButton.CheckedChanged += colorRadioButton_CheckedChanged;
            // 
            // textureRadioButton
            // 
            textureRadioButton.AutoSize = true;
            textureRadioButton.Font = new Font("Segoe UI", 13F);
            textureRadioButton.Location = new Point(1105, 540);
            textureRadioButton.Margin = new Padding(4);
            textureRadioButton.Name = "textureRadioButton";
            textureRadioButton.Size = new Size(122, 40);
            textureRadioButton.TabIndex = 11;
            textureRadioButton.Text = "texture";
            textureRadioButton.UseVisualStyleBackColor = true;
            textureRadioButton.CheckedChanged += textureRadioButton_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 936);
            Controls.Add(textureRadioButton);
            Controls.Add(colorRadioButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ksTrackBar);
            Controls.Add(kdTrackBar);
            Controls.Add(betaTrackBar);
            Controls.Add(alphaTrackBar);
            Controls.Add(divisionTrackBar);
            Controls.Add(canvas);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ((System.ComponentModel.ISupportInitialize)divisionTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)betaTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox canvas;
        private TrackBar divisionTrackBar;
        private TrackBar alphaTrackBar;
        private TrackBar betaTrackBar;
        private TrackBar kdTrackBar;
        private TrackBar ksTrackBar;
        private Label label1;
        private Label label2;
        private Label label3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem changeLightColorToolStripMenuItem;
        private RadioButton colorRadioButton;
        private RadioButton textureRadioButton;
    }
}
