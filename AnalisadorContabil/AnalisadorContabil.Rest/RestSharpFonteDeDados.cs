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
            IRestRequest request = Get(recurso.ToString());

            IRestResponse response = _client.Execute(request);

            object resultado = JsonConvert.DeserializeObject(response.Content);

            return resultado;
        }
        
        public static IRestRequest Get(String recurso)
        {
            IRestRequest request = new RestRequest(recurso, Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            return request;
        }
    }
}
