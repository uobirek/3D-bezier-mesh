using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TriangleMesh.Classes
{
    internal class Mesh
    {
        public List<Triangle> triangles;
        public int divisions;
        public Mesh(int divisions)
        {
            this.divisions = divisions;
            triangles = new List<Triangle>();
        }
        public void Create(BezierSurface bezierSurface)
        {
            Vertex[,] grid = new Vertex[divisions + 1, divisions + 1];
            triangles.Clear();
            for (int j = 0; j <= divisions; j++)
            {
                float v = j / (float)divisions;
                for (int i = 0; i <= divisions; i++)
                {
                    float u = i / (float)divisions;
                    grid[i, j] = new Vertex(bezierSurface.evaluateBezierSurface(u, v), divisions, bezierSurface.uTangent(u, v), bezierSurface.vTangent(u, v));
                }
            }
            for (int j = 0; j < divisions; ++j) 
            {
                for (int i = 0; i < divisions; ++i)  
                {
                    triangles.Add(new Triangle(
                        grid[i, j],
                        grid[i + 1, j],
                        grid[i, j + 1]
                    ));

                    triangles.Add(new Triangle(
                        grid[i + 1, j],
                        grid[i + 1, j + 1],
                        grid[i, j + 1]
                    ));
                }
            }




        }
        public void Draw(Bitmap bm, Graphics g, int width, int height)
        {
            if (triangles != null)
            {
                foreach (Triangle triangle in triangles)
                {
                    triangle.Draw(g);
                }
                 foreach (Triangle triangle in triangles)
                 {
                triangle.Fill(bm, width, height);
                }
            }

        }
    }
}
