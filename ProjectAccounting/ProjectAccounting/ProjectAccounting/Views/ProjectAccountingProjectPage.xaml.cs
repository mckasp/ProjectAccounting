using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class ProjectAccountingProjectPage : ContentPage
    {
        public ProjectAccountingProjectPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var projectAccountingProject = (ProjectAccountingProject)BindingContext;
            await App.Database.SaveProjectAsync(projectAccountingProject);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var projectAccountingProject = (ProjectAccountingProject)BindingContext;

            // Ensure referential integrity
            int NoOfRecords = await App.Database2.CountCashLedgerEntryBasedOnProjectFilterAsync(projectAccountingProject.Code);
            if (NoOfRecords != 0)
            {
                await DisplayAlert("Alert", "You cannot delete this project since there are ledger entries with this project code!", "OK");
                return;
            }

            await App.Database.DeleteProjectAsync(projectAccountingProject);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
