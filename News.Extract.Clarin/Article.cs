using System;
using HtmlAgilityPack;
using System.Xml;
using News.Core;

namespace News.Extract.Clarin
{
	public class Article : IExtractor
	{
		public void Accept (HtmlNode document, XmlWriter response)
		{
			response.WriteStartElement ("article");
			response.WriteAttributeString ("title", (document.SelectSingleNode("//h1/text()") as HtmlTextNode).Text);
			response.WriteAttributeString ("subtitle", (document.SelectSingleNode("//h1/../p/text()") as HtmlTextNode).Text);
			response.WriteEndElement ();
		}
	}
}