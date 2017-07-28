using System;

using Windows.UI.Xaml.Data;

namespace NeuOldDriver.Converters {

    public class NegateBool : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, string language) {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return !(bool)value;
        }
    }
}
