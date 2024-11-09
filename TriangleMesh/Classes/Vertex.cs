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


        public void UpdateAfterRotation(Vector3 P_, Vector3 Pu_, Vector3 Pv_)
        {
            this.P_ = P_;
            this.Pu_ = Pu_;
            this.Pv_ = Pv_;
            N_ = Vector3.Cross(Pu_, Pv_);
            if (N_.Length() < 1e-5) // use a small epsilon to detect near-zero normals
            {
                N_ = new Vector3(0, 0, 1); // default to some normal, e.g., (0, 0, 1)
            }
            else
            {
                N_ = Vector3.Normalize(N_);
            }
        }
    }
}
