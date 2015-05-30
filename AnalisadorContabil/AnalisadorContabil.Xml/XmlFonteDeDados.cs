using System;
using AnalisadorContabil.FonteDeDados;

namespace AnalisadorContabil.Xml
{
    public class XmlFonteDeDados : IFonteDeDados
    {
        private readonly string _pasta;

        public XmlFonteDeDados(String pasta)
        {
            _pasta = pasta;
        }

        public object GetDados(string id)
        {
            return 12345.67M;
        }
    }
}
