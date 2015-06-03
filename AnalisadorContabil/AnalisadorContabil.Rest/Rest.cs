using System;
using RestSharp;

namespace AnalisadorContabil.Rest
{
    public class Rest
    {
        public static IRestRequest Get(String recurso)
        {
            IRestRequest request = new RestRequest(recurso, Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            return request;
        }
    }
}
