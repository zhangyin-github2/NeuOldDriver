using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NeuOldDriver.ViewModels {

    public abstract class ViewModelBase : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propname = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        protected void SetProperty<T>(ref T src, T value, [CallerMemberName] string propname = "") {
            if (ReferenceEquals(src, value))
                return;
            OnPropertyChanged(propname);
        }
    }
}
