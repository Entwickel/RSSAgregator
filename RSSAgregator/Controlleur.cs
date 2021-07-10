﻿using System;
using System.Collections.Generic;
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
            RSSFile cur_flux = new RSSFile("https://www.nautiljon.com/actualite/rss.php");
        }

        public void Initialiser_taille_fenetre(int x, int y)
        {
            //App.Current.MainWindow access the Mainwindows Instance. Source : https://stackoverflow.com/questions/19647375/wpf-how-do-i-get-the-mainwindow-instance
            App.Current.MainWindow.Title = "RSS Agregator";
            App.Current.MainWindow.Width = x;
            App.Current.MainWindow.Height = y;

        }


    }
}
