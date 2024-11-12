using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TriangleMesh.Classes
{
    public class Triangle
    {
        Vector3 LightSource = new Vector3(0, 0, 300);
        Color LightColor;
        Color ObjectColor;
        public List<Vertex> vertices = new List<Vertex>();
        private Color fillColor;
        public Bitmap Texture { get; set; }
        float kd = 0.8f;
        float ks = 0.8f;
    
        List<PointF> TurnToXY()
        {
            List<PointF> list = new List<PointF>();
            foreach (var vertex in vertices) list.Add(new PointF(vertex.P_.X, vertex.P_.Y));
            return list;
        }
        public void Draw(Graphics g)
        {
            var XYVertices = TurnToXY();
            Pen pen = new Pen(Color.Blue);
            g.DrawLine(pen, XYVertices[0], XYVertices[1]);
            g.DrawLine(new Pen(Color.Red), XYVertices[1], XYVertices[2]);
            g.DrawLine(new Pen(Color.DarkGray), XYVertices[2], XYVertices[0]);
        }

        public Triangle(Vertex a, Vertex b, Vertex c)
        {
            vertices.Add(a);
            vertices.Add(b);
            vertices.Add(c);

        }


        public void Fill(Bitmap bm, int width, int height, float kd, float ks, Vector3 LightSource, Color LightColor, Color ObjectColor)
        {
            this.LightColor = LightColor;
            this.ObjectColor = ObjectColor;

            this.kd = kd;
            this.ks = ks;
            this.LightSource = LightSource;
            List<PointF> XYvertices = this.TurnToXY();
            List<(PointF vertex, int index)> sortedVertexes = new List<(PointF, int)>();
            for (int j = 0; j < XYvertices.Count; j++)
            {
                sortedVertexes.Add((XYvertices[j], j));
            }
            sortedVertexes.Sort((p, q) => p.vertex.Y.CompareTo(q.vertex.Y));
            int[] ind = new int[sortedVertexes.Count];
            for (int j = 0; j < sortedVertexes.Count; j++)
            {
                ind[j] = sortedVertexes[j].index;
            }
            int ymin = (int)XYvertices[ind[0]].Y;

            int ymax = (int)XYvertices[ind[vertices.Count - 1]].Y;
            int k = 0;


            List<Edge> AET = new List<Edge>();
            for (int y = ymin; y <= ymax; y++)
            {
                while (k < ind.Length && (int)XYvertices[ind[k]].Y == y)
                {
                    PointF vertex = XYvertices[ind[k]];
                    PointF previousVertex = ind[k] > 0 ? XYvertices[ind[k] - 1] : XYvertices[vertices.Count - 1];
                    PointF nextVertex = ind[k] < XYvertices.Count - 1 ? XYvertices[ind[k] + 1] : XYvertices[0];

                    if (vertex.Y != previousVertex.Y)
                    {
                        Edge edge = new Edge(vertex, previousVertex);
                        AET.Add(edge);
                    }
                    if (vertex.Y != nextVertex.Y)
                    {
                        Edge edge = new Edge(vertex, nextVertex);
                        AET.Add(edge);
                    }
                    k++;
                }
                AET.RemoveAll(edge => (int)edge.End.Y == y);
                AET = AET.OrderBy(edge => edge.IntersectionX).ToList();
                for (int i = 0; i < AET.Count - 1; i += 2)
                {
                    Edge previousedge = AET[i];
                    Edge currentedge = AET[i + 1];
                    int x1 = (int)Math.Round(previousedge.IntersectionX);
                    int x2 = (int)Math.Round(currentedge.IntersectionX);
                    for (int x = x1; x <= x2; x++)
                    {
                        SetTransformedPixel(bm, x, y, width, height);
                    }
                }
                foreach (var edge in AET)
                {
                    edge.UpdateCurrentX();
                }
            }

        }
        private Random rnd = new Random();

        public void SetTransformedPixel(Bitmap bitmap, float x, float y,  int width, int height)
        {
            Vector3 interpolatedNormal;
            float interpolatedZ;
            this.InterpolateNormalAndZ(x, y, out interpolatedNormal, out interpolatedZ);

            fillColor = GetColor(x, y, interpolatedZ, interpolatedNormal);

            float transformedX = x + width / 2;

            float transformedY = y + height / 2;

            if (transformedX >= 0 && transformedX < bitmap.Width && transformedY >= 0 && transformedY < bitmap.Height)
            {
                bitmap.SetPixel((int)transformedX, (int)transformedY, fillColor);
            }

        }
        private float TriangleArea(Vertex v0, Vertex v1, Vertex v2)
        {
            return 0.5f * Math.Abs(v0.P_.X * (v1.P_.Y - v2.P_.Y) + v1.P_.X * (v2.P_.Y - v0.P_.Y) + v2.P_.X * (v0.P_.Y - v1.P_.Y));
        }

        public void GetBarycentricCoordinates(Vector3 P, out float lambda0, out float lambda1, out float lambda2)
        {
            float area = TriangleArea(vertices[0], vertices[1], vertices[2]);

            Vertex pVertex = new Vertex(P, 0, Vector3.Zero, Vector3.Zero, 0, 0);
            float area1 = TriangleArea(pVertex, vertices[1], vertices[2]);
            float area2 = TriangleArea(vertices[0], pVertex, vertices[2]);
            float area3 = TriangleArea(vertices[0], vertices[1], pVertex);


            lambda0 = area1 / area;
            lambda1 = area2 / area;
            lambda2 = area3 / area;
        }

        public void InterpolateNormalAndZ(float x, float y, out Vector3 interpolatedNormal, out float interpolatedZ)
        {
            GetBarycentricCoordinates(new Vector3(x, y, 0), out float lambda0, out float lambda1, out float lambda2);

            interpolatedNormal = lambda0 * vertices[0].N_ + lambda1 * vertices[1].N_ + lambda2 * vertices[2].N_;

            interpolatedZ = lambda0 * vertices[0].P_.Z + lambda1 * vertices[1].P_.Z + lambda2 * vertices[2].P_.Z;
        }

        public Color GetColor(float x, float y, float z, Vector3 N)
        {

            float m = 20;

            Vector3 IL = new Vector3(
                LightColor.R / 255.0f, // Skala R
                LightColor.G / 255.0f, // Skala G
                LightColor.B / 255.0f  // Skala B
            );
            Color textureColor = GetTextureColor(x, y);  // Pobranie koloru z tekstury
            Vector3 IO = new Vector3(textureColor.R / 255.0f, textureColor.G / 255.0f, textureColor.B / 255.0f);

          //  Vector3 IO = new Vector3(0.3f, 0.5f, 0.9f);

            Vector3 L = new Vector3(LightSource.X - x, LightSource.Y - y, LightSource.Z - z);
            L = Vector3.Normalize(L);

            Vector3 V = new Vector3(0, 0, 1);
            V = Vector3.Normalize(V);

            Vector3 R = 2 * Vector3.Dot(N, L) * N - L;
            R = Vector3.Normalize(R);

            float cosNL = Vector3.Dot(N, L);
            if (cosNL < 0) cosNL = 0;

            float cosVR = Vector3.Dot(V, R);
            if (cosVR < 0) cosVR = 0;

            Vector3 I = kd * IL * IO * cosNL + ks * IL * IO * (float)Math.Pow(cosVR, m);
            I.X = Math.Clamp(I.X * 255, 0, 255);
            I.Y = Math.Clamp(I.Y * 255, 0, 255);
            I.Z = Math.Clamp(I.Z * 255, 0, 255);
            return Color.FromArgb((int)I.X, (int)I.Y, (int)I.Z);

        }
        public Color GetTextureColor(float x, float y)
        {
            // Pobranie wierzchołków trójkąta
            Vertex v0 = this.vertices[0];
            Vertex v1 = this.vertices[1];
            Vertex v2 = this.vertices[2];

            // Oblicz współczynniki barycentryczne dla punktu (x, y)
            float lambda0, lambda1, lambda2;
            this.GetBarycentricCoordinates(new Vector3(x, y, 0), out lambda0, out lambda1, out lambda2);

            // Interpolacja współrzędnych UV dla punktu (x, y) na podstawie współczynników barycentrycznych
            float u = lambda0 * v0.u + lambda1 * v1.u + lambda2 * v2.u;
            float v = lambda0 * v0.v + lambda1 * v1.v + lambda2 * v2.v;

            // Zmapowanie współrzędnych (u, v) na wymiary tekstury
            int textureX = (int)(u * Texture.Width);
            int textureY = (int)(v * Texture.Height);

            // Pobranie piksela z tekstury
            return Texture.GetPixel(textureX, textureY);
        }


    }

    public class Edge
    {
        public PointF Start { get; set; }
        public PointF End { get; set; }
        public float IntersectionX { get; set; }
        public float SlopeInverse { get; set; } 

        public Edge(PointF start, PointF end)
        {
            if (start.Y < end.Y)
            {
                Start = start;
                End = end;
            }
            else
            {
                Start = end;
                End = start;
            }
            IntersectionX = Start.X;
            SlopeInverse = (End.X - Start.X) / (End.Y - Start.Y);
        }

        public void UpdateCurrentX()
        {
            IntersectionX += SlopeInverse;
        }
    }
}
