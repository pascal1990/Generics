using ConsoleGenerics.Models;
using System;
using System.Collections.Generic;
using System.Text;


    public static class NonGenericsUse
    {
        public static void EnregisterEmploye(List<Employe> employes, string chemin)
        {
            List<string> lignes = new List<string>();

            lignes.Add("Nom,NumEmploye,Adresse,Salaire");

            foreach(Employe emp in employes)
            {
                lignes.Add($"{emp.Nom},{emp.NumEmploye},{emp.Adresse},{emp.Salaire}");
            }

            System.IO.File.WriteAllLines(chemin, lignes); 

        }

    public static void EnregisterProduit(List<Produit> produits, string chemin)
    {
        List<string> lignes = new List<string>();

        lignes.Add("Nom,NumEmploye,Adresse,Salaire");

        foreach (Produit prod in produits)
        {
            lignes.Add($"{prod.Nom},{prod.Prix},{prod.Quantite}");
        }

        System.IO.File.WriteAllLines(chemin, lignes);

    }

    public static List<Employe> ChargeEmploye(string chemin)
        {
            List<Employe> output = new List<Employe>();
            Employe emp;
            List<string> lignes = new List<string>();

            var dataFile = System.IO.File.ReadAllLines(chemin);

            for(int i = 0; i<dataFile.Length; i++)
            {
                if (i == 0) continue; // l'entete du fichier csv 

                var vals = dataFile[i].Split(',');
                emp = new Employe();

                emp.Nom = vals[0];
                emp.NumEmploye = vals[1];
                emp.Adresse = vals[2];
                emp.Salaire = double.Parse(vals[3]);

                output.Add(emp);
            }

            return output;
            

            
        }

    public static List<Produit> ChargeProduit(string chemin)
    {
        List<Produit> output = new List<Produit>();
        Produit prod;
        List<string> lignes = new List<string>();

        var dataFile = System.IO.File.ReadAllLines(chemin);

        for (int i = 0; i < dataFile.Length; i++)
        {
            if (i == 0) continue; // l'entete du fichier csv 

            var vals = dataFile[i].Split(',');
            prod = new Produit();

            prod.Nom = vals[0];
            prod.Prix = double.Parse(vals[1]);
            prod.Quantite = int.Parse(vals[2]);

            output.Add(prod);
        }

        return output;



    }
}

