using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Md2.Dal
{
    public class MdDbContext : DbContext
    {
        public DbSet<MdRepo> Repos { get; set; }
        public DbSet<MdResolvedReference> ResolvedReferences { get; set; }
        public string DbPath { get; }

        public MdDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "markdown.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class MdRepo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class MdResolvedReference
    {
        public Guid Id { get; set; }
        public MdRepo Repo { get; set; }
        // public string Branch {get;set;}
        public string SourceRelativePath { get; set; }
        public string TargetRelativePath { get; set; }
    }
}
