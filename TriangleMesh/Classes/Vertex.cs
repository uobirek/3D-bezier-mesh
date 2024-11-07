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
        public float u, v;

        public Vertex(Vector3 p)
        {
            this.P = p;
        }
        public Vertex(Vector3 P, int divisions, Vector3 Pu, Vector3 Pv)
        {
            this.Pu = Pu;
            this.Pv = Pv;
            this.P = P;
            N = Vector3.Cross(Pu, Pv);
            N = Vector3.Normalize(N);
            if (float.IsNaN(N.X))
            {
                N = Vector3.Zero;
            }
        }
    }
}
