using DRApp.Utils;
using DRApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DRApp.ViewModels {
    public class AuthStateVM : ViewModel{
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
            //this.mainPage = mainPage;
            // TODO check storage to know login or not
            LoginCommand = new Command(Login);
            LogoutCommand = new Command(Logout);

            Logout();
        }

        async void Login() {
            //Test
            await Application.Current.MainPage.DisplayAlert(Username, (await LocalStorage.TestOut()).ToString(), "Ok");
            Int32.TryParse(Username, out var intUname);
            LocalStorage.TestIn(intUname);


            // TODO check username password
            //IsLogin = false;
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
