using System.Threading.Tasks;
using System.ComponentModel;

using NeuOldDriver.Utils;

namespace NeuOldDriver.Models {

    public class IPGWModel : INotifyPropertyChanged {
        private bool   notLogged = true;
        private int    used = 0;
        private long   usedTime = 0;
        private int    balance = 0;
        private string ip;

        public bool NotLoggedIn {
            get { return notLogged; }
            private set { notLogged = value; NotifyPropertyChanged("NotLoggedIn"); }
        }

        public int Used {
            get { return used; }
            private set { used = value; NotifyPropertyChanged("Used"); }
        }

        public long UsedTime {
            get { return usedTime; }
            private set { usedTime = value; NotifyPropertyChanged("UsedTime"); }
        }

        public int Balance {
            get { return balance; }
            private set { balance = value; NotifyPropertyChanged("Balance"); }
        }

        public string IP {
            get { return ip; }
            private set { ip = value; NotifyPropertyChanged("IP"); }
        }

        public void DoLogin(LoginData data) {
            NotLoggedIn = false;
            Refresh();
        }

        public void Refresh() {
            Used = 100;
            UsedTime = 100;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void NotifyPropertyChanged(string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
