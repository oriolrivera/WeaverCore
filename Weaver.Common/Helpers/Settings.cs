namespace Weaver.Common.Helpers
{
    using System;
    using System.Net.Http;

    public class Settings
    {
        public const string UrlService = "http://192.168.1.15:5001";
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
