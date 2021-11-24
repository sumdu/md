using Md.Gfm.Models.Nodes.Abstract;
using System;

namespace Md.Gfm.Models.Nodes
{
    public class SoftBreak : AbstractNode
    {
        public SoftBreak()
        {
            NodeType = NodeType.Inline;
        }

        public override bool CanContainElement(AbstractNode node)
        {
            throw new NotImplementedException();
        }
    }
}
