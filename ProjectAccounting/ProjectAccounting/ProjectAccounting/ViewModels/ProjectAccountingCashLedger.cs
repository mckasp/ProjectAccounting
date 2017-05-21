using SQLite;
using System;

namespace ProjectAccounting
{
    public class ProjectAccountingCashLedger
    {

        public ProjectAccountingCashLedger()
        {
            PostingDate = DateTime.Today;
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime PostingDate { get; set; }
        public string Description { get; set; }
        public string CashRegister { get; set; }
        public string Project { get; set; }
        public decimal Amount { get; set; }
    }
}