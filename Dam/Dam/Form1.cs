using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        // spilvariabler
        int n; // Ukendt funktion, muligvis ikke i brug
        int player1; // Holder styr på antallet af brikker, som spiller 1 har taget
        int player2; // Holder styr på antallet af brikker, som spiller 2 har taget
        PictureBox[,] Placering; // Et 8x8 bræt med PictureBoxes, der repræsenterer felterne
        string color = "s"; // Holder styr på hvilken spillers tur det er ("s" eller "W")
        string k = ""; // Midlertidig variabel til markering af felt/brik
        string B1 = ""; // Midlertidig markering af første mulige bevægelse
        string B2 = ""; // Midlertidig markering af anden mulige bevægelse
        string k2 = ""; // Midlertidig variabel til markering af modstanderens brik, der kan tages

       
        // Formens Load-event, kaldes når formen indlæses
        private void Form1_Load(object sender, EventArgs e)
        { 
            groupBox1.Visible=false; // Skjuler vinderfeltet ved start
            
            // Initialiserer brættet med en 8x8 matrice af PictureBoxes
            Placering = new PictureBox[8, 8];
            int venstre = 2, top = 2; // Startpositioner for felterne
            Color[] colors = new Color[] { Color.SaddleBrown, Color.SandyBrown }; // Brættets farver
            for (int i = 0; i < 8; i++) // Rækker
            {
                venstre = 2; // Nulstil venstre position til start af rækken
                if (i % 2 == 0) // Skakmønster starter forskelligt for hver anden række
                {
                    colors[0] = Color.SaddleBrown; 
                    colors[1] = Color.SandyBrown; 
                }
                else 
                { 
                    colors[0] = Color.SandyBrown; 
                    colors[1] = Color.SaddleBrown; 
                }

                for (int j = 0; j < 8; j++) // Kolonner
                {
                    // her danner vi alle felter (som en PictureBox) og tilføjer dem til arrayet
                    Placering[i, j] = new PictureBox();
                    Placering[i, j].BackColor = colors[(j % 2 == 0) ? 1 : 0]; // Skifter farve for skakmønster
                    Placering[i, j].Location = new Point(venstre, top);
                    Placering[i, j].Size = new Size(60, 60);
                    venstre += 60; // Flytter positionen til næste felt
                    Placering[i, j].Name = i + " " + j; // Sætter navn baseret på position

                    if (i < (8 / 2) - 1 && Placering[i, j].BackColor == Color.SandyBrown)
                    { 
                        Placering[i, j].Image = Properties.Resources.s; Placering[i, j].Name += " s"; // Røde brikker for spiller 1
                    }
                    else if (i > (8 / 2) && Placering[i, j].BackColor == Color.SandyBrown)
                    {
                        Placering[i, j].Image = Properties.Resources.W; Placering[i, j].Name += " W"; // Hvide brikker for spiller 2
                    }

                    // Konfigurerer billede i midten af PictureBox
                    Placering[i, j].SizeMode = PictureBoxSizeMode.CenterImage;

                    // Event for når musen holdes over et felt
                    Placering[i, j].MouseHover += (sender2, e2) =>
                    {
                        PictureBox p = sender2 as PictureBox;
                        if (p.Image != null) p.BackColor = Color.FromArgb(255, 64, 64, 64); // Skifter baggrund for at fremhæve brikker
                    };

                    // Event for når musen forlader feltet
                    Placering[i, j].MouseLeave += (sender2, e2) =>
                    {
                        PictureBox p = sender2 as PictureBox;
                        if (p.Image != null) p.BackColor = Color.SandyBrown; // Skifter tilbage til normal farve
                    };


                    // Click-event for hver PictureBox (felt)
                    Placering[i, j].Click += (sender3, e3) =>
                    {

                        PictureBox p = sender3 as PictureBox;
                        if (p.Image != null) //siger vi essentielt at hvis der ikke er et billede på boxen altså "et brik", så skal den udføre det følgende
                        {
                            int c = -1, x, y;
                            valgfjerner(); // Fjerner mulige træk fra sidste tur
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
                                else if (k.Split(' ')[2] == "Ks")
                                {
                                    p.Image = Properties.Resources.Ks;
                                    p.Name = p.Name.Replace("b", "Ks");
                                }
                                else if (k.Split(' ')[2] == "Kw")
                                {
                                    p.Image = Properties.Resources.Kw;
                                    p.Name = p.Name.Replace("b", "Kw");
                                }


                                Placering[x, y].Image = null;

                                // Hvis modstanderens brik blev taget
                                if (k2 != "")
                                {
                                    x = Convert.ToInt32(k2.Split(' ')[0]);
                                    y = Convert.ToInt32(k2.Split(' ')[1]);
                                    Placering[x, y].Image = null;
                                    if (k2.Split(' ')[2] == "s")
                                    {
                                        player1++; // Opdaterer spiller 1’s point
                                        label2taget.Text = "Taget brikker; " + player1.ToString();
                                    }

                                    else
                                    {
                                        player2++; // Opdaterer spiller 2’s point
                                        label1taget.Text = "Taget brikker; " + player2.ToString();
                                    }
                                    winner(); // Tjekker om nogen har vundet
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
                                // Tjekker om det næste felt er tomt og markerer træk
                                try
                                {
                                    if (Placering[x + c, y + 1].Image == null)
                                    {
                                        Placering[x + c, y + 1].Image = Properties.Resources.b;
                                        Placering[x + c, y + 1].Name = (x + c) + " " + (y + 1) + " b";
                                        B1 = (x + c) + " " + (y + 1);
                                    }
                                    else
                                    {
                                        if (Placering[x + c, y + 1].Name.Split(' ')[2] != p.Name.Split(' ')[2] && Placering[x + (c * 2), y + 2].Image == null)
                                        {
                                            Placering[x + (c * 2), y + 2].Image = Properties.Resources.b;
                                            Placering[x + (c * 2), y + 2].Name = (x + (c * 2)) + " " + (y + 2) + " b";
                                            B1 = (x + (c * 2)) + " " + (y + 2);
                                            k2 = (x + c) + " " + (y + 1) + " " + Placering[x + c, y + 1].Name.Split(' ')[2];
                                        }

                                    }
                                }
                                catch { }
                                // Gentager for venstre bevægelse
                                try
                                {
                                    if (Placering[x + c, y - 1].Image == null)
                                    {
                                        Placering[x + c, y - 1].Image = Properties.Resources.b;
                                        Placering[x + c, y - 1].Name = (x + c) + " " + (y - 1) + " b";
                                        B2 = (x + c) + " " + (y - 1);
                                    }
                                    else
                                        if (Placering[x + c, y - 1].Name.Split(' ')[2] != p.Name.Split(' ')[2] && Placering[x + (c * 2), y - 2].Image == null)
                                    {
                                        Placering[x + (c * 2), y - 2].Image = Properties.Resources.b;
                                        Placering[x + (c * 2), y - 2].Name = (x + (c * 2)) + " " + (y - 2) + " b";
                                        B2 = (x + (c * 2)) + " " + (y - 2);
                                        k2 = (x + c) + " " + (y - 1) + " " + Placering[x + c, y - 1].Name.Split(' ')[2];
                                    }
                                }
                                catch { }
                            }

                        }
                    };

                    G.Controls.Add(Placering[i, j]); // Tilføjer PictureBox til formen
                }
                top += 60; // Flytter top til næste række

            }
        }


        // Fjerner midlertidige træk
        private void valgfjerner()
        {
            if (B1 != "")
            {
                int x, y;
                x = Convert.ToInt32(B1.Split(' ')[0]);
                y = Convert.ToInt32(B1.Split(' ')[1]);
                Placering[x, y].Image = null;
            }
            if (B2 != "")
            {
                int x, y;
                x = Convert.ToInt32(B2.Split(' ')[0]);
                y = Convert.ToInt32(B2.Split(' ')[1]);
                Placering[x, y].Image = null;
            }
        }
        // Nulstiller spillet til starttilstand
        public void restart()
        {
            for (int h = 0; h < 8; h++)
                for (int l = 0; l < 8; l++)
            {
                if (h < (8 / 2) - 1 && Placering[h, l].BackColor == Color.SandyBrown) 
                    {
                        Placering[h, l].Image = Properties.Resources.s;
                        Placering[h, l].Name = h +"  "+ l + " s"; 
                    }
                else if (h > (8 / 2) && Placering[h, l].BackColor == Color.SandyBrown)
                {
                    Placering[h, l].Image = Properties.Resources.W;
                    Placering[h, l].Name = h + "  " + l + " W";
                }
                if (h == ((8 / 2) - 1) || h == (8 / 2))
                    {
                        Placering[h, l].Image = null;
                    }
                   
            }
            label1taget.Text = "Taget brikker; 0";
            label2taget.Text = "Taget brikker; 0";
            player1 = 0;
            player2 = 0;
            
        }
        // Tjekker om en spiller har vundet spillet
        private void winner()
        {
            if (player1 == 12)
            {
                groupBox1.Visible = true;
                label3.Text = textBox1.Text + " Vandt!";
            }
            else if ( player2 == 12)
            {
                groupBox1.Visible = true;
                label3.Text = textBox2.Text + " Vandt!";
            }
        }
        // Event for start- og quit-knapper
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Event for genstartsknap, der kalder restart-metoden
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            restart();
        }

        private void MenuQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
