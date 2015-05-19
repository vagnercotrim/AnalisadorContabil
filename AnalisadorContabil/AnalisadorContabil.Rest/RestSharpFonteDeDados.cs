using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalisadorContabil.FonteDeDados;

namespace AnalisadorContabil.Rest
{
    public class RestSharpFonteDeDados : IFonteDeDados
    {
        private readonly string _endereco;

        public RestSharpFonteDeDados(String endereco)
        {
            _endereco = endereco;
        }

        public object GetDados(string id)
        {
            return new DateTime(2015, 5, 15);
        }
    }
}
