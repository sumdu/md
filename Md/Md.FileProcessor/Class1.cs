using DotLiquid;
using Markdig;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Md.FileProcessor
{
    public class FileProcessor
    {
        public void Process()
        {
            // collect all current dependencies

            // build in memory?

            // get new dependencies

            // replace dependencies

            var s = "Hello dear *User*!";
            // Microsoft.Docs.Build.PageBuilder -> LoadMarkdown()
            var html = Markdown.ToHtml(s);

            // Microsoft.Docs.Build.LiquidTemplate -> Render()    return template.Render(parameters);
            var templateBasePath = $"c:/temp/";
            
            var templateName = "templat123";
            var templatePath = $"{templateBasePath}/{templateName}.html.liquid";
            var templateString = File.ReadAllText(templatePath);

            // for testing purposes
            templateString = "<html> {{article_content}} </html>";

            var template = Template.Parse(templateString);
            template.MakeThreadSafe();
            //Template.FileSystem = "c:/temp/mytemplate/"; // absolute path

            var registers = new Hash
            {
                ["template_base_path"] = templateBasePath
            };

            var environments = new List<Hash>();
            environments.Add(new Hash
            {
                ["article_content"] = html,
            });

            var context = new DotLiquid.Context(
                    environments: environments,
                    outerScope: new Hash(),
                    registers: registers,
                    errorsOutputMode: ErrorsOutputMode.Rethrow,
                    maxIterations: 0,
                    formatProvider: CultureInfo.InvariantCulture,
                    cancellationToken: default
                    );

            var parameters = new RenderParameters(CultureInfo.InvariantCulture)
            {
                Context = context
            };

            var res = template.Render(parameters);
        }
    }
}
