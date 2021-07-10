using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.ServiceModel.Syndication;

namespace RSSAgregator
{
    class RSSFile
    {
        SyndicationFeed rssFeed;
        public bool is_rss_loaded; //verouille en écriture
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

        public void Display_RSS_Content()
        {
            foreach (SyndicationItem item in rssFeed.Items)
            {
                Debug.WriteLine("BONJOUR MONDE : " + item.Title.Text);
                Debug.WriteLine("BONJOUR MONDE : " + item.PublishDate);
                Debug.WriteLine("BONJOUR MONDE : " + item.Content);

            }


        }

    }


}
