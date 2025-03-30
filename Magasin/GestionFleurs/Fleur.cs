using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace TP1_POO2.Magasin
{
    internal class Fleur
    {
        public int nbreFleurs = 0;

        public Fleur()
        {
            nbreFleurs++;
        }

        public static List<Fleur> ImporterFleursDepuisCsv(string cheminFichier)
        {
            using (var reader = new StreamReader(cheminFichier))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Fleur>().ToList();
            }
        }


        public string Nom { get; set; }
        public string Couleur { get; set; }
        public decimal Prix { get; set; }

        [Name("Caractéristiques")]
        public string Caracteristiques { get; set; }

        public override string ToString()
        {
           return $"Nom:{Nom} | Couleur: {Couleur} | Prix: {Prix} | Description: {Caracteristiques}";
        }

        public static Fleur operator +(Fleur f1, Fleur f2)
        {
            Fleur f = new Fleur();
            f.Prix = f1.Prix + f2.Prix;
            f.Nom = f1.Nom + " et " + f2.Nom;
            f.Couleur = f1.Couleur + " et " + f2.Couleur;
            f.Caracteristiques = f1.Caracteristiques + " et " + f2.Caracteristiques;
            return f;
        }
    }
}
