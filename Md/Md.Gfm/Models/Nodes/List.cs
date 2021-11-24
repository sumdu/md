using Md.Gfm.Models.Nodes.Abstract;
using System;

namespace Md.Gfm.Models.Nodes
{
    public class List : AbstractNode
    {
        public List()
        {
            NodeType = NodeType.Block;
        }

        public override bool CanContainElement(AbstractNode node)
        {
            throw new NotImplementedException();
        }

        public char BulletChar { get; set; }
    }
}
