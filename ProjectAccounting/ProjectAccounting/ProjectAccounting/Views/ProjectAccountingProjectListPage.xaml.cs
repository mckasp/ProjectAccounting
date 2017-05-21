using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class ProjectAccountingProjectListPage : ContentPage
    {
        public ProjectAccountingProjectListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetProjectsAsync();
        }

        async void OnProjectAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectAccountingProjectPage
            {
                BindingContext = new ProjectAccountingProject()
            });
        }


        async void OnListProjectSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtTodoId = (e.SelectedItem as ProjectAccountingProject).ID;
            Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as ProjectAccountingProject).ID);

            await Navigation.PushAsync(new ProjectAccountingProjectPage
            {
                BindingContext = e.SelectedItem as ProjectAccountingProject
            });
        }
    }
}
