using MyFootballObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Football_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyPersonalFootData MyFoot = new MyPersonalFootData();
        DataGrid ChampionnatsDataGrid;
        DataGrid EquipesDataGrid;
        DataGrid PersonnesDataGrid;
        public MainWindow()
        {
            InitializeComponent();
            
            //MyPersonalFootData MyFoot = new MyPersonalFootData();

            MyFoot.LoadFromBinaryFormat("ClaesIsen"/*MyMap.Prenom + MyMap.Nom*/);
            try
            {
                dgChampionnats.DataContext = MyFoot.MaCollection;

                System.Diagnostics.PresentationTraceSources.DataBindingSource.Switch.Level = System.Diagnostics.SourceLevels.Critical;
            }
            catch (Exception)
            {
                Console.WriteLine("La collection est vide");
            }

        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e) // J'enregistre dans le fichier, la structure actuel de ma Collection
        {
            Console.WriteLine("J'enregistre");
            MyFoot.SaveAsBinaryFormat("ClaesIsen");
        }

        private void Menu_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Tools_About_Click(object sender, RoutedEventArgs e)
        {
            AboutMe About1 = new AboutMe();
            About1.ShowDialog();
        }

        private void Tools_Option_Click(object sender, RoutedEventArgs e) // Fenetre d'options
        {
            Options fo = new Options(this);
            fo.Show();
        }

        private void File_Save_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("J'enregistre");
            MyFoot.SaveAsBinaryFormat("ClaesIsen");
        }

        private void text_Norm_Click(object sender, RoutedEventArgs e)
        {
            TextInfo myTI = new CultureInfo("fr-FR", false).TextInfo;

            foreach (Championnats champ in MyFoot.MaCollection)
            {
                foreach (Equipes team in champ.ListeEquipes)
                {
                    foreach (Personnes toto in team.ListePersonnes)
                    {
                        toto.Nom = myTI.ToTitleCase(toto.Nom);
                        toto.Prenom = myTI.ToTitleCase(toto.Prenom);
                    }

                    team.Nom = myTI.ToTitleCase(team.Nom);
                }

                champ.Nom = myTI.ToTitleCase(champ.Nom);
            }
        }
        private void text_min_Click(object sender, RoutedEventArgs e)
        {
            foreach (Championnats champ in MyFoot.MaCollection)
            {
                foreach (Equipes team in champ.ListeEquipes)
                {
                    foreach (Personnes toto in team.ListePersonnes)
                    {
                        toto.Nom = toto.Nom.ToLower();
                        toto.Prenom = toto.Prenom.ToLower();
                    }

                    team.Nom = team.Nom.ToLower();
                }

                champ.Nom = champ.Nom.ToLower();
            }
        }
        private void text_MAJ_Click(object sender, RoutedEventArgs e)
        {
            foreach(Championnats champ in MyFoot.MaCollection)
            {
                foreach(Equipes team in champ.ListeEquipes)
                {
                    foreach(Personnes toto in team.ListePersonnes)
                    {
                        toto.Nom = toto.Nom.ToUpper();
                        toto.Prenom = toto.Prenom.ToUpper();
                    }

                    team.Nom = team.Nom.ToUpper();
                }

                champ.Nom = champ.Nom.ToUpper();
            }
        }

        private void ChampionnatsDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.dgEquipes.DataContext = null;
            this.dgEquipes.ItemsSource = null;

            ChampionnatsDataGrid = sender as DataGrid;
            if (!(ChampionnatsDataGrid?.SelectedItem is Championnats SelectedChamp)) return;

            this.dgEquipes.DataContext = this;
            this.dgEquipes.ItemsSource = SelectedChamp.ListeEquipes;

        }

        private void EquipesDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.dgPersonnes.DataContext = null;
            this.dgPersonnes.ItemsSource = null;

            EquipesDataGrid = sender as DataGrid;
            if (!(EquipesDataGrid?.SelectedItem is Equipes SelectedTeam)) return;

            this.dgPersonnes.DataContext = this;
            this.dgPersonnes.ItemsSource = SelectedTeam.ListePersonnes;
        }

        private void PersonnesDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonnesDataGrid = sender as DataGrid;
        }

        private void AjoutChampionnat_Click(object sender, RoutedEventArgs e)
        {
            CreationChampionnat AjoutChamp = new CreationChampionnat();
            AjoutChamp.Owner = this;
            AjoutChamp.ShowDialog();

            if (AjoutChamp.NewChamp.Nom == "")
                MessageBox.Show("ATTENTION, vous devez entrer un nom !");
            else
            {
                MyFoot.AddCollection(AjoutChamp.NewChamp);
            }
        }

        private void AjoutEquipe_Click(object sender, RoutedEventArgs e)
        {
            CreationEquipe AjoutEquipe = new CreationEquipe();
            AjoutEquipe.Owner = this;
            AjoutEquipe.ShowDialog();

            if (AjoutEquipe.NewTeam.Nom == "")
                MessageBox.Show("ATTENTION, vous devez entrer un nom !");
            else
            {

                if (!(ChampionnatsDataGrid?.SelectedItem is Championnats SelectedChamp)) return;

                SelectedChamp.AddCollection(AjoutEquipe.NewTeam);
            }
        }

        private void AjoutCoach_Click(object sender, RoutedEventArgs e)
        {
            CreationCoach AjoutCoach = new CreationCoach();
            AjoutCoach.Owner = this;
            AjoutCoach.ShowDialog();

            if (AjoutCoach.NewCoach.Nom == "")
                MessageBox.Show("ATTENTION, vous devez entrer un nom !");
            else if (AjoutCoach.NewCoach.Prenom == "")
                MessageBox.Show("ATTENTION, vous devez entrer un prénom !");
            else
            {

                if (!(EquipesDataGrid?.SelectedItem is Equipes SelectedTeam)) return;

                SelectedTeam.AddCollection(AjoutCoach.NewCoach);
            }
        }
        private void AjoutJoueur_Click(object sender, RoutedEventArgs e)
        {
            CreationJoueur AjoutJoueur = new CreationJoueur();
            AjoutJoueur.Owner = this;
            AjoutJoueur.ShowDialog();

            AjoutJoueur.NewPlayer.Position = 0;

            if (AjoutJoueur.NewPlayer.Nom == "")
                MessageBox.Show("ATTENTION, vous devez entrer un nom !");
            else if (AjoutJoueur.NewPlayer.Prenom == "")
                MessageBox.Show("ATTENTION, vous devez entrer un prénom !");

            else if (AjoutJoueur.PositionBox.Text == "1")
                AjoutJoueur.NewPlayer.Position = 1;
            else if (AjoutJoueur.PositionBox.Text == "2")
                AjoutJoueur.NewPlayer.Position = 2;
            else if (AjoutJoueur.PositionBox.Text == "3")
                AjoutJoueur.NewPlayer.Position = 3;
            else if (AjoutJoueur.PositionBox.Text == "4")
                AjoutJoueur.NewPlayer.Position = 4;
            else if (AjoutJoueur.PositionBox.Text == "5")
                AjoutJoueur.NewPlayer.Position = 5;
            else if (AjoutJoueur.PositionBox.Text == "6")
                AjoutJoueur.NewPlayer.Position = 6;
            else if (AjoutJoueur.PositionBox.Text == "7")
                AjoutJoueur.NewPlayer.Position = 7;
            else if (AjoutJoueur.PositionBox.Text == "8")
                AjoutJoueur.NewPlayer.Position = 8;
            else if (AjoutJoueur.PositionBox.Text == "9")
                AjoutJoueur.NewPlayer.Position = 9;
            else if (AjoutJoueur.PositionBox.Text == "10")
                AjoutJoueur.NewPlayer.Position = 10;
            else if (AjoutJoueur.PositionBox.Text == "11")
                AjoutJoueur.NewPlayer.Position = 11;
            else
                MessageBox.Show("ATTENTION, Position doit être un entier compris en 1 et 11 !");

            if (AjoutJoueur.NewPlayer.Position >= 1 && AjoutJoueur.NewPlayer.Position <= 11 && AjoutJoueur.NewPlayer.Nom != "" && AjoutJoueur.NewPlayer.Prenom != "")
            {

                if (!(EquipesDataGrid?.SelectedItem is Equipes SelectedTeam)) return;

                SelectedTeam.AddCollection(AjoutJoueur.NewPlayer);
            }
        }

        private void SupprimerChampionnat_Click(object sender, RoutedEventArgs e)
        {
            if (!(ChampionnatsDataGrid?.SelectedItem is Championnats SelectedChamp)) return;

            if (SelectedChamp.ListeEquipes.Count>0)
                MessageBox.Show("ATTENTION, vous devez d'abord supprimer toutes les équipes de ce championnat !");
            else
            {
                MyFoot.RemoveCollection(SelectedChamp);
            }
        }

        private void SupprimerEquipe_Click(object sender, RoutedEventArgs e)
        {
            if (!(ChampionnatsDataGrid?.SelectedItem is Championnats SelectedChamp)) return;
            if (!(EquipesDataGrid?.SelectedItem is Equipes SelectedTeam)) return;

            if (SelectedTeam.ListePersonnes.Count > 0)
                MessageBox.Show("ATTENTION, vous devez d'abord supprimer toutes les personnes de cette équipe !");
            else
            {
                SelectedChamp.RemoveCollection(SelectedTeam);
            }
        }

        private void SupprimerPersonne_Click(object sender, RoutedEventArgs e)
        {
            if (!(ChampionnatsDataGrid?.SelectedItem is Championnats SelectedChamp)) return;
            if (!(EquipesDataGrid?.SelectedItem is Equipes SelectedTeam)) return;
            if (!(PersonnesDataGrid?.SelectedItem is Personnes SelectedPersonne)) return;

            SelectedTeam.RemoveCollection(SelectedPersonne);
        }
    }
}
