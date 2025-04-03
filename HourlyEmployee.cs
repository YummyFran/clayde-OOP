using System.Collections.Generic;

namespace EmployeeRosterSystem
{
    /**
     *  Hourly Employee
     *  
     *  A type of employee that earns through the numbers of hours they worked.
     */
    public class HourlyEmployee : Employee
    {
        private int hoursWorked;
        private decimal hourlyRate;

        public HourlyEmployee(int hoursWorked, decimal hourlyRate,
                             string name, string address, int age, string companyName)
            : base(name, address, age, companyName)
        {
            this.hoursWorked = hoursWorked;
            this.hourlyRate = hourlyRate;
            this.type = "Hourly Employee";
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
                { "hoursWorked", hoursWorked },
                { "hourlyRate", hourlyRate }
            };
        }

        /**
         *  Calculates the employee earnings
         *  
         *  @returns {decimal} - the calculated earnings of this employee
         */
        public override decimal Earnings()
        {
            return hoursWorked > 40 ? hoursWorked * (hourlyRate * 1.5m) : hoursWorked * hourlyRate;
        }
    }
}