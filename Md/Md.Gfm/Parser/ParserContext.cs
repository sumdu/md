using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Md.Gfm.Parser
{
    class ParserContext
    {
        private string markdown;
        private string[] lines;
        private int currentLine;
        private bool contextFullyProcessed;

        private readonly string LINE_INDENT = "    ";

        public ParserContext(string markdown)
        {
            this.markdown = markdown;
            this.lines = markdown.Split('\r', '\n');
            this.currentLine = 0;
            this.contextFullyProcessed = false;
        }

        public bool HasMoreLines()
        {
            return !contextFullyProcessed && currentLine < lines.Length - 1;
        }

        public void MoveToNextLine()
        {
            if (contextFullyProcessed)
                throw new Exception("No more lines");

            if (HasMoreLines())
                currentLine++;
            else
                contextFullyProcessed = true;
        }

        public string GetLine()
        {
            if (contextFullyProcessed)
                throw new Exception("No more lines");

            return lines[currentLine];
        }

        public int GetLineNumber()
        {
            if (contextFullyProcessed)
                throw new Exception("No more lines");

            return currentLine;
        }

        public bool IsIndented()
        {
            if (contextFullyProcessed)
                throw new Exception("No more lines");

            return lines[currentLine].StartsWith(LINE_INDENT);
        }

        // not sure if this is ok. maybe need to 
        public string PeekNextLine()
        {
            if (contextFullyProcessed)
                throw new Exception("No more lines");

            // this needs to be move complicated
            // maybe "PeelNextNonEmptyLine"
            if (!HasMoreLines())
                throw new Exception("No more lines");

            return lines[currentLine + 1];
        }
    }
}
