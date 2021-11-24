using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Md.FileProcessor
{
    public class LolTemplate
    {
        private string Path { get; }

        public LolTemplate(string path)
        {
            Path = path;
        }

        public string ArticleTemplate { get { return File.ReadAllText($"{Path}/Article.liquid"); } }
    }
}
