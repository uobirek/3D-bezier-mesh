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
            canvas.Location = new Point(12, 12);
            canvas.Name = "canvas";
            canvas.Size = new Size(606, 426);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            // 
            // divisionTrackBar
            // 
            divisionTrackBar.Location = new Point(624, 21);
            divisionTrackBar.Maximum = 20;
            divisionTrackBar.Name = "divisionTrackBar";
            divisionTrackBar.Size = new Size(250, 69);
            divisionTrackBar.TabIndex = 1;
            divisionTrackBar.Scroll += divisionTrackBar_Scroll;
            // 
            // alphaTrackBar
            // 
            alphaTrackBar.Location = new Point(624, 105);
            alphaTrackBar.Maximum = 45;
            alphaTrackBar.Minimum = -45;
            alphaTrackBar.Name = "alphaTrackBar";
            alphaTrackBar.Size = new Size(250, 69);
            alphaTrackBar.TabIndex = 2;
            alphaTrackBar.Scroll += alphaTrackBar_Scroll;
            // 
            // betaTrackBar
            // 
            betaTrackBar.Location = new Point(624, 180);
            betaTrackBar.Name = "betaTrackBar";
            betaTrackBar.Size = new Size(250, 69);
            betaTrackBar.TabIndex = 3;
            betaTrackBar.Scroll += betaTrackBar_Scroll;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 450);
            Controls.Add(betaTrackBar);
            Controls.Add(alphaTrackBar);
            Controls.Add(divisionTrackBar);
            Controls.Add(canvas);
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
