using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DRApp.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatRoom : ContentPage {
        public int RoomId { get; set; }
        public string ChatTitle => "Chat Room #" + RoomId;
        public ChatRoom(int roomId) {
            this.RoomId = roomId;
            InitializeComponent();

            BindingContext = this;
        }

        protected override void OnAppearing() {
            // TODO get message, start signalr, join signalr room
            base.OnAppearing();
        }

        protected override void OnDisappearing() {
            // TODO get out of signalr room
            base.OnDisappearing();
        }
    }
}