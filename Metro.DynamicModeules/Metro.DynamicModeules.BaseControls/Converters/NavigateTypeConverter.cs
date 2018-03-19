using Metro.DynamicModeules.BaseControls.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Metro.DynamicModeules.BaseControls.Converters
{
    public class NavigateTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NavigateType nType = NavigateType.First;
            Enum.TryParse(value?.ToString(), out nType);
            return nType;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
