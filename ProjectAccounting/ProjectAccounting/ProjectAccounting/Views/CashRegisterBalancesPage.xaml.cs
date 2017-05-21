using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class CashRegisterBalancesPage : ContentPage
    {
        public CashRegisterBalancesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listViewBalancesCashRegister.ItemsSource = await App.Database3.GetCashRegisterBalancesAsync();
        }
    }
}
