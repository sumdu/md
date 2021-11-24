using Md.Gfm.Models.Nodes;
using Md.Gfm.Models.Nodes.Abstract;
using Md.Gfm.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Md.Gfm.Models.Parsers
{
    interface IAbstractParser
    {
        bool TryParse(ParserContext context, out AbstractNode node);
    }
}
