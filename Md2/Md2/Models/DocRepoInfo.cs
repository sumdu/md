using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Md2.Models
{
    public class DocRepoInfo
    {
        /// <summary>
        /// Account name
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Repo name
        /// </summary>
        public string RepoName { get; set; }

        /// <summary>
        /// Branch name
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// If documentaion is inside of a subfolder, then work with subfolder only
        /// </summary>
        public string RelativePathToRepoRoot { get; set; }

        /// <summary>
        /// Github URL
        /// </summary>
        public string RepoUrl { get { return String.Format("https://github.com/{0}/{1}", AccountName, RepoName); } }

        public string DownloadUrl { get { return String.Format("https://api.github.com/repos/{0}/{1}/zipball/{2}", AccountName, RepoName, Branch); } }
    }
}
