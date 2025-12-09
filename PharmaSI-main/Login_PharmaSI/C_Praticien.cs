using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Login_PharmaSI
{
    public class C_Praticien
    {
        // --- PROPRIÉTÉS ---
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public double CoefNotoriete { get; set; }
        public string NomDiplome { get; set; }
        public int CoefPrescription { get; set; } // Ajout pour la règle 4
        public string NomSpecialite { get; set; }
        public string TypePraticien { get; set; } // Ajout pour gérer le type

        // Propriété calculée pratique pour l'affichage
        public string NomComplet
        {
            get { return this.Nom.ToUpper() + " " + this.Prenom; }
        }

        // --- MÉTHODES ---
        public static C_Praticien GetPraticienById(int idCherche)
        {
            C_Praticien lePraticien = null;
            string connectionString = "server=localhost;user=root;password=;database=PharmaSI";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // REQUÊTE INTELLIGENTE :
                    // 1. On récupère le coeff de prescription (manquant avant).
                    // 2. On utilise GROUP_CONCAT pour mettre tous les types (ex: "Libéral, Hospitalier") dans une seule case.
                    string query = @"
                        SELECT 
                            p.nom, p.prenom, p.adresse, p.code_postal, p.ville, p.coefficient_notoriete,
                            d.libelle AS nom_diplome, 
                            d.coefficient_prescription,
                            s.nom AS nom_specialite,
                            GROUP_CONCAT(t.libelle SEPARATOR ', ') AS types_praticien
                        FROM praticien p
                        INNER JOIN diplomes d ON p.iddiplome = d.idDiplome
                        INNER JOIN specialite s ON p.idspecialite = s.idSpecialite
                        INNER JOIN exercer e ON p.idpraticien = e.idPraticien
                        INNER JOIN type t ON e.idtype = t.idType
                        WHERE p.idpraticien = @id
                        GROUP BY p.idpraticien";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idCherche);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lePraticien = new C_Praticien();
                            lePraticien.Id = idCherche;
                            lePraticien.Nom = reader["nom"].ToString();
                            lePraticien.Prenom = reader["prenom"].ToString();
                            lePraticien.Adresse = reader["adresse"].ToString();
                            lePraticien.CodePostal = reader["code_postal"].ToString();
                            lePraticien.Ville = reader["ville"].ToString();
                            lePraticien.CoefNotoriete = Convert.ToDouble(reader["coefficient_notoriete"]);

                            lePraticien.NomDiplome = reader["nom_diplome"].ToString();
                            lePraticien.CoefPrescription = Convert.ToInt32(reader["coefficient_prescription"]); // Nouveau

                            lePraticien.NomSpecialite = reader["nom_specialite"].ToString();
                            lePraticien.TypePraticien = reader["types_praticien"].ToString(); // Le résultat du Group_Concat
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Erreur BDD : " + ex.Message);
                }
            }
            return lePraticien;
        }

        // Ta méthode pour la liste (je la laisse telle quelle, elle est bonne pour la ComboBox)
        public static List<C_Praticien> GetListePraticiens()
        {
            List<C_Praticien> laListe = new List<C_Praticien>();
            string connectionString = "server=localhost;user=root;password=;database=PharmaSI";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idpraticien, nom, prenom FROM praticien";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            C_Praticien p = new C_Praticien();
                            p.Id = Convert.ToInt32(reader["idpraticien"]);
                            p.Nom = reader["nom"].ToString();
                            p.Prenom = reader["prenom"].ToString();
                            laListe.Add(p);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Erreur BDD (Liste) : " + ex.Message);
                }
            }
            return laListe;
        }
    }
}