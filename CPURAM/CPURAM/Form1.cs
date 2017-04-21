using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using dll;


namespace CPURAM
{
   

    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        bdd_connect bddObjectCnx = new bdd_connect();

        public Form1()
        {
            InitializeComponent();
            
        }

        ~Form1()
        {
            this.bddObjectCnx.add_log("closed");
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            float ftotalRAM = totalRAM.NextValue();
            float fcpu = pCPU.NextValue();

            if (ftotalRAM < 300)
            {
                this.bddObjectCnx.add_log("Failed to launch due to bad performances");

                string message = "There is not enough memory to start the hologram. Please close other programs and click on the button below to try again";
                string title = "RedX Program"
                    ;
                MessageBoxButtons buttons = MessageBoxButtons.AbortRetryIgnore;

                DialogResult result = MessageBox.Show(message, title, buttons,  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Abort)
                {
                    System.Windows.Forms.Application.Exit();
                }
                else if (result == DialogResult.Retry)
                {
                    System.Windows.Forms.Application.Exit();
                    System.Diagnostics.Process.Start(@"C:\Users\Nathanael Anstett\Documents\Visual Studio 2015\Projects\CPURAM\CPURAM\bin\Debug\CPURAM.exe");
                }
                else
                {
                    // Do something
                }

            }
            else
            {
                Thread ThreadHologram;

                ThreadHologram = new Thread(new ThreadStart(hologram));
                
                timer.Start();
                ThreadHologram.Start();  
            }
        }

        private void hologram()
        {
            // Thread that lunch the hologram
            System.Diagnostics.Process.Start(@"C:\Users\Nathanael Anstett\Documents\Redx.exe");
            this.bddObjectCnx.add_log("Redx has been launched successfully !");

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            float fcpu = pCPU.NextValue();
            float fram = pRAM.NextValue();
            metroProgressBarCPU.Value = (int)fcpu;
            metroProgressBarRAM.Value = (int)fram;
            lblCPU.Text = String.Format("{0:0.00}%", fcpu);
            lblRAM.Text = String.Format("{0:0.00}%", fram);

            this.bddObjectCnx.add_log("Processor : "+String.Format("{0:0.00}%", fcpu)+" -- Ram :" +String.Format("{0:0.00}%", fram));
            

        }
    }
}
