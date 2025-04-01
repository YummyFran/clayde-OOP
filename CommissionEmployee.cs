using System.Collections.Generic;

namespace EmployeeRosterSystem
{
    public class CommissionEmployee : Employee
    {
        private decimal regularSalary;
        private int itemSold;
        private decimal commissionRate;

        public CommissionEmployee(decimal regularSalary, int itemSold, decimal commissionRate,
                                string name, string address, int age, string companyName)
            : base(name, address, age, companyName)
        {
            this.regularSalary = regularSalary;
            this.itemSold = itemSold;
            this.commissionRate = commissionRate;
            this.type = "Commissioned Employee";
        }

        public override Dictionary<string, object> GetDeterminants()
        {
            return new Dictionary<string, object>
            {
                { "regularSalary", regularSalary },
                { "itemSold", itemSold },
                { "commissionRate", commissionRate }
            };
        }

        public override decimal Earnings()
        {
            return regularSalary + (itemSold * commissionRate);
        }
    }
}