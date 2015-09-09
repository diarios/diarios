namespace News
{
    using System;
    using System.Xml;
    using HtmlAgilityPack;

    /// <summary>
    /// Interfaz que representa un extractor de datos de una pagina html.
    /// </summary>
	public interface ICrawler
	{
        /// <summary>
        /// Convierte una pagina html a un conjunto de datos en xml.
        /// </summary>
        /// <param name="document">Documento html.</param>
        /// <param name="response">Salida en xml.</param>
		void Craw(HtmlNode document, XmlWriter response);
	}
}