using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Login_PharmaSI
{
    public class C_Produit
    {
        public int Id { get; set; }
        public string NomCommercial { get; set; }
        public double Prix { get; set; }
        public string Effets { get; set; }
        public string ContreIndications { get; set; }
        public string Interactions { get; set; }

        public string NomFamille { get; set; }
        public string LesComposants { get; set; }

        public static C_Produit GetProduitById(int idCherche)
        {
            C_Produit leProduit = null;
            string connectionString = "server=localhost;user=root;password=;database=PharmaSI";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // --- CORRECTION : ON NE RECUPERE PLUS LA FAMILLE POUR L'INSTANT ---
                    // On sélectionne juste le produit, sans faire de JOIN risqué
                    string query = "SELECT * FROM produit WHERE idProduit = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idCherche);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            leProduit = new C_Produit();
                            leProduit.Id = Convert.ToInt32(reader["idProduit"]);
                            leProduit.NomCommercial = reader["NumeroDuProduit"].ToString();

                            if (reader["PrixEchantillon"] != DBNull.Value)
                                leProduit.Prix = Convert.ToDouble(reader["PrixEchantillon"]);

                            leProduit.Effets = reader["EffetsTherapeutiques"].ToString();
                            leProduit.ContreIndications = reader["Contre-indications"].ToString();
                            leProduit.Interactions = reader["Interactions"].ToString();

                            // On met une valeur par défaut pour ne pas laisser vide
                            leProduit.NomFamille = "Non spécifiée";
                        }
                    }

                    // --- REQUÊTE 2 : Les Composants (Ça, ça devrait marcher) ---
                    if (leProduit != null)
                    {
                        string queryCompo = @"
                            SELECT c.libelle, c.quantite
                            FROM composer lien
                            INNER JOIN composant c ON lien.idComposant = c.idComposant
                            WHERE lien.idProduit = @id";

                        MySqlCommand cmdCompo = new MySqlCommand(queryCompo, conn);
                        cmdCompo.Parameters.AddWithValue("@id", idCherche);

                        using (MySqlDataReader readerCompo = cmdCompo.ExecuteReader())
                        {
                            string listeTxt = "";
                            while (readerCompo.Read())
                            {
                                string nomC = readerCompo["libelle"].ToString();
                                string qteC = readerCompo["quantite"].ToString();
                                listeTxt += "- " + nomC + " (" + qteC + " mg)\n";
                            }

                            if (string.IsNullOrEmpty(listeTxt))
                                leProduit.LesComposants = "Aucun composant listé";
                            else
                                leProduit.LesComposants = listeTxt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Erreur BDD : " + ex.Message);
                }
            }
            return leProduit;
        }

        public static List<C_Produit> GetListeProduits()
        {
            List<C_Produit> laListe = new List<C_Produit>();
            string connectionString = "server=localhost;user=root;password=;database=PharmaSI";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idProduit, NumeroDuProduit FROM produit ORDER BY NumeroDuProduit";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            C_Produit p = new C_Produit();
                            p.Id = Convert.ToInt32(reader["idProduit"]);
                            p.NomCommercial = reader["NumeroDuProduit"].ToString();
                            laListe.Add(p);
                        }
                    }
                }
                catch (Exception ex) { }
            }
            return laListe;
        }
    }
}