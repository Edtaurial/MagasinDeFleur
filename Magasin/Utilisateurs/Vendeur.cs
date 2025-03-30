using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_POO2.Magasin
{
    internal class Vendeur:Utilisateur
    {
        public List<Commande> Commandes = new List<Commande>();
        public Vendeur(string nom, string courriel, string grade) : base(nom, courriel, grade)
        {
           
        }

        public override void AfficherInfo()
        {
            Console.WriteLine($"Nom: {nom} | Courriel: {courriel} | Grade: {grade}");
        }

        public void ConsulterCommande(Commande commande)
        {
            commande.AfficherCommande();
        }

        public void AnnulerCommande(int id)
        {
            foreach(var commande in Commandes)
            {
                if (commande.Id == id)
                {
                    Commandes.Remove(commande);
                    Console.WriteLine($"Commande {id} annulée");
                    return;
                }
                else
                    Console.WriteLine("Non valide");
            }
        }
    }
}
