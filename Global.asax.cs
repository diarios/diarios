using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.Reflection;

namespace News
{
	public class Global : System.Web.HttpApplication
	{
		private static Dictionary<string, ICrawler> crawlers;

		protected void Application_Start (Object sender, EventArgs e)
		{
			crawlers = Assembly.GetExecutingAssembly()
				.GetTypes ()
				.Where (type => type.GetInterfaces ().Contains (typeof(ICrawler)))
				.ToDictionary (
					type => '/' + string.Join ("/", type.FullName.Split ('.')),
					type => (ICrawler)Activator.CreateInstance (type)
				);
		}

		protected void Application_BeginRequest (Object sender, EventArgs e)
		{
			if (crawlers.ContainsKey (this.Request.Path)) {

				this.Response.ContentType = "text/xml";
				crawlers[this.Request.Path].Craw (
					new HtmlWeb ().Load (this.Request.Form ["url"]).DocumentNode,
					new System.Xml.XmlTextWriter(this.Response.Output)
				);
				this.Response.End ();

			}
		}
	}
}
