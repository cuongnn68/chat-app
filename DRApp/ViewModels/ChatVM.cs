using System.Net.Http;
using DRApp.Services;
using DRApp.Utils;

namespace DRApp.ViewModels {
    public class ChatVM : ViewModel {
        private ApiRequest api;
        private int roomId;
        
        public ChatVM(int roomId) : base() {
            this.roomId = roomId;

            api = new ApiRequest();

            api.GetMesseage(roomId);
        }
    }
}