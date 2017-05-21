using SQLite;

namespace ProjectAccounting
{
    public class ProjectAccountingProject
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
