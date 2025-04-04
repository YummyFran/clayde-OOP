﻿using System.Collections.Generic;

namespace EmployeeRosterSystem
{
    public class CommissionEmployee : Employee
    {
        /**
         *  Commissioned Employee
         *  
         *  A type of employee that earns through its salary plus a commission per item.
         */
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

        /**
         *  Overridden determinants that adds to this employees information
         *  
         *  @returns {Dictionary<string, object>} - a map of determinants
         */
        public override Dictionary<string, object> GetDeterminants()
        {
            return new Dictionary<string, object>
            {
                { "regularSalary", regularSalary },
                { "itemSold", itemSold },
                { "commissionRate", commissionRate }
            };
        }

        /**
         *  Calculates the employee earnings
         *  
         *  @returns {decimal} - the calculated earnings of this employee
         */
        public override decimal Earnings()
        {
            return regularSalary + (itemSold * commissionRate);
        }
    }
}