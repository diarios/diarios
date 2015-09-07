using System;
using HtmlAgilityPack;
using System.Xml;

namespace News.Core
{
	public interface IExtractor
	{
		void Accept (HtmlNode document, XmlWriter response);
	}
}