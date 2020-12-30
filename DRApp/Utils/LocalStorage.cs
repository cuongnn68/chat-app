using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DRApp.Utils {
    class LocalStorage {
        static int userId;

        static public int UserId {
            get => userId; 
            set { 
                userId = value;
                SecureStorage.SetAsync(nameof(UserId), value.ToString());
            }
        }

        static string username;
        static public string Username { 
            get => username; 
            set {
                username = value;
                SecureStorage.SetAsync(nameof(Username), value);
            } 
        }

        static string token;
        static public string Token{ 
            get => token;
            set {
                token = value;
                SecureStorage.SetAsync(nameof(Token), value);
            } 
        }

        public async Task UpdateAsync() {
            Int32.TryParse(await SecureStorage.GetAsync(nameof(UserId)), out userId);
            Username = await SecureStorage.GetAsync(nameof(Username));
            Token = await SecureStorage.GetAsync(nameof(Token));
        }

        static public async Task<int> TestOut() {
            Int32.TryParse(await SecureStorage.GetAsync("Test"),out var o);
            return o;
        }
        static public void TestIn(int i) {
            SecureStorage.SetAsync("Test", i.ToString());
        }

    }
}
