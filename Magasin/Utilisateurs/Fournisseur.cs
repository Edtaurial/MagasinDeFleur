using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_POO2.Magasin
{
    internal class Fournisseur: Utilisateur
    {
        public static List<Fleur> fleurs = new List<Fleur>();
        public Fournisseur(string nom, string courriel, string grade) : base(nom, courriel, grade) { }

        public override void AfficherInfo()
        {
            Console.WriteLine($"Nom: {nom} | Courriel: {courriel} | Grade: {grade}");
        }

        public static List<Fleur> ApprovisionnerEnFleur(string cheminFichier)
        {

            // Lire toutes les lignes du fichier
            string[] lignes = File.ReadAllLines("Fleurs_db/fleurs_db.csv");

            // Configuration culturelle pour les nombres
            CultureInfo culture = CultureInfo.InvariantCulture; // Pour les points décimaux

            // On saute la première ligne (en-têtes)
            for (int i = 1; i < lignes.Length; i++)
            {
                string[] colonnes = lignes[i].Split(',');

                try
                {
                    Fleur fleur = new Fleur
                    {
                        Nom = colonnes[0],
                        Prix = decimal.Parse(colonnes[1], culture), // Utilise la culture
                        Couleur = colonnes[2],
                        Caracteristiques = colonnes[3]
                    };
                    fleurs.Add(fleur);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur ligne {i + 1}: {ex.Message}");
                }
            }

            return fleurs;
        }

        public static Fleur TrouverFleur(List<Fleur> fleurs, string nom)
        {
            foreach (Fleur fleur in fleurs)
            {
                if (fleur.Nom == nom)
                    return fleur;
            }
            return null; // Si non trouvée
        }
    }
}
