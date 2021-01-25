using DRApp.Utils;
using DRApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DRApp.Services;
using Xamarin.Forms;

namespace DRApp.ViewModels {
    public class AuthStateVM : ViewModel
    {
        private ApiRequest api;
        
        private Page mainPage;
        private bool isLogin = false;
        public bool IsLogin {
            get => isLogin;
            private set {
                if (isLogin == value) return;
                isLogin = value;
                OnPropertyChanged(nameof(IsLogin));
            }
        }

        private string username;
        public string Username {
            get => username;
            set { 
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string password;
        public string Password { 
            get => password; 
            set {
                password = value;
                //OnPropertyChanged(nameof(Password));
            }
        }

        public Command LoginCommand { get; private set; }
        public Command LogoutCommand { get; private set; }

        
        public AuthStateVM() {

            
            LoginCommand = new Command(Login);
            LogoutCommand = new Command(Logout);

            //this.mainPage = mainPage;
            // TODO check storage to know login or not
            api = new ApiRequest();
            var logined = api.CheckAuthAsync();
            Console.WriteLine(logined);
            Console.WriteLine(LocalStorage.Domain);
            if (logined) {
                isLogin = true;

            }

            isLogin = false;
            Logout();
        }

        void Login() {
            //Test
            // await Application.Current
            //     .MainPage
            //     .DisplayAlert(Username, Password, "Ok");

            var userInfo = api.LoginAsync(Username, Password).Result;

            LocalStorage.Token = userInfo.Token;
            LocalStorage.UserId = userInfo.Id;
            LocalStorage.Username = userInfo.Username;
            
            IsLogin = true;
            Application.Current.MainPage = new NavigationPage(new RoomSelection());
            //if (IsLogin == true) return;
            //Application.Current.MainPage = new NavigationPage(new RoomSelection());
            //IsLogin = true;
        }
        void Logout() { 
            IsLogin = false;
            mainPage = new NavigationPage(new Login(this));
            Application.Current.MainPage = new NavigationPage(new Login(this));
        }

    }
}
