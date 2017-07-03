namespace FacadeNotifier.Core.APIs.Slack
{
    using FacadeNotifier.Core.APIs.Slack.DTOs;
    using FacadeNotifier.Core.Utils;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class SlackApi
    {
        private readonly Uri _webhookUrl;

        public SlackApi()
        {
            _webhookUrl = new Uri(NoticeCredentials.SlackApiEndpoint);
        }

        public async Task<IEnumerable<SlackRoomItem>> GetRooms()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, $"channels.list?token={NoticeCredentials.SlackApiToken}"))
            {
                using (var httpClient = new HttpClient() { BaseAddress = _webhookUrl })
                {
                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        using (var content = response.Content)
                        {
                            var json = await content.ReadAsStringAsync();

                            return JsonConvert.DeserializeObject<SlackRoomResponse>(json).Channels;
                        }
                    }
                    else
                        return null;
                }
            }
        }

        public async Task<IEnumerable<SlackUserItem>> GetUsers()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, $"users.list?token={NoticeCredentials.SlackApiToken}"))
            {
                using (var httpClient = new HttpClient() { BaseAddress = _webhookUrl })
                {
                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        using (var content = response.Content)
                        {
                            var json = await content.ReadAsStringAsync();

                            return JsonConvert.DeserializeObject<SlackUserResponse>(json).Members;
                        }
                    }
                    else
                        return null;
                }
            }
        }
    }
}