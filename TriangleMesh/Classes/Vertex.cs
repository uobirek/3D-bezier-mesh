using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TriangleMesh.Classes
{
    public class Vertex
    {
        public Vector3 P, Pu, Pv, N;
        public Vector3 P_, Pu_, Pv_, N_;
        public float u, v;


        public Vertex(Vector3 P, int divisions, Vector3 Pu, Vector3 Pv)
        {
            this.Pu = Pu;
            this.Pv = Pv;
            this.P = P;
            N = Vector3.Cross(Pu, Pv);
            if (N.Length() < 1e-5) // use a small epsilon to detect near-zero normals
            {
                N = new Vector3(0, 0, 1); // default to some normal, e.g., (0, 0, 1)
            }
            else
            {
                N = Vector3.Normalize(N);
            }
            Pu_ = Pu;
            Pv_ = Pv;
            P_ = P;
            N_ = N;

        }


        public void UpdateAfterRotation(Vector3 P_, Vector3 Pu_, Vector3 Pv_, Vector3 LightSource)
        {
            // Zaktualizuj pozycje punktów i wektorów
            this.P_ = P_;
            this.Pu_ = Pu_;
            this.Pv_ = Pv_;

            // Oblicz wektor normalny jako iloczyn wektorowy Pu_ i Pv_
            N_ = Vector3.Cross(Pu_, Pv_);

            // Jeśli długość wektora normalnego jest bliska zeru, przypisz domyślny wektor normalny
            if (N_.Length() < 1e-5)
            {
                N_ = new Vector3(0, 0, 1); // Domyślny kierunek normalny
            }
            else
            {
                // Znormalizuj normalną, aby jej długość była równa 1
                N_ = Vector3.Normalize(N_);
            }

            // Sprawdź, czy normalna jest skierowana w stronę obserwatora, który jest "nad" sceną (na większym Z)
            Vector3 ViewPoint = new Vector3(P_.X, P_.Y, P_.Z + 200); // Obserwator nad punktem P_

            // Jeśli normalna jest skierowana przeciwnie do obserwatora, odwróć ją
            if (Vector3.Dot((ViewPoint - P_), N_) < 0)
            {
                N_ = -N_;
            }
        }


    }
}
