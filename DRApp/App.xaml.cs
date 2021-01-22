using System;
using DRApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DRApp.Views;
using DRApp.ViewModels;

namespace DRApp {
    public partial class App : Application {
        private AuthStateVM authVM;

        public App() {
            InitializeComponent();
            DI.Init();
            var str = DI.ServiceProvider.GetService<ITestService>().TestMethod();
            Console.WriteLine(str);
            authVM = new AuthStateVM(DI.ServiceProvider.GetService<ITestService>());
            // authVM = DI.ServiceProvider.GetService<>();


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
