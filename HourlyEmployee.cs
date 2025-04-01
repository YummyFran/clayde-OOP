using System.Collections.Generic;

namespace EmployeeRosterSystem
{
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

        public override Dictionary<string, object> GetDeterminants()
        {
            return new Dictionary<string, object>
            {
                { "hoursWorked", hoursWorked },
                { "hourlyRate", hourlyRate }
            };
        }

        public override decimal Earnings()
        {
            return hoursWorked > 40 ? hoursWorked * (hourlyRate * 1.5m) : hoursWorked * hourlyRate;
        }
    }
}