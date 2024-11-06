using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleMesh.Classes
{
    internal class Triangle
    {
        List<Vertex> vertices = new List<Vertex>();
        List <PointF> TurnToXY()
        {
            List<PointF> list = new List<PointF>();
            foreach (var vertex in vertices) list.Add(new PointF(vertex.P.X, vertex.P.Y));
            return list;
        }
        public void Draw(Graphics g)
        {
            var XYVertices = TurnToXY();
            Pen pen = new Pen(Color.Blue);
            g.DrawLine(pen, XYVertices[0], XYVertices[1]);
            g.DrawLine(pen, XYVertices[1], XYVertices[2]);
            g.DrawLine(pen, XYVertices[2], XYVertices[0]);
        }

        public Triangle (Vertex a, Vertex b, Vertex c)
        {
            vertices.Add(a);
            vertices.Add(b);
            vertices.Add(c);
        }
    }
}
