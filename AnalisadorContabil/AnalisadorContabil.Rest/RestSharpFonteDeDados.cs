using AnalisadorContabil.FonteDeDados;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace AnalisadorContabil.Rest
{
    public class RestSharpFonteDeDados : IFonteDeDados
    {
        private readonly RestClient _client;

        public RestSharpFonteDeDados(String endereco)
        {
            _client = new RestClient(endereco);
        }

        public object GetDados(object recurso)
        {
            IRestRequest request = Rest.Get(recurso.ToString());

            IRestResponse response = _client.Execute(request);

            return JsonConvert.DeserializeObject(response.Content);
        }
    }
}
