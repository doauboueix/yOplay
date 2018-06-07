using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System.Data;
using System.Linq;
using ClassLibrary;
using SQL;

namespace WpfApplication1
{
    public partial class Films : Window
    {
        public List<Film> EFilms { get; set; } = new List<Film>();
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        public Films()
        {
            InitializeComponent();
            DataContext = this;
            EFilms.Add(new Film(15.99M, "Fantastique", "pack://application:,,,/WpfApplication1;component/adds/Film/TombRaider.jpg", "Tomb Raider", "Simon West", "Lara Croft, 21 ans, n'a ni projet, ni ambition : fille d'un explorateur excentrique porté disparu" + "\n" + "depuis sept ans, cette jeune femme rebelle et indépendante refuse de reprendre l'empire de" + "\n" + "son père. Convaincue qu'il n'est pas mort, elle met le cap sur la destination où son père a été" + "\n" + "vu pour la dernière fois : la tombe légendaire d'une île mythique au large du Japon. Mais le" + "\n" + "voyage se révèle des plus périlleux et il lui faudra affronter d'innombrables ennemis et" + "\n" + "repousser ses propres limites pour devenir...Tomb Raider...", "pack://application:,,,/WpfApplication1;component/adds/4etoiles.png"));
            EFilms.Add(new Film(15.99M, "Drame", "pack://application:,,,/WpfApplication1;component/adds/Film/Akira.jpg", "Akira", "Katsuhiro Ōtomo", "Le 16 juillet 1988, Tokyo est détruit. Trente - et - un ans plus tard, après la Troisième Guerre" + "\n" + "mondiale, en 2019, Neo - Tokyo est une mégalopole corrompue et sillonnée par des bandes" + "\n" + "de jeunes motards désœuvrés et drogués.Une nuit, l'un d'eux, Tetsuo, a un accident en" + "\n" + "essayant d'éviter ce qui semble être d'abord un jeune garçon mais qui a un visage de vieillard." + "\n" + "Il est capturé par l'armée et fait l'objet de nombreux tests dans le cadre d'un projet militaire" + "\n" + "secret visant à repérer et à former des êtres possédant des prédispositions à des pouvoirs" + "\n" + "psychiques (télépathie, téléportation, télékinésie…).", "pack://application:,,,/WpfApplication1;component/adds/4etoiles.png"));
            EFilms.Add(new Film(13.99M, "Comedie", "pack://application:,,,/WpfApplication1;component/adds/Film/taxi5.jpg", "Taxi 5", "Franck Gastambide", "Sylvain Marot, super flic parisien et pilote d’exception, est muté contre son gré à la Police" + "\n" + "Municipale de Marseille. L’ex-commissaire Gibert, devenu Maire de la ville et au plus bas dans" + "\n" + "les sondages, va alors lui confier la mission de stopper le redoutable « Gang des Italiens », qui" + "\n" + "écume des bijouteries à l’aide de puissantes Ferrari. Mais pour y parvenir, Marot n’aura pas" + "\n" + "d’autre choix que de collaborer avec le petit-neveu du célèbre Daniel, Eddy Maklouf, le pire" + "\n" + "chauffeur VTC de Marseille, mais le seul à pouvoir récupérer le légendaire TAXI blanc.", "pack://application:,,,/WpfApplication1;component/adds/2etoiles.png"));
            EFilms.Add(new Film(9.99M, "Horreur", "pack://application:,,,/WpfApplication1;component/adds/Film/SlenderMan.jpg", "Slender Man", "Eric Knudsen", "Un long métrage centré sur Slender Man, monstre créé sur Internet en 2009 et devenu une" + "\n" + "légende urbaine.", "pack://application:,,,/WpfApplication1;component/adds/3etoiles.png"));
            EFilms.Add(new Film(16.99M, "Fantastique", "pack://application:,,,/WpfApplication1;component/adds/Film/ReadyPlayerOne.jpg", "Ready player one", "Steven Spielberg", "2045. Le monde est au bord du chaos. Les êtres humains se réfugient dans l'OASIS, univers" + "\n" + "virtuel mis au point par le brillant et excentrique James Halliday. Avant de disparaître, celui-ci" + "\n" + "a décidé de léguer son immense fortune à quiconque découvrira l'œuf de Pâques numérique" + "\n" + "qu'il a pris soin de dissimuler dans l'OASIS. L'appât du gain provoque une compétition" + "\n" + "planétaire. Mais lorsqu'un jeune garçon, Wade Watts, qui n'a pourtant pas le profil d'un héros," + "\n" + "décide de participer à la chasse au trésor, il est plongé dans un monde parallèle à la fois" + "\n" + "mystérieux et inquiétant…", "pack://application:,,,/WpfApplication1;component/adds/5etoiles.png"));
            EFilms.Add(new Film(16.99M, "Drame", "pack://application:,,,/WpfApplication1;component/adds/Film/ThePassenger.jpg", "The Passenger", "Jaume Collet-Serra", "Comme tous les jours après son travail, Michael MacCauley (Liam Neeson) prend le train de" + "\n" + "banlieue qui le ramène chez lui. Mais aujourd’hui, son trajet quotidien va prendre une toute" + "\n" + "autre tournure. Après avoir reçu l’appel d’un mystérieux inconnu, il est forcé d’identifier un" + "\n" + "passager caché dans le train, avant le dernier arrêt. Alors qu’il se bat contre la montre pour" + "\n" + "résoudre cette énigme, il se retrouve pris dans un terrible engrenage. Une conspiration qui" + "\n" + "devient une question de vie ou de mort, pour lui ainsi que pour tous les autres passagers !", "pack://application:,,,/WpfApplication1;component/adds/5etoiles.png"));
            EFilms.Add(new Film(10.99M, "Comedie", "pack://application:,,,/WpfApplication1;component/adds/Film/LesTuches3.jpg", "Les Tuche 3", "Olivier Baroux", "Jeff Tuche, se réjouit de l’arrivée du TGV dans son cher village. Malheureusement, le train à" + "\n" + "grande vitesse ne fait que passer, sans s’arrêter à Bouzolles. Déçu, il tente de joindre le" + "\n" + "président de la République pour que son village ne reste pas isolé du reste du territoire. Sans" + "\n" + "réponse de l’Élysée, Jeff ne voit plus qu’une seule solution pour se faire entendre : se présenter" + "\n" + "à l’élection présidentielle... Profitant de circonstances politiques imprévisibles, Jeff Tuche et toute" + "\n" + "sa famille vont s’installer à l’Élysée pour une mission à haut risque : gouverner la France.", "pack://application:,,,/WpfApplication1;component/adds/3etoiles.png"));
            EFilms.Add(new Film(12.99M, "Horreur", "pack://application:,,,/WpfApplication1;component/adds/Film/Ghostland.jpg", "Ghostland", "Pascal Laugier", "Suite au décès de sa tante, Pauline et ses deux filles héritent d’une maison. Mais dès la" + "\n" + "première nuit, des meurtriers pénètrent dans la demeure et Pauline doit se battre pour sauver" + "\n" + "ses filles. Un drame qui va traumatiser toute la famille mais surtout affecter différemment" + "\n" + "chacune des jeunes filles dont les personnalités vont diverger davantage à la suite de cette nuit" + "\n" + "cauchemardesque.", "pack://application:,,,/WpfApplication1;component/adds/4etoiles.png"));
            EFilms.Add(new Film(16.99M, "Fantastique", "pack://application:,,,/WpfApplication1;component/adds/Film/SoloStarWars.jpg", "Solo: A Star Wars Story", "Ron Howard", "Embarquez à bord du Faucon Millenium et partez à l’aventure en compagnie du plus célèbre" + "\n" + "vaurien de la galaxie. Au cours de périlleuses aventures dans les bas-fonds d’un monde" + "\n" + "criminel, Han Solo va faire la connaissance de son imposant futur copilote Chewbacca et croiser" + "\n" + "la route du charmant escroc Lando Calrissian… Ce voyage initiatique révèlera la personnalité" + "\n" + "d’un des héros les plus marquants de la saga Star Wars.", "pack://application:,,,/WpfApplication1;component/adds/4etoiles.png"));
            EFilms.Add(new Film(12.99M, "Drame", "pack://application:,,,/WpfApplication1;component/adds/Film/RedSparrow.jpg", "Red Sparrow", "Francis Lawrence", "Une jeune ballerine, dont la carrière est brisée nette après une chute, est recrutée contre sa" + "\n" + "volonté par les services secrets russes. Entraînée à utiliser ses charmes et son corps comme des" + "\n" + "armes, elle découvre l’ampleur de son nouveau pouvoir et devient rapidement l’un de leurs" + "\n" + "meilleurs agents. Sa première cible est un agent infiltré de la CIA en Russie.Entre manipulation" + "\n" + "et séduction, un jeu dangereux s’installe entre eux.", "pack://application:,,,/WpfApplication1;component/adds/4etoiles.png"));
            EFilms.Add(new Film(14.99M, "Comedie", "pack://application:,,,/WpfApplication1;component/adds/Film/DeadPool2.jpg", "Deadpool 2", "David Leitch", "L’insolent mercenaire de Marvel remet le masque ! Plus grand, plus - mieux, et" + "\n" + "occasionnellement les fesses à l’air, il devra affronter un Super - Soldat dressé pour tuer," + "\n" + "repenser l’amitié, la famille, et ce que signifie l’héroïsme – tout en bottant cinquante nuances" + "\n" + "de culs, car comme chacun sait, pour faire le Bien, il faut parfois se salir les doigts.", "pack://application:,,,/WpfApplication1;component/adds/3etoiles.png"));
            EFilms.Add(new Film(12.99M, "Horreur", "pack://application:,,,/WpfApplication1;component/adds/Film/TheFirstPurge.jpg", "The First Purge", "Gerard McMurray", "Pour faire passer le taux de criminalité en-dessous de 1% le reste de l’année, les « Nouveaux" + "\n" + "Pères Fondateurs » testent une théorie sociale qui permettrait d’évacuer la violence durant une" + "\n" + "nuit dans une ville isolée. Mais lorsque l’agressivité des tyrans rencontre la rage de" + "\n" + "communautés marginalisées, le phénomène va s’étendre au-delà des frontières de la ville test" + "\n" + "jusqu’à atteindre la nation entière.", "pack://application:,,,/WpfApplication1;component/adds/5etoiles.png"));
            EFilms.Add(new Film(13.99M, "Fantastique", "pack://application:,,,/WpfApplication1;component/adds/Film/AnimauxFantastiques2.jpg", "Les Animaux Fantastiques 2", "David Yates", "1927. Quelques mois après sa capture, le célèbre sorcier Gellert Grindelwald s'évade comme il" + "\n" + "l'avait promis et de façon spectaculaire. Réunissant de plus en plus de partisans, il est à l'origine" + "\n" + "d'attaque d'humains normaux par des sorciers et seul celui qu'il considérait autrefois comme" + "\n" + "un ami, Albus Dumbledore, semble capable de l'arrêter. Mais Dumbledore va devoir faire appel" + "\n" + "au seul sorcier ayant déjoué les plans de Grindelwald auparavant : son ancien élève Norbert" + "\n" + "Dragonneau.", "pack://application:,,,/WpfApplication1;component/adds/5etoiles.png"));
            EFilms.Add(new Film(9.99M, "Drame", "pack://application:,,,/WpfApplication1;component/adds/Film/ShapeOfWater.jpg", "La Forme de l'eau", "Guillermo del Toro", "Modeste employée d’un laboratoire gouvernemental ultrasecret, Elisa mène une existence" + "\n" + "solitaire, d’autant plus isolée qu’elle est muette. Sa vie bascule à jamais lorsqu’elle et sa" + "\n" + "collègue Zelda découvrent une expérience encore plus secrète que les autres…", "pack://application:,,,/WpfApplication1;component/adds/5etoiles.png"));
            EFilms.Add(new Film(11.99M, "Comedie", "pack://application:,,,/WpfApplication1;component/adds/Film/JohnnyEnglish.jpg", "Johnny English contre-attaque", "David Kerr", "Cette nouvelle aventure démarre lorsqu’une cyber-attaque révèle l’identité de tous les agents" + "\n" + "britanniques sous couverture. Johnny English devient alors le dernier espoir des services secrets." + "\n" + "Rappelé de sa retraite, il plonge tête la première dans sa mission : découvrir qui est le génie du" + "\n" + "piratage qui se cache derrière ces attaques. Avec ses méthodes obsolètes Johnny English doit" + "\n" + "relever les défis de la technologie moderne pour assurer la réussite de sa mission.", "pack://application:,,,/WpfApplication1;component/adds/3etoiles.png"));
            EFilms.Add(new Film(9.99M, "Horreur", "pack://application:,,,/WpfApplication1;component/adds/Film/Heredite.jpg", "Heredite", "Ari Aster", "Lorsque Ellen, matriarche de la famille Graham, décède, sa famille découvre des secrets de plus en plus" + "\n" + "terrifiants sur sa lignée. Une hérédité sinistre à laquelle il semble impossible d’échapper.", "pack://application:,,,/WpfApplication1;component/adds/3etoiles.png"));
            list.ItemsSource = EFilms;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list.ItemsSource);
            view.Filter = UserFilter;
            UC.OnClosed += UCtitre_OnClosed;
            UC.OnSolded += UCtitre_OnSolded;
        }



