using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Football_Manager
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        private MainWindow mainWindow;
        private ColorDialog MyDialog;
        private System.Windows.Media.Brush CouleurActuelFond;
        private System.Windows.Media.Brush CouleurActuelTexte;

        public Options(MainWindow mW)
        {
            InitializeComponent();
            mainWindow = mW;
            ExempleCouleurs.Background = mainWindow.dgChampionnats.RowBackground;
            ExempleCouleurs.Foreground = mainWindow.dgChampionnats.Foreground;
            CouleurActuelFond = mainWindow.dgChampionnats.RowBackground;
            CouleurActuelTexte = mainWindow.dgChampionnats.Foreground;
        }

        private void Click_CouleurTexte(object sender, System.EventArgs e)
        {
            MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;

            MyDialog.ShowDialog();
            while (MyDialog.AllowFullOpen) { }
            System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(MyDialog.Color.A, MyDialog.Color.R, MyDialog.Color.G, MyDialog.Color.B);
            SolidColorBrush brush = new SolidColorBrush(newColor);
            this.ExempleCouleurs.Foreground = brush;
        }

        private void Click_CouleurFond(object sender, RoutedEventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;

            MyDialog.ShowDialog();
            while (MyDialog.AllowFullOpen) { }
            System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(MyDialog.Color.A, MyDialog.Color.R, MyDialog.Color.G, MyDialog.Color.B);
            SolidColorBrush brush = new SolidColorBrush(newColor);
            this.ExempleCouleurs.Background = brush;
        }

        private void Option_Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Option_Cancel_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.dgChampionnats.RowBackground = CouleurActuelFond;
            mainWindow.dgChampionnats.Foreground = CouleurActuelTexte;
            mainWindow.dgEquipes.RowBackground = CouleurActuelFond;
            mainWindow.dgEquipes.Foreground = CouleurActuelTexte;
            mainWindow.dgPersonnes.RowBackground = CouleurActuelFond;
            mainWindow.dgPersonnes.Foreground = CouleurActuelTexte;
            this.Close();
        }

        private void Option_Appliquer_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.dgChampionnats.RowBackground = ExempleCouleurs.Background;
            mainWindow.dgChampionnats.Foreground = ExempleCouleurs.Foreground;
            mainWindow.dgEquipes.RowBackground = ExempleCouleurs.Background;
            mainWindow.dgEquipes.Foreground = ExempleCouleurs.Foreground;
            mainWindow.dgPersonnes.RowBackground = ExempleCouleurs.Background;
            mainWindow.dgPersonnes.Foreground = ExempleCouleurs.Foreground;
        }
    }
}
