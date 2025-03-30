using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TP1_POO2.Magasin.Commande;

namespace TP1_POO2.Magasin
{
    internal class Facture
    {
        public int Id;
        public Commande commande;
        public decimal montantTotal;
        public string modePaiement;
        public DateTime date;

        public Facture(int id, Commande commande, string modePaiement)
        {
            Id = id;
            this.commande = commande;
            this.montantTotal = commande.CalculerMontantTotal();
            this.modePaiement = modePaiement;
            date = DateTime.Now;
        }

        public void ValiderPaiement(Commande commande, string methodePaiement)
        {
            commande.statut = StatutCommande.Traitee;
            Console.WriteLine($"\nPaiement de {commande.CalculerMontantTotal()}$ accepté par {methodePaiement}");
            Console.WriteLine("Merci pour votre achat !");
        }

        public void AfficherFacture()
        {
            Console.WriteLine("****************Facture***************");
            Console.WriteLine($"Facture No: {Id}");
            Console.WriteLine($"Date d'émission: {date}");
            Console.WriteLine();
            Console.WriteLine("Details de la commande: ");

            if(commande.fleurs.Count > 0)
            {
                Console.WriteLine("Fleurs:");
                foreach(Fleur fleur in commande.fleurs)
                {
                    Console.WriteLine($"- {fleur.Nom} ({fleur.Couleur}) : {fleur.Prix}");
                    Console.WriteLine($"Description:{ fleur.Caracteristiques}");
                }
            }

            if (commande.Bouquets.Count > 0)
            {
                Console.WriteLine("Bouquets :");
                foreach (Bouquet bouquet in commande.Bouquets)
                {
                    Console.WriteLine($"- Bouquet : {bouquet.CalculerPrix()} $");
                }
            }

            Console.WriteLine("*************************************");
            Console.WriteLine($"Montant total : {montantTotal} $");
            Console.WriteLine($"Mode de paiement : {modePaiement}");
            Console.WriteLine("*************************************");
        }



    }
}
