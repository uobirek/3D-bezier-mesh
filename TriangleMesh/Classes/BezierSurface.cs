using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangleMesh.Classes
{
    public class BezierSurface
    {
        public List<Vector3> controlPoints = new List<Vector3>();
        private float currentalpha = 0;
        private float currentbeta = 0;


        public void Draw(Graphics g)
        {
            foreach (var point in controlPoints)
            {
                g.DrawEllipse(new Pen(Color.Black), point.X, point.Y, 5, 5);
            }
            DrawControlMesh(g, new Pen(Color.DarkRed));
        }
        public void DrawControlMesh(Graphics g, Pen pen)
        {
            int gridSize = (int)Math.Sqrt(controlPoints.Count);

          
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize - 1; x++)
                {
                    int index = y * gridSize + x;
                    Vector3 start = controlPoints[index];
                    Vector3 end = controlPoints[index + 1];

                    g.DrawLine(pen, new PointF(start.X, start.Y), new PointF(end.X, end.Y));
                }
            }

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize - 1; y++)
                {
                    int index = y * gridSize + x;
                    Vector3 start = controlPoints[index];
                    Vector3 end = controlPoints[index + gridSize];

                    g.DrawLine(pen, new PointF(start.X, start.Y), new PointF(end.X, end.Y));
                }
            }
        }

        public void Rotate(float alpha, float beta)
        {
            alpha = (float)(alpha * Math.PI / 180);
            beta = (float)(beta * Math.PI / 180);
            for (int i = 0; i < controlPoints.Count; i++)
                controlPoints[i] = RotatePoint(controlPoints[i], alpha - currentalpha, beta - currentbeta);
            currentalpha = alpha;
            currentbeta = beta;
        }


        public static Vector3 RotatePoint(Vector3 point, float alpha, float beta)
        {
            // Obrót wokół osi X o kąt alpha
            float cosAlpha = MathF.Cos(alpha);
            float sinAlpha = MathF.Sin(alpha);

            float y1 = cosAlpha * point.Y - sinAlpha * point.Z;
            float z1 = sinAlpha * point.Y + cosAlpha * point.Z;
            Vector3 rotatedX = new Vector3(point.X, y1, z1);

            // Obrót wokół osi Y o kąt beta (dotyczy X i Z)
            float cosBeta = MathF.Cos(beta);
            float sinBeta = MathF.Sin(beta);

            float x2 = cosBeta * rotatedX.X + sinBeta * rotatedX.Z;
            float z2 = -sinBeta * rotatedX.X + cosBeta * rotatedX.Z;
            Vector3 rotatedXZ = new Vector3(x2, rotatedX.Y, z2);

            return rotatedXZ;
        }




        public void LoadControlPoints(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(' ');
                    if (parts.Length == 3 &&
                        float.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out float x) &&
                        float.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out float y) &&
                        float.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out float z))
                    {
                        controlPoints.Add(new Vector3(x, y, z));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }
        }
        private Vector3 evaluateBezierCurve(List<Vector3> curve, float t)
        {
            Vector3 P1 = curve[0];
            Vector3 P2 = curve[1];
            Vector3 P3 = curve[2];
            Vector3 P4 = curve[3];
            Vector3 P12 = (1 - t) * P1 + t * P2;
            Vector3 P23 = (1 - t) * P2 + t * P3;
            Vector3 P34 = (1 - t) * P3 + t * P4;
            Vector3 P1223 = (1 - t) * P12 + t * P23;
            Vector3 P2334 = (1 - t) * P23 + t * P34;

            return (1 - t) * P1223 + t * P2334;
        }
        public Vector3 evaluateBezierSurface(float u, float v)
        {
            List<Vector3> Pu = new List<Vector3>();
            for (int i = 0; i < 4; i++)
            {
                List<Vector3> curveP = new List<Vector3>();
                curveP.Add(controlPoints[i * 4]);
                curveP.Add(controlPoints[i * 4 + 1]);
                curveP.Add(controlPoints[i * 4 + 2]);
                curveP.Add(controlPoints[i * 4 + 3]);
                Pu.Add(evaluateBezierCurve(curveP, u));
            }
            return evaluateBezierCurve(Pu, v);
        }
        public Vector3 vTangent(float u, float v)
        {
            List<Vector3> Pu = new List<Vector3>();
            for (int i = 0; i < 4; i++)
            {
                List<Vector3> curveP = new List<Vector3>();
                curveP.Add(controlPoints[i * 4]);
                curveP.Add(controlPoints[i * 4 + 1]);
                curveP.Add(controlPoints[i * 4 + 2]);
                curveP.Add(controlPoints[i * 4 + 3]);
                Pu.Add(evaluateBezierCurve(curveP, u));
            }
            return beziercurveTangent(Pu, v);
        }
        public Vector3 uTangent(float u, float v)
        {
            List<Vector3> Pv = new List<Vector3>();
            for (int i = 0; i < 4; i++)
            {
                List<Vector3> curveP = new List<Vector3>();
                curveP.Add(controlPoints[i]);
                curveP.Add(controlPoints[i + 4]);
                curveP.Add(controlPoints[i + 8]);
                curveP.Add(controlPoints[i + 12]);
                Pv.Add(evaluateBezierCurve(curveP, v));
            }
            return beziercurveTangent(Pv, u);
        }
        private Vector3 beziercurveTangent(List<Vector3> curve, float t)
        {
            Vector3 P0 = curve[0];
            Vector3 P1 = curve[1];
            Vector3 P2 = curve[2];
            Vector3 P3 = curve[3];
            return -3 * P0 * (float)Math.Pow(1 - t, 2)
                    + 3 * P1 * (float)Math.Pow(1 - t, 2)
                    - 6 * P1 * (float)(t) * (1 - t)
                    - 3 * P2 * (float)Math.Pow(t, 2)
                    + 6 * P2 * (float)(t) * (1 - t)
                    + 3 * P3 * (float)Math.Pow(t, 2);
        }

        public Vector3 normalTangent(float u, float v)
        {
            // Oblicz tangenty w kierunku u i v
            List<Vector3> Pu = new List<Vector3>();
            for (int i = 0; i < 4; i++)
            {
                List<Vector3> curveP = new List<Vector3>();
                curveP.Add(controlPoints[i * 4]);
                curveP.Add(controlPoints[i * 4 + 1]);
                curveP.Add(controlPoints[i * 4 + 2]);
                curveP.Add(controlPoints[i * 4 + 3]);
                Pu.Add(evaluateBezierCurve(curveP, u)); // Zakładając, że evaluateBezierCurve oblicza punkt na krzywej
            }

            List<Vector3> Pv = new List<Vector3>();
            for (int i = 0; i < 4; i++)
            {
                List<Vector3> curveP = new List<Vector3>();
                curveP.Add(controlPoints[i * 4]);
                curveP.Add(controlPoints[i * 4 + 1]);
                curveP.Add(controlPoints[i * 4 + 2]);
                curveP.Add(controlPoints[i * 4 + 3]);
                Pv.Add(evaluateBezierCurve(curveP, v)); // Oblicz punkt wzdłuż drugiego parametru
            }

            // Tangenty w kierunku u i v
            Vector3 tangentU = beziercurveTangent(Pu, v);
            Vector3 tangentV = beziercurveTangent(Pv, u);

            // Normalna to iloczyn wektorowy tych dwóch tangentów
            Vector3 normal = Vector3.Cross(tangentU, tangentV);
            normal = Vector3.Normalize(normal); // Upewnij się, że normalna jest znormalizowana
            return normal;
        }


    }
}
