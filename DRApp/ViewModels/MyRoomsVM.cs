using DRApp.ViewModels;
using DRApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using DRApp.Services;
using Xamarin.Forms;

namespace DRApp.ViewModels {
    public class MyRoomsVM : ViewModel {
        private INavigation nag;
        private ApiRequest api;

        
        public Command<RoomInfo> TapCommand { get; set; }

        RoomInfo selectedRoom;
        public RoomInfo SelectedRoom {
            get => selectedRoom;
            set {
                Debug.WriteLine(value?.Name);
                selectedRoom = value;
                nag.PushAsync(new ChatRoom(SelectedRoom.Id));
                selectedRoom = null;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }

        ObservableCollection<RoomInfo> rooms = new ObservableCollection<RoomInfo>();
        public ObservableCollection<RoomInfo> Rooms {
            
            get => rooms;
            set {
                if(rooms == value) {
                    return;
                }
                rooms = value;
                OnPropertyChanged(nameof(Rooms));
            }
        }

        public MyRoomsVM(INavigation navigation) : base(){
            api = new ApiRequest();
            rooms = new ObservableCollection<RoomInfo>(api.GetRooms());

            nag = navigation;
            TapCommand = new Command<RoomInfo>(ChooseRoom);

            Debug.WriteLine(SelectedRoom);
            
            // Test
            // Rooms = new ObservableCollection<RoomInfo>
            // {
            //     new RoomInfo
            //     {
            //         Id = 123222,
            //         Name = "name 69",
            //     },
            //     new RoomInfo
            //     {
            //         Id = 2,
            //         Name = "name 2",
            //     },
            //     new RoomInfo
            //     {
            //         Id = 3,
            //         Name = "name 3",
            //     },
            // };
            // OnPropertyChanged(nameof(Rooms));

            // TODO make this to service, use Toast
            //Application.Current.MainPage.DisplayAlert("alerttttt", "ok", "cancel");
        }

        void ChooseRoom(RoomInfo dupRoom) {
            // Debug.WriteLine("fck this shit");
            // Debug.WriteLine(dupRoom?.Name);
            // if (dupRoom != null) {
            //     Rooms.Add(dupRoom);
            // }
            // Debug.WriteLine(SelectedRoom?.Name);
            SelectedRoom = null;
            OnPropertyChanged(nameof(SelectedRoom));

            nag.PushAsync(new ChatRoom(SelectedRoom.Id));
        }
    }
}
