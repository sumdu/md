using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Md.Gfm.Models.Parsers
{
    static class AllParsers
    {
        public static IList<IAbstractParser> Get()
        {
            return new List<IAbstractParser>
            {
                new HeadingParser()
            };
        }
    }
}
