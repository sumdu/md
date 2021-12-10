using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Md2.Common
{
    public class ZipService
    {
        public void Unzip(string filename, string destinationFolder)
        {
            ZipFile.ExtractToDirectory(filename, destinationFolder);
        }
    }
}
