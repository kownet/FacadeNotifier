﻿namespace FacadeNotifier.Core.APIs.HipChat
{
    using DTOs;
    using FacadeNotifier.Core.Utils;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class HipChatApi
    {
        private readonly Uri _webhookUrl;

        public HipChatApi()
        {
            _webhookUrl = new Uri(NoticeCredentials.HipChatApiEndpoint);
        }

        public async Task<IEnumerable<HipChatRoomItem>> GetRooms()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "room"))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", NoticeCredentials.HipChatApiToken);

                using (var httpClient = new HttpClient() { BaseAddress = _webhookUrl })
                {
                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        using (var content = response.Content)
                        {
                            var json = await content.ReadAsStringAsync();

                            return JsonConvert.DeserializeObject<HipChatRoomResponse>(json).Items;
                        }
                    }
                    else
                        return null;
                }
            }
        }
    }
}