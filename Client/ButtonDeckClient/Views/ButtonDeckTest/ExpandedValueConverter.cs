using System;
using System.Globalization;
using System.Windows.Data;

namespace ButtonDeckClient.Views.ButtonDeckTest
{
    class ExpandedValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var value_actionType = (ActionTypes)value;
            var parameter_actionType = (ActionTypes)parameter;

            return value_actionType == parameter_actionType;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var value_bool = (bool)value;
            var parameter_actionType = (ActionTypes)parameter;

            if (value_bool)
                return parameter_actionType;

            return ActionTypes.Unknown;
        }
    }
}
