using System;
using Microsoft.Data.SqlClient;
class Init
{
    public Init()
    {
        CreateDB();
        CreateTableCat();
        CreateTablePro();

        AddCat("Vetements");
        AddCat("Jouets");
        AddCat("Saucissons");

        AddPro("Saucisson du Burzet", 100, "16.00", 2);
        AddPro("Saucisson de Charpey", 50, "14.00", 2);
        AddPro("Saucisson des frères Manet", 100, "16.50", 2);
        AddPro("Saucisson Ferdinand Chaudouard", 10, "8.00", 2);
        AddPro("T-shirt", 100, "12.00", 0);
        AddPro("Bilboquet", 5, "4.50", 1);
    }

    // ~Init()
    // {
    //     Console.WriteLine("destructeur appelé!");
    //     DropTablePro();
    //     DropTableCat();
    //     DropDB();
    // }

    public void DisplayPro()
    {
        string connectionString = "Server=localhost\\MSSQLSERVER03;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = $@"
        IF OBJECT_ID('Produits') IS NOT NULL
        BEGIN
        SELECT * FROM Produits JOIN Categories ON fk_cat=pk_cat
        END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nom = reader["nom_pro"].ToString()!;
                        int qte = Convert.ToInt32(reader["quantite_pro"])!;
                        double prix = Convert.ToDouble(reader["prix_pro"])!;
                        string categorie = reader["nom_cat"].ToString()!;
                        Console.WriteLine($"nom : {nom}, quantité : {qte}, prix : {prix}€, catégorie : {categorie}");

                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
    public void DisplayCumulPricePro()
    {
        string connectionString = "Server=localhost\\MSSQLSERVER03;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = $@"
        IF OBJECT_ID('Produits') IS NOT NULL
        BEGIN
        SELECT SUM(prix_pro*quantite_pro) AS total FROM Produits
        END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        double prix = Convert.ToDouble(reader["total"])!;
                        Console.WriteLine($"total : {prix}€");

                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
    public void DeletePro(string name)
    {

        string connectionString = "Server=localhost\\MSSQLSERVER03;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = $@"
        IF OBJECT_ID('Produits') IS NOT NULL
        BEGIN
        DELETE FROM Produits Where nom_pro = '{name}'
        END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine($"Le produit \"{name}\"  a été éffacé avec succès.");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
    public void EditPricePro(string name, string prix)
    {

        string connectionString = "Server=localhost\\MSSQLSERVER03;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = $@"
        IF OBJECT_ID('Produits') IS NOT NULL
        BEGIN
        UPDATE Produits SET prix_pro = '{prix}' WHERE nom_pro = '{name}';
        END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine($"Le prix du produit \"{name}\"  a été modifié avec succès.");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

    public void AddCat(string name)
    {
        string connectionString = "Server=localhost\\MSSQLSERVER03;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = $@"
        IF OBJECT_ID('Categories') IS NOT NULL
        BEGIN
        INSERT INTO Categories (nom_cat) VALUES('{name}')
        END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine($"La categorie \"{name}\"  a été ajoutée avec succès.");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

    public void AddPro(string name, int qte, string prix, int cat)
    {

        string connectionString = "Server=localhost\\MSSQLSERVER03;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = $@"
        IF OBJECT_ID('Produits') IS NOT NULL
        BEGIN
        INSERT INTO Produits (
            nom_pro,
            quantite_pro,
            prix_pro,
            fk_CAT
            ) 
            VALUES(
            '{name}',
            {qte},
            '{prix}',
            {cat}
            )
        END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine($"Le produit \"{name}\"  a été ajoutée avec succès.");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

    public void CreateTableCat()
    {
        string connectionString = "Server=localhost\\MSSQLSERVER03;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = @"
        IF OBJECT_ID('Categories') IS NULL
        BEGIN
        CREATE TABLE Categories(pk_cat INT IDENTITY(0, 1) PRIMARY KEY, nom_cat NVARCHAR(50))
        END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("La Table Categories a été créée avec succès.");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
    public void CreateTablePro()
    {
        string connectionString = "Server=localhost\\MSSQLSERVER03;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = @"IF OBJECT_ID('Produits') IS NULL
        BEGIN
        CREATE TABLE Produits(
            pk_pro INT IDENTITY(0, 1) PRIMARY KEY,
            nom_pro NVARCHAR(50) NOT NULL,
            quantite_pro INT NOT NULL,
            prix_pro FLOAT NOT NULL,
            fk_CAT INT FOREIGN KEY REFERENCES Categories(pk_cat)
        )
        END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("La Table Produits a été créée avec succès.");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }



    public void DropTableCat()
    {
        string connectionString = "Server=localhost\\MSSQLSERVER03;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = @"IF OBJECT_ID('Categories') IS NOT NULL
        BEGIN
        DROP TABLE Categories
        END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("La Table Categories a été effacée avec succès.");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
    public void DropTablePro()
    {
        string connectionString = "Server=localhost\\MSSQLSERVER03;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = @"IF OBJECT_ID('Produits') IS NOT NULL
        BEGIN
        DROP TABLE Produits
        END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("La Table Produits a été effacée avec succès.");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }




    public void CreateDB()
    {
        string connectionString = "Server=localhost\\MSSQLSERVER03;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = @"IF DB_ID('StoreDB') IS NULL
                            BEGIN
                            CREATE DATABASE StoreDB
                            END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("La DB a été créée avec succès.");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
    public void DropDB()
    {
        string connectionString = "Server=localhost\\MSSQLSERVER03;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        string query = @"IF DB_ID('StoreDB') IS NOT NULL
                            BEGIN
                            DROP DATABASE StoreDB
                            END;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("La DB a été effacée avec succès.");

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}