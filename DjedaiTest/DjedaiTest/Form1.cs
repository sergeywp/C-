using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace DjedaiTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int maxserch(int[] inpmass)
        {
            int maxEl=0, maxN = 0;
            for (int i = 0; i < inpmass.Length; i++)
            {
                if (inpmass[i] > maxEl)
                {
                    //если текущий элемент больше максимального, то он становится максимальным.
                    maxEl = inpmass[i];
                    maxN = i+1;
                }
            }
            return maxN ;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int temp;
            int[] prov =new int[9];
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < 5000; i++)
            {
                temp = rand.Next(1, 10);
                /*if ((panel1.BackColor != Color.Red) && (panel1.BackColor != Color.Green))
                    panel1.BackColor = Color.Red;
                if (panel1.BackColor != Color.Green)
                    panel1.BackColor = Color.Green;
                if (panel1.BackColor != Color.Red)
                    panel1.BackColor = Color.Red;*/
                Thread.Sleep(2);
                //panel1.BackColor = Color.Green;
                prov[temp-1]++;
            }

            
                stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            String h = "";
            for (int i = 0; i < prov.Length; i++)
                h = h + Environment.NewLine + "number " + (i+1).ToString()+ " : " + prov[i];
            h = h + Environment.NewLine + "max elem on :" + maxserch(prov);
                InfoList.Text += String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10) + h ;             
        }

        private void panel1_BackColorChanged(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Green;
        }
    }
}
