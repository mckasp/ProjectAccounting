using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectAccounting
{
    public class CustomDatePicker : DatePicker
    {
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize",
                                    typeof(double),
                                    typeof(CustomDatePicker),
                                    20.0);

        public CustomDatePicker()
        {
            SetDatePickerFontSize((double)FontSizeProperty.DefaultValue);
        }

        public double FontSize
        {
            set { SetValue(FontSizeProperty, value); }
            get { return (double)GetValue(FontSizeProperty); }
        }

        void SetDatePickerFontSize(double fontSize)
        {
            FontSize = 20;
        }


    }
}
