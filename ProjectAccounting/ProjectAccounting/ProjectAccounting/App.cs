using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Xaml;

using Xamarin.Forms;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProjectAccounting
{
    public class App : Application
    {

        static ProjectAccountingProjectDatabase database;
        static ProjectAccountingCashLedgerDatabase database2;
        static CashRegisterDatabase database3;
        public static string DatabaseFilePath;
        public static string DatabaseFileName;
        public static string BackupSourcePath;

        public App()
        {
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            Resources.Add("DatabaseFilePath", DependencyService.Get<IFileHelper>().GetLocalFilePath("Accounting.db"));
            Resources.Add("DatabaseFileName", "Accounting.db");
            Resources.Add("BackupSourcePath", "/storage/emulated/0/BLM");

            var nav = new NavigationPage(new MainPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
            
            // The root page of your application
            // MainPage = new NavigationPage(new MainPage());
        }

        public static ProjectAccountingProjectDatabase Database
        {
            get
            {
                if (database == null)
                {
                    DatabaseFileName = "Accounting.db";
                    DatabaseFilePath = DependencyService.Get<IFileHelper>().GetLocalFilePath(DatabaseFileName);
                    database = new ProjectAccountingProjectDatabase(DatabaseFilePath);
                }
                return database;
            }
        }

        public static ProjectAccountingCashLedgerDatabase Database2
        {
            get
            {
                if (database2 == null)
                {
                    database2 = new ProjectAccountingCashLedgerDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Accounting.db"));
                }
                return database2;
            }
        }

        public static CashRegisterDatabase Database3
        {
            get
            {
                if (database3 == null)
                {
                    database3 = new CashRegisterDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Accounting.db"));
                }
                return database3;
            }
        }

        public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
