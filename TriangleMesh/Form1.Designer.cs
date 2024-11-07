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
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)divisionTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)betaTrackBar).BeginInit();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.BackColor = SystemColors.ControlLight;
            canvas.Location = new Point(10, 10);
            canvas.Margin = new Padding(2);
            canvas.Name = "canvas";
            canvas.Size = new Size(840, 486);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            // 
            // divisionTrackBar
            // 
            divisionTrackBar.Location = new Point(884, 11);
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
            alphaTrackBar.Location = new Point(25, 528);
            alphaTrackBar.Margin = new Padding(2);
            alphaTrackBar.Maximum = 90;
            alphaTrackBar.Minimum = -90;
            alphaTrackBar.Name = "alphaTrackBar";
            alphaTrackBar.Size = new Size(710, 56);
            alphaTrackBar.TabIndex = 2;
            alphaTrackBar.Value = 45;
            alphaTrackBar.Scroll += alphaTrackBar_Scroll;
            // 
            // betaTrackBar
            // 
            betaTrackBar.Location = new Point(26, 597);
            betaTrackBar.Margin = new Padding(2);
            betaTrackBar.Maximum = 90;
            betaTrackBar.Minimum = -90;
            betaTrackBar.Name = "betaTrackBar";
            betaTrackBar.Size = new Size(709, 56);
            betaTrackBar.TabIndex = 3;
            betaTrackBar.Value = 45;
            betaTrackBar.Scroll += betaTrackBar_Scroll;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 681);
            Controls.Add(betaTrackBar);
            Controls.Add(alphaTrackBar);
            Controls.Add(divisionTrackBar);
            Controls.Add(canvas);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ((System.ComponentModel.ISupportInitialize)divisionTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)betaTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox canvas;
        private TrackBar divisionTrackBar;
        private TrackBar alphaTrackBar;
        private TrackBar betaTrackBar;
    }
}
