using System;

class Program
{
    static void Main()
    {
        Init init = new();


        int n = 0;
        do
        {

            try
            {
                Console.WriteLine("Saisissez une option : ");
                Console.WriteLine("1. Ajouter un produit");
                Console.WriteLine("2. Modifier le prix d'un produit");
                Console.WriteLine("3. Supprimer un produit");
                Console.WriteLine("4. Afficher tous les produits");
                Console.WriteLine("5. Afficher le prix cumulé de tous les produits");
                Console.WriteLine("6. Quitter");
                n = Convert.ToInt32(Console.ReadLine()!);
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Saisissez le nom du produit :");
                        string nom = Console.ReadLine()!;

                        int qte = 0;
                        bool valid = false;
                        do
                        {
                            try
                            {
                                Console.WriteLine("Sa quantité :");
                                qte = Convert.ToInt32(Console.ReadLine()!);
                                valid = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Saisissez à nouveau : {e.Message}");
                            }

                        } while (!valid);

                        double prix = 0;
                        valid = false;
                        do
                        {
                            try
                            {
                                Console.WriteLine("Son prix :");
                                prix = Convert.ToDouble(Console.ReadLine()!.Replace(".", ","));
                                valid = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Saisissez à nouveau : {e.Message}");
                            }

                        } while (!valid);


                        int cat = 0;
                        valid = false;
                        do
                        {
                            try
                            {
                                Console.WriteLine("Sa catégorie :");
                                qte = Convert.ToInt32(Console.ReadLine()!);
                                valid = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Saisissez à nouveau : {e.Message}");
                            }

                        } while (!valid);
                        init.AddPro(nom, qte, prix.ToString().Replace(",", "."), cat);
                        break;
                    case 2:
                        Console.WriteLine("Saisissez le nom du produit :");
                        nom = Console.ReadLine()!;

                        prix = 0;
                        valid = false;
                        do
                        {
                            try
                            {
                                Console.WriteLine("Son nouveau prix :");
                                prix = Convert.ToDouble(Console.ReadLine()!.Replace(".", ","));
                                valid = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Saisissez à nouveau : {e.Message}");
                            }

                        } while (!valid);
                        init.EditPricePro(nom, prix.ToString().Replace(",", "."));
                        break;
                    case 3:
                        Console.WriteLine("Saisissez le nom du produit :");
                        nom = Console.ReadLine()!;
                        init.DeletePro(nom);
                        break;
                    case 4:
                        init.DisplayPro();
                        break;
                    case 5:
                        init.DisplayCumulPricePro();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");

            }
        } while (n != 6);
        Console.WriteLine("Programme terminé!");
        init.DropTablePro();
        init.DropTableCat();
        // init.DropDB();



    }
}