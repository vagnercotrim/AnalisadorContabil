using System;
using System.Collections.Generic;
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
            IDictionary<string, object> dictionary = AnonymousObject.ToDictionary(consulta);
            
            _doc.Load(_pasta + @"\"+ dictionary["arquivo"]);

            XPathNavigator nav = _doc.CreateNavigator();

            return nav.Evaluate(dictionary["consulta"].ToString());
        }
    }
}
