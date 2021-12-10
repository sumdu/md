using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Md2.Models
{
    public class DocRepoInfoCollection : List<DocRepoInfo>
    {
        public string LocalGitDirRoot { get; set; }
    }
}
