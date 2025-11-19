using System;
using System.Linq;
using System.Windows.Forms;

namespace Login_PharmaSI
{
    public partial class page_delegue_regional : Form
    {
        private readonly string _prenom;
        private readonly string _nom;
        private readonly string _poste;

        public page_delegue_regional()
        {
            InitializeComponent();
            // IMPORTANT (Option B) : ne pas compter sur les événements du Designer
            WireLogout();
        }

        public page_delegue_regional(string prenom, string nom, string poste) : this()
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
            // Cherche pbDeconnexion, sinon un fallback par nom d'image si besoin
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

            // Titre de la fenêtre
            this.Text = $"Espace Délégué régional — {fullName} ({_poste})";

            // Label “Bonjour …” : dans ton designer, c’est label10
            TrySetLabelText("label10", $"Bonjour {fullName}");

            // Labels contextuels (si présents)
            TrySetLabelText("labelBienvenue", $"Bienvenue {fullName}");
            TrySetLabelText("labelUser", fullName);
            TrySetLabelText("labelPoste", _poste);
        }

        private void TrySetLabelText(string name, string value)
        {
            var lbl = Controls.Find(name, true).FirstOrDefault() as Label;
            if (lbl != null) lbl.Text = value;
        }

        // Handlers générés par le designer peuvent rester vides si tu en as :
        private void label10_Click(object sender, EventArgs e) { }
    }
}
