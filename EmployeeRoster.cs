using System;
using System.Collections.Generic;

namespace EmployeeRosterSystem
{
    /**
     *  The employee rota.
     *  
     *  Stores and handles all employee related details and/or actions.
     *  
     *  @contructor - creates an array or Employees with the given size.
     *  @param {int} maxSize - the maximum size of this roster.
     */
    public class EmployeeRoster
    {
        private Employee[] employees;
        private int maxSize;
        public EmployeeRoster(int maxSize)
        {
            this.maxSize = maxSize;
            employees = new Employee[maxSize];
        }

        /**
         *  Adds an employee to an empty slot of this roster.
         *  
         *  @param {Emplpyee} employee - the employee to be added.
         *  @returns {bool} - A state of adding an employee.
         */
        public bool Add(Employee employee)
        {
            for (int i = 0; i < maxSize; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = employee;
                    return true;
                }
            }
            return false;
        }

        /**
         *  Removes an employee from the roster, leaving its slot to null.
         *  
         *  @param {int} employeeId - the id of an employee to be removed.
         *  @returns {bool} - A state of removing the employee.
         */
        public bool Remove(int employeeId)
        {
            if (employeeId < 0 || employeeId >= maxSize || employees[employeeId] == null)
                return false;

            employees[employeeId] = null;
            return true;
        }

        /**
         *  Counts all employees in the roster.
         *  
         *  @returns {int} - the count of all employees.
         */
        public int Count()
        {
            int count = 0;
            for (int i = 0; i < maxSize; i++)
            {
                if (employees[i] != null)
                {
                    count++;
                }
            }
            return count;
        }

        /**
         *  Counts all commissioned employees in the roster.
         *  
         *  @returns {int} - the count of all commissioned employees.
         */
        public int CountCE()
        {
            int count = 0;
            for (int i = 0; i < maxSize; i++)
            {
                if (employees[i] != null && employees[i].GetInfos()["type"].ToString() == "Commissioned Employee")
                {
                    count++;
                }
            }
            return count;
        }

        /**
         *  Counts all hourly employees in the roster.
         *  
         *  @returns {int} - the count of all hourly employees.
         */
        public int CountHE()
        {
            int count = 0;
            for (int i = 0; i < maxSize; i++)
            {
                if (employees[i] != null && employees[i].GetInfos()["type"].ToString() == "Hourly Employee")
                {
                    count++;
                }
            }
            return count;
        }

        /**
         *  Counts all piece workers in the roster.
         *  
         *  @returns {int} - the count of all piece workers.
         */
        public int CountPW()
        {
            int count = 0;
            for (int i = 0; i < maxSize; i++)
            {
                if (employees[i] != null && employees[i].GetInfos()["type"].ToString() == "Piece Worker")
                {
                    count++;
                }
            }
            return count;
        }

        /**
         *  Generates a list of all employee information object. (To be displayed)
         *  
         *  @returns {List<object[]>} - a list of objects that contains employee details.
         */
        public List<object[]> Display()
        {
            List<object[]> allEmployees = new List<object[]>();

            for (int i = 0; i < maxSize; i++)
            {
                if (employees[i] != null)
                {
                    var employee = employees[i].GetInfos();
                    allEmployees.Add(new object[]
                    {
                        employee["name"],
                        employee["address"],
                        employee["age"],
                        employee["companyName"],
                        employee["type"],
                        i
                    });
                }
            }
            return allEmployees;
        }

        /**
         *  Generates a list of all commissioned employee information object. (To be displayed)
         *  
         *  @returns {List<object[]>} - a list of objects that contains commissioned employee details.
         */
        public List<object[]> DisplayCE()
        {
            List<object[]> allCEEmployees = new List<object[]>();

            for (int i = 0; i < maxSize; i++)
            {
                if (employees[i] != null && employees[i].GetInfos()["type"].ToString() == "Commissioned Employee")
                {
                    var employee = employees[i].GetInfos();
                    allCEEmployees.Add(new object[]
                    {
                        employee["name"],
                        employee["address"],
                        employee["age"],
                        employee["companyName"],
                        employee["type"]
                    });
                }
            }
            return allCEEmployees;
        }

        /**
         *  Generates a list of all commissioned hourly information object. (To be displayed)
         *  
         *  @returns {List<object[]>} - a list of objects that contains hourly employee details.
         */
        public List<object[]> DisplayHE()
        {
            List<object[]> allHEEmployees = new List<object[]>();

            for (int i = 0; i < maxSize; i++)
            {
                if (employees[i] != null && employees[i].GetInfos()["type"].ToString() == "Hourly Employee")
                {
                    var employee = employees[i].GetInfos();
                    allHEEmployees.Add(new object[]
                    {
                        employee["name"],
                        employee["address"],
                        employee["age"],
                        employee["companyName"],
                        employee["type"]
                    });
                }
            }
            return allHEEmployees;
        }

        /**
         *  Generates a list of all piece workers information object. (To be displayed)
         *  
         *  @returns {List<object[]>} - a list of objects that contains piece workers details.
         */
        public List<object[]> DisplayPW()
        {
            List<object[]> allPWEmployees = new List<object[]>();

            for (int i = 0; i < maxSize; i++)
            {
                if (employees[i] != null && employees[i].GetInfos()["type"].ToString() == "Piece Worker")
                {
                    var employee = employees[i].GetInfos();
                    allPWEmployees.Add(new object[]
                    {
                        employee["name"],
                        employee["address"],
                        employee["age"],
                        employee["companyName"],
                        employee["type"]
                    });
                }
            }
            return allPWEmployees;
        }

        /**
         *  Generates a payroll of all commissioned employee information object
         *  together with its stats and earnings. (To be displayed)
         *  
         *  @returns {List<object[]>} - a list of objects that contains the employee's payroll.
         */
        public List<object[]> Payroll()
        {
            List<object[]> allEmployees = new List<object[]>();

            for (int i = 0; i < maxSize; i++)
            {
                if (employees[i] != null)
                {
                    var employee = employees[i].GetInfos();
                    var determinants = employees[i].GetDeterminants();

                    List<object> data = new List<object>
                    {
                        i,
                        employee["name"],
                        employee["address"],
                        employee["age"],
                        employee["companyName"],
                        employee["type"],
                        employees[i].Earnings()
                    };

                    if (employee["type"].ToString() == "Commissioned Employee")
                    {
                        data.Add(determinants["regularSalary"]);
                        data.Add(determinants["itemSold"]);
                        data.Add(determinants["commissionRate"]);
                    }

                    if (employee["type"].ToString() == "Hourly Employee")
                    {
                        data.Add(determinants["hoursWorked"]);
                        data.Add(determinants["hourlyRate"]);
                    }

                    if (employee["type"].ToString() == "Piece Worker")
                    {
                        data.Add(determinants["itemsProduced"]);
                        data.Add(determinants["wagePerItem"]);
                    }

                    allEmployees.Add(data.ToArray());
                }
            }
            return allEmployees;
        }

        /**
         *  maxSize getter
         */
        public int GetSize()
        {
            return maxSize;
        }
    }
}