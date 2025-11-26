using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_PharmaSI
{
    public static class Session
    {
        // Les variables accessibles de n'importe où
        public static int Id;
        public static string Nom;
        public static string Prenom;
        public static string Poste;

        // Fonction pour remplir le coffre (à appeler au login)
        public static void Stocker(int id, string nom, string prenom, string poste)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Poste = poste;
        }

        // Fonction pour vider le coffre (à la déconnexion)
        public static void Vider()
        {
            Id = 0;
            Nom = "";
            Prenom = "";
            Poste = "";
        }
    }
}
