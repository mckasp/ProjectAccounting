using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class ProjectAccountingCashLedgerPage : ContentPage
    {
        public ProjectAccountingCashLedgerPage()
        {
            InitializeComponent();

            // Subscribe to "ProjectSelection" message; here the selected project selected by the user is returned to the calling page and the property is updated
            MessagingCenter.Subscribe<ProjectLookupPage, ProjectAccountingProject>(this, "ProjectSelection", (sender, info) =>
            {
                ProjectEntry.Text = info.Code;
            });

            // Subscribe to "CashRegisterSelection" message; here the selected cash register selected by the user is returned to the calling page and the property is updated
            MessagingCenter.Subscribe<CashRegisterLookupPage, CashRegister>(this, "CashRegisterSelection", (sender, info) =>
            {
                CashRegisterEntry.Text = info.Code;
            });
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {

            var projectAccountingCashLedger = (ProjectAccountingCashLedger)BindingContext;

            // Check project code
            int NoOfRecords = await App.Database.LookupProjectAsync(projectAccountingCashLedger.Project);
            if ((projectAccountingCashLedger.Project == "") || (NoOfRecords == 0))
            {
                await DisplayAlert("Alert", "You must specify a valid project!", "Cancel");
                return;
            }

            // Check cash register code
            NoOfRecords = await App.Database3.LookupCashRegisterAsync(projectAccountingCashLedger.CashRegister);
            if ((projectAccountingCashLedger.CashRegister == "") || (NoOfRecords == 0))
            {
                await DisplayAlert("Alert", "You must specify a valid cash register!", "Cancel");
                return;
            }

            // Save record
            await App.Database2.SaveCashLedgerEntryAsync(projectAccountingCashLedger);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Delete cash ledger entry?", "Do you really want to delete this cash ledger entry?", "Yes", "No"))
            {
                var projectAccountingCashLedger = (ProjectAccountingCashLedger)BindingContext;
                await App.Database2.DeleteCashLedgerEntryAsync(projectAccountingCashLedger);
                await Navigation.PopAsync();
            }
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void OnLookupProjectClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProjectLookupPage());
        }

        async void OnLookupCashRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CashRegisterLookupPage());
        }
    }
}