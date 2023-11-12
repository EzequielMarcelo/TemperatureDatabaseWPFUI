// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Globalization;
using System.Windows.Data;

namespace TemperatureDataBaseWPF.Helpers
{
    internal class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? enumValue = value.ToString();
            string? targetValue = parameter.ToString();

            if(enumValue == null || targetValue == null)
                throw new ArgumentException("ExceptionEnumToBooleanConverterValuesCannotBeNull");

            return enumValue.Equals(targetValue, StringComparison.InvariantCultureIgnoreCase);                              
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? targetValue = parameter.ToString();
            if (value == null || targetValue == null || !(value is bool))
                throw new ArgumentException("ExceptionEnumToBooleanConverterValuesCannotBeNull");

            if ((bool)value)
                return Enum.Parse(targetType, targetValue, ignoreCase: true);

            return false;
        }
    }
}
