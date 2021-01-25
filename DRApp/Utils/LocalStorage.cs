using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DRApp.Utils {
    public static class LocalStorage
    {
        private static string domain;

        public static string Domain
        {
            get => domain;
            set
            {
                domain = value;
                SecureStorage.SetAsync(nameof(Domain), value);
            }
        }
        
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
            try {
                int.TryParse(await SecureStorage.GetAsync(nameof(UserId)), out userId);
            } catch  {
                Console.WriteLine("UserId null");
            }

            try
            {
                Username = await SecureStorage.GetAsync(nameof(Username));
            }
            catch
            {
                Console.WriteLine("Username empty");
            }

            try
            {
                Token = await SecureStorage.GetAsync(nameof(Token));
            }
            catch
            {
                Console.WriteLine("Token null");
            }
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
