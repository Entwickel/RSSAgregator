using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using RSSAgregator;

namespace RSSAgregator
{
    class Controlleur
    {
        public int x_fenetre;
        public int y_fenetre;


        public Controlleur(int x, int y)
        {
            x_fenetre = x;
            y_fenetre = y;
            Initialiser_taille_fenetre(x, y);
            RSSFile cur_flux = new RSSFile(Environment.CurrentDirectory + @"\Nautilion.xml\");
            if (cur_flux.is_rss_loaded == true) //on vérifie si le contenu à bien été chargé, sinon on traite
                cur_flux.Display_RSS_Content();
            else
                Erreur_chargement_rss();

        }

        public void Initialiser_taille_fenetre(int x, int y)
        {
            //App.Current.MainWindow access the Mainwindows Instance. Source : https://stackoverflow.com/questions/19647375/wpf-how-do-i-get-the-mainwindow-instance
            App.Current.MainWindow.Title = "RSS Agregator";
            App.Current.MainWindow.Width = x;
            App.Current.MainWindow.Height = y;

        }

        //TODO
        public void Erreur_chargement_rss()
        {
            Debug.WriteLine("erreur de chargement rss");

        }


    }
}
