using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using DRApp.Services;
using DRApp.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DRApp.Views;
using DRApp.ViewModels;

namespace DRApp {
    public partial class App : Application {
        private AuthStateVM authVM;

        public App() {
            InitializeComponent();
            LocalStorage.UpdateAsync().Wait();
            #if DEBUG
            LocalStorage.Domain = "https://discord-ripoff.azurewebsites.net/"; // for pc
            #else 
            LocalStorage.Domain = "https://discord-ripoff.azurewebsites.net/"
            #endif
            Singleton.HttpClient.UpdateToken();
            
            // test
            // HttpClient client = new HttpClient();
            // var res2 = client.GetAsync("https://discord-ripoff.azurewebsites.net/api/user/18").Result;
            // var we = new ApiRequest().CheckAuthAsync();
            // Console.WriteLine(we);
            
            // Singleton.HttpClient.Client.
            

            authVM = new AuthStateVM();

            // dont use di anymore
            // DI.Init();
            // var str = DI.ServiceProvider.GetService<ITestService>().TestMethod();


            //MainPage = new NavigationPage(new RoomSelection()) {
            //    //BarBackgroundColor = Color.Magenta,
            //};


            //MainPage.Navigation.PushAsync(new ChatRoom(), true);

            //MainPage.Navigation.PushModalAsync(new Login());

            //MainPage = new NavigationPage(new MainPage());
            //MainPage.Navigation.PushAsync(new Login());

        }
        // TODO nagvigation
        // TODO side menu
        protected override void OnStart() {
            
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
