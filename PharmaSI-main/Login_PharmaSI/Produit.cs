using System;
using System.Collections.Generic;
using System.Drawing; // Nécessaire pour les polices/couleurs
using System.Linq;
using System.Windows.Forms;

namespace Login_PharmaSI
{
    public partial class Produit : Form
    {
        public Produit()
        {
            InitializeComponent();
            WireLogout();
            WireHome();
        }

        // --- VOS FONCTIONS DE NAVIGATION (GARDER TEL QUEL) ---
        private void GenericLogout_Click(object sender, EventArgs e) => this.Close();

        private void WireLogout()
        {
            var pb = this.Controls.Find("pbDeconnexion", true).OfType<PictureBox>().FirstOrDefault();
            if (pb != null) { pb.Cursor = Cursors.Hand; pb.Click += GenericLogout_Click; }
        }

        private void WireHome()
        {
            var pb = this.Controls.Find("pictureBox8", true).OfType<PictureBox>().FirstOrDefault();
            if (pb != null) { pb.Cursor = Cursors.Hand; pb.Click += pictureBox8_Click; }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            // (Votre logique de retour ici... je la raccourcis pour la lisibilité)
            // Si vous avez votre code de retour, gardez-le ici !
            this.Close();
        }

        private void praticienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Praticien laPage = new Praticien(); laPage.Show(); this.Hide(); laPage.FormClosed += (s, args) => this.Close();
        }
        private void produitToolStripMenuItem_Click(object sender, EventArgs e) { }

        // ---------------------------------------------------------
        // --- C'EST ICI QUE CA CHANGE POUR LE TABLEAU ---
        // ---------------------------------------------------------

        private void Praticien_Load(object sender, EventArgs e)
        {
            RemplirComboProduits();
            Configurertableau(); // On lance la configuration du design du tableau
        }

        private void Configurertableau()
        {
            // 1. Options de base pour que ce soit joli
            dgvFiche.RowHeadersVisible = false; // Cache la colonne grise à gauche
            dgvFiche.AllowUserToAddRows = false; // Empêche la ligne vide à la fin
            dgvFiche.ReadOnly = true; // Empêche l'utilisateur de modifier
            dgvFiche.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Hauteur auto pour le texte long
            dgvFiche.BackgroundColor = Color.White; // Fond blanc
            dgvFiche.BorderStyle = BorderStyle.None;

            // 2. Création des 2 colonnes
            dgvFiche.Columns.Clear();

            // Colonne 1 : Le Titre (ex: "Prix")
            dgvFiche.Columns.Add("Titre", "Information");
            dgvFiche.Columns[0].Width = 150; // Largeur fixe
            dgvFiche.Columns[0].DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Gras

            // Colonne 2 : La Valeur (ex: "12.50 €")
            dgvFiche.Columns.Add("Valeur", "Détail");
            dgvFiche.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Prend tout le reste de la place
            dgvFiche.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Retour à la ligne automatique !
            dgvFiche.Columns[1].DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
        }

        private void RemplirComboProduits()
        {
            try
            {
                List<C_Produit> mesProduits = C_Produit.GetListeProduits();
                comboBox1.DataSource = mesProduits;
                comboBox1.DisplayMember = "NomCommercial";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedValue == null) return;

            int id;
            if (int.TryParse(comboBox1.SelectedValue.ToString(), out id))
            {
                C_Produit p = C_Produit.GetProduitById(id);

                if (p != null)
                {
                    // ON REMPLIT LE TABLEAU
                    dgvFiche.Rows.Clear(); // On vide l'ancien affichage

                    // On ajoute les lignes une par une
                    dgvFiche.Rows.Add("Nom Commercial", p.NomCommercial);

                    // Si on n'a pas la famille (suite à l'erreur précédente), on met "Non spécifiée"
                    string laFamille = string.IsNullOrEmpty(p.NomFamille) ? "Non spécifiée" : p.NomFamille;
                    dgvFiche.Rows.Add("Famille", laFamille);

                    dgvFiche.Rows.Add("Prix Échantillon", p.Prix.ToString("0.00") + " €");

                    dgvFiche.Rows.Add("Effets", p.Effets);
                    dgvFiche.Rows.Add("Contre-Indications", p.ContreIndications);
                    dgvFiche.Rows.Add("Interactions", p.Interactions);

                    // On ajoute une ligne vide pour espacer
                    dgvFiche.Rows.Add("", "");

                    dgvFiche.Rows.Add("COMPOSITION", p.LesComposants);

                    // Petite astuce : Mettre la ligne "COMPOSITION" en couleur différente
                    int lastRow = dgvFiche.Rows.Count - 1;
                    dgvFiche.Rows[lastRow].DefaultCellStyle.BackColor = Color.LightGray;
                    dgvFiche.Rows[lastRow].DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
                }
            }
        }

        // (Laissez vos autres méthodes vides ici...)
        private void label10_Click(object sender, EventArgs e) { }
        private void consultationToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void saisieToolStripMenuItem_Click(object sender, EventArgs e) { }
    }
}