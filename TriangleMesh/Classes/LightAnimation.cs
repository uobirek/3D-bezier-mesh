using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TriangleMesh.Classes
{
    public class LightAnimation
    {
        private float time = 0;  
        private float speed = 1;
        public Vector3 LightSource;

        // Parametry kwadratu
        private float x_min = -100;
        private float y_min = -100;
        private float x_max = 100;
        private float y_max = 100;
        int x = 5;
        public LightAnimation()
        {
            LightSource = new Vector3(-50,-50, 200); // Początkowa pozycja źródła światła
        }

        public void Update()
        {
            LightSource.X += x;
            LightSource.Y += x;

            time += speed;
            if (time > 20)
            {
                x = -x;
                time = 0;
            }


        }

        public Vector3 GetLightSource()
        {
            return LightSource;
        }
    }
}
