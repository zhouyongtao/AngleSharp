using AngleSharp.Dom;
using NUnit.Framework;

namespace AngleSharp.Core.Tests
{
    /// <summary>
    /// Tests from https://github.com/html5lib/html5lib-tests:
    /// tree-construction/ruby.dat
    /// </summary>
    [TestFixture]
    public class RubyElementTests
    {
        [Test]
        public void RubyElementImpliedEndForRbWithRb()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rb>b<rb></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rb1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rb1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rb1).Attributes.Count);
            Assert.AreEqual("rb", dochtml0body1ruby0rb1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rb1.NodeType);

            var dochtml0body1ruby0rb1Text0 = dochtml0body1ruby0rb1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rb1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rb1Text0.TextContent);

            var dochtml0body1ruby0rb2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rb2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rb2).Attributes.Count);
            Assert.AreEqual("rb", dochtml0body1ruby0rb2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rb2.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRbWithRt()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rb>b<rt></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rb1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rb1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rb1).Attributes.Count);
            Assert.AreEqual("rb", dochtml0body1ruby0rb1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rb1.NodeType);

            var dochtml0body1ruby0rb1Text0 = dochtml0body1ruby0rb1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rb1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rb1Text0.TextContent);

            var dochtml0body1ruby0rt2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rt2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rt2).Attributes.Count);
            Assert.AreEqual("rt", dochtml0body1ruby0rt2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rt2.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRbWithRtc()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rb>b<rtc></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rb1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rb1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rb1).Attributes.Count);
            Assert.AreEqual("rb", dochtml0body1ruby0rb1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rb1.NodeType);

            var dochtml0body1ruby0rb1Text0 = dochtml0body1ruby0rb1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rb1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rb1Text0.TextContent);

            var dochtml0body1ruby0rtc2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rtc2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc2).Attributes.Count);
            Assert.AreEqual("rtc", dochtml0body1ruby0rtc2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc2.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRbWithRp()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rb>b<rp></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rb1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rb1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rb1).Attributes.Count);
            Assert.AreEqual("rb", dochtml0body1ruby0rb1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rb1.NodeType);

            var dochtml0body1ruby0rb1Text0 = dochtml0body1ruby0rb1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rb1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rb1Text0.TextContent);

            var dochtml0body1ruby0rp2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rp2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rp2).Attributes.Count);
            Assert.AreEqual("rp", dochtml0body1ruby0rp2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rp2.NodeType);
        }

        [Test]
        public void RubyElementNoImpliedEndForRbWithSpan()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rb>b<span></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(2, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rb1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(2, dochtml0body1ruby0rb1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rb1).Attributes.Count);
            Assert.AreEqual("rb", dochtml0body1ruby0rb1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rb1.NodeType);

            var dochtml0body1ruby0rb1Text0 = dochtml0body1ruby0rb1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rb1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rb1Text0.TextContent);

            var dochtml0body1ruby0rb1span1 = dochtml0body1ruby0rb1.ChildNodes[1];
            Assert.AreEqual(0, dochtml0body1ruby0rb1span1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rb1span1).Attributes.Count);
            Assert.AreEqual("span", dochtml0body1ruby0rb1span1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rb1span1.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRtWithRb()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rt>b<rb></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rt1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rt1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rt1).Attributes.Count);
            Assert.AreEqual("rt", dochtml0body1ruby0rt1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rt1.NodeType);

            var dochtml0body1ruby0rt1Text0 = dochtml0body1ruby0rt1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rt1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rt1Text0.TextContent);

            var dochtml0body1ruby0rb2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rb2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rb2).Attributes.Count);
            Assert.AreEqual("rb", dochtml0body1ruby0rb2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rb2.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRtWithRt()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rt>b<rt></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rt1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rt1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rt1).Attributes.Count);
            Assert.AreEqual("rt", dochtml0body1ruby0rt1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rt1.NodeType);

            var dochtml0body1ruby0rt1Text0 = dochtml0body1ruby0rt1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rt1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rt1Text0.TextContent);

            var dochtml0body1ruby0rt2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rt2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rt2).Attributes.Count);
            Assert.AreEqual("rt", dochtml0body1ruby0rt2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rt2.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRtWithRtc()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rt>b<rtc></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rt1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rt1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rt1).Attributes.Count);
            Assert.AreEqual("rt", dochtml0body1ruby0rt1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rt1.NodeType);

            var dochtml0body1ruby0rt1Text0 = dochtml0body1ruby0rt1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rt1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rt1Text0.TextContent);

            var dochtml0body1ruby0rtc2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rtc2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc2).Attributes.Count);
            Assert.AreEqual("rtc", dochtml0body1ruby0rtc2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc2.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRtWithRp()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rt>b<rp></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rt1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rt1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rt1).Attributes.Count);
            Assert.AreEqual("rt", dochtml0body1ruby0rt1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rt1.NodeType);

            var dochtml0body1ruby0rt1Text0 = dochtml0body1ruby0rt1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rt1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rt1Text0.TextContent);

            var dochtml0body1ruby0rp2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rp2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rp2).Attributes.Count);
            Assert.AreEqual("rp", dochtml0body1ruby0rp2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rp2.NodeType);
        }

        [Test]
        public void RubyElementNoImpliedEndForRtWithSpan()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rt>b<span></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(2, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rt1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(2, dochtml0body1ruby0rt1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rt1).Attributes.Count);
            Assert.AreEqual("rt", dochtml0body1ruby0rt1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rt1.NodeType);

            var dochtml0body1ruby0rt1Text0 = dochtml0body1ruby0rt1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rt1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rt1Text0.TextContent);

            var dochtml0body1ruby0rt1span1 = dochtml0body1ruby0rt1.ChildNodes[1];
            Assert.AreEqual(0, dochtml0body1ruby0rt1span1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rt1span1).Attributes.Count);
            Assert.AreEqual("span", dochtml0body1ruby0rt1span1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rt1span1.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRtcWithRb()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rtc>b<rb></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rtc1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rtc1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc1).Attributes.Count);
            Assert.AreEqual("rtc", dochtml0body1ruby0rtc1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc1.NodeType);

            var dochtml0body1ruby0rtc1Text0 = dochtml0body1ruby0rtc1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rtc1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rtc1Text0.TextContent);

            var dochtml0body1ruby0rb2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rb2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rb2).Attributes.Count);
            Assert.AreEqual("rb", dochtml0body1ruby0rb2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rb2.NodeType);
        }

        [Test]
        public void RubyElementNoImpliedEndForRtcWithRt()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rtc>b<rt>c<rt>d</ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(2, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rtc1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(3, dochtml0body1ruby0rtc1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc1).Attributes.Count);
            Assert.AreEqual("rtc", dochtml0body1ruby0rtc1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc1.NodeType);

            var dochtml0body1ruby0rtc1Text0 = dochtml0body1ruby0rtc1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rtc1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rtc1Text0.TextContent);

            var dochtml0body1ruby0rtc1rt1 = dochtml0body1ruby0rtc1.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rtc1rt1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc1rt1).Attributes.Count);
            Assert.AreEqual("rt", dochtml0body1ruby0rtc1rt1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc1rt1.NodeType);

            var dochtml0body1ruby0rtc1rt1Text0 = dochtml0body1ruby0rtc1rt1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rtc1rt1Text0.NodeType);
            Assert.AreEqual("c", dochtml0body1ruby0rtc1rt1Text0.TextContent);

            var dochtml0body1ruby0rtc1rt2 = dochtml0body1ruby0rtc1.ChildNodes[2];
            Assert.AreEqual(1, dochtml0body1ruby0rtc1rt2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc1rt2).Attributes.Count);
            Assert.AreEqual("rt", dochtml0body1ruby0rtc1rt2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc1rt2.NodeType);

            var dochtml0body1ruby0rtc1rt2Text0 = dochtml0body1ruby0rtc1rt2.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rtc1rt2Text0.NodeType);
            Assert.AreEqual("d", dochtml0body1ruby0rtc1rt2Text0.TextContent);
        }

        [Test]
        public void RubyElementImpliedEndForRtcWithRtc()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rtc>b<rtc></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rtc1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rtc1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc1).Attributes.Count);
            Assert.AreEqual("rtc", dochtml0body1ruby0rtc1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc1.NodeType);

            var dochtml0body1ruby0rtc1Text0 = dochtml0body1ruby0rtc1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rtc1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rtc1Text0.TextContent);

            var dochtml0body1ruby0rtc2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rtc2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc2).Attributes.Count);
            Assert.AreEqual("rtc", dochtml0body1ruby0rtc2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc2.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRtcWithRp()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rtc>b<rp></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(2, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rtc1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(2, dochtml0body1ruby0rtc1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc1).Attributes.Count);
            Assert.AreEqual("rtc", dochtml0body1ruby0rtc1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc1.NodeType);

            var dochtml0body1ruby0rtc1Text0 = dochtml0body1ruby0rtc1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rtc1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rtc1Text0.TextContent);

            var dochtml0body1ruby0rtc1rp1 = dochtml0body1ruby0rtc1.ChildNodes[1];
            Assert.AreEqual(0, dochtml0body1ruby0rtc1rp1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc1rp1).Attributes.Count);
            Assert.AreEqual("rp", dochtml0body1ruby0rtc1rp1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc1rp1.NodeType);
        }

        [Test]
        public void RubyElementNoImpliedEndForRtcWithSpan()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rtc>b<span></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(2, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rtc1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(2, dochtml0body1ruby0rtc1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc1).Attributes.Count);
            Assert.AreEqual("rtc", dochtml0body1ruby0rtc1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc1.NodeType);

            var dochtml0body1ruby0rtc1Text0 = dochtml0body1ruby0rtc1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rtc1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rtc1Text0.TextContent);

            var dochtml0body1ruby0rtc1span1 = dochtml0body1ruby0rtc1.ChildNodes[1];
            Assert.AreEqual(0, dochtml0body1ruby0rtc1span1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc1span1).Attributes.Count);
            Assert.AreEqual("span", dochtml0body1ruby0rtc1span1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc1span1.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRpWithRb()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rp>b<rb></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rp1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rp1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rp1).Attributes.Count);
            Assert.AreEqual("rp", dochtml0body1ruby0rp1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rp1.NodeType);

            var dochtml0body1ruby0rp1Text0 = dochtml0body1ruby0rp1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rp1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rp1Text0.TextContent);

            var dochtml0body1ruby0rb2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rb2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rb2).Attributes.Count);
            Assert.AreEqual("rb", dochtml0body1ruby0rb2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rb2.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRpWithRt()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rp>b<rt></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rp1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rp1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rp1).Attributes.Count);
            Assert.AreEqual("rp", dochtml0body1ruby0rp1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rp1.NodeType);

            var dochtml0body1ruby0rp1Text0 = dochtml0body1ruby0rp1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rp1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rp1Text0.TextContent);

            var dochtml0body1ruby0rt2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rt2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rt2).Attributes.Count);
            Assert.AreEqual("rt", dochtml0body1ruby0rt2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rt2.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRpWithRtc()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rp>b<rtc></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rp1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rp1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rp1).Attributes.Count);
            Assert.AreEqual("rp", dochtml0body1ruby0rp1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rp1.NodeType);

            var dochtml0body1ruby0rp1Text0 = dochtml0body1ruby0rp1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rp1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rp1Text0.TextContent);

            var dochtml0body1ruby0rtc2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rtc2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc2).Attributes.Count);
            Assert.AreEqual("rtc", dochtml0body1ruby0rtc2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc2.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndForRpWithRp()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rp>b<rp></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rp1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rp1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rp1).Attributes.Count);
            Assert.AreEqual("rp", dochtml0body1ruby0rp1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rp1.NodeType);

            var dochtml0body1ruby0rp1Text0 = dochtml0body1ruby0rp1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rp1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rp1Text0.TextContent);

            var dochtml0body1ruby0rp2 = dochtml0body1ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rp2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rp2).Attributes.Count);
            Assert.AreEqual("rp", dochtml0body1ruby0rp2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rp2.NodeType);
        }

        [Test]
        public void RubyElementNoImpliedEndForRpWithSpan()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby>a<rp>b<span></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(2, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0Text0.TextContent);

            var dochtml0body1ruby0rp1 = dochtml0body1ruby0.ChildNodes[1];
            Assert.AreEqual(2, dochtml0body1ruby0rp1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rp1).Attributes.Count);
            Assert.AreEqual("rp", dochtml0body1ruby0rp1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rp1.NodeType);

            var dochtml0body1ruby0rp1Text0 = dochtml0body1ruby0rp1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rp1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rp1Text0.TextContent);

            var dochtml0body1ruby0rp1span1 = dochtml0body1ruby0rp1.ChildNodes[1];
            Assert.AreEqual(0, dochtml0body1ruby0rp1span1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rp1span1).Attributes.Count);
            Assert.AreEqual("span", dochtml0body1ruby0rp1span1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rp1span1.NodeType);
        }

        [Test]
        public void RubyElementImpliedEndWithRuby()
        {
            var doc = DocumentBuilder.Html(@"<html><ruby><rtc><ruby>a<rb>b<rt></ruby></ruby></html>");

            var dochtml0 = doc.ChildNodes[0];
            Assert.AreEqual(2, dochtml0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0).Attributes.Count);
            Assert.AreEqual("html", dochtml0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0.NodeType);

            var dochtml0head0 = dochtml0.ChildNodes[0];
            Assert.AreEqual(0, dochtml0head0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0head0).Attributes.Count);
            Assert.AreEqual("head", dochtml0head0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0head0.NodeType);

            var dochtml0body1 = dochtml0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1).Attributes.Count);
            Assert.AreEqual("body", dochtml0body1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1.NodeType);

            var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
            Assert.AreEqual(1, dochtml0body1ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0.NodeType);

            var dochtml0body1ruby0rtc0 = dochtml0body1ruby0.ChildNodes[0];
            Assert.AreEqual(1, dochtml0body1ruby0rtc0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc0).Attributes.Count);
            Assert.AreEqual("rtc", dochtml0body1ruby0rtc0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc0.NodeType);

            var dochtml0body1ruby0rtc0ruby0 = dochtml0body1ruby0rtc0.ChildNodes[0];
            Assert.AreEqual(3, dochtml0body1ruby0rtc0ruby0.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc0ruby0).Attributes.Count);
            Assert.AreEqual("ruby", dochtml0body1ruby0rtc0ruby0.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc0ruby0.NodeType);

            var dochtml0body1ruby0rtc0ruby0Text0 = dochtml0body1ruby0rtc0ruby0.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rtc0ruby0Text0.NodeType);
            Assert.AreEqual("a", dochtml0body1ruby0rtc0ruby0Text0.TextContent);

            var dochtml0body1ruby0rtc0ruby0rb1 = dochtml0body1ruby0rtc0ruby0.ChildNodes[1];
            Assert.AreEqual(1, dochtml0body1ruby0rtc0ruby0rb1.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc0ruby0rb1).Attributes.Count);
            Assert.AreEqual("rb", dochtml0body1ruby0rtc0ruby0rb1.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc0ruby0rb1.NodeType);

            var dochtml0body1ruby0rtc0ruby0rb1Text0 = dochtml0body1ruby0rtc0ruby0rb1.ChildNodes[0];
            Assert.AreEqual(NodeType.Text, dochtml0body1ruby0rtc0ruby0rb1Text0.NodeType);
            Assert.AreEqual("b", dochtml0body1ruby0rtc0ruby0rb1Text0.TextContent);

            var dochtml0body1ruby0rtc0ruby0rt2 = dochtml0body1ruby0rtc0ruby0.ChildNodes[2];
            Assert.AreEqual(0, dochtml0body1ruby0rtc0ruby0rt2.ChildNodes.Length);
            Assert.AreEqual(0, ((Element)dochtml0body1ruby0rtc0ruby0rt2).Attributes.Count);
            Assert.AreEqual("rt", dochtml0body1ruby0rtc0ruby0rt2.NodeName);
            Assert.AreEqual(NodeType.Element, dochtml0body1ruby0rtc0ruby0rt2.NodeType);
        }
    }
}