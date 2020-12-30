using DRApp.ViewModels;
using DRApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DRApp.ViewModels {
    public class MyRoomsVM : ViewModel {
        INavigation nag;
        public Command<Room> TapCommand { get; set; }

        Room selectedRoom;
        public Room SelectedRoom {
            get => selectedRoom;
            set {
                Debug.WriteLine(value?.Name);
                selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }

        ObservableCollection<Room> rooms = new ObservableCollection<Room>();
        public ObservableCollection<Room> Rooms {
            
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
            
            nag = navigation;
            TapCommand = new Command<Room>(ChooseRoom);

            // Test
            Rooms = new ObservableCollection<Room>
            {
                new Room
                {
                    Id = 123222,
                    Name = "name 69",
                },
                new Room
                {
                    Id = 2,
                    Name = "name 2",
                },
                new Room
                {
                    Id = 3,
                    Name = "name 3",
                },
            };
            OnPropertyChanged(nameof(Rooms));

            // TODO make this to service, use Toast
            //Application.Current.MainPage.DisplayAlert("alerttttt", "ok", "cancel");
        }

        void ChooseRoom(Room dupRoom) {
            Debug.WriteLine("fuck this shit");
            Debug.WriteLine(dupRoom?.Name);
            Debug.WriteLine(SelectedRoom?.Name);
            if (dupRoom != null) {
                Rooms.Add(dupRoom);
            }
        }
    }
}
