using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ProjectAccounting
{
    public class ProjectAccountingProjectDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ProjectAccountingProjectDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath,false);
            database.CreateTableAsync<ProjectAccountingProject>().Wait();
        }

        public Task<List<ProjectAccountingProject>> GetProjectsAsync()
        {
            return database.Table<ProjectAccountingProject>().ToListAsync();
        }

        public Task<List<ProjectAccountingProject>> GetProjectBalancesAsync()
        {
            return database.QueryAsync<ProjectAccountingProject>(@"SELECT Code, Name, Sum(Amount) AS Balance FROM ProjectAccountingProject INNER JOIN ProjectAccountingCashLedger " +
                                                     "ON [ProjectAccountingProject].Code = [ProjectAccountingCashLedger].Project GROUP BY Code " +
                                                     "UNION " +
                                                     "SELECT '_ T O T A L', '', Sum(Amount) AS Balance FROM ProjectAccountingCashLedger");
        }

        public Task<ProjectAccountingProject> GetProjectAsync(int id)
        {
            return database.Table<ProjectAccountingProject>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveProjectAsync(ProjectAccountingProject project)
        {
            if (project.ID != 0)
            {
                return database.UpdateAsync(project);
            }
            else
            {
                return database.InsertAsync(project);
            }
        }

        public Task<int> DeleteProjectAsync(ProjectAccountingProject project)
        {
            return database.DeleteAsync(project);
        }

        public Task<int> LookupProjectAsync(string project)
        {
            return database.Table<ProjectAccountingProject>().Where(i => i.Code == project).CountAsync();
        }

    }
}

