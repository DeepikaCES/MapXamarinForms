using System;
using System.Net.Http;
using Flurl.Http.Configuration;
using MapXamarinForms.Services.Interfaces;

namespace MapXamarinForms.Utils
{
    public class CustomHttpClientFactory : DefaultHttpClientFactory
    {
        public override HttpClient CreateHttpClient(HttpMessageHandler handler)
        {
            if (handler is HttpClientHandler clientHandler)
                // bypass SSL certificate
                clientHandler.ServerCertificateCustomValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => { return true; };
            return base.CreateHttpClient(handler);
        }
    }
}
