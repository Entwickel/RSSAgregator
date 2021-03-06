using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Collections.Specialized;

namespace RSSAgregator
{
    class RSSFile
    {
        public SyndicationFeed rssFeed;
        public bool is_rss_loaded; 
        public List<MyItems> list_rss_content = new List<MyItems>();
        public string rss_source;
        public RSSFile(string url)
        {
            is_rss_loaded = false;
            try
            {

                XmlReader reader = XmlReader.Create(url);
                rssFeed = SyndicationFeed.Load(reader);
                is_rss_loaded = true;

            }
            catch
            {
                Debug.WriteLine("erreur");

            }

        }

        public int Obtenir_RSS_Content(int nombre)
        {
            //Contain each row for RSS
            int increment = 0;
            rss_source = rssFeed.Generator;
            if (rss_source == null)
                rss_source = rssFeed.Title.Text;
            foreach (SyndicationItem item in rssFeed.Items)
            {
                MyItems rss_row = new MyItems();
                rss_row.Titre = item.Title.Text;
                rss_row.Date = item.PublishDate.ToString();
                list_rss_content.Add(rss_row);
                increment = increment + 1;
                if (increment >= nombre)
                    return Constants.SUCCESS;
            }
            return Constants.SUCCESS;



        }

    }


}
