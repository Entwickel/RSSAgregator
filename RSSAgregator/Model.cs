using System;
using System.Collections.Generic;
using System.Text;

namespace RSSAgregator
{

    public static class Constants
    {
        public const int SUCCESS = 1;
        public const int FAILURE = 0;
    }

    public class MyItems 
    {
        public string Titre { get; set; }
        public string Date { get; set; }
    }
    class Model
    {
        public RSSFile cur_flux;
        public Model()
        {
            //DO NOthing
        }

        public bool Obtenir_flux_rss(string url)
        {
            cur_flux = new RSSFile(url);
            return cur_flux.is_rss_loaded;

        }

    }
}
