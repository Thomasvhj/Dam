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
        int player1;
        int player2;
        Random randTurn = new Random();
        PictureBox[,] P;
        string color = "s";
        string k = "";
        string B1 = "";
        string B2 = "";
        string k2 = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            n = 8;
            P = new PictureBox[n, n];
            int venstre = 2, top = 2;
            Color[] colors = new Color[] { Color.SaddleBrown, Color.SandyBrown };
            for (int i = 0; i < n; i++)
            {
                venstre = 2;
                if (i % 2 == 0) { colors[0] = Color.SaddleBrown; colors[1] = Color.SandyBrown; }
                else { colors[0] = Color.SandyBrown; colors[1] = Color.SaddleBrown; }
                for (int j = 0; j < n; j++)
                {
                    P[i, j] = new PictureBox();
                    P[i, j].BackColor = colors[(j % 2 == 0) ? 1 : 0];
                    P[i, j].Location = new Point(venstre, top);
                    P[i, j].Size = new Size(60, 60);
                    venstre += 60;
                    P[i, j].Name = i + " " + j;
                    
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
                    P[i, j].MouseLeave += (sender2, e2) =>
                    {
                        PictureBox p = sender2 as PictureBox;
                        if (p.Image != null) p.BackColor = Color.SandyBrown;
                    };

                    P[i, j].Click += (sender3, e3) =>
                    {
                        
                        PictureBox p = sender3 as PictureBox;
                        if (p.Image != null)
                        {
                            int c = -1, x, y;
                            F();
                            if (p.Name.Split(' ')[2] == "b")
                            {
                                if (color == "s") color = "W";
                                else color = "s";
                                x = Convert.ToInt32(k.Split(' ')[0]);
                                y = Convert.ToInt32(k.Split(' ')[1]);
                                B1 = "";
                                B2 = "";
                                if (k.Split(' ')[2] == "s")
                                {
                                    p.Image = Properties.Resources.s;
                                    p.Name = p.Name.Replace("b", "s");
                                }
                                else
                                if (k.Split(' ')[2] == "W")
                                {
                                    p.Image = Properties.Resources.W;
                                    p.Name = p.Name.Replace("b", "W");
                                }
                                P[x, y].Image = null; 
                                
                                if (k2 != "")
                                {
                                    x = Convert.ToInt32(k2.Split(' ')[0]);
                                    y = Convert.ToInt32(k2.Split(' ')[1]);
                                    P[x, y].Image = null;
                                    if (k2.Split(' ')[2] == "s") player1++;
                                    else player2++;

                                    k2 = "";

                                }
                            }
                            else 
                            if (p.Name.Split(' ')[2] == color)
                            {

                                x = Convert.ToInt32(p.Name.Split(' ')[0]);
                                y = Convert.ToInt32(p.Name.Split(' ')[1]);
                                k = p.Name;
                                if (p.Name.Split(' ')[2] == "s") c = 1;
                                try
                                {
                                    if (P[x + c, y + 1].Image == null)
                                    {
                                        P[x + c, y + 1].Image = Properties.Resources.b;
                                        P[x + c, y + 1].Name = (x + c) + " " + (y + 1) + " b";
                                        B1 = (x + c) + " " + (y + 1);
                                    }
                                    else
                                    {
                                        if (P[x+c, y+1].Name.Split(' ')[2] != p.Name.Split(' ')[2] && P[x + (c*2), y+2].Image ==null )
                                        {
                                            P[x + (c * 2), y + 2].Image = Properties.Resources.b;
                                            P[x + (c * 2), y + 2].Name = (x + (c * 2)) + " " + (y + 2) + " b";
                                            B1 = (x + (c * 2)) + " " + (y + 2);
                                            k2 = (x + c) + " " + (y + 1) + " " + P[x + c, y + 1].Name.Split(' ')[2];
                                        }
                                        
                                    }
                                }
                                catch { }
                                try
                                {
                                    if (P[x + c, y - 1].Image == null)
                                    {
                                        P[x + c, y - 1].Image = Properties.Resources.b;
                                        P[x + c, y - 1].Name = (x + c) + " " + (y - 1) + " b";
                                        B2 = (x + c) + " " + (y - 1);
                                    }
                                    else
                                        if (P[x + c, y - 1].Name.Split(' ')[2] != p.Name.Split(' ')[2] && P[x + (c * 2), y - 2].Image == null)
                                    {
                                        P[x + (c * 2), y - 2].Image = Properties.Resources.b;
                                        P[x + (c * 2), y - 2].Name = (x + (c * 2)) + " " + (y - 2) + " b";
                                        B2 = (x + (c * 2)) + " " + (y - 2);
                                        k2 = (x + c) + " " + (y - 1) + " " + P[x + c, y - 1].Name.Split(' ')[2];
                                    }
                                }
                                catch { }
                            }

                        }
                    };

                    G.Controls.Add(P[i, j]);
                }
                top += 60;

            }

        }

        private void F()
        {
            if ( B1 != "")
            {
                int x, y; 
                x = Convert.ToInt32(B1.Split(' ')[0]);
                y = Convert.ToInt32(B1.Split(' ')[1]);
                P[x, y].Image = null;
            }
            if( B2 != "")
            {
                int x, y;
                x = Convert.ToInt32(B2.Split(' ')[0]);
                y = Convert.ToInt32(B2.Split(' ')[1]);
                P[x, y].Image = null;
            }
        }

        public void restart()
        {
            for (int h = 0; h<n; h++) { 
            if (h < (n / 2) - 1 && P[h, 1].BackColor == Color.SandyBrown) { P[h, 1].Image = Properties.Resources.s; P[h, 1].Name += " s"; }
            else if (h > (n / 2) && P[h, 1].BackColor == Color.SandyBrown)
            {
                P[h, 1].Image = Properties.Resources.W; P[h, 1].Name += " W";
            }
                if (h == ((n / 2) - 1) || h == (n / 2)) P[h, 1].Image = null;
            }
        }


        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            btnQuit.Visible = true;

        }
    }
}
