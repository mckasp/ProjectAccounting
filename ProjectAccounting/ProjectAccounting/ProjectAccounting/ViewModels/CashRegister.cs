using SQLite;

namespace ProjectAccounting
{
    public class CashRegister
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
