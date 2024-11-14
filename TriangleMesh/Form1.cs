using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;
using TriangleMesh.Classes;

namespace TriangleMesh
{
    public partial class MainForm : Form
    {
        Color lightColor = Color.White;
        Color objectColor;
        Mesh mesh;
        BezierSurface bezierSurface = new BezierSurface();
        private System.Windows.Forms.Timer animationTimer;
        private LightAnimation lightAnimation;
        float kd, ks;
        int beta, alpha;
        bool texture;
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


            //bezierSurface.Draw(g);
            mesh.Draw(bitmap, g, canvas.Width, canvas.Height, kd, ks, LightSource, lightColor, objectColor, texture);
            e.Graphics.DrawImage(bitmap, -canvas.Width / 2, -canvas.Height / 2);
            int lightSourceSize = 10;
            g.FillEllipse(Brushes.Yellow, LightSource.X - lightSourceSize / 2, LightSource.Y - lightSourceSize / 2, lightSourceSize, lightSourceSize);
            g.FillEllipse(Brushes.Red, 0, 0, lightSourceSize, lightSourceSize);

            g.DrawString("Light Source", new Font("Arial", 8), Brushes.Black, LightSource.X + 10, LightSource.Y - 10);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Vector3 LightSource = lightAnimation.GetLightSource();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\BezierSurface.txt");
            bezierSurface.LoadControlPoints(filePath);
            GetValues();
            bezierSurface.Rotate(alpha, beta, lightAnimation);
             mesh.Create(bezierSurface, LightSource, divisionTrackBar.Value);
            Update();


        }
        private void GetValues()
        {
            kd = (float)kdTrackBar.Value / 10;
            ks = (float)ksTrackBar.Value / 10;
            beta = betaTrackBar.Value;
            alpha = alphaTrackBar.Value;
        }

        private void divisionTrackBar_Scroll(object sender, EventArgs e)
        {
            Vector3 LightSource = lightAnimation.GetLightSource();

            mesh.Create(bezierSurface, LightSource, divisionTrackBar.Value);
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
            texture = false;
            textureRadioButton.Checked = true;
        }

        private void textureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            texture = true;
            colorRadioButton.Checked = false;
        }
    }
}
