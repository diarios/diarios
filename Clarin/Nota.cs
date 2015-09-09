namespace News.Clarin
{
    using System;
    using System.Xml;
    using HtmlAgilityPack;

    /// <summary>
    /// Extrae los datos de una nota de clarin
    /// </summary>
    public class Nota : ICrawler
    {
        /// <summary>
        /// Convierte una pagina html a un conjunto de datos en xml.
        /// </summary>
        /// <param name="document">Documento html.</param>
        /// <param name="response">Salida en xml.</param>
        public void Craw(HtmlNode document, XmlWriter response)
        {
            response.WriteStartElement("article");
            response.WriteAttributeString("title", (document.SelectSingleNode("//h1/text()") as HtmlTextNode).Text);
            response.WriteAttributeString("subtitle", (document.SelectSingleNode("//h1/../p/text()") as HtmlTextNode).Text);
            response.WriteEndElement();
        }
    }
}