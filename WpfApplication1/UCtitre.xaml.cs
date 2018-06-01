using ClassLibrary;
using System;
using System.Windows;
using System.Windows.Controls;
using SQL;


namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour UCtitre.xaml
    /// </summary>
    public partial class UCtitre : UserControl
    {

        public event EventHandler OnClosed;
        public event EventHandler OnSolded;
        public string Titre
        {
            get { return (string)GetValue(TitreProperty); }
            set { SetValue(TitreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Titre.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitreProperty =
            DependencyProperty.Register("Titre", typeof(string), typeof(UCtitre), new PropertyMetadata(string.Empty));


        public string NomPrenom
        {
            get; set;
        }

        public UCtitre()
        {
            Utilisateur Utilisateur = new Utilisateur();
            NomPrenom = Utilisateur.GetPrenom() + " " + Utilisateur.GetNom();
            InitializeComponent();
            Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
            DataContext = this;
        }



        // MENU COMPTE UTILISATEUR !!! //
        ///////////////////////////////////////////////////////////////////////
        private void SeDeconnecter(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            if (OnClosed != null)
                OnClosed.Invoke(this, new EventArgs());
        }


        private void AugmenterSolde(object sender, RoutedEventArgs e)
        {
            if (OnSolded != null)
                OnSolded.Invoke(this, new EventArgs());
        }
        ///////////////////////////////////////////////////////////////////////
    }
}
    
