using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class CashRegisterPage : ContentPage
    {
        public CashRegisterPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var cashRegister = (CashRegister)BindingContext;
            await App.Database3.SaveCashRegisterAsync(cashRegister);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var cashRegister = (CashRegister)BindingContext;

            // Ensure referential integrity
            int NoOfRecords = await App.Database2.CountCashLedgerEntryBasedOnCashRegisterFilterAsync(cashRegister.Code);
            if (NoOfRecords != 0)
            {
                await DisplayAlert("Alert", "You cannot delete this cash register since there are ledger entries with this cash register code!", "OK");
                return;
            }

            await App.Database3.DeleteCashRegisterAsync(cashRegister);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
