using System;
using System.Collections.Generic;

namespace EmployeeRosterSystem
{
    public class EmployeeRoster
    {
        private Employee[] employees;
        private int maxSize;

        public EmployeeRoster(int maxSize)
        {
            this.maxSize = maxSize;
            employees = new Employee[maxSize];
        }

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

        public bool Remove(int employeeId)
        {
            if (employeeId < 0 || employeeId >= maxSize || employees[employeeId] == null)
                return false;

            employees[employeeId] = null;
            return true;
        }

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

        public int GetSize()
        {
            return maxSize;
        }
    }
}