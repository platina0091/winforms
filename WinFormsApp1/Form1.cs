using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        int v1, v2;
        bool fi, dvig, ysl1;
        String f, zn, f1;
        double k, b1;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            c = new Circle(this.Width / 2, this.Height / 2);
            type = "circle";
            label1.Text = "Circle";
            con = true;
            dvig = false;
            f1 = "Поопр";
            dvig = false;
            fig = new List<Shape>() { c };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            {
                if (fig.Count >= 3)
                {
                    if (f1 == "Поопр")
                    {


                        for (int i = 0; i < fig.Count; i++)
                        {
                            fig[i].Fig = false;
                        }
                        for (int i = 0; i < fig.Count - 1; i++)
                        {
                            for (int b = i + 1; b < fig.Count; b++)
                            {
                                v1 = i;
                                v2 = b;
                                fi = true;
                                ysl1 = true;
                                if ((fig[v2].X - fig[v1].X) != 0)
                                {
                                    k = (fig[v2].Y - fig[v1].Y) / Convert.ToDouble(fig[v2].X - fig[v1].X);
                                    b1 = fig[v2].Y - Math.Round(k * fig[v2].X);
                                    for (int chet = 0; chet < fig.Count; chet++)
                                    {
                                        if (chet == i || chet == b)
                                        {
                                            continue;
                                        }
                                        if (fi && fig[chet].Y < fig[chet].X * k + b1)
                                        {
                                            fi = false;
                                            zn = "<";
                                        }
                                        else if (fi)
                                        {
                                            fi = false;
                                            zn = ">";
                                        }
                                        if ((fig[chet].Y < fig[chet].X * k + b1) && zn == ">")
                                        {
                                            ysl1 = false;
                                            break;
                                        }
                                        if ((fig[chet].Y > fig[chet].X * k + b1) && zn == "<")
                                        {
                                            ysl1 = false;
                                            break;
                                        }

                                    }
                                }
                                else
                                {
                                    for (int chet = 0; chet < fig.Count; chet++)
                                    {
                                        if (chet == i || chet == b)
                                        {
                                            continue;
                                        }
                                        if (fi && fig[chet].X < fig[v1].X)
                                        {
                                            fi = false;
                                            zn = "<";
                                        }
                                        else if (fi && fig[chet].X > fig[v1].X)
                                        {
                                            fi = false;
                                            zn = ">";
                                        }
                                        else if ((fig[chet].X < fig[v1].X) && zn == ">")
                                        {
                                            ysl1 = false;
                                            break;
                                        }
                                        else if ((fig[chet].X > fig[v1].X) && zn == "<")
                                        {
                                            ysl1 = false;
                                            break;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                                if (ysl1)
                                {
                                    e.Graphics.DrawLine(new Pen(Color.Blue), fig[v1].X, fig[v1].Y, fig[v2].X, fig[v2].Y);
                                    fig[v1].Fig = true;
                                    fig[v2].Fig = true;
                                }


                            }
                        }
                        if (fig[fig.Count - 1].Fig == false && dvig)
                        {
                            for (int i = 0; i < fig.Count - 1; i++)
                            {
                                fig[i].Draw(e.Graphics);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < fig.Count; i++)
                            {
                                fig[i].Draw(e.Graphics);
                            }
                        }
                    }
                    else if (f1 == "Дж")
                    {
                        for (int i = 0; i < fig.Count; i++)
                        {
                            fig[i].Fig = false;
                        }
                        int dop = 0;
                        for (int i = 1; i < fig.Count; i++)
                        {
                            if (fig[i].Y > fig[dop].Y)
                            {
                                dop = i;
                            }
                            else if (fig[i].Y == fig[dop].Y && fig[i].X < fig[dop].X)
                            {
                                dop = i;
                            }
                        }
                        Circle dop1 = new Circle(fig[dop].X - 1000, fig[dop].Y);
                        int dop2 = dop;
                        double dopCos = 2;
                        int dopFig = 0;
                        for (int i = 0; i < fig.Count; i++)
                        {
                            if (Shape.angle(dop1, fig[dop], fig[i]) < dopCos)
                            {
                                dopCos = Shape.angle(dop1, fig[dop], fig[i]);
                                dopFig = i;
                            }

                        }
                        e.Graphics.DrawLine(new Pen(Color.Blue), fig[dop].X, fig[dop].Y, fig[dopFig].X, fig[dopFig].Y);
                        fig[dopFig].Fig = true;
                        fig[dop].Fig = true;
                        int dopFig2 = (dop2 + 1) % fig.Count;
                        for (int b = 0; b < fig.Count; b++)
                        {
                            if (dopFig2 == dop2)
                            {
                                break;
                            }
                            dopCos = 2;
                            for (int i = 0; i < fig.Count; i++)
                            {
                                if (Shape.angle(fig[dop], fig[dopFig], fig[i]) < dopCos)
                                {
                                    dopCos = Shape.angle(fig[dop], fig[dopFig], fig[i]);
                                    dopFig2 = i;
                                }

                            }
                            e.Graphics.DrawLine(new Pen(Color.Blue), fig[dopFig2].X, fig[dopFig2].Y, fig[dopFig].X, fig[dopFig].Y);
                            fig[dopFig2].Fig = true;
                            fig[dopFig].Fig = true;
                            dop = dopFig;
                            dopFig = dopFig2;

                        }
                        if (fig[fig.Count - 1].Fig == false && dvig)
                        {

                            for (int i = 0; i < fig.Count - 1; i++)
                            {
                                fig[i].Draw(e.Graphics);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < fig.Count; i++)
                            {
                                fig[i].Draw(e.Graphics);
                            }
                        }
                    }

                }
                else
                {
                    if (fig[fig.Count - 1].Fig == false && dvig)
                    {
                        for (int i = 0; i < fig.Count - 1; i++)
                        {
                            fig[i].Draw(e.Graphics);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < fig.Count; i++)
                        {
                            fig[i].Draw(e.Graphics);
                        }
                    }
                }


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

                if (fig[fig.Count - 1].Fig == false)
                {
                    dvig = true;
                    for (int i = 0; i < fig.Count; i++)
                    {
                        fig[i].isMoving = true;
                        fig[i].OX = fig[i].X - e.X;
                        fig[i].OY = fig[i].Y - e.Y;
                        con = false;
                    }
                }
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < fig.Count; i++)
            {
                fig[i].isMoving = false;
            }
            con = true;
            for (int i = 0; i < fig.Count; i++)
            {
                if (!fig[i].Fig)
                {
                    fig.Remove(fig[i]);
                    i -= 1;
                    Refresh();
                }
            }
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

        private void jarvisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1 = "Дж";
            Refresh();
        }

        private void byDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1 = "Поопр";
            Refresh();
        }
    }
}