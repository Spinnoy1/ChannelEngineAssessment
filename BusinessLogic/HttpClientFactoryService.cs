﻿using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class HttpClientFactoryService //: IHttpClientServiceImplementation
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        public HttpClientFactoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task Execute()
        {
            throw new NotImplementedException();
        }
    }
}
