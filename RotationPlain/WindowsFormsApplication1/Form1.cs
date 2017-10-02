using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void change(double phiD, double[,] mass, int N)
        {
            //поворот точек
            double pi = 3.14159265358979323846;
            double phi;
            phi = phiD * pi / 180;
            for (int i = 0; i < N * N; i++)
            {
                double xold, yold;
                xold = mass[i, 0];
                yold = mass[i, 1];
                mass[i, 0] = xold * Math.Cos(phi) - yold * Math.Sin(phi);
                mass[i, 1] = xold * Math.Sin(phi) + yold * Math.Cos(phi);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int N = 2;
            double[,] mass = new double[N*N,2];//x=[*,0]; y=[*,1]
 
            for (int i = 0; i < N * N; i++)
            {
                mass[i,0] = i / N*3+50;
                mass[i, 1] = i % N *3 + 50;
            }

            String s="";

            for (int i = 0; i < N * N; i++)
            {
                s = s + Environment.NewLine + mass[i, 0].ToString() + ":" + mass[i, 1].ToString() + " ";
            }
            textBox1.Text = s;
            Graphics gr = pictureBox1.CreateGraphics();
            Pen p = new Pen(Color.FromArgb(0,0,255),5);
            for (int j = 0; j < 90000/9; j++)
            {
                p = new Pen(Color.FromArgb(j % 64 + 128, j % 128, j % 255, j % 255), 5);
                change(Convert.ToDouble(1), mass, N);
                for (int i = 0; i < N * N; i++)
                    gr.DrawLine(p, new Point(Convert.ToInt32(mass[i, 0]) + 150, Convert.ToInt32(mass[i, 1]) + 150), new Point(Convert.ToInt32(mass[i, 0]) + 1 + 150, Convert.ToInt32(mass[i, 1]) + 1 + 150));
            }
            //gr.DrawLine(p, new Point(0, 0), new Point(100, 100));
        }
    }
}
