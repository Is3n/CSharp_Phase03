using MyFootballObjects;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Football_Manager
{
    /// <summary>
    /// Interaction logic for CreationJoueur.xaml
    /// </summary>
    public partial class CreationJoueur : Window
    {

        string image = "Images/PersonneWithoutPic.jpeg";
        public Joueurs NewPlayer = new Joueurs();

        public CreationJoueur()
        {
            InitializeComponent();
            AffDateCreation.Text = DateTime.Now.ToString();
        }

        private void BoutonOK_Click(object sender, RoutedEventArgs e)
        {
            /*if(NameBox.Text == "")
                 MessageBox.Show("ATTENTION, vous devez entrer un nom !");
            else
            {*/
            NewPlayer.Nom = LastNameBox.Text;
            NewPlayer.Prenom = FirstNameBox.Text;
            NewPlayer.DateNaissance = (System.DateTime)DateNaissancePicker.SelectedDate;
            NewPlayer.DebutActivite = DateTime.Now;


            if (PhotoBox.Text == "" || PhotoBox.Text == "none")
                NewPlayer.Photo = image;
            else
                NewPlayer.Photo = PhotoBox.Text;
            //}*/

            this.Close();

        }
    }
}

