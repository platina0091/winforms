using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Circle c;
        Triangle t;
        Square s;
        List<Shape> fig;
        string type;
        bool con;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            c = new Circle(this.Width/2, this.Height/2);
            type = "circle";
            label1.Text = "Circle";
            con = true;
            fig = new List<Shape>() { c };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < fig.Count; i++)
            {
                fig[i].Draw(e.Graphics);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < fig.Count; i++)
            {
                if (fig[i].isMoving)
                {
                    fig[i].X = e.X + fig[i].OX;
                    fig[i].Y = e.Y + fig[i].OY;
                    Refresh();
                }
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = fig.Count - 1; i >= 0; i--)
                {
                    if (fig[i].Isinside(e.X, e.Y))
                    {
                        fig.Remove(fig[i]);
                        Refresh();
                        break;
                    }
                }
            }
            for (int i = 0; i < fig.Count; i++)
            {
                if (fig[i].Isinside(e.X, e.Y))
                {
                    fig[i].isMoving = true;
                    fig[i].OX = fig[i].X - e.X;
                    fig[i].OY = fig[i].Y - e.Y;
                    con = false;
                }
            }
            if (con && e.Button == MouseButtons.Left)
            {
                if (type == "circle")
                {
                    fig.Add(new Circle(e.X, e.Y));
                }
                else if (type == "square")
                {
                    fig.Add(new Square(e.X, e.Y));
                }
                else
                {
                    fig.Add(new Triangle(e.X, e.Y));
                }

                Refresh();
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < fig.Count; i++)
            {
                fig[i].isMoving = false;
            }
            con = true;
        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void shapeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void circleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            type = "circle";
            label1.Text = "Circle";
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = "triangle";
            label1.Text = "Triangle";
        }

        private void squareToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            type = "square";
            label1.Text = "Square";
        }
    }
}