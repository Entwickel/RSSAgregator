using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
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
        TabControl tbControl; //Main Widget to manage tab
        int number_tab = 1;
        bool tbCtrl_Is_Loaded = false;
        //TODO properly Queue
        public Queue<String> tab_to_create;
        public MainWindow()
        {
            InitializeComponent();
            //instancie the queue for the tab management
            tab_to_create = new Queue<String>();
            Controlleur rss = new Controlleur(800,600); //initialise window size and run main instance
        }

        //Permet d'afficher les infos dans la listeview
        public void display_RSS(List<MyItems> rss_flux, int tab, string tab_name)
        {
            //if tab is not exist
            if (tab > number_tab)
            {
                tab_to_create.Enqueue(tab_name);
            }

            GridView gridView = new GridView();
            ListProfile.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Date",
                DisplayMemberBinding = new Binding("Date")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Titre",
                DisplayMemberBinding = new Binding("Titre")
            });

            //TODO
            foreach (MyItems rss in rss_flux)
            {
                ListProfile.Items.Add(rss);

            }

        }

        public void Create_tab(string name,int number)
        {
            TabItem newTabItem = new TabItem
            {
                Header = name,
                Name = "tab" + number_tab.ToString()
            };
            //TODO propoer the gestion of the new_tab item

            //Store adding new in a temp var
            TabItem temp = Adding_New_Tab;

            //Remove new_tab_item for add him on the left after
            tbControl.Items.Remove(Adding_New_Tab);
            newTabItem.IsSelected = true;
            tbControl.Items.Add(newTabItem);
            number_tab += 1;

            //Finally add temporay item at the end of the list tab, not really proper ..
            tbControl.Items.Add(temp);

        }

        public void Manage_tab_in_queue()
        {
            int current_tab = 1;
            foreach(string name in tab_to_create) 
            {
                Create_tab(name, current_tab);
            }


        }

        // Interaction logic for Window Event
        private void tbCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            tbControl = (sender as TabControl);
            tbCtrl_Is_Loaded = true;
            Manage_tab_in_queue();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int tab_indice = number_tab + 1;
            Create_tab("Onglet" + tab_indice.ToString(),tab_indice);
         
        }


    }
}
