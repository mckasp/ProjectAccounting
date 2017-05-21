using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;

namespace ProjectAccounting
{
    public partial class DatabaseLookupPage : ContentPage
    {
        public DatabaseLookupPage()
        {
            InitializeComponent();

            // string[] fileNames = DependencyService.Get<IFileHelper>().GetFiles(App.Current.Resources["BackupSourcePath"].ToString());
            // lookupListViewDatabase.ItemsSource = fileNames;

            lookupListViewDatabase.ItemsSource = DependencyService.Get<IFileHelper>().GetFiles(App.Current.Resources["BackupSourcePath"].ToString());
        }

        public void OnLookupDatabaseSelected(object sender, SelectedItemChangedEventArgs args)
        {
            DependencyService.Get<IFileHelper>().FileCopy(App.Current.Resources["BackupSourcePath"].ToString() + "/" + args.SelectedItem.ToString(), App.Current.Resources["DatabaseFilePath"].ToString(),true);
            Navigation.PopAsync();
            DisplayAlert("Alert", "The database was successfully restored!", "OK");
        }
    }
}
