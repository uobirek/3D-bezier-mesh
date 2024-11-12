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
        private float time = 0;  // Zmienna czasu
        private float speed = 0.01f;  // Szybkość ruchu źródła światła
        private Vector3 LightSource;  // Współrzędne źródła światła

        // Parametry kwadratu
        private float x_min = -100;
        private float y_min = -100;
        private float x_max = 100;
        private float y_max = 100;

        public LightAnimation()
        {
            LightSource = new Vector3(-100,250, 100); // Początkowa pozycja źródła światła
        }

        public void Update()
        {
            //// Zwiększamy czas
            //time += speed;

            //// Ruch źródła światła po krawędzi kwadratu
            //float sideLength = 200;  // Długość boku kwadratu

            //if (time < 0.25f)
            //{
            //    // Ruch od (x_min, y_min) do (x_max, y_min) - dolna krawędź
            //    LightSource.X = x_min + time * 4 * sideLength;
            //    LightSource.Y = y_min;
            //}
            //else if (time < 0.5f)
            //{
            //    // Ruch od (x_max, y_min) do (x_max, y_max) - prawa krawędź
            //    time -= 0.25f;
            //    LightSource.X = x_max;
            //    LightSource.Y = y_min + time * 4 * sideLength;
            //}
            //else if (time < 0.75f)
            //{
            //    // Ruch od (x_max, y_max) do (x_min, y_max) - górna krawędź
            //    time -= 0.5f;
            //    LightSource.X = x_max - time * 4 * sideLength;
            //    LightSource.Y = y_max;
            //}
            //else
            //{
            //    // Ruch od (x_min, y_max) do (x_min, y_min) - lewa krawędź
            //    time -= 0.75f;
            //    LightSource.X = x_min;
            //    LightSource.Y = y_max - time * 4 * sideLength;
            //}

            //// Resetowanie czasu, aby cykl się powtarzał
            //if (time >= 1)
            //{
            //    time = 0;
            //}
        }

        public Vector3 GetLightSource()
        {
            return LightSource;
        }
    }
}
