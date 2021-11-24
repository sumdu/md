using Md.Gfm.Models.Nodes.Abstract;
using System;

namespace Md.Gfm.Models.Nodes
{
    public class BlockQuote : AbstractNode
    {
        public BlockQuote()
        {
            NodeType = NodeType.Block;
        }

        public override bool CanContainElement(AbstractNode node)
        {
            throw new NotImplementedException();
        }
    }
}
