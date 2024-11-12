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
            canvas.Location = new Point(11, 42);
            canvas.Margin = new Padding(2);
            canvas.Name = "canvas";
            canvas.Size = new Size(840, 486);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            // 
            // divisionTrackBar
            // 
            divisionTrackBar.Location = new Point(884, 120);
            divisionTrackBar.Margin = new Padding(2);
            divisionTrackBar.Maximum = 30;
            divisionTrackBar.Minimum = 1;
            divisionTrackBar.Name = "divisionTrackBar";
            divisionTrackBar.Size = new Size(200, 56);
            divisionTrackBar.TabIndex = 1;
            divisionTrackBar.Value = 20;
            divisionTrackBar.Scroll += divisionTrackBar_Scroll;
            // 
            // alphaTrackBar
            // 
            alphaTrackBar.Location = new Point(25, 554);
            alphaTrackBar.Margin = new Padding(2);
            alphaTrackBar.Maximum = 180;
            alphaTrackBar.Minimum = -180;
            alphaTrackBar.Name = "alphaTrackBar";
            alphaTrackBar.Size = new Size(710, 56);
            alphaTrackBar.TabIndex = 2;
            alphaTrackBar.Value = 45;
            alphaTrackBar.Scroll += alphaTrackBar_Scroll;
            // 
            // betaTrackBar
            // 
            betaTrackBar.Location = new Point(25, 614);
            betaTrackBar.Margin = new Padding(2);
            betaTrackBar.Maximum = 180;
            betaTrackBar.Minimum = -180;
            betaTrackBar.Name = "betaTrackBar";
            betaTrackBar.Size = new Size(709, 56);
            betaTrackBar.TabIndex = 3;
            betaTrackBar.Value = 45;
            betaTrackBar.Scroll += betaTrackBar_Scroll;
            // 
            // kdTrackBar
            // 
            kdTrackBar.Location = new Point(884, 210);
            kdTrackBar.Margin = new Padding(2);
            kdTrackBar.Name = "kdTrackBar";
            kdTrackBar.Size = new Size(200, 56);
            kdTrackBar.TabIndex = 4;
            kdTrackBar.Value = 10;
            kdTrackBar.Scroll += kdTrackBar_Scroll;
            // 
            // ksTrackBar
            // 
            ksTrackBar.Location = new Point(884, 300);
            ksTrackBar.Margin = new Padding(2);
            ksTrackBar.Name = "ksTrackBar";
            ksTrackBar.Size = new Size(200, 56);
            ksTrackBar.TabIndex = 5;
            ksTrackBar.Value = 10;
            ksTrackBar.Scroll += ksTrackBar_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(884, 178);
            label1.Name = "label1";
            label1.Size = new Size(37, 30);
            label1.TabIndex = 6;
            label1.Text = "kd";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(884, 268);
            label2.Name = "label2";
            label2.Size = new Size(33, 30);
            label2.TabIndex = 7;
            label2.Text = "ks";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(884, 88);
            label3.Name = "label3";
            label3.Size = new Size(134, 30);
            label3.TabIndex = 8;
            label3.Text = "triangulation";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1112, 28);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menu";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeLightColorToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(76, 24);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // changeLightColorToolStripMenuItem
            // 
            changeLightColorToolStripMenuItem.Name = "changeLightColorToolStripMenuItem";
            changeLightColorToolStripMenuItem.Size = new Size(219, 26);
            changeLightColorToolStripMenuItem.Text = "Change Light Color";
            changeLightColorToolStripMenuItem.Click += changeLightColorToolStripMenuItem_Click;
            // 
            // colorRadioButton
            // 
            colorRadioButton.AutoSize = true;
            colorRadioButton.Checked = true;
            colorRadioButton.Font = new Font("Segoe UI", 13F);
            colorRadioButton.Location = new Point(884, 392);
            colorRadioButton.Name = "colorRadioButton";
            colorRadioButton.Size = new Size(83, 34);
            colorRadioButton.TabIndex = 10;
            colorRadioButton.TabStop = true;
            colorRadioButton.Text = "color";
            colorRadioButton.UseVisualStyleBackColor = true;
            // 
            // textureRadioButton
            // 
            textureRadioButton.AutoSize = true;
            textureRadioButton.Font = new Font("Segoe UI", 13F);
            textureRadioButton.Location = new Point(884, 432);
            textureRadioButton.Name = "textureRadioButton";
            textureRadioButton.Size = new Size(102, 34);
            textureRadioButton.TabIndex = 11;
            textureRadioButton.Text = "texture";
            textureRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 749);
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
