using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Xml;
namespace final_output
{
    class Program
    {
        static void Main(string[] args)
        {
            ParseLinks();
        }

        static void ParseLinks()
        {
            var inputFile = File.ReadLines("nonBlogLinks.txt");
            var urlList = new System.Collections.Generic.List<string>(inputFile);
            var newUrlList = new System.Collections.Generic.List<string>();
            var counter = 0;
            foreach (string url in urlList)
            {
                if (url == "")
                {
                    continue;
                }
                counter++;
                Console.WriteLine(counter);
                var html = @url;
                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");
                if (!(node.InnerHtml.StartsWith("page not found", StringComparison.InvariantCultureIgnoreCase)))
                {
                    foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//a"))
                    {
                        if (link.Attributes["href"] != null && link.Attributes["href"].Value != null)
                        {
                            if (link.Attributes["href"].Value.StartsWith("http://www.ncte.org") || link.Attributes["href"].Value.StartsWith("https://www.ncte.org") || link.Attributes["href"].Value.StartsWith("http://ncte.org") || link.Attributes["href"].Value.StartsWith("https://ncte.org") || link.Attributes["href"].Value.StartsWith("http://secure.ncte.org") || link.Attributes["href"].Value.StartsWith("https://secure.ncte.org"))
                            {
                                newUrlList.Add(url + "\t" + link.Attributes["href"].Value);
                            }
                        }
                    }
                }
            }
            File.WriteAllText("outputfile.txt", string.Empty);
            File.WriteAllLines("outputfile.txt", newUrlList);
        }
    }
}
