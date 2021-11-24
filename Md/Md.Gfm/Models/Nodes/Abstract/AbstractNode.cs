using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Md.Gfm.Models.Nodes.Abstract
{
    public abstract class AbstractNode
    {
        public NodeType NodeType { get; protected set; }
        public abstract bool CanContainElement(AbstractNode node);

        public IList<AbstractNode> Children { get; set; }

        public AbstractNode Parent { get; set; }
        //public AbstractNode Next { get; set; }
        //public AbstractNode Previous { get; set; }
        //public AbstractNode FirstChild { get; set; }
        //public AbstractNode LastChild { get; set; }

        public string DbgMarkdownText { get; set; }
        public int DbgLineNumber { get; set; }
        public int DbgStartPos { get; set; }
        public int DbgLen { get; set; }
    }
}
