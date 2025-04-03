namespace EmployeeRosterSystem
{
    /**
     *  Person
     *  
     *  A class that describes what a person is
     */
    public class Person
    {
        protected string name;
        protected string address;
        protected int age;

        public Person(string name, string address, int age)
        {
            this.name = name;
            this.address = address;
            this.age = age;
        }
    }
}