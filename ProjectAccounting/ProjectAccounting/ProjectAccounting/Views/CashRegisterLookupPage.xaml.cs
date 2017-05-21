using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class CashRegisterLookupPage : ContentPage
    {
        public CashRegisterLookupPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            lookupCashRegisterListView.ItemsSource = await App.Database3.GetCashRegistersAsync();
        }

        async void OnLookupCashRegisterSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                lookupCashRegisterListView.SelectedItem = null;

                MessagingCenter.Send<CashRegisterLookupPage, CashRegister>
                    (this, "CashRegisterSelection", (CashRegister)args.SelectedItem);

                Navigation.PopModalAsync();
            }

        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
