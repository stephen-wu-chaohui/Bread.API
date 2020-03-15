using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Bread.Application.Repositoies;
using Bread.Domain.Entities;
using System.Net.Http.Headers;

namespace Bread.Infrastructure.Data.Repositories
{
    public class YoutubeReader : IVideoRepository
    {
        static readonly Dictionary<string, string> AppSettings = new Dictionary<string, string>
        {
            ["Google.ClientId"] = "761099168890-g59ht25ug7n739um7cbnnr1oi6r8af8p.apps.googleusercontent.com",
            ["Google.ClientSecret"] = "MEJvyei_qoUz7roWEsZyzmI5",
            ["Google.APIKey"] = "AIzaSyDqyxV-9TUWmyVP27xwIuhV2lKLh8-gpas",
            ["Youtube.ChannelId"] = "UCtcwkfeJL45qwR4MEJSHhYw"
        };

        static readonly string playListsAPIUrl = "https://www.googleapis.com/youtube/v3/playlists";
        static readonly string playlistItemsAPIUrl = "https://www.googleapis.com/youtube/v3/playlistItems";

        private static readonly Dictionary<string, IEnumerable<PlayList>> channelDict = new Dictionary<string, IEnumerable<PlayList>>();
        private static readonly Dictionary<string, IEnumerable<PlayItem>> playlistDict = new Dictionary<string, IEnumerable<PlayItem>>();

        static public EntityTagHeaderValue SavedETag { get; private set; }

        public async Task<IEnumerable<PlayList>> LoadChannelAsync(string channelId, bool refresh)
        {
            if (string.IsNullOrEmpty(channelId)) {
                channelId = AppSettings["Youtube.ChannelId"];
            }

            if (channelDict.ContainsKey(channelId)) {
                var dictItem = channelDict[channelId];
                return await Task.FromResult(dictItem);
            }

            var args = new Dictionary<string, string> {
                ["part"] = "snippet",
                ["channelId"] = channelId,
                ["key"] = AppSettings["Google.APIKey"],
                ["maxResults"] = "50",
            };
            string playListsUrl = playListsAPIUrl + '?' + string.Join("&", args.Select(kv => $"{kv.Key}={kv.Value}"));

            using (HttpClient httpClient = new HttpClient()) {
                if (SavedETag != null) {
                    httpClient.DefaultRequestHeaders.IfNoneMatch.Add(SavedETag);
                }

                var response = await httpClient.GetAsync(playListsUrl);
                var retCode = response.StatusCode;
                var jsonString = await response.Content.ReadAsStringAsync();

                try {
                    JObject jObject = JsonConvert.DeserializeObject<JObject>(jsonString);
                    var items = jObject["items"];
                    var playLists = new List<PlayList>();
                    foreach (var item in items) {
                        var id = item.Value<string>("id");
                        var snippet = item.Value<JObject>("snippet");

                        var text = snippet.Value<string>("title");
                        var publishedAt = snippet.Value<string>("publishedAt");
                        var description = snippet.Value<string>("description");

                        var thumbnails = snippet.Value<JObject>("thumbnails");
                        var thumbnailUrl = thumbnails.Value<JObject>("high").Value<string>("url");

                        playLists.Add(new PlayList {
                            Id = id,
                            Text = text,
                            Description = description,
                            PublishedAt = publishedAt,
                            ThumbnailUrl = thumbnailUrl,
                        });
                    }

                    channelDict[channelId] = playLists;

                    SavedETag = response.Headers.ETag;
                    return await Task.FromResult(playLists);
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public async Task<IEnumerable<PlayItem>> LoadPlayItemsAsync(string playlistId)
        {
            if (playlistDict.ContainsKey(playlistId)) {
                var dicItem = playlistDict[playlistId];
                await Task.FromResult(dicItem);
            }

            var args = new Dictionary<string, string> {
                ["part"] = "snippet",
                ["playlistId"] = playlistId,
                ["key"] = AppSettings["Google.APIKey"],
                ["maxResults"] = "50",
            };
            string playlistItemsUrl = playlistItemsAPIUrl + '?' + string.Join("&", args.Select(kv => $"{kv.Key}={kv.Value}"));

            using (HttpClient httpClient = new HttpClient()) {
                string jsonString = await httpClient.GetStringAsync(playlistItemsUrl);
                try {
                    JObject jObject = JsonConvert.DeserializeObject<JObject>(jsonString);
                    var items = jObject["items"];
                    var playItems = new List<PlayItem>();
                    foreach (var item in items) {
                        var id = item.Value<string>("id");
                        var spippet = item.Value<JObject>("snippet");
                        var text = spippet.Value<string>("title");
                        var description = spippet.Value<string>("description");

                        var thumbnails = spippet.Value<JObject>("thumbnails");
                        var thumbnailUrl = thumbnails.Value<JObject>("high").Value<string>("url");

                        var resourceId = spippet.Value<JObject>("resourceId");
                        var videoId = resourceId.Value<string>("videoId");

                        playItems.Add(new PlayItem {
                            Id = id,
                            Text = text,

                            Description = description,
                            ThumbnailUrl = thumbnailUrl,
                            VideoId = videoId,
                        });
                    }

                    playlistDict[playlistId] = playItems;
                    return await Task.FromResult(playItems);
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            }

            return null;
        }
    }
}
