using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;
using TriangleMesh.Classes;

namespace TriangleMesh
{
    public partial class MainForm : Form
    {
        Mesh mesh;
        BezierSurface bezierSurface = new BezierSurface();
        Vector3 LightSource = new Vector3(0, 300, 0);
        float kd, ks;
        int beta, alpha;
        public MainForm()
        {
            InitializeComponent();
            mesh = new Mesh(divisionTrackBar.Value);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            var bitmap = new Bitmap(this.canvas.Width, this.canvas.Height);
            Graphics g = e.Graphics;
            g.ScaleTransform(1, -1);
            g.TranslateTransform(canvas.Width / 2, -canvas.Height / 2);
          
            int lightSourceSize = 10;
            g.FillEllipse(Brushes.Yellow, LightSource.X - lightSourceSize / 2, LightSource.Y - lightSourceSize / 2, lightSourceSize, lightSourceSize);
            g.DrawString("Light Source", new Font("Arial", 8), Brushes.Black, LightSource.X + 10, LightSource.Y - 10);
   
            mesh.Draw(bitmap, g, canvas.Width, canvas.Height, kd, ks);
            e.Graphics.DrawImage(bitmap, -canvas.Width / 2, -canvas.Height / 2);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\BezierSurface.txt");
            bezierSurface.LoadControlPoints(filePath);
            GetValues();
            bezierSurface.Rotate(alpha, beta);
            mesh.Create(bezierSurface, LightSource, divisionTrackBar.Value);
            canvas.Invalidate();


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
            bezierSurface.Rotate(alpha, beta);
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
    }
}
