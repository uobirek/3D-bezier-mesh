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
        public float u_, v_;


        public Vertex(Vector3 P, int divisions, Vector3 Pu, Vector3 Pv, float u, float v)
        {
            this.Pu = Pu;
            this.Pv = Pv;
            this.P = P;
            N = Vector3.Cross(Pu, Pv);
            //if (N.Length() < 1e-5) 
            //{
            //    N = new Vector3(, 0, 0); 
            //}
            //else
            //{
                N = Vector3.Normalize(N);
            //}
            this.u = u;
            this.v = v;

            if (u > 1 || v > 1)
            {

            }
            Pu_ = Pu;
            Pv_ = Pv;
            P_ = P;
            N_ = N;
            u_ = u;
            v_ = v;
        }

        public void Update(Vector3 P_, Vector3 Pu_, Vector3 Pv_, Vector3 LightSource, float u_, float v_)
        {
            this.P_ = P_;
            this.Pu_ = Pu_;
            this.Pv_ = Pv_;
            this.u_ = u_;
            this.v_ = v_;

            N_ = Vector3.Cross(Pu_, Pv_);

            //if (N_.Length() < 1e-5)
            //{
            //    N_ = new Vector3(0, 0, 1); 
            //}
            //else
            //{
                N_ = Vector3.Normalize(N_);
          //  }

            Vector3 ViewPoint = new Vector3(P_.X, P_.Y, P_.Z + 200);

            if (Vector3.Dot((ViewPoint - P_), N_) < 0)
            {
                N_ = -N_;
            }
            
        }


    }
}
