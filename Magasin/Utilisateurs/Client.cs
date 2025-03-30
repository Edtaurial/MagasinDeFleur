using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_POO2.Magasin
{
    internal class Client:Utilisateur
    {
        public Client(string nom, string courriel, string grade):base(nom,courriel, grade)
        {
        }

        public override void AfficherInfo()
        {
            Console.WriteLine($"Nom: {nom} | Courriel: {courriel} | Grade: {grade}");
        }

    }
}
