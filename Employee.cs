using System.Collections.Generic;

namespace EmployeeRosterSystem
{
    public abstract class Employee : Person
    {
        private string companyName;
        protected string type;

        public Employee(string name, string address, int age, string companyName)
            : base(name, address, age)
        {
            this.companyName = companyName;
        }

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

        public abstract Dictionary<string, object> GetDeterminants();
    }
}