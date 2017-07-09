using System.Threading.Tasks;
using System.ComponentModel;

namespace NeuOldDriver.Models {

    public class IPGWModel : INotifyPropertyChanged {
        private bool loggedIn = false;

        private int  used;
        private long usedTime;

        public bool NotLoggedIn { get { return !loggedIn; } }

        public int Used { get { return used; } }

        public long UsedTime { get { return UsedTime; } }

        public void DoLogin(LoginData data) {
            loggedIn = true;
            NotifyPropertyChanged("NotLoggedIn");
            Refresh();
        }

        public void Refresh() {
            NotifyPropertyChanged("Used");
            NotifyPropertyChanged("UsedTime");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void NotifyPropertyChanged(string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
