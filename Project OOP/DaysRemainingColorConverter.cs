using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Project_OOP
{
    public class DaysRemainingColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                // Bereken het aantal resterende dagen
                int daysRemaining = (date - DateTime.Today).Days;

                if (daysRemaining < 3)
                {
                    return new SolidColorBrush(Colors.Red);
                }

                if (daysRemaining < 5)
                {
                    return new SolidColorBrush(Colors.Orange);
                }
            }
            return Brushes.White; // Standaardtekstkleur
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
