using Md.Gfm.Models;
using Md.Gfm.Models.Nodes;
using Md.Gfm.Models.Nodes.Abstract;
using Md.Gfm.Models.Parsers;
using System.Collections.Generic;

namespace Md.Gfm.Parser
{
    public class MarkdownParser
    {
        public AbstractSyntaxTree Parse(string markdown)
        {
            var parsers = AllParsers.Get();
            var context = new ParserContext(markdown);

            var res = new AbstractSyntaxTree();
            res.Root = new Document();

            res.Root.Children = new List<AbstractNode>();

            res.Root.DbgMarkdownText = markdown;
            res.Root.DbgLineNumber = context.GetLineNumber();
            res.Root.DbgStartPos = 0;
            res.Root.DbgLen = 0;

            while (true)
            {
                foreach (var parser in parsers)
                {
                    if (parser.TryParse(context, out var node))
                    {
                        res.Root.Children.Add(node);
                        break;
                    }
                }

                if (!context.HasMoreLines())
                {
                    break;
                }
                context.MoveToNextLine();
            };

            return res;
        }        
    }
}
