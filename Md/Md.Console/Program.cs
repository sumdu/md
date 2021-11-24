using Md.Gfm.Parser;
using System;

namespace Md.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var markdown = "######### Heading text";
            var parser = new MarkdownParser();
            var res = parser.Parse(markdown);

        }
    }
}
