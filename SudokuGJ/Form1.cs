using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SudokuGJ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(102, 47, 10);
            label1.Text = "SOKOBAN";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ime = textBox1.Text;

            Board boardForm = new Board(ime, 0, 0, 0);
            boardForm.Size = new Size(800, 500);
            boardForm.ShowDialog();

            /*string[] lines = System.IO.File.ReadAllLines("Writetext.txt");
            
            foreach (string line in lines)
            {

            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines("Writetext.txt");

            String s = "Top 10:\n\n";

            String []novi = new String[100];


            int t = 0;

            //foreach (string line in lines)
            for (int i= 0;i<lines.Length;i++)
            for (int j=i+1;j<lines.Length;j++)
            {
                String[] pom = lines[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                String[] pom1 = lines[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                /*t++;
                if (t<10) s += pom[0]+"\n";*/

                int r1 = 0;
                int r2 = 0;
                Int32.TryParse(pom[1], out r1);
                Int32.TryParse(pom1[1], out r2);

                if (r1 < r2)
                {
                    String pomr = lines[i];
                    lines[i] = lines[j];
                    lines[j] = pomr;
                }
            }

            for (int i = 0; i < Math.Min(10, lines.Length); i++)
            {

                String[] pom = lines[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                s += pom[0] + " - " + pom[1] + "\n";
            }
            MessageBox.Show(s);
        }
    }
}
