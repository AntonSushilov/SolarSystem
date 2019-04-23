using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SolarSystem
{
    [Serializable]
    public abstract class SpaceObj
    {
        public string Name { get; set; }
        public PointF Position { get; set; }
        public int R { get; set; }
        public PointF Fulcrum { get; set; }
        public Orbit Orbit { get; set; }
        public Color Cl { get; set; }
        public double _v;

        public SpaceObj(string name, int r, Orbit orbit, PointF f, double v,Color cl)
        {
            Name = name;
            R = r;
            Orbit = orbit;
            Fulcrum = f;
            _v = v;
            Cl = cl;
        }

        public void Draw(Graphics g, ScreenConverter sc)
        {
            PointF location = sc.IJ(Position);
            SolidBrush br = new SolidBrush(Cl);
            g.FillEllipse(br, location.X, location.Y, sc.LengthR2Sx(2 * R), sc.LengthR2Sx(2 * R));

        }

        public void Update(float dt)
        {
            float x = Fulcrum.X + (float)(Orbit.A * Math.Cos(dt * _v)) - R;
            float y = Fulcrum.Y + (float)(Orbit.B * Math.Sin(dt * _v)) + R;
            Position = new PointF(x, y);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
