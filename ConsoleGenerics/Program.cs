using ConsoleGenerics.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");



            string employeCSVFichier = @"C:\Temp\employes.csv";
            string produitCSVFichier = @"C:\Temp\produits.csv";

            List<Employe> employes = new List<Employe>();
            List<Produit> produits = new List<Produit>();

            PeuplerEmployeProduit(employes, produits);

            Console.ReadKey();

            //NonGenericsUse.EnregisterEmploye(employes, employeCSVFichier);

            //List<Employe> employesEn = NonGenericsUse.ChargeEmploye(employeCSVFichier);

            //foreach (Employe emp in employesEn)
            //{
            //    Console.WriteLine($"{emp.Nom},{emp.NumEmploye},{emp.Adresse},{emp.Salaire}");
            //}

            GenericsUse.Enregister<Employe>(employes, employeCSVFichier);
            GenericsUse.Enregister<Produit>(produits, produitCSVFichier);

            List<Employe> employesEn = GenericsUse.Charge<Employe>(employeCSVFichier);
            List<Produit> produitsEn = GenericsUse.Charge<Produit>(produitCSVFichier);

            foreach (Employe emp in employesEn)
            {
                Console.WriteLine($"{emp.Nom},{emp.NumEmploye},{emp.Adresse},{emp.Salaire}");
            }

            Console.WriteLine();

            foreach (Produit prod in produitsEn)
            {
                Console.WriteLine($"{prod.Nom},{prod.Prix},{prod.Quantite}");
            }




            Console.ReadKey();
        }

        private static void PeuplerEmployeProduit(List<Employe> employes, List<Produit> produits)
        {
            employes.Add(new Employe() { Nom = "Pascal Fossouo", NumEmploye = "XXDD12", Adresse = "100 Douala", Salaire = 10.5 });
            employes.Add(new Employe() { Nom = "Leslie Shmit", NumEmploye = "XXDD14", Adresse = "150 Douala", Salaire = 13.5 });

            produits.Add(new Produit() { Nom = "Telephone Iphone 6", Prix = 10, Quantite = 2 });
            produits.Add(new Produit() { Nom = "Telephone HP30", Prix = 100, Quantite = 1 });
        }
    }
}
