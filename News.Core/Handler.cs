using System;
using System.Web;
using HtmlAgilityPack;

namespace News.Core
{
	public class Handler<TExtract> : IHttpHandler where TExtract: IExtractor, new() 
	{
		public void ProcessRequest (HttpContext context)
		{
			context.Response.ContentType = "text/xml";
			new TExtract ().Accept (
				new HtmlWeb ().Load (context.Request.Form ["url"]).DocumentNode,
				new System.Xml.XmlTextWriter(context.Response.Output)
			);
			context.Response.End ();
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}