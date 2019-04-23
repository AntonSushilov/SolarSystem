using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SolarSystem
{
    public class ScreenConverter
    {
        public int I1 = 0, J1 = 0, I2, J2;
        public double _xMin = 0;
        public double _xMax = 2000;
        public double _yMin = 0;
        public double _yMax = 1500;

        public ScreenConverter(int x, int y)
        {
            I2 = x;
            J2 = y;
        }

        public int II(double x)
        {
            return I1 + (int)((x - _xMin) * (I2 - I1) / (_xMax - _xMin));
        }

        public int JJ(double y)
        {
            return J2 + (int)((y - _yMin) * (J1 - J2) / (_yMax - _yMin));
        }

        public PointF IJ(PointF v)
        {
            int x = II(v.X);
            int y = JJ(v.Y);

            return new PointF(x, y);
        }

        public double XX(int I)
        {
            return _xMin + (I - I1) * (_xMax - _xMin) / (I2 - I1);
        }

        public double YY(int J)
        {
            return _yMin + (J - J2) * (_yMax - _yMin) / (J1 - J2);
        }

        public int LengthR2Sx(float val)
        {
            return (int)(val / (_xMax - _xMin) * I2);
        }

        public int LengthR2Sy(float val)
        {
            return (int)(val / (_yMax - _yMin) * J2);
        }

        public void Scaling(double k)
        {
            _xMin *= k;
            _xMax *= k;
            _yMin *= k;
            _yMax *= k;
        }

        public void Move(Point end, Point begin)
        {
            _xMax -= XX(end.X) - XX(begin.X);
            _xMin -= XX(end.X) - XX(begin.X);
            _yMax -= YY(end.Y) - YY(begin.Y);
            _yMin -= YY(end.Y) - YY(begin.Y);
        }
    }
}
