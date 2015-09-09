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
            response.WriteAttributeString("title", document.SelectSingleNodeText("//h1"));
            response.WriteAttributeString("subtitle", document.SelectSingleNodeText("//h1/../p"));
            response.WriteEndElement();
        }
    }
}