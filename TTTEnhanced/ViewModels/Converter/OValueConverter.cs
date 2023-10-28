using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace TTTEnhanced.ViewModels.Converter;

public class OValueConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is char c)
        {
            return c == 'O';
        }

        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}