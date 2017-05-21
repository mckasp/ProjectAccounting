using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ProjectAccounting
{
    public class CashRegisterDatabase
    {
        readonly SQLiteAsyncConnection database3;

        public CashRegisterDatabase(string dbPath)
        {
            database3 = new SQLiteAsyncConnection(dbPath, false);
            database3.CreateTableAsync<CashRegister>().Wait();
        }

        public Task<List<CashRegister>> GetCashRegistersAsync()
        {
            return database3.Table<CashRegister>().ToListAsync();
        }

        public Task<List<CashRegister>> GetCashRegisterBalancesAsync()
        {
            return database3.QueryAsync<CashRegister>(@"SELECT Code, Name, Sum(Amount) AS Balance FROM [CashRegister] INNER JOIN [ProjectAccountingCashLedger] " +
                                                     "ON [CashRegister].Code = [ProjectAccountingCashLedger].CashRegister GROUP BY Code " +
                                                     "UNION " +
                                                     "SELECT '_ T O T A L', '', Sum(Amount) AS Balance FROM ProjectAccountingCashLedger");
        }

        public Task<CashRegister> GetCashRegisterAsync(int id)
        {
            return database3.Table<CashRegister>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveCashRegisterAsync(CashRegister cashRegister)
        {
            if (cashRegister.ID != 0)
            {
                return database3.UpdateAsync(cashRegister);
            }
            else
            {
                return database3.InsertAsync(cashRegister);
            }
        }

        public Task<int> DeleteCashRegisterAsync(CashRegister cashRegister)
        {
            return database3.DeleteAsync(cashRegister);
        }

        public Task<int> LookupCashRegisterAsync(string cashRegister)
        {
            return database3.Table<CashRegister>().Where(i => i.Code == cashRegister).CountAsync();
        }

    }
}

