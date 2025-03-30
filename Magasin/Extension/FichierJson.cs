using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_POO2.Magasin
{
    class FichierJson
    {
        public static void Sauvegarder(string nomFichier, object donnees)
        {
            // Crée un dossier Data s'il n'existe pas
            if (!Directory.Exists("Donnees"))
                Directory.CreateDirectory("Donnees");

            string cheminComplet = Path.Combine("Donnees", nomFichier);
            string json_serialized = JsonConvert.SerializeObject(donnees, Formatting.Indented);
            File.WriteAllText(cheminComplet, json_serialized);
        }
    }
}
