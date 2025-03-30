using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_POO2.Magasin
{
    internal class Commande
    {
        public int Id { get; set; }
        public static List<Commande> Commandes;
        public Client client { get; set; }
        public Utilisateur vendeur { get; set; }
        public List<Fleur> fleurs { get; set; }
        public List<Bouquet> Bouquets { get; set; }
        public DateTime date;
        public StatutCommande statut;
        public MoyenPaiement moyenPaiement;

        public Commande(int Id, Client client)
        {
            this.Id = Id;
            this.client = client;
            fleurs= new List<Fleur>();
            Bouquets = new List<Bouquet>();
            Commandes = new List<Commande>();
            date = DateTime.Now;
            statut = StatutCommande.EnAttente;
        }

        public decimal CalculerMontantTotal()
        {
            decimal prixFleur = 0;
            foreach (Fleur fleur in fleurs)
            {
                prixFleur += fleur.Prix;
            }

            decimal prixBouquet = 0;
            foreach (var bouquet in Bouquets)
            {
                prixBouquet += bouquet.CalculerPrix();
            }
            return prixFleur + prixBouquet;


        }

        public enum StatutCommande
        {
            EnAttente,
            EnTraitement,
            Traitee,
            Annulee
        }
        public enum MoyenPaiement
        {
            Debit,
            Credit,
            Espece
        }



        



        public void AfficherCommande()
        {
            Console.WriteLine("\n=== DÉTAIL DE LA COMMANDE ===");
            Console.Write($"Commande effectuee par: "); client.AfficherInfo();
            Console.WriteLine($"\nFLEURS INDIVIDUELLES ({fleurs.Count})");

            // Afficher les fleurs individuelles
            foreach(var fleur in fleurs)
            {
                Console.WriteLine($"- {fleur.Nom} ({fleur.Couleur}) : {fleur.Prix}$");
            }
            

            Console.WriteLine($"\nBOUQUETS ({Bouquets.Count})");

            // Afficher chaque bouquet
            foreach (var bouquet in Bouquets)
            {
                Console.WriteLine($"\nBouquet contenant {bouquet.Bouquets.Count} fleurs :");
                foreach (var fleur in bouquet.Bouquets)
                {
                    Console.WriteLine($"  - {fleur.Nom} ({fleur.Couleur}) : {fleur.Prix}$");
                }
                Console.WriteLine($"  Message carte : {bouquet.MessagePersonnalise ?? "Aucun"}");
                Console.WriteLine($"  Prix du bouquet : {bouquet.CalculerPrix()}$");
            }

            Console.WriteLine("\n=== TOTAL COMMANDE ===");
            Console.WriteLine($"Montant total : {CalculerMontantTotal()}$");
        }

        public static void AfficherToutesLesCommandes()
        {
            foreach (var commande in Commandes)
            {
                Console.WriteLine($"Commande No: {commande.Id} | Client: {commande.client.nom} | Date: {commande.date} | Statut: {commande.statut}");
            }
        }

    }
}
