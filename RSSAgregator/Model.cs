using System;
using System.Collections.Generic;
using System.Text;

namespace RSSAgregator
{
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
