using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Md2
{
    internal class MarkdownDocumentVisitor
    {
        public List<string> Visit(MarkdownDocument document)
        {
            var res = new List<string>();

            if (document == null)
            {
                return res;
            }

            ExtractContainerBlock(document, res);

            return res;
        }

        public void ExtractContainerBlock(ContainerBlock blocks, List<string> res)
        {
            for (var i = 0; i < blocks.Count; i++)
            {
                var block = blocks[i];
                if (block is LeafBlock leafBlock && leafBlock.Inline != null)
                {
                    ExtractContainerInline(leafBlock.Inline, res);
                }
                else if (block is ContainerBlock containerBlock)
                {
                    ExtractContainerBlock(containerBlock, res);
                }
            }
        }

        private void ExtractContainerInline(ContainerInline inlines, List<string> res)
        {
            foreach (var inline in inlines)
            {
                if (inline is LeafInline leafInline)
                {
                    
                }
                else if (inline is ContainerInline containerInline)
                {
                    if (inline is LinkInline linkInline)
                    {
                        res.Add(linkInline.Url);
                    }

                    ExtractContainerInline(containerInline, res);
                }
            }
        }
    }
}
