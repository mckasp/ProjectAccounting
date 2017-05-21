using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class ProjectLookupPage : ContentPage
    {
        public ProjectLookupPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            lookupListView.ItemsSource = await App.Database.GetProjectsAsync();
        }


        async void OnLookupProjectSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                lookupListView.SelectedItem = null;

                MessagingCenter.Send<ProjectLookupPage, ProjectAccountingProject>
                    (this, "ProjectSelection", (ProjectAccountingProject)args.SelectedItem);

                Navigation.PopModalAsync();
            }

        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }


}
