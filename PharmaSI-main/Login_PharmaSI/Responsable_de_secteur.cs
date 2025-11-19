using System;
using System.Linq;
using System.Windows.Forms;

namespace Login_PharmaSI
{
    public partial class Responsable_de_secteur : Form
    {
        private readonly string _prenom;
        private readonly string _nom;
        private readonly string _poste;

        public Responsable_de_secteur()
        {
            InitializeComponent();
        }

        // Nouveau constructeur : on reçoit prénom + nom + poste
        public Responsable_de_secteur(string prenom, string nom, string poste) : this()
        {
            _prenom = prenom;
            _nom    = nom;
            _poste  = poste;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyUserContext();
            WireLogout();
        }

        private void WireLogout()
        {
            // Si pbDeconnexion n'existe pas dans le designer, ce code ne casse pas
            var ctrl = Controls.Find("pbDeconnexion", true).FirstOrDefault();
            if (ctrl is PictureBox pb)
            {
                pb.Click -= pbDeconnexion_Click;
                pb.Click += pbDeconnexion_Click;
                pb.Cursor = Cursors.Hand;
                pb.TabStop = false;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void pbDeconnexion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyUserContext()
        {
            string fullName = BuildFullName(_prenom, _nom);
            if (string.IsNullOrWhiteSpace(fullName)) return;

            // Titre de la fenêtre
            this.Text = $"Espace Responsable de secteur — {fullName} ({_poste})";

            // Label(s) standards si présents dans le form
            TrySetLabelText("labelBienvenue", $"Bienvenue {fullName}");
            TrySetLabelText("labelUser", fullName);
            TrySetLabelText("labelPoste", _poste);

            // Votre label "Bonjour ..." (souvent nommé label10 dans votre projet)
            TrySetLabelText("label10", $"Bonjour {fullName}");

            // Filet de sécurité : si un label existant commence par "Bonjour", on le remplace
            var lblBonjour = Controls
                .OfType<Label>()
                .FirstOrDefault(l => (l.Text ?? string.Empty).TrimStart().StartsWith("Bonjour"));
            if (lblBonjour != null) lblBonjour.Text = $"Bonjour {fullName}";
        }

        private static string BuildFullName(string prenom, string nom)
        {
            prenom = (prenom ?? "").Trim();
            nom    = (nom ?? "").Trim();
            if (prenom.Length == 0 && nom.Length == 0) return string.Empty;
            if (prenom.Length == 0) return nom;
            if (nom.Length == 0) return prenom;
            return $"{prenom} {nom}";
        }

        private void TrySetLabelText(string name, string value)
        {
            var lbl = Controls.Find(name, true).FirstOrDefault() as Label;
            if (lbl != null) lbl.Text = value;
        }

        // Handlers générés par le designer (laisse-les si VS les a créés)
        private void label1_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void pbDeconnexion_Click_1(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void pictureBox8_Click(object sender, EventArgs e) { }
        private void pictureBox7_Click(object sender, EventArgs e) { }
        private void pictureBox6_Click(object sender, EventArgs e) { }
        private void pictureBox5_Click(object sender, EventArgs e) { }
        private void pictureBox4_Click(object sender, EventArgs e) { }
        private void pictureBox3_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
    }
}
