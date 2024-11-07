﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TriangleMesh.Classes
{
    public class Triangle
    {
        List<Vertex> vertices = new List<Vertex>();
        private Color fillColor;
        List<PointF> TurnToXY()
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
            g.DrawLine(new Pen(Color.Red), XYVertices[1], XYVertices[2]);
            g.DrawLine(new Pen(Color.DarkGray), XYVertices[2], XYVertices[0]);
        }

        public Triangle(Vertex a, Vertex b, Vertex c)
        {
            vertices.Add(a);
            vertices.Add(b);
            vertices.Add(c);
            fillColor = Color.DarkBlue;

        }


        public void Fill(Bitmap bm, int width, int height)
        {
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

        public void SetTransformedPixel(Bitmap bitmap, float x, float y, int width, int height)
        {
            if (this.vertices[0].N.X == float.NaN)
            {

            }
            fillColor = GetColor(x, y, this.vertices[0].P.Z, this.vertices[0].N);
            float transformedX = x + width / 2;

            float transformedY = y + height / 2;

            if (transformedX >= 0 && transformedX < bitmap.Width && transformedY >= 0 && transformedY < bitmap.Height)
            {
                bitmap.SetPixel((int)transformedX, (int)transformedY, fillColor);
            }
            else
            {

            }
        }
        Vector3 LightSource = new Vector3(100, 200, 300);

        public Color GetColor(float x, float y, float z, Vector3 N)
        {
            float kd = 0.7f;
            float ks = 0.5f;
            float m = 10f;
            Vector3 IL = new Vector3(1, 1, 1);
            Vector3 IO = new Vector3(0.3f, 0.4f, 0.5f);
            Vector3 L = new Vector3(LightSource.X - x, LightSource.Y - y, LightSource.Z - z);
            Vector3 V = new Vector3(0, 0, 1);
            Vector3 R = 2 * Vector3.Dot(N, L) * N - L;
            R = Vector3.Normalize(R);
            L = Vector3.Normalize(L);
            IO = Vector3.Normalize(IO);
            IL = Vector3.Normalize(IL);

            float cosNL = Vector3.Dot(N, L);
            float cosVR = Vector3.Dot(V, R);
            Vector3 I = kd * IL * IO * cosNL + ks * IL * IO * (float)Math.Pow(cosVR, m);
            I.X = Math.Clamp(I.X * 255, 0, 255);
            I.Y = Math.Clamp(I.Y * 255, 0, 255);
            I.Z = Math.Clamp(I.Z * 255, 0, 255);
            return Color.FromArgb((int)I.X, (int)I.Y, (int)I.Z);

        }

    }

    public class Edge
    {
        public PointF Start { get; set; }
        public PointF End { get; set; }
        public float IntersectionX { get; set; }
        public float SlopeInverse { get; set; }  // 1 / slope, used to update x on each scanline

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
