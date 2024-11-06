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

        public Vertex (Vector3 p)
        {
            P = p;
        }
    }
}
