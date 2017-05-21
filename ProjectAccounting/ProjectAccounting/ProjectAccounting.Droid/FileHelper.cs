using System;
using System.IO;
using Xamarin.Forms;
using System.Collections;
using ProjectAccounting.Droid;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace ProjectAccounting.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }

        public bool BackupDatabase(string filepath, string filename)
        {
            try
            {

                // Access to the following path on the SD card is denied
                // var myFolder = "/storage/extSdCard/BLM";

                var documents = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                var myFolder = Path.Combine(documents, "BLM");
                if (!(Directory.Exists(myFolder)))
                {
                    Directory.CreateDirectory(myFolder);
                }
                File.Copy(filepath, Path.Combine(myFolder, filename));
                return true;
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine("{0} Database 'Accounting.db' could not be backed up to directory BLM.", e);
                return false;
            }
        }

        public bool RestoreDatabase(string filepath, string filename)
        {
            try
            {
                var documents = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                var myFolder = Path.Combine(documents, "BLM");
                File.Copy(Path.Combine(myFolder, filename),filepath,true);
                return true;
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine("{0} Database 'Accounting.db' could not be restored from directory BLM.", e);
                return false;
            }
        }

        /*
        public string[] GetFiles(string databasePath)
        {
            return Directory.GetFiles(databasePath)
                            .Select(Path.GetFileName)
                            .ToArray();
        }
        */

        public IEnumerable GetFiles(string databasePath)
        {
            return Directory.GetFiles(databasePath)
                            .Select(Path.GetFileName);
        }

        public void FileCopy(string oldPathAndName, string newPathAndName, bool overwrite)
        {
            File.Copy(oldPathAndName, newPathAndName, overwrite);
        }
    }
}