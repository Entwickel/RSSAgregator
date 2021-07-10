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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RSSAgregator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TabControl tbControl; //utiliser pour gérer les onglets
        public MainWindow()
        {
            InitializeComponent();
            Controlleur rss = new Controlleur(800,600); //initialise la taille de la fenetre et lance l'instance principale

        }

        private void tbCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            tbControl = (sender as TabControl);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TabItem newTabItem = new TabItem
            {
                Header = "Test",
                Name = "Test"
            };
            tbControl.Items.Add(newTabItem);
        }
    }
}
