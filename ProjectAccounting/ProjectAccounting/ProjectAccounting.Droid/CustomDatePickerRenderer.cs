using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Android.Util;
using Android.Widget;
using ProjectAccounting;


[assembly: ExportRenderer (typeof(ProjectAccounting.CustomDatePicker),
                           typeof(ProjectAccounting.Droid.CustomDatePickerRenderer))]

namespace ProjectAccounting.Droid
{
    public class CustomDatePickerRenderer : ViewRenderer<ProjectAccounting.CustomDatePicker,ProjectAccounting.Droid.CustomDatePickerRenderer>
    {
        CustomDatePicker customDatePicker;

        protected override void OnElementChanged(ElementChangedEventArgs<CustomDatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                customDatePicker = new CustomDatePicker ();
                // SetNativeControl (customDatePicker);
                customDatePicker.FontSize = 30;
            }

        }

    }
}