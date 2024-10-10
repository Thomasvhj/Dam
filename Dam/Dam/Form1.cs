using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n;
        int Turn;
        Random randTurn = new Random();
        PictureBox[,] P;
        private void Form1_Load(object sender, EventArgs e)
        {


            n = 8;
            P = new PictureBox[n, n];
            int venstre = 2, top = 2;
            Color[] colors = new Color[] { Color.White, Color.SandyBrown };
            for (int i = 0; i < n; i++)
            {
                venstre = 2;
                if (i % 2 == 0) { colors[0] = Color.White; colors[1] = Color.SandyBrown; }
                else { colors[0] = Color.SandyBrown; colors[1] = Color.White; }
                for (int j = 0; j < n; j++)
                {
                    P[i, j] = new PictureBox();
                    P[i, j].BackColor = colors[(j % 2 == 0) ? 1 : 0];
                    P[i, j].Location = new Point(venstre, top);
                    P[i, j].Size = new Size(60, 60);
                    venstre += 60;
                    if (i < (n / 2) - 1 && P[i, j].BackColor == Color.SandyBrown) { P[i, j].Image = Properties.Resources.s; P[i, j].Name += " s"; }
                    else if (i > (n / 2) && P[i, j].BackColor == Color.SandyBrown)
                    {
                        P[i, j].Image = Properties.Resources.W; P[i, j].Name += " W";
                    }
                    P[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                    P[i, j].MouseHover += (sender2, e2) =>
                    {
                        PictureBox p = sender2 as PictureBox;
                        if (p.Image != null) p.BackColor = Color.FromArgb(255, 64, 64, 64);
                    };
                    P[i, j].MouseHover += (sender2, e2) =>
                    {
                        PictureBox p = sender2 as PictureBox;
                        if (p.Image != null) p.BackColor = Color.LightGray;
                    };

                    P[i, j].Click += (sender3, e3) =>
                    {
                        PictureBox p = sender3 as PictureBox;
                        if (p.Image != null)
                        {
                            int c = -1
                        }
                    }


                    G.Controls.Add(P[i, j]);




                }
                top += 60;

            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Turn = randTurn.Next(1, 2);
            btnStart.Visible = false;
            btnQuit.Visible = true;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
