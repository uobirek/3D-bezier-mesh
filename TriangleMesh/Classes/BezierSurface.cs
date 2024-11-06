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

        public void Draw(Graphics g)
        {
            foreach (var point in controlPoints)
            {
                g.DrawEllipse(new Pen(Color.Black), point.X, point.Y, 5, 5);
            }
        }

        public void Rotate(float alpha, float beta)
        {
            for (int i = 0; i < controlPoints.Count; i++)
                controlPoints[i] = RotatePoint(controlPoints[i], alpha, beta);
        }


        public static Vector3 RotatePoint(Vector3 point, float alpha, float beta)
        {
            float cosAlpha = MathF.Cos(alpha);
            float sinAlpha = MathF.Sin(alpha);

            float cosBeta = MathF.Cos(beta);
            float sinBeta = MathF.Sin(beta);

            float y1 = cosAlpha * point.Y - sinAlpha * point.Z;
            float z1 = sinAlpha * point.Y + cosAlpha * point.Z;
            Vector3 rotatedX = new Vector3(point.X, y1, z1);

            float x2 = cosBeta * rotatedX.X - sinBeta * rotatedX.Y;
            float y2 = sinBeta * rotatedX.X + cosBeta * rotatedX.Y;
            Vector3 rotatedXZ = new Vector3(x2, y2, rotatedX.Z);

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


    }
}
