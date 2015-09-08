using NUnit.Framework;
using System;
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
			doc.LoadHtml("<body><h1>the title</h1><p><li></li>the subtitle</p></body>");
			var buff = new StringWriter ();

			IExtractor ext = new Article ();
			ext.Accept (doc.DocumentNode, new XmlTextWriter(buff));

			Assert.AreEqual ("<article title=\"the title\" subtitle=\"the subtitle\" />", buff.ToString());
		}
	}
}