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
        Color LightColor;
        Color ObjectColor;

        public Bitmap Texture { get; set; }
        public void LoadTexture(string filePath)
        {
            Texture = new Bitmap(filePath);
        }
        public void Create(BezierSurface bezierSurface, Vector3 LightSource, int divisions)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\stones.jpeg");
            LoadTexture(filePath);
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
                    grid[i, j] = new Vertex(bezierSurface.evaluateBezierSurface(u, v), divisions, bezierSurface.uTangent(u, v), bezierSurface.vTangent(u, v), u, v);
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
                    triangles.Last().Texture = Texture;

                    triangles.Add(new Triangle(
                        grid[i + 1, j],
                        grid[i + 1, j + 1],
                        grid[i, j + 1]
                    ));
                    triangles.Last().Texture = Texture;

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
                     grid[i, j].Update(bezierSurface.evaluateBezierSurface(u, v), bezierSurface.uTangent(u, v), bezierSurface.vTangent(u, v), LightSource);
                }
            }
        }
        public void Draw(Bitmap bm, Graphics g, int width, int height, float kd, float ks, Vector3 LightSource, Color LightColor, Color ObjectColor, bool texture)
        {
            this.LightSource = LightSource;
            if (triangles != null)
            {
                triangles.Sort((a, b) =>
                {
                    float avgZ_A = a.vertices.Average(vertex => vertex.P_.Z);
                    float avgZ_B = b.vertices.Average(vertex => vertex.P_.Z);

                    return avgZ_A.CompareTo(avgZ_B);
                });

                foreach (Triangle triangle in triangles)
                {
                    triangle.Fill(bm, width, height, kd, ks, LightSource, LightColor, ObjectColor, texture); 
                }
            }
        }


    }
}