        /// <summary>
        /// Méthode utilisée pour l'évênement OnClosed du UserControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCtitre_OnClosed(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// Méthode utilisée pour l'évênement OnSolded du UserControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCtitre_OnSolded(object sender, EventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// Barre de recherche
        /// </summary>
        /// <param name="item"></param>
        /// <returns> True si la barre est vide ou tous les items dont le texte de la barre de recherche correspond à un élément d'un film </returns>
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Film).Nom.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0) || ((item as Film).Realisateur.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0) || ((item as Film).Genre.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0) || ((item as Film).Prix.ToString().IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }



        /// <summary>
        /// Raffraichit la liste et affiche tous les items que la barre de recherche a trouvé 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(list.ItemsSource).Refresh();
        }



        /// <summary>
        /// Tri par colonne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Column_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Content.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                list.Items.SortDescriptions.Clear();
            }
            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;


            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            list.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }



        /// <summary>
        /// Class SortAdorner
        /// </summary>
        public class SortAdorner : Adorner
        {
            private static Geometry ascGeometry =
                    Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry descGeometry =
                    Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                    : base(element)
            {
                this.Direction = dir;
            }



            /// <summary>
            /// Redéfinition de la méthode OnRender
            /// </summary>
            /// <param name="drawingContext"></param>
            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                        (
                                AdornedElement.RenderSize.Width - 15,
                                (AdornedElement.RenderSize.Height - 5) / 2
                        );
                drawingContext.PushTransform(transform);

                Geometry geometry = ascGeometry;
                if (this.Direction == ListSortDirection.Descending)
                    geometry = descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }



        /// <summary>
        /// Bouton Tout ( recherche par Genre )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RechercheTout(object sender, RoutedEventArgs e)
        {
            list.ItemsSource = EFilms;
        }



        /// <summary>
        /// Bouton Fantastique ( recherche par Genre )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RechercheFantastique(object sender, RoutedEventArgs e)
        {
            List<Film> Fantastique = EFilms.Where(film => film.Genre == "Fantastique").ToList();
            list.ItemsSource = Fantastique;
        }



        /// <summary>
        /// Bouton Drame ( recherche par Genre )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RechercheDrame(object sender, RoutedEventArgs e)
        {
            List<Film> Drame = EFilms.Where(film => film.Genre == "Drame").ToList();
            list.ItemsSource = Drame;
        }



        /// <summary>
        /// Bouton Comedie ( recherche par Genre )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RechercheComedie(object sender, RoutedEventArgs e)
        {
            List<Film> Comedie = EFilms.Where(film => film.Genre == "Comedie").ToList();
            list.ItemsSource = Comedie;
        }



        /// <summary>
        /// Bouton Horreur ( recherche par Genre )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RechercheHorreur(object sender, RoutedEventArgs e)
        {
            List<Film> Horreur = EFilms.Where(film => film.Genre == "Horreur").ToList();
            list.ItemsSource = Horreur;
        }



        /// <summary>
        /// Double Clique sur un item de la ListView --> Redirection vers Fils_Page
        /// Affiche l'item séléctionné avec possibilité d'achat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject originalSource = (DependencyObject)e.OriginalSource;
            while ((originalSource != null) && !(originalSource is ListViewItem))
            {
                originalSource = VisualTreeHelper.GetParent(originalSource);
            }
            if (originalSource != null)
            {
                var Film = list.SelectedItem as Film;
                var nom = Film.Nom;
                var realisateur = Film.Realisateur;
                var prix = Film.Prix;
                var genre = Film.Genre;
                var source = Film.Source;
                var description = Film.Description;
                var note = Film.Note;

                Films_Page Films_Page = new Films_Page(source, nom, realisateur, genre, prix, description, note);
                Films_Page.Show();
                this.Close();
            }
        }



        /// <summary>
        /// Bouton Accueil du Menu Material Design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accueil(object sender, RoutedEventArgs e)
        {
            Accueil Accueil = new Accueil();
            Accueil.Show();
            this.Close();
        }



        /// <summary>
        /// Bouton Mes Films du menu Material Design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MesFilms(object sender, RoutedEventArgs e)
        {
            MesFilms MesFilms = new MesFilms();
            MesFilms.Show();
            this.Close();
        }



        /// <summary>
        /// Ouvre le menu Material Design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }



        /// <summary>
        /// Ferme le menu Material Design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }



        /// <summary>
        /// Regroupe toutes les methodes du menu Material Design ( car ils sont dans une ListView donc obligation de passer par un switch / case )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemAccueil":
                    Accueil(sender, e);
                    break;
                case "ItemSearch":
                    ItemSearch.Visibility = Visibility.Collapsed;
                    ItemSearchBar.Visibility = Visibility.Visible;
                    break;
                case "ItemSearchBar":
                    ItemSearchBar.Visibility = Visibility.Collapsed;
                    ItemSearch.Visibility = Visibility.Visible;
                    txtFilter.Clear();
                    break;
                case "ItemMesFilms":
                    MesFilms(sender, e);
                    break;
                case "ItemGenreON":
                    ItemGenreON.Visibility = Visibility.Collapsed;
                    ItemGenreOFF.Visibility = Visibility.Visible;
                    if (stackP.Visibility == Visibility.Hidden)
                    {
                        stackP.Visibility = Visibility.Visible;
                    }
                    break;
                case "ItemGenreOFF":
                    ItemGenreOFF.Visibility = Visibility.Collapsed;
                    ItemGenreON.Visibility = Visibility.Visible;
                    if (stackP.Visibility == Visibility.Visible)
                    {
                        stackP.Visibility = Visibility.Hidden;
                    }
                    break;
            }
        }



        /// <summary>
        /// Bouton valider de l'InputBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            int cpt = 0;
            int cpt2 = 0;
            string input = InputTextBox.Text;
            foreach (Char c in input) // pour chaque caractère inscrit dans la textbox //
            {
                if (!Char.IsDigit(c)) // si ce caractère n'est pas un chiffre compris entre 0 et 9 //
                {
                    cpt += 1; // alors on incrémente le compteur de 1 //
                }
                cpt2 += 1;
            }
            if (cpt2 == 0)
                MessageBox.Show("Vous n'avez entré aucune valeur !", "Erreur");
            else if (cpt != 0) // si le compteur n'est pas égal à 0 //
            {
                MessageBox.Show("Format valide (Entiers uniquement) !", "Erreur format"); // on affiche un message indiquant que le format n'est pas respecté //
                InputTextBox.Text = String.Empty; // on réinitialise le contenu de la textbox //
            }
            else
            {
                Utilisateur Utilisateur = Utilisateur.CurrentUtilisateur;
                Utilisateur.AjouterSolde(Convert.ToDecimal(input));
                UC.Solde.Content = "Mon solde: " + Utilisateur.GetSolde() + "€";
                SQLupdate SQLupdate = new SQLupdate();
                SQLupdate.UpdateSolde(Utilisateur.GetUserName(),Convert.ToDecimal(input));

                InputBox.Visibility = Visibility.Collapsed;
                InputTextBox.Text = String.Empty;
            }
        }



        /// <summary>
        /// Bouton annuler de l'InputBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
            InputTextBox.Text = String.Empty;
        }
    }
}