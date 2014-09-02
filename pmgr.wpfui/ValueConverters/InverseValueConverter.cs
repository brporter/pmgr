using System;
using System.Windows.Data;
using System.Windows.Markup;
using Ninject.Planning.Targets;

namespace BryanPorter.PasswordManager.WpfUi.ValueConverters
{
    public sealed class InverseValueConverter
        : MarkupExtension, IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof (bool))
                throw new ArgumentException("Cannot convert to the specified targetType", "targetType");

            var boolValue = System.Convert.ToBoolean(value);

            return !boolValue;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new ArgumentException("Cannot convert to the specified targetType", "targetType");

            var boolValue = System.Convert.ToBoolean(value);

            return !boolValue;
        }

        public override object ProvideValue(System.IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
