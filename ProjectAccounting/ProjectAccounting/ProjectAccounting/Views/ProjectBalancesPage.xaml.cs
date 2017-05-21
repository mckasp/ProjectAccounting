using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class ProjectBalancesPage : ContentPage
    {
        public ProjectBalancesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listViewBalances.ItemsSource = await App.Database.GetProjectBalancesAsync();
        }

    }
}
