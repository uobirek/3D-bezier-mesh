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

        public MainForm()
        {
            InitializeComponent();
            mesh = new Mesh(5);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(1, -1);
            g.TranslateTransform(canvas.Width / 2, -canvas.Height / 2);
            if (bezierSurface != null)
            {
                bezierSurface.Draw(g);

            }
            if (mesh.triangles != null)
                foreach (Triangle triangle in mesh.triangles)
                {
                    triangle.Draw(g);
                }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\BezierSurface.txt");
            bezierSurface.LoadControlPoints(filePath);
            mesh.Create(bezierSurface);
            canvas.Invalidate();
        }

        private void divisionTrackBar_Scroll(object sender, EventArgs e)
        {
            mesh.divisions = divisionTrackBar.Value;
            mesh.Create(bezierSurface);
            canvas.Invalidate();
        }

        private void betaTrackBar_Scroll(object sender, EventArgs e)
        {
            int beta = betaTrackBar.Value;
            bezierSurface.Rotate(0, beta);
            mesh.Create(bezierSurface);
            canvas.Invalidate();
        }
        private void alphaTrackBar_Scroll(object sender, EventArgs e)
        {
            int alpha = alphaTrackBar.Value;
            bezierSurface.Rotate(alpha, 0);
            mesh.Create(bezierSurface);
            canvas.Invalidate();
        }

       
    }
}
