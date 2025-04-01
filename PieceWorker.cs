using System.Collections.Generic;

namespace EmployeeRosterSystem
{
    public class PieceWorker : Employee
    {
        private int itemsProduced;
        private decimal wagePerItem;

        public PieceWorker(int itemsProduced, decimal wagePerItem,
                          string name, string address, int age, string companyName)
            : base(name, address, age, companyName)
        {
            this.itemsProduced = itemsProduced;
            this.wagePerItem = wagePerItem;
            this.type = "Piece Worker";
        }

        public override Dictionary<string, object> GetDeterminants()
        {
            return new Dictionary<string, object>
            {
                { "itemsProduced", itemsProduced },
                { "wagePerItem", wagePerItem }
            };
        }

        public override decimal Earnings()
        {
            return itemsProduced * wagePerItem;
        }
    }
}