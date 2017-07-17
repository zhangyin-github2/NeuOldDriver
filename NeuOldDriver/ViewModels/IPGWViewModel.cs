using NeuOldDriver.Models;

namespace NeuOldDriver.ViewModels {

    public class IPGWViewModel : ViewModelBase {

        internal class UserInfo {
            public int Used { get; set; }
            public string Balance { get; set; }
            public string IP { get; set; }
        };

        private UserData model = new UserData();
        private UserInfo cachedInfo = new UserInfo();
        
    }
}
