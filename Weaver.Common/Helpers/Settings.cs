namespace Weaver.Common.Helpers
{
    using System;
    using System.Net.Http;

    public class Settings
    {
        public const string UrlService = "url";
        public const string servicePrefix = "/api/";

        public static HttpClient BaseHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(Settings.UrlService)
            };

            return client;
        }

        public static string GetPath(string endPoint)
        {
            return $"{Settings.servicePrefix}{endPoint}";
        }

        public static string GetPath(string endPoint, int id)
        {
            return $"{Settings.servicePrefix}{endPoint}/{id}";
        }
    }
}
