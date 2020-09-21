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
    /// Interaction logic for CreationEquipe.xaml
    /// </summary>
    public partial class CreationEquipe : Window
    {

        string image = "Images/TeamWithoutPic.jpg";
        public Equipes NewTeam = new Equipes();

        public CreationEquipe()
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
                NewTeam.Nom = NameBox.Text;
                NewTeam.DateCreation = DateTime.Now;

                if (LogoBox.Text == "" || LogoBox.Text == "none")
                    NewTeam.Logo = image;
                else
                    NewTeam.Logo = LogoBox.Text;
           //}*/

           this.Close();

        }
    }
    
}
