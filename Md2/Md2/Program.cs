using Markdig;
using Md2.Dal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Md2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var ast = Markdown.Parse("Click [here](other-file.md) and another one [yo](yo.html)", true);
            //var res = new MarkdownDocumentVisitor().Visit(ast);

            // re-build all links for the repo
            using (var db = new MdDbContext())
            {
                var allLinks = db.ResolvedReferences.ToList();


                var repos = db.Repos.ToList();
                if (repos.Count == 0)
                {
                    var repo1 = new MdRepo() { Name = "docs", Url = "http://github.com/user/repo" };
                    db.Repos.Add(repo1);
                    db.SaveChanges();
                }

                var repo = db.Repos.First();
                var repoArticles = db.ResolvedReferences.Where(r => r.Repo == repo);

                if (repoArticles.Any())
                    db.Remove(repoArticles);

                foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory() + "/../../../../../demo-md-files/"))
                {
                    var content = File.ReadAllText(file);
                    var ast = Markdown.Parse(content, true);
                    var res = new MarkdownDocumentVisitor().Visit(ast);

                    var links = res.Select(l => new MdResolvedReference() { Repo = repo, SourceRelativePath = file, TargetRelativePath = l }).ToArray();
                    db.ResolvedReferences.AddRange(links);
                    db.SaveChanges();
                }

                //db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                //db.SaveChanges();
            }

            
            
        }
    }
}