namespace FacadeNotifier.Core.APIs.HipChat
{
    using DTOs;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class HipChatApi
    {
        private readonly Uri _webhookUrl;
        private readonly string _roomsInfoToken = "";

        public HipChatApi()
        {
            _webhookUrl = new Uri("https://api.hipchat.com/v2/");
        }

        public async Task<IEnumerable<HipChatRoomItem>> GetRooms()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "room"))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _roomsInfoToken);

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