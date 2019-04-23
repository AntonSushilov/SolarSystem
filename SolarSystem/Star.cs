using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SolarSystem
{
    [Serializable]
    public class Star : SpaceObj
    {
        public List<Planet> Planets { get; set; }

        public Star(string name, int r, Orbit orbit, PointF f, double v, Color cl) : base(name, r, orbit, f, v, cl)
        {
            Planets = new List<Planet>();
        }

    }
}
