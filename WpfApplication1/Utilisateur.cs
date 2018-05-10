using System.Collections.Generic;

namespace WpfApplication1
{
    public partial class Utilisateur
    {
        private static string UserName;
        private static string Nom;
        private static string Prenom;
        private static decimal Solde;

        public Utilisateur()
        {

        }
        
        ////////////////////////////////////////////////
        public string GetUserName()
        {
            return UserName;
        }
        public void SetUserName(string username)
        {
            UserName = username;
        }
        ////////////////////////////////////////////////

        public string GetNom()
        {
            return Nom;
        }
        public void SetNom(string nom)
        {
            Nom = nom;
        }
        ////////////////////////////////////////////////

        public string GetPrenom()
        {
            return Prenom;
        }
        public void SetPrenom(string prenom)
        {
            Prenom = prenom;
        }
        ////////////////////////////////////////////////

        public decimal GetSolde()
        {
            return Solde;
        }

        ////////////////////////////////////////////////
        public void SetSolde(decimal solde)
        {
            Solde = solde;
        }
        ////////////////////////////////////////////////

        public void AjouterSolde(decimal solde)
        {
            Solde += solde;
        }
        ////////////////////////////////////////////////

        public void ReduireSolde(decimal solde)
        {
            Solde -= solde;
        }
        ////////////////////////////////////////////////
    }
}
