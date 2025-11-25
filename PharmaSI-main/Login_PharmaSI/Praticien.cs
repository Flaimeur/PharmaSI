using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_PharmaSI
{
    public partial class Praticien : Form
    {
        public Praticien()
        {
            InitializeComponent();
            WireLogout();
        }

        private void GenericLogout_Click(object sender, EventArgs e) => this.Close();
        private void WireLogout()
        {
            
            var pb = this.Controls.Find("pbDeconnexion", true).OfType<PictureBox>().FirstOrDefault()
                  ?? this.Controls.Find("pictureBox9", true).OfType<PictureBox>().FirstOrDefault();

            if (pb != null) 
            {
                pb.Cursor = Cursors.Hand; 

                pb.Click += GenericLogout_Click;
            }
        }

        private void Praticien_Load(object sender, EventArgs e)
        {

        }

        private void pbDeconnexion_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
