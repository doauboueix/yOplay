namespace ClassLibrary
{
    public class Utilisateur
    {
        public static Utilisateur CurrentUtilisateur;
        private string UserName;
        private string Nom;
        private string Prenom;
        private decimal Solde;
       //private static Dictionary<ListPlaylists, string> dictionary;

        public Utilisateur()
        {
           CurrentUtilisateur = this;
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

       /* public Dictionary<ListPlaylists, string> GetDictionary()
        {
            return dictionary;
        }
        ////////////////////////////////////////////////

        public void SetDictionary(ListPlaylists list, string username)
        {
            dictionary.Add(list, username);
        }
        ////////////////////////////////////////////////
        */
    }
}
