using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class ProjectAccountingCashLedgerListPage : ContentPage
    {
        public ProjectAccountingCashLedgerListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database2.GetCashLedgerEntriesAsync();
        }

        async void OnCashLedgerEntryAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectAccountingCashLedgerPage
            {
                BindingContext = new ProjectAccountingCashLedger()
            });
        }

        async void OnListCashLedgerEntrySelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtTodoId = (e.SelectedItem as ProjectAccountingCashLedger).ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as ProjectAccountingCashLedger).ID);

            await Navigation.PushAsync(new ProjectAccountingCashLedgerPage
            {
                BindingContext = e.SelectedItem as ProjectAccountingCashLedger
            });
        }



    }
}
