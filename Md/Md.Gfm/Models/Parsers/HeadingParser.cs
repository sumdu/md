using Md.Gfm.Models.Nodes;
using Md.Gfm.Models.Nodes.Abstract;
using Md.Gfm.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Md.Gfm.Models.Parsers
{
    class HeadingParser : IAbstractParser
    {
        public bool TryParse(ParserContext context, out AbstractNode node)
        {
            var res = false;
            Heading resNode = null;

            var txt = context.GetLine().Trim();
            var match = Regex.Match(txt, @"(?<hashtag>#+)\s(?<text>.+)", RegexOptions.Compiled);
            if (match.Success)
            {
                res = true;
                resNode = new Heading();
                resNode.Level = match.Groups["hashtag"].Value.Length;
                resNode.DbgMarkdownText = match.Groups["text"].Value;

                context.MoveToNextLine();
            }

            node = resNode;
            return res;
        }
    }
}
