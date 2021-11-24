using Md.Gfm.Models.Nodes.Abstract;
using System;

namespace Md.Gfm.Models.Nodes
{
    public class LineBreak : AbstractNode
    {
        public LineBreak()
        {
            NodeType = NodeType.Inline;
        }

        public override bool CanContainElement(AbstractNode node)
        {
            throw new NotImplementedException();
        }
    }
}
