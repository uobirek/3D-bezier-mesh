using System;
using System.Numerics;

namespace TriangleMesh.Classes
{
    public class LightAnimation
    {
        private float time = 0;
        private float speed = 0.1f;
        private float radius = 100f;
        public Vector3 center = new Vector3(0, 0, 200); 
        public Vector3 LightSource;
        public float currentalpha;
        public float currentbeta;
        public bool animation = true;


        public LightAnimation()
        {
            LightSource = new Vector3(center.X + radius, center.Y, center.Z); 
        }

        public void Update()
        {

            if (animation)
            {
                time += speed;

                LightSource.X = center.X + radius * (float)Math.Cos(time);
                LightSource.Y = center.Y + radius * (float)Math.Sin(time);


                LightSource.Z = center.Z;
                UpdateRotation();
            }


        }

        public void SetAlphaBeta(float alpha, float beta)
        {
      
            currentalpha = alpha;
            currentbeta = beta;
            
        }
        public void UpdateRotation()
        {
            LightSource = RotatePoint(LightSource, currentalpha, currentbeta);
        }

        public static Vector3 RotatePoint(Vector3 point, float alpha, float beta)
        {
            float cosAlpha = MathF.Cos(alpha);
            float sinAlpha = MathF.Sin(alpha);

            float y1 = cosAlpha * point.Y - sinAlpha * point.Z;
            float z1 = sinAlpha * point.Y + cosAlpha * point.Z;
            Vector3 rotatedX = new Vector3(point.X, y1, z1);

            float cosBeta = MathF.Cos(beta);
            float sinBeta = MathF.Sin(beta);

            float x2 = cosBeta * rotatedX.X + sinBeta * rotatedX.Z;
            float z2 = -sinBeta * rotatedX.X + cosBeta * rotatedX.Z;
            Vector3 rotatedXZ = new Vector3(x2, rotatedX.Y, z2);

            return rotatedXZ;
        }

        public Vector3 GetLightSource()
        {
            return LightSource;
        }
    }
}