using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;
using TriangleMesh.Classes;

namespace TriangleMesh
{
    public partial class MainForm : Form
    {
        Color lightColor = Color.White;
        Color objectColor = Color.Blue;
        Mesh mesh;
        BezierSurface bezierSurface = new BezierSurface();
        private System.Windows.Forms.Timer animationTimer;
        private LightAnimation lightAnimation;
        float kd, ks;
        int m;
        int beta, alpha;
        bool texture;
        string normalMapFileName;
        string textureFileName;
        bool animation;
        public MainForm()
        {
            InitializeComponent();
            mesh = new Mesh(divisionTrackBar.Value);
            lightAnimation = new LightAnimation();

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 1;
            animationTimer.Tick += OnAnimationTick;
            animationTimer.Start();
        }
        private void OnAnimationTick(object sender, EventArgs e)
        {
            lightAnimation.Update();

            canvas.Invalidate();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Vector3 LightSource = lightAnimation.GetLightSource();
            var bitmap = new Bitmap(this.canvas.Width, this.canvas.Height);
            Graphics g = e.Graphics;
            g.ScaleTransform(1, -1);
            g.TranslateTransform(canvas.Width / 2, -canvas.Height / 2);


            mesh.Draw(bitmap, g, canvas.Width, canvas.Height, kd, ks, m, LightSource, lightColor, objectColor, texture);
            e.Graphics.DrawImage(bitmap, -canvas.Width / 2, -canvas.Height / 2);
            int lightSourceSize = 10;
            g.FillEllipse(Brushes.Yellow, LightSource.X - lightSourceSize / 2, LightSource.Y - lightSourceSize / 2, lightSourceSize, lightSourceSize);


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Vector3 LightSource = lightAnimation.GetLightSource();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\BezierSurface.txt");
            bezierSurface.LoadControlPoints(filePath);
            GetValues();
            bezierSurface.Rotate(alpha, beta, lightAnimation);
            mesh.Create(bezierSurface, LightSource, divisionTrackBar.Value);

            normalMapFileName = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\normal_map.jpg");

            mesh.LoadNormalMap(normalMapFileName);
            textureFileName = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\greentexture.jpg");
            mesh.LoadTexture(textureFileName);

            normalMapPictureBox.Image = mesh.NormalMap;
            normalMapPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            texturePictureBox.Image = mesh.Texture;
            texturePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            Update();



        }
        private void GetValues()
        {
            kd = (float)kdTrackBar.Value / 10;
            ks = (float)ksTrackBar.Value / 10;
            beta = betaTrackBar.Value;
            alpha = alphaTrackBar.Value;
            m = mTrackBar.Value;
        }

        private void divisionTrackBar_Scroll(object sender, EventArgs e)
        {
            lightAnimation = new LightAnimation();

            Vector3 LightSource = lightAnimation.GetLightSource();

            mesh.Create(bezierSurface, LightSource, divisionTrackBar.Value);
            mesh.LoadNormalMap(normalMapFileName);
            mesh.LoadTexture(textureFileName);

            Update();
            canvas.Invalidate();
        }

        private void betaTrackBar_Scroll(object sender, EventArgs e)
        {
            Update();
        }
        private void alphaTrackBar_Scroll(object sender, EventArgs e)
        {
            Update();
        }
        private void Update()
        {
            GetValues();

            bezierSurface.Rotate(alpha, beta, lightAnimation);

            mesh.Update(bezierSurface);
            canvas.Invalidate();

        }

        private void kdTrackBar_Scroll(object sender, EventArgs e)
        {
            Update();
        }

        private void ksTrackBar_Scroll(object sender, EventArgs e)
        {
            Update();
        }

        private void changeLightColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog
            {
                FullOpen = true
            };

            colorDialog.Color = lightColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lightColor = colorDialog.Color;
            }
            Update();
        }

        private void colorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (texture)
            {
                texture = false;
                textureRadioButton.Checked = false;
            }

        }

        private void textureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!texture)
            {
                texture = true;

                colorRadioButton.Checked = false;
            }

        }

        private void zLightTrackBar_Scroll(object sender, EventArgs e)
        {
            lightAnimation.center.Z = zLightTrackBar.Value;
        }

        private void mTrackBar_Scroll(object sender, EventArgs e)
        {
            Update();
        }

        private void LoadNormalMapBtn_Click(object sender, EventArgs e)
        {
            var initialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\");

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = initialDirectory;
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Select a Normal Map";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mesh.LoadNormalMap(openFileDialog.FileName);
                normalMapFileName = openFileDialog.FileName;
                normalMapPictureBox.Image = mesh.NormalMap;
                normalMapPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Update();
        }

        private void LoadTextureBtn_Click(object sender, EventArgs e)
        {
            var initialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\");

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = initialDirectory;
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Select a Texture";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mesh.LoadTexture(openFileDialog.FileName);
                textureFileName = openFileDialog.FileName;
                texturePictureBox.Image = mesh.Texture;
                texturePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            Update();
        }

        private void changeObjectColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog
            {
                FullOpen = true
            };

            colorDialog.Color = objectColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                objectColor = colorDialog.Color;
            }
            Update();
        }

        private void animationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            animation = animationCheckBox.Checked;
            lightAnimation.animation = animation;
        }
    }
}
