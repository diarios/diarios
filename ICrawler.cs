using System;
using System.Xml;
using HtmlAgilityPack;

namespace News
{
	public interface ICrawler
	{
		void Craw(HtmlDocument document, XmlWriter response);
	}
}