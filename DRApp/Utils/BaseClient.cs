using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DRApp.Utils
{
    public class BaseClient
    {
        public readonly HttpClient Client;

        public BaseClient()
        {
            Client = new HttpClient();
            var tokenMem = LocalStorage.Token;
            if (!string.IsNullOrEmpty(tokenMem)) return;

            var authHeader = new AuthenticationHeaderValue("bearer", tokenMem);
            Client.DefaultRequestHeaders.Authorization = authHeader;
        }

        // bool CheckToken(string token)
        // {
        //     Client.PostAsync()
        // }
    }
}