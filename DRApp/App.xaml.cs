using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DRApp.Views;
using DRApp.ViewModels;

namespace DRApp {
    public partial class App : Application {
        AuthStateVM authVM;
        public App() {
            InitializeComponent();
            authVM = new AuthStateVM();


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
