using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int caseSwitch;
            Int32.TryParse(this.comboBox1.SelectedItem.ToString(), out caseSwitch);

            string filename = "";

            switch (caseSwitch)
            {
                case 1:
                    filename = "Coeur";
                    this.BackColor = Color.FromArgb(38, 38, 38);
                    break;
                case 2:
                    filename = "Cube";
                    this.BackColor = Color.FromArgb(38, 38, 38);
                    break;
                case 3:
                    filename = "Cercle";
                    this.BackColor = Color.FromArgb(38, 38, 38);
                    break;
                case 4:
                    filename = "Bonjour";
                    this.BackColor = Color.FromArgb(0, 0, 0);
                    break;
                default:
                    break;

            }

            this.pictureBox2.Image = Image.FromFile(@"C:\gifs\" + filename + "_0.gif", true); // haut
            this.pictureBox3.Image = Image.FromFile(@"C:\gifs\" + filename + "_180.gif", true); //bas
            this.pictureBox4.Image = Image.FromFile(@"C:\gifs\" + filename + "_90.gif", true); //droite
            this.pictureBox5.Image = Image.FromFile(@"C:\gifs\" + filename + "_270.gif", true); //gauche

        }

    }
}
