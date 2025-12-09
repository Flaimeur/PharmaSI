using System;
using System.Linq;
using System.Windows.Forms;

namespace Login_PharmaSI
{
    public partial class page_visiteur : Form
    {
        private readonly string _prenom;
        private readonly string _nom;
        private readonly string _poste;

        public page_visiteur()
        {
            InitializeComponent();
            WireLogout();   // câblage propre
        }

        public page_visiteur(string prenom, string nom, string poste) : this()
        {
            _prenom = prenom;
            _nom = nom;
            _poste = poste;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyUserContext();
        }

        private void WireLogout()
        {
            var pb = this.Controls.Find("pbDeconnexion", true).OfType<PictureBox>().FirstOrDefault()
                     ?? this.Controls.Find("pictureBox9", true).OfType<PictureBox>().FirstOrDefault();

            if (pb != null)
            {
                pb.Cursor = Cursors.Hand;
                pb.TabStop = false;
                pb.SizeMode = PictureBoxSizeMode.Zoom;

                pb.Click -= GenericLogout_Click;
                pb.Click += GenericLogout_Click;
            }
        }

        private void GenericLogout_Click(object sender, EventArgs e) => this.Close();

        private void ApplyUserContext()
        {
            string fullName = $"{_prenom} {_nom}".Trim();
            if (string.IsNullOrWhiteSpace(fullName)) return;

            this.Text = $"Espace Visiteur — {fullName} ({_poste})";

            // Dans cette page aussi, ton label “Bonjour …” est label10
            TrySetLabelText("label10", $"Bonjour {fullName}");

            TrySetLabelText("labelBienvenue", $"Bienvenue {fullName}");
            TrySetLabelText("labelUser", fullName);
            TrySetLabelText("labelPoste", _poste);
        }

        private void TrySetLabelText(string name, string value)
        {
            var lbl = Controls.Find(name, true).FirstOrDefault() as Label;
            if (lbl != null) lbl.Text = value;
        }

        // Handlers auto-générés éventuellement vides
        private void label10_Click(object sender, EventArgs e) { }

        //switch de page
        private void praticienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Praticien laPage = new Praticien();

            laPage.Show();

            this.Hide();

            laPage.FormClosed += (s, args) => this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pbDeconnexion_Click(object sender, EventArgs e)
        {

        }

        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produit laPage = new Produit();

            laPage.Show();

            this.Hide();

            laPage.FormClosed += (s, args) => this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void consultationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
