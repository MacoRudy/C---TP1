using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2Linq.BO;

namespace TP2Linq
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();
        static void Main(string[] args)
        {
            InitialiserDatas();

            Console.WriteLine("question 1");
            foreach (var item in ListeAuteurs.Where(x => x.Nom.StartsWith("G")))
            {
                Console.WriteLine(item.Prenom);
            }

            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("question 2");
            foreach (var item in ListeLivres.GroupBy(x => x.Auteur).OrderByDescending(x => x.Count()).First())
            {
                Console.WriteLine(item.Auteur.Nom + " " + item.Auteur.Prenom);
                break;
            }

            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("question 3");

            foreach (var item in ListeLivres.GroupBy(x => x.Auteur))
            {
                double moyenne = item.Average(x => x.NbPages);
                Console.WriteLine(item.Key.Nom + " : " + moyenne);

            }

            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("question 4");
            foreach (var item in ListeLivres.OrderByDescending(x => x.NbPages))
            {
                Console.WriteLine("nom du livre " + item.Titre);
                break;
            }

            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("question 5");

            foreach (var item in ListeAuteurs)
            {
                if (item.Factures.Any())
                {
                    decimal salaire = item.Factures.Average(x => x.Montant);
                    Console.WriteLine("salaire de " + item.Nom + " " + item.Prenom + " : " + salaire);
                }

            }

            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("question 6");

            foreach (var item in ListeLivres.GroupBy(x => x.Auteur))
            {
                Console.WriteLine(item.Key.Nom + " " + item.Key.Prenom + " :");
                foreach (var subitem in item)
                {
                    Console.WriteLine(subitem.Titre);
                }
                Console.WriteLine();
            }

            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("question 7");

            foreach (var item in ListeLivres.OrderBy(x => x.Titre))
            {
                Console.WriteLine(item.Titre);
            }

            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("question 8");

            double average = ListeLivres.Average(x => x.NbPages);

            foreach (var item in ListeLivres.Where(x => x.NbPages > average))
            {
                Console.WriteLine(item.Titre);
            }

            Console.WriteLine("------------------------------------------------------------------------------------");

            Console.WriteLine("question 9");

            foreach (var item in ListeLivres.GroupBy(x => x.Auteur).OrderBy(x => x.Count()).First())
            {
                Console.WriteLine(item.Auteur.Nom + " " + item.Auteur.Prenom);
                break;
            }

            Console.ReadKey();
        }



        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}
