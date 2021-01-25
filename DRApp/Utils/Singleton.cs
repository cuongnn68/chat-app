using System.Net.Http.Headers;

namespace DRApp.Utils
{
    public static class Singleton
    {
        // public static LocalStorage Storage = new LocalStorage();
        public static readonly BaseClient HttpClient = new BaseClient();

        public static AuthenticationHeaderValue GetAuthHeader() {
            var tokenMem = LocalStorage.Token;
            if (string.IsNullOrEmpty(tokenMem)) return null;
            return new AuthenticationHeaderValue("bearer", tokenMem);
        }
    }
    
}