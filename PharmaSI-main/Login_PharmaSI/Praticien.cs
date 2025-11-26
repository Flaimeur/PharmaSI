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
            WireHome();
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

        private void WireHome()
        {
            var pb = this.Controls.Find("Homme", true).OfType<PictureBox>().FirstOrDefault()
                  ?? this.Controls.Find("pictureBox8", true).OfType<PictureBox>().FirstOrDefault();

            if (pb != null)
            {
                pb.Cursor = Cursors.Hand;
                pb.Click -= pictureBox8_Click;
                pb.Click += pictureBox8_Click;
            }
        }

        

        private void RemplirComboPraticiens()
        {
            try
            {
                List<C_Praticien> mesDocteurs = C_Praticien.GetListePraticiens();
                comboBox1.DataSource = mesDocteurs;

                comboBox1.DisplayMember = "NomComplet";

                comboBox1.ValueMember = "Id";

                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void Praticien_Load(object sender, EventArgs e)
        {
            RemplirComboPraticiens();

            label2.BringToFront();
            label3.BringToFront();
            label4.BringToFront();
            label5.BringToFront();
            label6.BringToFront();
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
            // secu pour eviter les bug d'affichage si la liste est vide ou il y r sélectionné on fait r
            if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedValue == null) return;

            // 2.Récup l'ID
            int idSelectionne;
            bool estUnChiffre = int.TryParse(comboBox1.SelectedValue.ToString(), out idSelectionne);

            if (estUnChiffre == false) return;

            //Appel de la classe
            C_Praticien monPraticien = C_Praticien.GetPraticienById(idSelectionne);

            // 4. AFFICHAGE
            if (monPraticien != null)
            {
                // Label 2 : NOM Prénom 
                label2.Text = monPraticien.Nom.ToUpper() + " " + monPraticien.Prenom;
                // Label 3 : Adresse complète 
                label3.Text = monPraticien.Adresse + "\n" +
                              monPraticien.CodePostal + " " + monPraticien.Ville;
                // Label 4 : Nom du diplôme 
                label4.Text = monPraticien.NomDiplome;
                // Label 6 : Spécialité 
                label6.Text = monPraticien.NomSpecialite;
                // Label 5 : La note 
                label5.Text = monPraticien.CoefNotoriete + " / 20";
            }
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
            this.Hide();

            string monPoste = Session.Poste.ToLower();
            Form pageRetour = null;

            if (monPoste.Contains("visiteur"))
            {
                pageRetour = new page_visiteur();
            }
            else if (monPoste.Contains("responsable"))
            {
                pageRetour = new Responsable_de_secteur();
            }
            else if (monPoste.Contains("delegue"))
            {
                pageRetour = new page_delegue_regional();
            }

            if (pageRetour != null)
            {
                pageRetour.Show();
                pageRetour.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Erreur : Poste non reconnu (" + Session.Poste + ")");
                this.Show();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void praticienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Praticien laPage = new Praticien();

            laPage.Show();

            this.Hide();

            laPage.FormClosed += (s, args) => this.Close();
        }
    }
}
