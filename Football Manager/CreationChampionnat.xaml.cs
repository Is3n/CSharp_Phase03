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
    /// Interaction logic for CreationChampionnat.xaml
    /// </summary>
    public partial class CreationChampionnat : Window
    {
        string image = "Images/logo_FIFA.svg.png";
        public Championnats NewChamp = new Championnats();

        public CreationChampionnat()
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
                NewChamp.Nom = NameBox.Text;
                NewChamp.DateCreation = DateTime.Now;

                if (LogoBox.Text == "" || LogoBox.Text == "none")
                    NewChamp.Logo = image;
                else
                    NewChamp.Logo = LogoBox.Text;
            //}*/

            this.Close();

        }
    }
}
