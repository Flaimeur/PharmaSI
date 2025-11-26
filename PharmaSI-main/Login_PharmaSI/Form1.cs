using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login_PharmaSI
{
    public partial class Form1 : Form
    {
        // ===== Connexion MySQL (J'ai gardé ton code tel quel) =====
        private const string Host = "127.0.0.1";
        private const uint Port = 3306;
        private const string Db = "pharmasi";
        private const string Uid = "root";
        private const string Pwd = "";

        private static string ConnString =>
            $"Server={Host};Port={Port};Database={Db};Uid={Uid};Pwd={Pwd};SslMode=None;CharSet=utf8mb4;";
        // ===========================

        public Form1()
        {
            InitializeComponent();

            if (LoginMotDePasse != null) LoginMotDePasse.UseSystemPasswordChar = true;
            if (ButtonConnexion != null) this.AcceptButton = ButtonConnexion;

            if (ButtonConnexion != null)
            {
                ButtonConnexion.Click -= ButtonConnexion_Click;
                ButtonConnexion.Click += ButtonConnexion_Click;
            }
        }

        private void ButtonConnexion_Click(object sender, EventArgs e)
        {
            string login = LoginIdentifiant.Text.Trim();
            string mdp = LoginMotDePasse.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrEmpty(mdp))
            {
                MessageBox.Show("Identifiant et mot de passe sont requis.");
                return;
            }

            try
            {
                using (var cn = new MySqlConnection(ConnString))
                using (var cmd = cn.CreateCommand())
                {
                    // MODIF 1 : J'ai ajouté "id" dans le SELECT
                    cmd.CommandText = @"
                        SELECT id, prenom, nom, poste 
                        FROM employe
                        WHERE mail = @login AND mdp = @mdp
                        LIMIT 1;";

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@mdp", mdp);

                    cn.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                        {
                            MessageBox.Show("Erreur login/mot de passe. Connexion impossible.");
                            return;
                        }

                        // MODIF 2 : On récupère l'ID
                        int id = Convert.ToInt32(r["id"]);
                        string prenom = Convert.ToString(r["prenom"]);
                        string nom = Convert.ToString(r["nom"]);
                        string poste = Convert.ToString(r["poste"]);
                        string p = Normalize(poste);

                        // MODIF 3 : On remplit le coffre-fort (Session)
                        Session.Stocker(id, nom, prenom, poste);

                        // --- Le reste de ton code ne change pas ---
                        // On continue d'utiliser tes constructeurs avec paramètres pour ne rien casser
                        if (p.Contains("visiteur"))
                        {
                            GoTo(new page_visiteur(prenom, nom, poste));
                            return;
                        }
                        if (p.Contains("responsable") && p.Contains("secteur"))
                        {
                            GoTo(new Responsable_de_secteur(prenom, nom, poste));
                            return;
                        }
                        if (p.Contains("delegue") && p.Contains("regional"))
                        {
                            GoTo(new page_delegue_regional(prenom, nom, poste));
                            return;
                        }

                        string nomAffiche = string.IsNullOrWhiteSpace(prenom) ? "Utilisateur" : $"{prenom} {nom}".Trim();
                        MessageBox.Show($"Bonjour {nomAffiche}, vous êtes {poste} et ne pouvez vous connecter.");
                        return;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erreur MySQL : {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion : " + ex.Message);
            }
        }

        private void GoTo(Form next)
        {
            this.Hide();
            next.StartPosition = FormStartPosition.CenterScreen;

            next.FormClosed += (_, __) =>
            {
                // MODIF 4 : On vide la session quand on se déconnecte
                Session.Vider();

                try { LoginIdentifiant?.Clear(); } catch { }
                try { LoginMotDePasse?.Clear(); } catch { }
                if (LoginMotDePasse != null) LoginMotDePasse.UseSystemPasswordChar = true;

                this.Show();
                this.Activate();
                LoginIdentifiant?.Focus();
            };

            next.Show();
        }

        private static string Normalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            string formD = input.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(formD.Length);
            foreach (char ch in formD)
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void pictureBox3_Click(object sender, EventArgs e) { }
        private void pictureBox4_Click(object sender, EventArgs e) { }
        private void LoginIdentifiant_TextChanged(object sender, EventArgs e) { }
    }
}