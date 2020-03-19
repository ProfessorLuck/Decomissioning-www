using System;
using System.IO;

namespace filtered_output
{
    class Program
    {
        static void Main(string[] args)
        {
            Filter();
        }

        static void Filter()
        {
            var inputFile = File.ReadLines("outputFile.txt");
            var urlList = new System.Collections.Generic.List<string>(inputFile);
            string[] Urls;
            var filteredUrls = new System.Collections.Generic.List<string>();

            foreach (string url in urlList)
            {
                Urls = (url.Split("\t"));
                if (Urls[1].StartsWith("https://secure.ncte.org"))
                {
                    filteredUrls.Add(Urls[1]);
                }
            }
        }
    }
}
