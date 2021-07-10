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
        public RSSFile(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            if (reader == null)
            {
                Debug.WriteLine("erreur");
            }
            else
            {
                rssFeed = SyndicationFeed.Load(reader);

            }

        }

        public void Display_RSS_Content()
        {
            foreach (SyndicationItem item in rssFeed.Items)
            {
                Debug.WriteLine("BONJOUR MONDE : " + item.Title.Text);
                Debug.WriteLine("BONJOUR MONDE : " + item.Links.ToString());
                Debug.WriteLine("BONJOUR MONDE : " + item.PublishDate);

            }
            

        }

    }


}
