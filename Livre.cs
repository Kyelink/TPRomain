using System;
class Livre
{
    public string Titre { get; set; }
    public int AnneePublication { get; set; }
    public Auteur Aut { get; set; }
    public Livre(string TitreC, int AnneePublicationC, Auteur AutC)
    {
        Titre = TitreC;
        AnneePublication = AnneePublicationC;
        Aut = AutC;
    }
    public void AfficherInformations()
    {
        Console.WriteLine($"Titre : {Titre}, Année de publication : {AnneePublication}, Auteur : {Aut.Nom} {Aut.Prenom}");
    }
}