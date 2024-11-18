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
            changeObjectColorToolStripMenuItem = new ToolStripMenuItem();
            colorRadioButton = new RadioButton();
            textureRadioButton = new RadioButton();
            label4 = new Label();
            zLightTrackBar = new TrackBar();
            label5 = new Label();
            mTrackBar = new TrackBar();
            rotationGroupBox = new GroupBox();
            groupBox1 = new GroupBox();
            LoadNormalMapBtn = new Button();
            normalMapPictureBox = new PictureBox();
            texturePictureBox = new PictureBox();
            LoadTextureBtn = new Button();
            animationCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)divisionTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)betaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)zLightTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).BeginInit();
            rotationGroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)normalMapPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)texturePictureBox).BeginInit();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.BackColor = SystemColors.ControlLight;
            canvas.Location = new Point(11, 42);
            canvas.Margin = new Padding(2);
            canvas.Name = "canvas";
            canvas.Size = new Size(840, 540);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Paint += canvas_Paint;
            // 
            // divisionTrackBar
            // 
            divisionTrackBar.Location = new Point(884, 67);
            divisionTrackBar.Margin = new Padding(2);
            divisionTrackBar.Maximum = 70;
            divisionTrackBar.Minimum = 1;
            divisionTrackBar.Name = "divisionTrackBar";
            divisionTrackBar.Size = new Size(200, 56);
            divisionTrackBar.TabIndex = 1;
            divisionTrackBar.TickFrequency = 5;
            divisionTrackBar.Value = 20;
            divisionTrackBar.Scroll += divisionTrackBar_Scroll;
            // 
            // alphaTrackBar
            // 
            alphaTrackBar.Location = new Point(33, 25);
            alphaTrackBar.Margin = new Padding(2);
            alphaTrackBar.Maximum = 180;
            alphaTrackBar.Minimum = -180;
            alphaTrackBar.Name = "alphaTrackBar";
            alphaTrackBar.Size = new Size(710, 56);
            alphaTrackBar.TabIndex = 2;
            alphaTrackBar.Scroll += alphaTrackBar_Scroll;
            // 
            // betaTrackBar
            // 
            betaTrackBar.Location = new Point(33, 85);
            betaTrackBar.Margin = new Padding(2);
            betaTrackBar.Maximum = 180;
            betaTrackBar.Minimum = -180;
            betaTrackBar.Name = "betaTrackBar";
            betaTrackBar.Size = new Size(709, 56);
            betaTrackBar.TabIndex = 3;
            betaTrackBar.Value = 1;
            betaTrackBar.Scroll += betaTrackBar_Scroll;
            // 
            // kdTrackBar
            // 
            kdTrackBar.Location = new Point(14, 60);
            kdTrackBar.Margin = new Padding(2);
            kdTrackBar.Name = "kdTrackBar";
            kdTrackBar.Size = new Size(200, 56);
            kdTrackBar.TabIndex = 4;
            kdTrackBar.Value = 7;
            kdTrackBar.Scroll += kdTrackBar_Scroll;
            // 
            // ksTrackBar
            // 
            ksTrackBar.Location = new Point(14, 150);
            ksTrackBar.Margin = new Padding(2);
            ksTrackBar.Name = "ksTrackBar";
            ksTrackBar.Size = new Size(200, 56);
            ksTrackBar.TabIndex = 5;
            ksTrackBar.Value = 7;
            ksTrackBar.Scroll += ksTrackBar_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(14, 28);
            label1.Name = "label1";
            label1.Size = new Size(28, 23);
            label1.TabIndex = 6;
            label1.Text = "kd";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(14, 118);
            label2.Name = "label2";
            label2.Size = new Size(25, 23);
            label2.TabIndex = 7;
            label2.Text = "ks";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(884, 42);
            label3.Name = "label3";
            label3.Size = new Size(108, 23);
            label3.TabIndex = 8;
            label3.Text = "triangulation";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1152, 28);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menu";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeLightColorToolStripMenuItem, changeObjectColorToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(76, 24);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // changeLightColorToolStripMenuItem
            // 
            changeLightColorToolStripMenuItem.Name = "changeLightColorToolStripMenuItem";
            changeLightColorToolStripMenuItem.Size = new Size(230, 26);
            changeLightColorToolStripMenuItem.Text = "Change Light Color";
            changeLightColorToolStripMenuItem.Click += changeLightColorToolStripMenuItem_Click;
            // 
            // changeObjectColorToolStripMenuItem
            // 
            changeObjectColorToolStripMenuItem.Name = "changeObjectColorToolStripMenuItem";
            changeObjectColorToolStripMenuItem.Size = new Size(230, 26);
            changeObjectColorToolStripMenuItem.Text = "Change Object Color";
            changeObjectColorToolStripMenuItem.Click += changeObjectColorToolStripMenuItem_Click;
            // 
            // colorRadioButton
            // 
            colorRadioButton.AutoSize = true;
            colorRadioButton.Checked = true;
            colorRadioButton.Font = new Font("Segoe UI", 10F);
            colorRadioButton.Location = new Point(870, 507);
            colorRadioButton.Name = "colorRadioButton";
            colorRadioButton.Size = new Size(69, 27);
            colorRadioButton.TabIndex = 10;
            colorRadioButton.TabStop = true;
            colorRadioButton.Text = "color";
            colorRadioButton.UseVisualStyleBackColor = true;
            colorRadioButton.CheckedChanged += colorRadioButton_CheckedChanged;
            // 
            // textureRadioButton
            // 
            textureRadioButton.AutoSize = true;
            textureRadioButton.Font = new Font("Segoe UI", 10F);
            textureRadioButton.Location = new Point(870, 540);
            textureRadioButton.Name = "textureRadioButton";
            textureRadioButton.Size = new Size(85, 27);
            textureRadioButton.TabIndex = 11;
            textureRadioButton.Text = "texture";
            textureRadioButton.UseVisualStyleBackColor = true;
            textureRadioButton.CheckedChanged += textureRadioButton_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(14, 288);
            label4.Name = "label4";
            label4.Size = new Size(18, 23);
            label4.TabIndex = 12;
            label4.Text = "z";
            // 
            // zLightTrackBar
            // 
            zLightTrackBar.LargeChange = 40;
            zLightTrackBar.Location = new Point(14, 313);
            zLightTrackBar.Margin = new Padding(2);
            zLightTrackBar.Maximum = 300;
            zLightTrackBar.Minimum = 150;
            zLightTrackBar.Name = "zLightTrackBar";
            zLightTrackBar.Size = new Size(200, 56);
            zLightTrackBar.SmallChange = 20;
            zLightTrackBar.TabIndex = 13;
            zLightTrackBar.TickFrequency = 20;
            zLightTrackBar.Value = 150;
            zLightTrackBar.Scroll += zLightTrackBar_Scroll;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(14, 205);
            label5.Name = "label5";
            label5.Size = new Size(25, 23);
            label5.TabIndex = 15;
            label5.Text = "m";
            // 
            // mTrackBar
            // 
            mTrackBar.LargeChange = 10;
            mTrackBar.Location = new Point(14, 230);
            mTrackBar.Margin = new Padding(2);
            mTrackBar.Maximum = 100;
            mTrackBar.Minimum = 1;
            mTrackBar.Name = "mTrackBar";
            mTrackBar.Size = new Size(200, 56);
            mTrackBar.SmallChange = 5;
            mTrackBar.TabIndex = 14;
            mTrackBar.TickFrequency = 5;
            mTrackBar.Value = 40;
            mTrackBar.Scroll += mTrackBar_Scroll;
            // 
            // rotationGroupBox
            // 
            rotationGroupBox.Controls.Add(alphaTrackBar);
            rotationGroupBox.Controls.Add(betaTrackBar);
            rotationGroupBox.Location = new Point(12, 592);
            rotationGroupBox.Name = "rotationGroupBox";
            rotationGroupBox.Size = new Size(839, 145);
            rotationGroupBox.TabIndex = 16;
            rotationGroupBox.TabStop = false;
            rotationGroupBox.Text = "rotation";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(mTrackBar);
            groupBox1.Controls.Add(kdTrackBar);
            groupBox1.Controls.Add(zLightTrackBar);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(ksTrackBar);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(870, 128);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(230, 373);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "light settings";
            // 
            // LoadNormalMapBtn
            // 
            LoadNormalMapBtn.Location = new Point(870, 573);
            LoadNormalMapBtn.Name = "LoadNormalMapBtn";
            LoadNormalMapBtn.Size = new Size(80, 80);
            LoadNormalMapBtn.TabIndex = 18;
            LoadNormalMapBtn.Text = "Load Normal Map";
            LoadNormalMapBtn.UseVisualStyleBackColor = true;
            LoadNormalMapBtn.Click += LoadNormalMapBtn_Click;
            // 
            // normalMapPictureBox
            // 
            normalMapPictureBox.Location = new Point(956, 573);
            normalMapPictureBox.Name = "normalMapPictureBox";
            normalMapPictureBox.Size = new Size(80, 80);
            normalMapPictureBox.TabIndex = 19;
            normalMapPictureBox.TabStop = false;
            // 
            // texturePictureBox
            // 
            texturePictureBox.Location = new Point(956, 659);
            texturePictureBox.Name = "texturePictureBox";
            texturePictureBox.Size = new Size(80, 80);
            texturePictureBox.TabIndex = 21;
            texturePictureBox.TabStop = false;
            // 
            // LoadTextureBtn
            // 
            LoadTextureBtn.Location = new Point(870, 659);
            LoadTextureBtn.Name = "LoadTextureBtn";
            LoadTextureBtn.Size = new Size(80, 80);
            LoadTextureBtn.TabIndex = 20;
            LoadTextureBtn.Text = "Load Texture";
            LoadTextureBtn.UseVisualStyleBackColor = true;
            LoadTextureBtn.Click += LoadTextureBtn_Click;
            // 
            // animationCheckBox
            // 
            animationCheckBox.AutoSize = true;
            animationCheckBox.Checked = true;
            animationCheckBox.CheckState = CheckState.Checked;
            animationCheckBox.Location = new Point(986, 510);
            animationCheckBox.Name = "animationCheckBox";
            animationCheckBox.Size = new Size(98, 24);
            animationCheckBox.TabIndex = 22;
            animationCheckBox.Text = "animation";
            animationCheckBox.UseVisualStyleBackColor = true;
            animationCheckBox.CheckedChanged += animationCheckBox_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 750);
            Controls.Add(animationCheckBox);
            Controls.Add(texturePictureBox);
            Controls.Add(LoadTextureBtn);
            Controls.Add(normalMapPictureBox);
            Controls.Add(LoadNormalMapBtn);
            Controls.Add(groupBox1);
            Controls.Add(rotationGroupBox);
            Controls.Add(textureRadioButton);
            Controls.Add(colorRadioButton);
            Controls.Add(label3);
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
            ((System.ComponentModel.ISupportInitialize)zLightTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).EndInit();
            rotationGroupBox.ResumeLayout(false);
            rotationGroupBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)normalMapPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)texturePictureBox).EndInit();
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
        private Label label4;
        private TrackBar zLightTrackBar;
        private Label label5;
        private TrackBar mTrackBar;
        private GroupBox rotationGroupBox;
        private GroupBox groupBox1;
        private Button LoadNormalMapBtn;
        private PictureBox normalMapPictureBox;
        private PictureBox texturePictureBox;
        private Button LoadTextureBtn;
        private ToolStripMenuItem changeObjectColorToolStripMenuItem;
        private CheckBox animationCheckBox;
    }
}
