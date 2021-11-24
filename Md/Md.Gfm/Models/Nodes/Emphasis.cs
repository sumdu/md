using Md.Gfm.Models.Nodes.Abstract;
using System;

namespace Md.Gfm.Models.Nodes
{
    /// <summary>
    /// Italic inline block
    /// </summary>
    public class Emphasis : AbstractNode
    {
        public Emphasis()
        {
            NodeType = NodeType.Inline;
        }

        public override bool CanContainElement(AbstractNode node)
        {
            throw new NotImplementedException();
        }
    }
}
