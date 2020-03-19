using System;
using System.IO;
using System.Collections.Generic;
namespace separate_blog
{
    public class separate
    {
        public static List<string> blogLinks = new List<string>();
        public static List<string> nonBlogLinks = new List<string>();
        
        public static void SeparateLinks()
        { 
            var lines = File.ReadLines("links.txt");

            foreach (var line in lines)
            {
                if (line.Contains("blog"))
                {
                    blogLinks.Add(line);
                }
                else{
                    nonBlogLinks.Add(line);
                }
            }
        }
        public static void PrintLinks()
        {
            if(System.IO.File.Exists("bloglinks.txt"))System.IO.File.Delete("bloglinks.txt");
            using(StreamWriter outputfile = new StreamWriter("blogLinks.txt")){
                foreach (string item in blogLinks)
                {
                    outputfile.WriteLine(item);
                }
            }

            if(System.IO.File.Exists("bloglinks.txt"))System.IO.File.Delete("nonBlogLinks.txt");
            using(StreamWriter of = new StreamWriter("nonBlogLinks.txt")){
                foreach (string item in nonBlogLinks)
                {
                    of.WriteLine(item);
                }
            }
        }

    }
}