using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;


namespace RSSAgregator
{
    class RSSFile
    {
        //Dictionary<string, string> rssFetch;
        public RSSFile(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            while (reader.Read())
            {
                Debug.WriteLine(reader.Value);

            }

        }

    }


}
