using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Building.Manager.Controls.Schedule
{
    public class ColorDaysConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
            {
                return "Red";
            }
            else
            {
                return new SolidColorBrush(Color.FromRgb(255, 141, 27));
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        //if (value == null)
        //{
        //    return Brushes.Red;
        //}

        //else
        //{
        //    var endDate = System.Convert.ToDateTime(value);
        //    return Brushes.Orange;
        //}

    }

        
    }   

