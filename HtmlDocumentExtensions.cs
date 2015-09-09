using System;
using HtmlAgilityPack;

namespace News
{
    public static class HtmlDocumentExtensions
    {
        public static string SelectSingleNodeText(this HtmlNode doc, string q)
        {
            return (doc.SelectSingleNode(q+"/text()") as HtmlTextNode).Text;
        }
    }
}