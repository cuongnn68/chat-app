using DRApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DRApp.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage {
        AuthStateVM authVM;
        public Login(AuthStateVM authVM) {
            InitializeComponent();
            this.authVM = authVM;
            BindingContext = authVM;
        }
        // TODO binding model
        // TODO show alert or bread???
        // TODO check empty
        // TODO send /api/user/auth

        protected override void OnAppearing() {
            base.OnAppearing();
            // TODO check token exist and try validate token
        }

        public void LoginBtnClicked(object o, EventArgs e) {
            //var ukm = (Test)BindingContext;
            DisplayAlert("yes", "pass.Text. please fast", "how to disable this"); // RM  pass is in XAML
        }
    }

    class Test {
        public string pass { get; set; }
    }
}