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
    /// Interaction logic for CreationCoach.xaml
    /// </summary>
    public partial class CreationCoach : Window
    {

        string image = "Images/PersonneWithoutPic.jpeg";
        public Entraineurs NewCoach = new Entraineurs();

        public CreationCoach()
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
            NewCoach.Nom = LastNameBox.Text;
            NewCoach.Prenom = FirstNameBox.Text;
            NewCoach.DateNaissance = (System.DateTime) DateNaissancePicker.SelectedDate;
            NewCoach.DebutActivite = DateTime.Now;

            if (PhotoBox.Text == "" || PhotoBox.Text == "none")
                NewCoach.Photo = image;
            else
                NewCoach.Photo = PhotoBox.Text;
            //}*/

            this.Close();

        }
    }
}
