﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace InternetBankingAdmin
{
    public static class AdminApi
    {
        private const string ApiBaseUri = "http://localhost:56364";

        public static HttpClient InitializeClient()
        {
            var client = new HttpClient { BaseAddress = new Uri(ApiBaseUri) };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
