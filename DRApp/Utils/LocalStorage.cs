using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DRApp.Utils {
    static class LocalStorage {
        static int userId;

        public static int UserId {
            get => userId; 
            set { 
                userId = value;
                SecureStorage.SetAsync(nameof(UserId), value.ToString());
            }
        }

        static string username;
        public static string Username { 
            get => username; 
            set {
                username = value;
                SecureStorage.SetAsync(nameof(Username), value);
            } 
        }

        static string token;
        public static string Token{ 
            get => token;
            set {
                token = value;
                SecureStorage.SetAsync(nameof(Token), value);
            } 
        }

        public static async Task UpdateAsync() {
            Int32.TryParse(await SecureStorage.GetAsync(nameof(UserId)), out userId);
            Username = await SecureStorage.GetAsync(nameof(Username));
            Token = await SecureStorage.GetAsync(nameof(Token));
        }

        public static async Task<int> TestOut() {
            Int32.TryParse(await SecureStorage.GetAsync("Test"),out var o);
            return o;
        }
        public static void TestIn(int i) {
            SecureStorage.SetAsync("Test", i.ToString());
        }

    }
}
