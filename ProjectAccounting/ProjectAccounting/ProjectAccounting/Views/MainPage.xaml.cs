using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Projects
        async void OnProjectsClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ProjectAccountingProjectListPage());
        }

        async void OnProjectBalancesClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ProjectBalancesPage());
        }

        // Cash Registers
        async void OnCashRegistersClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CashRegisterListPage());
        }

        async void OnCashRegisterBalancesClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CashRegisterBalancesPage());
        }

        // Cash Ledger
        async void OnCashLedgerClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ProjectAccountingCashLedgerListPage());
        }

        // Backup Database
        void OnBackupDatabaseClicked(object sender, EventArgs args)
        {
            if (DependencyService.Get<IFileHelper>().BackupDatabase(App.Current.Resources["DatabaseFilePath"].ToString(), DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + App.Current.Resources["DatabaseFileName"].ToString()))
            {
                DisplayAlert("Database backup", "Database 'Accounting.db' was successfully backed up to directory BLM.", "OK");
            }
            
        }

        // Restore Database
        void OnRestoreDatabaseClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new DatabaseLookupPage());
        }
    }
}
