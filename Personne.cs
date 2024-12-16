using System;
class Auteur
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public Auteur(string NomC, string PrenomC)
    {
        Nom = NomC;
        Prenom = PrenomC;
    }
    public void AfficherInformations()
    {
        Console.WriteLine($"Nom : {Nom}, Prénom : {Prenom}");
    }
}