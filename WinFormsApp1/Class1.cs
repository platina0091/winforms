using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinFormsApp1
{

    abstract class Shape
    {
        protected int x, y, ox, oy;
        protected static int R;
        protected bool IsMoving;

        public Shape(int xx, int yy)
        {
            x = xx; y = yy; IsMoving = false;
        }
        public bool isMoving
        {
            get { return IsMoving; }
            set { IsMoving = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int OX
        {
            get { return ox; }
            set { ox = value; }
        }
        public int OY
        {
            get { return oy; }
            set { oy = value; }
        }
        static Shape()
        {
            R = 100;
        }
        public abstract void Draw(Graphics g);
        public abstract bool Isinside(int Curx, int Cury);
    }
    class Circle : Shape
    {
        public Circle(int xx, int yy) : base(xx, yy) { }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Blue), x - R, y - R, 2 * R, 2 * R);
        }
        public override bool Isinside(int curX, int curY)
        {
            if ((curX - x) * (curX - x) + (curY - y) * (curY - y) <= R * R)
            {
                return true;
            }
            return false;
        }
    }

    class Triangle : Shape
    {
        public Triangle(int xx, int yy) : base(xx, yy) { }
        public override void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Color.Red), x, y + R, Convert.ToInt32(x - Math.Sqrt(3) * R / 2), y - R / 2);
            g.DrawLine(new Pen(Color.Red), Convert.ToInt32(x - Math.Sqrt(3) * R / 2), y - R / 2, Convert.ToInt32(x + Math.Sqrt(3) * R / 2), y - R / 2);
            g.DrawLine(new Pen(Color.Red), Convert.ToInt32(x + Math.Sqrt(3) * R / 2), y - R / 2, x, y + R);

        }
        public override bool Isinside(int curX, int curY)
        {
            double a = R * Math.Sqrt(3);
            double h1 = R * 3 / 2.0;
            double y1 = y - h1 / 3;
            double x2 = x - a / 2;
            double x3 = x + a / 2;
            if ((curY - y1) <= Math.Sqrt(3) * (curX - x2) && ((curY - y1) <= (-1 * Math.Sqrt(3) * (curX - x2) + Math.Sqrt(3) * a)) && curY >= y1)
            {
                return true;
            }
            return false;
        }
    }

    class Square : Shape
    {
        public Square(int xx, int yy) : base(xx, yy) { }
        public override void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Color.Blue), Convert.ToInt32(x - R / Math.Sqrt(2)), Convert.ToInt32(y - R / Math.Sqrt(2)), Convert.ToInt32(x - R / Math.Sqrt(2)), Convert.ToInt32(y + R / Math.Sqrt(2)));
            g.DrawLine(new Pen(Color.Blue), Convert.ToInt32(x - R / Math.Sqrt(2)), Convert.ToInt32(y + R / Math.Sqrt(2)), Convert.ToInt32(x + R / Math.Sqrt(2)), Convert.ToInt32(y + R / Math.Sqrt(2)));
            g.DrawLine(new Pen(Color.Blue), Convert.ToInt32(x + R / Math.Sqrt(2)), Convert.ToInt32(y + R / Math.Sqrt(2)), Convert.ToInt32(x + R / Math.Sqrt(2)), Convert.ToInt32(y - R / Math.Sqrt(2)));
            g.DrawLine(new Pen(Color.Blue), Convert.ToInt32(x + R / Math.Sqrt(2)), Convert.ToInt32(y - R / Math.Sqrt(2)), Convert.ToInt32(x - R / Math.Sqrt(2)), Convert.ToInt32(y - R / Math.Sqrt(2)));
        }
        public override bool Isinside(int curX, int curY)
        {
            double a = R / Math.Sqrt(2);
            double x1 = x - a;
            double x2 = x + a;
            double y1 = y + a;
            double y2 = y - a;
            if (curX >= x1 && curX <= x2 && curY >= y2 && curY <= y1)
            {
                return true;
            }
            return false;
        }

    }

}