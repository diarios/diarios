using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.Reflection;
using System.IO;
using System.Text;
using System.Xml;

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
                var writer = new XmlTextWriter (this.Response.Output);
				crawlers[this.Request.Path].Craw (
                    new HtmlWeb ().Load (new StreamReader(this.Request.InputStream).ReadToEnd()).DocumentNode,
					writer
				);
				this.Response.End ();
			}
		}
	}
}
