using System.Collections;


namespace ProjectAccounting
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);

        bool BackupDatabase(string filepath, string filename);

        bool RestoreDatabase(string filepath, string filename);

        // string[] GetFiles(string databasePath);

        IEnumerable GetFiles(string databasePath);

        void FileCopy(string oldPathAndName, string newPathAndName, bool overwrite);
    }
}
