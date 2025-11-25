using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Login_PharmaSI
{
    public class C_Praticien
    {
        //PROPRIÉTÉS
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public double CoefNotoriete { get; set; }
        //stocke txt 
        public string NomDiplome { get; set; }
        public string NomSpecialite { get; set; }

        public string NomComplet
        {
            get { return this.Nom.ToUpper() + " " + this.Prenom; }
        }

        public static C_Praticien GetPraticienById(int idCherche)
        {
            C_Praticien lePraticien = null;

            string connectionString = "server=localhost;user=root;password=;database=PharmaSI";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Requête 
                    string query = @"
                        SELECT 
                            p.nom, p.prenom, p.adresse, p.code_postal, p.ville, p.coefficient_notoriete,
                            d.libelle AS nom_diplome, 
                            s.nom AS nom_specialite
                        FROM praticien p
                        INNER JOIN diplomes d ON p.iddiplome = d.idDiplome
                        INNER JOIN specialite s ON p.idspecialite = s.idSpecialite
                        WHERE p.idpraticien = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idCherche);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Remplit l'objet avec les données 
                            lePraticien = new C_Praticien();

                            lePraticien.Id = idCherche;
                            lePraticien.Nom = reader["nom"].ToString();
                            lePraticien.Prenom = reader["prenom"].ToString();
                            lePraticien.Adresse = reader["adresse"].ToString();
                            lePraticien.CodePostal = reader["code_postal"].ToString();
                            lePraticien.Ville = reader["ville"].ToString();

                            lePraticien.CoefNotoriete = Convert.ToDouble(reader["coefficient_notoriete"]);

                            lePraticien.NomDiplome = reader["nom_diplome"].ToString();
                            lePraticien.NomSpecialite = reader["nom_specialite"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Si erreu loguer ou renvoyer null
                    System.Windows.Forms.MessageBox.Show("Erreur BDD : " + ex.Message);
                }
            }

            return lePraticien; 
        }
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
                    System.Windows.Forms.MessageBox.Show("Erreur BDD (GetListe) : " + ex.Message);
                }
            }
            return laListe;
        }
    }


}