using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SolarSystem
{
    [Serializable]
    public class Planet : SpaceObj
    {

        public Planet(string name, int r, Orbit orbit, PointF f, double v, Color cl) : base(name, r, orbit, f, v, cl)
        {

        }

    }
}
