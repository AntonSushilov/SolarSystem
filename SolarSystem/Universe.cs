using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SolarSystem
{
    public class Universe
    {
        public List<SpaceObj> Space;


        public Universe()
        {
            Space = new List<SpaceObj>();
        }

        Pen myPen = new Pen(Color.FromArgb(32, Color.White), 1);
        public void DrawAll(Graphics g, ScreenConverter sc)
        {
            foreach (SpaceObj o in Space)
            {
                g.DrawEllipse(myPen, sc.II(o.Fulcrum.X - o.Orbit.A), sc.JJ(o.Fulcrum.Y + o.Orbit.B), sc.LengthR2Sx(o.Orbit.A * 2), sc.LengthR2Sy(o.Orbit.B * 2));
                o.Draw(g, sc);
            }
        }


        public void UpdateAll(float dt)
        {
            foreach (SpaceObj o in Space)
                o.Update(dt);
        }
    }
}
