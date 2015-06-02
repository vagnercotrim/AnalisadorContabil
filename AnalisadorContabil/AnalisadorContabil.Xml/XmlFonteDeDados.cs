using System;
using AnalisadorContabil.FonteDeDados;
using System.Xml;
using System.Xml.XPath;

namespace AnalisadorContabil.Xml
{
    public class XmlFonteDeDados : IFonteDeDados
    {
        private readonly string _pasta;
        private readonly XmlDocument _doc = new XmlDocument();

        public XmlFonteDeDados(String pasta)
        {
            _pasta = pasta;
        }

        public object GetDados(object consulta)
        {
            _doc.Load(_pasta + @"\resumodomes.xml");

            XPathNavigator nav = _doc.CreateNavigator();

            return nav.Evaluate(consulta.ToString());
        }
    }
}
