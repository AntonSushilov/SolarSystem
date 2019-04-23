using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    [Serializable]
    public class Orbit
    {
        public float A { get; set; }
        public float B { get; set; }

        public Orbit(float a, float b)
        {
            A = a;
            B = b;
        }
    }
}
