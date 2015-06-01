using System;
using AnalisadorContabil.FonteDeDados;
using System.Xml;
using System.Xml.XPath;

namespace AnalisadorContabil.Xml
{
    public class XmlFonteDeDados : IFonteDeDados
    {
        private readonly string _pasta;
        private XmlDocument doc = new XmlDocument();

        public XmlFonteDeDados(String pasta)
        {
            _pasta = pasta;
        }

        public object GetDados(string consulta)
        {
            doc.Load(_pasta + @"\resumodomes.xml");

            XPathNavigator nav = doc.CreateNavigator();

            return nav.Evaluate(consulta);
        }
    }
}
