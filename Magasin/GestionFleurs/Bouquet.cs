using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_POO2.Magasin
{
    internal class Bouquet
    {
        public List<Fleur> Bouquets;
        public string MessagePersonnalise { get; set; }
        private static List<Bouquet> ModelesBouquets = new List<Bouquet>();

        public Bouquet()
        {
            Bouquets = new List<Fleur>();
        }

        public void CreerBouquet(Fleur fleur)
        {
            Bouquets.Add(fleur);
        }

        public decimal CalculerPrix()
        {
            decimal prixTotal = 0;
            int fraisLabeur = 2;

            int fraisCarte;      // int fraisCarte = string.IsNullOrEmpty(MessagePersonnalise) ? 0 : 1;
            if (MessagePersonnalise == null || MessagePersonnalise == "")
                fraisCarte = 0;
            else
                fraisCarte = 1;

            foreach (var fleur in Bouquets)
            {
                prixTotal += fleur.Prix;
            }

            return prixTotal + fraisLabeur + fraisCarte;
        }

        public static void EnregistrerModele(Bouquet bouquet)
        {
            ModelesBouquets.Add(bouquet);
        }

        public static void AfficherModeles()
        {
            if (ModelesBouquets.Count == 0)
            {
                Console.WriteLine("Aucun modèle de bouquet enregistré.");
            }
            else
            {
                Console.WriteLine("Modèles de bouquets enregistrés :\n");

                foreach (var bouquet in ModelesBouquets)
                {
                    Console.WriteLine($"Bouquet avec {bouquet.Bouquets.Count} fleurs");

                    // Afficher les fleurs du bouquet
                    foreach (var fleur in bouquet.Bouquets)
                    {
                        Console.WriteLine($"  - {fleur.Nom} ({fleur.Prix} $)");
                    }

                    Console.WriteLine($"Message personnalisé : {bouquet.MessagePersonnalise ?? "Aucun"}");
                    Console.WriteLine($"Prix total : {bouquet.CalculerPrix()} $");
                    Console.WriteLine("----------------------");
                }
            }
        }

    }
}
