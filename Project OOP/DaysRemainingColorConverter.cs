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

                // Geef oranje kleur terug als minder dan 5 dagen over zijn, anders witte achtergrond
                if (daysRemaining < 5)
                {
                    return new SolidColorBrush(Colors.Orange);
                }

                else if (daysRemaining < 3)
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }
            return Brushes.White; // Standaardtekstkleur, als er meer dan 5 dagen over zijn
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
