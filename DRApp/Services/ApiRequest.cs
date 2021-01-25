using System.Collections.Generic;
using System.Net.Http;
using DRApp.Utils;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DRApp.Services
{
    public class ApiRequest {
        private HttpClient httpClient;

        public ApiRequest() {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = Singleton.GetAuthHeader();
        }

        public List<RoomInfo> GetRooms() {
            var res = httpClient.GetAsync($"{LocalStorage.Domain}api/user/{LocalStorage.UserId}/room").Result;
            var roomsJson = res.Content.ReadAsStringAsync().Result;
            var rooms = JsonSerializer.Deserialize<RoomsListWrapper>(roomsJson,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return rooms.Value;
        }

        public async Task<LoginInfoModel> LoginAsync(string username, string password)
        {
            var sendInfo = new SendLoginModel
            {
                Username = username,
                Password = password
            };
            var content = new StringContent(
                JsonSerializer.Serialize(sendInfo),
                System.Text.Encoding.UTF8,
                "application/json");
            var res = httpClient.PostAsync($"{LocalStorage.Domain}api/user/auth", content).Result;
            if (!res.IsSuccessStatusCode)
            {
                return null;
            }

            var resStr = await res.Content.ReadAsStringAsync();
            var userInfo = JsonSerializer.Deserialize<LoginInfoModel>(resStr, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});
            return userInfo;
        }

        public bool CheckAuthAsync()
        {
            var token = LocalStorage.Token;
            var content = new StringContent(
                JsonSerializer.Serialize(new TokenInfo {Token = token}),
                System.Text.Encoding.UTF8,
                "application/json");
            var domain = LocalStorage.Domain + "api/user/check-auth";
            var res = httpClient.PostAsync(domain, content).Result;
            return res.IsSuccessStatusCode;
        }

        public List<MesseageInfo> GetMesseage(int roomId) {
            var res = httpClient.GetAsync($"{LocalStorage.Domain}api/room/{roomId}/message").Result;
            var messagesJson = res.Content.ReadAsStringAsync().Result;
            var messages = JsonSerializer.Deserialize<ListMessageWrapper>(messagesJson,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return messages?.Value;
        }
    }

    public class RoomInfo {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MesseageInfo {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public string TimeCreated { get; set; }
    }

    public class ListMessageWrapper {
        [JsonPropertyName("$values")]
        public List<MesseageInfo> Value { get; set; }
    }

    public class TokenInfo
    {
        public string Token { get; set; }
    }

    public class LoginInfoModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }

    public class SendLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
    }

    public class RoomsListWrapper {
        [JsonPropertyName("$values")]
        public List<RoomInfo> Value { get; set; }
    }
}