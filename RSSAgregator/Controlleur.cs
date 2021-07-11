using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using RSSAgregator;

namespace RSSAgregator
{
    class Controlleur
    {
        public int x_fenetre;
        public int y_fenetre;
        public Model model;


        public Controlleur(int x, int y)
        {
            x_fenetre = x;
            y_fenetre = y;
            model = new Model();
            Initialiser_taille_fenetre(x, y);
            Charger_flux_rss();
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

        public int Charger_flux_rss()
        {
            string url = Charger_profile(Environment.CurrentDirectory + @"\profile1.txt");
            Debug.WriteLine("URL = ::::::" + url);
            bool success = model.Obtenir_flux_rss(url);
            if (success == true)
            {//on vérifie si le contenu à bien été chargé, sinon on traite
                int code_return = model.cur_flux.Obtenir_RSS_Content(3);
                if (code_return == Constants.SUCCESS)
                {
                    var main = App.Current.MainWindow as MainWindow;
                    main.display_RSS(model.cur_flux.list_rss_content);
                    return Constants.SUCCESS;
                }
                else
                {
                    //END programm
                    return Constants.FAILURE; 

                }

            }
            else
            {
                return Constants.FAILURE;
            }

        }

        public string Charger_profile(string path)
        {
            Debug.WriteLine(path);
            if (File.Exists(path))
            {
                //première URL
                return File.ReadAllLines(path)[0];
            }
            else
            {
                return ""; 
                //ERREUR
            }
            //TODO recup parametre initialisation

        }



    }
}
