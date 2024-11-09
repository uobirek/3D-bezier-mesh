using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TriangleMesh.Classes
{
    internal class Mesh(int divisions)
    {
        public List<Triangle> triangles = new List<Triangle>();
        Vertex[,]? grid;
        public int divisions = divisions;
        Vector3 LightSource;

        public void Create(BezierSurface bezierSurface, Vector3 LightSource, int divisions)
        {
            this.divisions = divisions;
            this.LightSource = LightSource;
            grid = new Vertex[divisions + 1, divisions + 1];
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

        public void Update(BezierSurface bezierSurface)
        {

            for (int j = 0; j <= divisions; j++)
            {
                float v = j / (float)divisions;
                for (int i = 0; i <= divisions; i++)
                {
                    float u = i / (float)divisions;
                     grid[i, j].UpdateAfterRotation(bezierSurface.evaluateBezierSurface(u, v), bezierSurface.uTangent(u, v), bezierSurface.vTangent(u, v));
                      
                }
            }
           
        }
        public void Draw(Bitmap bm, Graphics g, int width, int height, float kd, float ks)
        {
            if (triangles != null)
            {
                foreach (Triangle triangle in triangles)
                {
                    triangle.Draw(g);
                }


                triangles.Sort((a, b) =>
                {
                    // Dla każdego trójkąta pobieramy maksymalną wartość Z z jego wierzchołków
                    float maxZ_A = a.vertices.Max(vertex => vertex.P.Z);
                    float maxZ_B = b.vertices.Max(vertex => vertex.P.Z);

                    // Sortujemy malejąco - największe Z (bliżej obserwatora) będą pierwsze
                    return maxZ_B.CompareTo(maxZ_A);
                });

                foreach (Triangle triangle in triangles)
                {
                    triangle.Fill(bm, width, height, kd, ks, LightSource);
                }
            }

        }
    }
}
