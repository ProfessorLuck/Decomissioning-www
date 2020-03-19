using System;
using System.IO;

namespace separate_blog
{
    class Program
    {
        static void Main(string[] args)
        {
            separate.SeparateLinks();
            separate.PrintLinks();
        }
    }
}
