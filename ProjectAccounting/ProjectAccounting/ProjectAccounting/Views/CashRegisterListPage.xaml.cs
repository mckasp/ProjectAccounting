using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class CashRegisterListPage : ContentPage
    {
        public CashRegisterListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listViewCashRegister.ItemsSource = await App.Database3.GetCashRegistersAsync();
        }

        async void OnCashRegisterAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CashRegisterPage
            {
                BindingContext = new CashRegister()
            });
        }

        async void OnListCashRegisterSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtTodoId = (e.SelectedItem as CashRegister).ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as CashRegister).ID);

            await Navigation.PushAsync(new CashRegisterPage
            {
                BindingContext = e.SelectedItem as CashRegister
            });
        }
    }
}
