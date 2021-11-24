using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Md.Gfm.Models.Nodes.Abstract
{
    public enum NodeType
    {
        None = -1, // error
        Block = 0,
        Inline = 1
    }
}
