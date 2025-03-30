using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_POO2
{
    internal abstract class Utilisateur
    {
        public string nom;
        protected string courriel;
        protected string grade;

        public Utilisateur(string nom, string courriel, string grade){
            this.nom = nom;
            this.courriel = courriel;
            this.grade = grade;
        }

        public abstract void AfficherInfo();
    }
}
