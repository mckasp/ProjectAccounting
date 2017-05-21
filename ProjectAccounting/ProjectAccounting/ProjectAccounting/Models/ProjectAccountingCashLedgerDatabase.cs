using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ProjectAccounting
{
    public class ProjectAccountingCashLedgerDatabase
    {
        readonly SQLiteAsyncConnection database2;

        public ProjectAccountingCashLedgerDatabase(string dbPath)
        {
            database2 = new SQLiteAsyncConnection(dbPath,false);
            database2.CreateTableAsync<ProjectAccountingCashLedger>().Wait();
        }

        public Task<List<ProjectAccountingCashLedger>> GetCashLedgerEntriesAsync()
        {
            return database2.Table<ProjectAccountingCashLedger>().ToListAsync();
        }

        //public Task<List<ProjectAccountingProject>> GetProjectsAsync()
        //{
        //    return database2.QueryAsync<ProjectAccountingProject>("SELECT * FROM [ProjectAccountingProject]");
        //}

        public Task<ProjectAccountingCashLedger> GetCashLedgerEntryAsync(int id)
        {
            return database2.Table<ProjectAccountingCashLedger>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveCashLedgerEntryAsync(ProjectAccountingCashLedger cashLedgerEntry)
        {
            if (cashLedgerEntry.ID != 0)
            {
                return database2.UpdateAsync(cashLedgerEntry);
            }
            else
            {
                return database2.InsertAsync(cashLedgerEntry);
            }
        }

        public Task<int> DeleteCashLedgerEntryAsync(ProjectAccountingCashLedger cashLedgerEntry)
        {
            return database2.DeleteAsync(cashLedgerEntry);
        }

        public Task<int> CountCashLedgerEntryBasedOnProjectFilterAsync(string filter)
        {
                return database2.Table<ProjectAccountingCashLedger>().Where(i => i.Project == filter).CountAsync();
        }

        public Task<int> CountCashLedgerEntryBasedOnCashRegisterFilterAsync(string filter)
        {
            return database2.Table<ProjectAccountingCashLedger>().Where(i => i.CashRegister == filter).CountAsync();
        }
    }
}
