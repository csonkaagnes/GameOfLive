using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Életjáték
{


    public partial class Form1 : Form
    {


        bool[,] pálya = new bool[n, m];
        bool[,] újPálya = new bool[n, m];

        int sejtszám = 80;

        Random rnd = new Random();
         static int n = 100;
         static int m = 100;

        public Form1()
        {
            InitializeComponent();
            Form2 f2 = new Form2();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                
                try
                {
                    n = int.Parse(f2.textBox1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hibás a szélesség paraméter");
                    Form1 f1 = new Form1();
                    return;
                }
                try
                {
                    m = int.Parse(f2.textBox2.Text);
                }

                catch (Exception)
                {
                    MessageBox.Show("Hibás a magasság paraméter");
                    Form1 f1 = new Form1();
                    return;
                }
                try
                {
                    sejtszám = int.Parse(f2.textBox3.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hibás a sejtszám paraméter");
                    Form1 f1 = new Form1();
                    return;
                }

            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Height = m * Kocka.méret + 50;
                Width = n * Kocka.méret + 50;

                for (int i = 0; i < sejtszám; i++)
                {
                    Kocka k = new Kocka();
                    int x = rnd.Next(n);
                    int y = rnd.Next(m);
                    k.Top = k.Height * y;
                    k.Left = k.Width * x;
                    pálya[x, y] = true;
                    Controls.Add(k);


                }
                Timer timer = new Timer();
                timer.Interval = 500;
                timer.Start();
                timer.Tick += Timer_Tick;


                for (int sor = 0; sor < n; sor++)
                {
                    for (int oszlop = 0; oszlop < m; oszlop++)
                    {
                        if (pálya[sor, oszlop] == true)
                        {
                            Kocka k = new Kocka();
                            k.Top = k.Height * oszlop;
                            k.Left = k.Width * sor;
                            Controls.Add(k);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("A program nem futattható le");
                Form1 f1 = new Form1();
                return;
            }
            
                
            
            
        }
           

        private void Timer_Tick(object sender, EventArgs e)
        {

            int mezőÉrtéke(int sor, int oszlop, bool[,] p)
            {
                if (sor >= p.GetUpperBound(0)) return 0;
                if (oszlop >= p.GetUpperBound(1)) return 0;
                if (sor < 0 || oszlop < 0) return 0;
                return (p[sor, oszlop] ? 1 : 0);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    int szomszéd = 0;


                    szomszéd += mezőÉrtéke(i, j - 1, pálya);
                    szomszéd += mezőÉrtéke(i, j + 1, pálya);
                    szomszéd += mezőÉrtéke(i - 1, j - 1, pálya);
                    szomszéd += mezőÉrtéke(i - 1, j + 1, pálya);
                    szomszéd += mezőÉrtéke(i - 1, j, pálya);
                    szomszéd += mezőÉrtéke(i + 1, j - 1, pálya);
                    szomszéd += mezőÉrtéke(i + 1, j + 1, pálya);
                    szomszéd += mezőÉrtéke(i + 1, j, pálya);



                    int érték = mezőÉrtéke(i, j, pálya);


                    if (érték == 0 && szomszéd == 3)
                    {
                        érték = 1;
                    }
                    else if (érték == 1 && (szomszéd < 2 || szomszéd > 3))
                    {
                        érték = 0;
                    }

                    újPálya[i, j] = (érték == 0 ? false : true);
                }
            }

            Controls.Clear();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    pálya[i, j] = újPálya[i, j];
                    if (újPálya[i, j])
                    {
                        Kocka k = new Kocka();
                        k.Top = k.Height * j;
                        k.Left = k.Width * i;
                        Controls.Add(k);
                    }
                }

            }

        }
    }






}

