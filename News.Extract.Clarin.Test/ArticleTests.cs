using NUnit.Framework;
using System;
using NMock;
using HtmlAgilityPack;
using System.Xml;
using News.Core;
using System.IO;

namespace News.Extract.Clarin.Test
{
	[TestFixture] public class ArticleTests
	{
		[Test] public void SimpleCaseTest ()
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml("<h1>the title</h1>");
			var buff = new StringWriter ();

			IExtractor ext = new Article ();
			ext.Accept (doc.DocumentNode, new XmlTextWriter(buff));

			Assert.AreEqual ("<article title=\"the title\" />", buff.ToString());
		}
	}
}