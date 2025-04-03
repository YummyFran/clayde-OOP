using System.Collections.Generic;

namespace EmployeeRosterSystem
{
    /**
     *  Employee
     *  
     *  An abstract class that handles informations of any employee
     */
    public abstract class Employee : Person
    {
        private string companyName;
        protected string type;

        public Employee(string name, string address, int age, string companyName)
            : base(name, address, age)
        {
            this.companyName = companyName;
        }

        /**
         *  An abstract method that would calculates the employee earnings
         *  
         *  @returns {decimal} - the calculated earnings of this employee
         */
        public abstract decimal Earnings();

        public Dictionary<string, object> GetInfos()
        {
            return new Dictionary<string, object>
            {
                { "name", name },
                { "address", address },
                { "age", age },
                { "companyName", companyName },
                { "type", type }
            };
        }

        /**
         *  An abstract method that determines the stats of a specific employee.
         *  
         *  @returns {Dictionary<string, object>} - a map of determinants
         */
        public abstract Dictionary<string, object> GetDeterminants();
    }
}