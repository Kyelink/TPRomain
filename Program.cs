using System;
// using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost\\MSSQLSERVER03;Database=MyDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;";
        // string titre = "Eragon Re-Zero";
        // string auteur = "Michel Drucker";
        // int annee = 2027;
        // string query = $"DELETE FROM Livre Where ID = 106;";
        // string query = $"SELECT AVG(annee) FROM Livre;";
        string query = @"SELECT auteur, COUNT(*) AS count
                        FROM livre
                        GROUP BY auteur;";
        // string query = $"INSERT INTO Livre (Titre, Annee, Auteur) VALUES('{titre}',{annee},'{auteur}');";
        // string query = $"UPDATE Livre SET annee = 2001 WHERE annee = 2008;";
        // string query = "CREATE TABLE Livre(ID INT IDENTITY(101, 1) PRIMARY KEY, Titre VARCHAR(50), Annee INT, Auteur VARCHAR(50));";
        // string query = "DROP TABLE Livre;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                // command.ExecuteNonQuery();
                // Console.WriteLine("La table a été crée avec succès.");

                // double avg = (double)command.ExecuteScalar();
                // Console.WriteLine("Moyenne : " + avg);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                        while(reader.Read()){
                            string aut = reader["auteur"].ToString()!;
                            int count = Convert.ToInt32(reader["count"])!;
                            Console.WriteLine($"Auteur : {aut}, count : {count}");

                        }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erreur lors de la requete : " + ex.Message);
            }
        }
    }
}