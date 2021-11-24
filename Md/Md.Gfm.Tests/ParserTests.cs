using Md.Gfm.Models.Nodes;
using NUnit.Framework;

namespace Md.Gfm.Tests
{
    public class ParserTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        //[Test]
        //public void ParseReturnsAbstractTree()
        //{
        //    var parser = new TreeParser();
        //    var tree = parser.Parse("");

        //    Assert.IsNotNull(tree);
        //    Assert.IsNotNull(tree.Nodes);
        //    Assert.AreEqual(0, tree.Nodes.Count);
        //}

        //[Test]
        //public void ParseHeader1()
        //{
        //    var parser = new TreeParser();
        //    var tree = parser.Parse("# Hello");
            
        //    Assert.AreEqual(1, tree.Nodes.Count);
        //    Assert.IsInstanceOf(typeof(Heading), tree.Nodes[0]);
        //    var p = (Heading)tree.Nodes[0];
        //    Assert.AreEqual(1, p.Level);
        //    Assert.AreEqual("Hello", p.Text);
        //}

        //[Test]
        //public void ParseMustPreserveInternalTabs()
        //{
        //    var parser = new TreeParser();
        //    var tree = parser.Parse("`foo\tbar\t\tbim`");

        //    Assert.AreEqual(1, tree.Nodes.Count);
        //    Assert.IsInstanceOf(typeof(InlineCode), tree.Nodes[0]);
        //    var p = (InlineCode)tree.Nodes[0];
        //    Assert.AreEqual("foo\tbar\t\tbim", p.Text);
        //}
    }
}