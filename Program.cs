// // See https://aka.ms/new-console-template for more information

using System;
using System.Linq.Expressions;
// using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Auteur pers = new("Michel", "Drucker");
            Livre bk = new("Eragon", 1995, pers);
            bk.AfficherInformations();

            int n = 0;
            List<Livre> librairie = [bk];
            do
            {

                try
                {
                    Console.WriteLine("Saisissez une option : ");
                    Console.WriteLine("1. Ajouter un livre");
                    Console.WriteLine("2. Afficher tous les livres");
                    Console.WriteLine("3. Rechercher un livre par titre");
                    Console.WriteLine("4. Supprimer un livre");
                    Console.WriteLine("5. Quitter");
                    n = Convert.ToInt32(Console.ReadLine()!);
                    switch (n)
                    {
                        case 1:
                            bool continuer = false;
                            do
                            {
                                Console.WriteLine("Saisissez titre :");
                                string titre = Console.ReadLine()!;

                                int annee = 0;
                                bool validYear = false;
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("Saisissez année de publication :");
                                        annee = Convert.ToInt32(Console.ReadLine()!);
                                        validYear = true;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine($"Une erreur s'est produite : {e.Message}");
                                    }

                                } while (!validYear);
                                Console.WriteLine("Saisissez nom de l'auteur :");
                                string nom = Console.ReadLine()!;
                                Console.WriteLine("Saisissez prénom de l'auteur :");
                                string prenom = Console.ReadLine()!;
                                Auteur aut = new(nom, prenom);
                                Livre book = new(titre, annee, aut);
                                librairie.Add(book);
                                Console.WriteLine("Livre ajouté!");
                                Console.WriteLine("Ajouter nouveau livre? (Y/N)");
                                string ans = Console.ReadLine()!;
                                if (ans == "y" || ans == "Y")
                                {
                                    continuer = true;
                                }
                                else
                                {
                                    continuer = false;
                                }
                            } while (continuer);
                            break;
                        case 2:
                            Console.WriteLine("Liste des livres :");
                            foreach (Livre x in librairie)
                            {
                                x.AfficherInformations();
                            }
                            break;
                        case 3:
                            bool found = false;
                            Console.WriteLine("Saisissez titre de livre :");
                            string titreAChercher = Console.ReadLine()!;
                            foreach (Livre x in librairie)
                            {
                                if (x.Titre == titreAChercher)
                                {
                                    found = true;
                                    x.AfficherInformations();
                                    break;
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine("Livre non trouvé!");
                            }
                            break;
                        case 4:
                            bool found2 = false;
                            Console.WriteLine("Saisissez titre de livre :");
                            string titreAChercher2 = Console.ReadLine()!;
                            foreach (Livre x in librairie)
                            {
                                if (x.Titre == titreAChercher2)
                                {
                                    found2 = true;
                                    librairie.Remove(x);
                                    Console.WriteLine("Livre supprimé!");
                                    break;
                                }
                            }
                            if (!found2)
                            {
                                Console.WriteLine("Livre non trouvé!");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Une erreur s'est produite : {ex.Message}");

                }
            } while (n != 5);
            Console.WriteLine("Programme terminé!");


            // int n;
            // try
            // {
            //     Console.WriteLine("Saisissez nombre : ");
            //     n = Convert.ToInt32(Console.ReadLine()!);
            //     Console.WriteLine($"Nombre entré : {n}");
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine($"Une erreur s'est produite : {e.Message}");
            // }
            // finally
            // {
            //     Console.WriteLine("Tentative de conversion terminée");
            // }



            // List<int> l = [];


            // for (int i = 0; i < 5; i++)
            // {
            //     Console.WriteLine("Saisissez nombre : ");
            //     l.Add(Convert.ToInt32(Console.ReadLine()!));
            // }
            // Console.WriteLine("nombres pairs : ");
            // foreach (int x in l)
            // {
            //     if (x % 2 == 0)
            //     {
            //         Console.WriteLine(x);
            //     }
            // }

            // Console.WriteLine("Saisissez note : ");
            // int mark = Convert.ToInt32(Console.ReadLine()!);

            // switch (mark)
            // {
            //     case < 10:
            //         Console.WriteLine(mark + "/20 : Insuffisant");
            //         break;
            //     case int x when x >= 10 || x < 16:
            //         Console.WriteLine(mark + "/20 : Assez bien");
            //         break;
            //     case int x when x >= 16:
            //         Console.WriteLine(mark + "/20 : Bien");
            //         break;
            //     default:
            //         Console.WriteLine("Mark not valid");
            //         break;
            // }

            // if(mark<10){
            //     Console.WriteLine(mark+"/20 : Insuffisant");
            // }
            // else if(mark<16){
            //     Console.WriteLine(mark+"/20 : Assez bien");
            // }
            // else{
            //     Console.WriteLine(mark+"/20 : Bien");
            // }



        }
    }
}