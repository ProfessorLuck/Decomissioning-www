using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
namespace blog_mover
{
    class Program
    {
        static void Main(string[] args)
        {
            MoveBlogs().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MoveBlogs()
        {   
            var linkFile = File.ReadAllLines("nonBlogLinks.txt");
            var linkList = new System.Collections.Generic.List<string>(linkFile);
            var blogList = new System.Collections.Generic.List<string>();
                
            foreach (string link in linkList)
            {
                if (link == "")
                {
                    continue;
                }
                var client = new HttpClient();
                //var response = await client.GetAsync(link);
                var response = client.GetAsync(link).ConfigureAwait(false).GetAwaiter().GetResult();
                string redirectUri = response.RequestMessage.RequestUri.AbsoluteUri;
                using (StreamWriter outputFile = File.AppendText("blogLinks.txt"))
                {
                    if (redirectUri.Contains("blog"))
                    {
                        outputFile.WriteLine(link);
                        blogList.Add(link);
                    }
                }
                
            }
            foreach (string link in blogList)
            {
                linkList.Remove(link);
            }
            File.WriteAllText("nonBlogLinks.txt", string.Empty);
            File.WriteAllLines("nonBlogLinks.txt", linkList);
        }    
    }
}
