using Windows.UI.Xaml.Controls;

using NeuOldDriver.Models;

namespace NeuOldDriver.Pages {

    public sealed partial class IPGW : Page {

        public IPGW() {
            this.InitializeComponent();
        }

        private void DoLogin(object sender, LoginData e) {
            data.DoLogin(e);
            
        }
    }
}
