using System.Collections.Generic;

namespace EmployeeRosterSystem
{
    /**
     *  Piece Worker
     *  
     *  A type of employee that earns through the number of items they produce
     *  
     */
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

        /**
         *  Overridden determinants that adds to this employees information
         *  
         *  @returns {Dictionary<string, object>} - a map of determinants
         */
        public override Dictionary<string, object> GetDeterminants()
        {
            return new Dictionary<string, object>
            {
                { "itemsProduced", itemsProduced },
                { "wagePerItem", wagePerItem }
            };
        }

        /**
         *  Calculates the employee earnings
         *  
         *  @returns {decimal} - the calculated earnings of this employee
         */
        public override decimal Earnings()
        {
            return itemsProduced * wagePerItem;
        }
    }
}