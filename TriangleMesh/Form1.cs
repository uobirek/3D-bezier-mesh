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
            mesh = new Mesh(divisionTrackBar.Value);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            var bitmap = new Bitmap(this.canvas.Width, this.canvas.Height);
            Graphics g = e.Graphics;
            g.ScaleTransform(1, -1);
            g.TranslateTransform(canvas.Width / 2, -canvas.Height / 2);
            //if (bezierSurface != null)
            //{
            //    bezierSurface.Draw(g);
            //}
         //   mesh.triangles.Insert(0,(new Triangle(new Vertex(new Vector3(-99, 167, 115)), new Vertex(new Vector3(-143, 36, -44)), new Vertex(new Vector3(37, 143, -23)))));
            mesh.Draw(bitmap, g, canvas.Width, canvas.Height);
            e.Graphics.DrawImage(bitmap, -canvas.Width/2, -canvas.Height/2);


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\BezierSurface.txt");
            bezierSurface.LoadControlPoints(filePath);
            Rotate();
        }

        private void divisionTrackBar_Scroll(object sender, EventArgs e)
        {
            mesh.divisions = divisionTrackBar.Value;
            mesh.Create(bezierSurface);
            canvas.Invalidate();
        }

        private void betaTrackBar_Scroll(object sender, EventArgs e)
        {
            Rotate();
        }
        private void alphaTrackBar_Scroll(object sender, EventArgs e)
        {
            Rotate();
        }
        private void Rotate()
        {
            int beta = betaTrackBar.Value;
            int alpha = alphaTrackBar.Value;
            bezierSurface.Rotate(alpha, beta);
            mesh.Create(bezierSurface);
            canvas.Invalidate();
        }

       
    }
}
