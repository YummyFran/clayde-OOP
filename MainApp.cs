using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EmployeeRosterSystem
{
    /**
     * Employee Roster System
     * 
     * Handles declarative functionalites like displaying menu and
     * and recieving user inputs. Controls how the system should behave.
     * 
     */
    public class MainApp
    {
        private EmployeeRoster roster;

        public void Run()
        {
            PlayIntro();
            int size = AskRosterSize();
            roster = new EmployeeRoster(size);
            MainMenu();
        }

        /**
         * 
         * Plays introduction screen of the system
         * 
         * */
        private void PlayIntro()
        {
            Console.Clear();

            string[] art = {
                "░▒▓███████▓▒░ ░▒▓██████▓▒░ ░▒▓███████▓▒░▒▓████████▓▒░▒▓████████▓▒░▒▓███████▓▒░",
                "░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░         ░▒▓█▓▒░   ░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░",
                "░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░         ░▒▓█▓▒░   ░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░",
                "░▒▓███████▓▒░░▒▓█▓▒░░▒▓█▓▒░░▒▓██████▓▒░   ░▒▓█▓▒░   ░▒▓██████▓▒░ ░▒▓███████▓▒░",
                "░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░",
                "░▒▓█▓▒░░▒▓█▓▒░▒▓█▓▒░░▒▓█▓▒░      ░▒▓█▓▒░  ░▒▓█▓▒░   ░▒▓█▓▒░      ░▒▓█▓▒░░▒▓█▓▒░",
                "░▒▓█▓▒░░▒▓█▓▒░░▒▓██████▓▒░░▒▓███████▓▒░   ░▒▓█▓▒░   ░▒▓████████▓▒░▒▓█▓▒░░▒▓█▓▒░"
            };

            PrintText(art);
            Console.WriteLine("\nPress Enter key to continue...");
            Console.ReadLine();
        }

        /**
         *  Asks user to input roster size infinitely until user enters a valid integer.
         *  
         *  @returns {int} A valid integer size.
         */
        private int AskRosterSize()
        {
            Console.Clear();
            PrintText(GenerateTextBox("Booting Employee Roster"));
            Console.WriteLine();
            PrintText("██loading...██████████████████████████", 8);

            int size;
            do
            {
                Console.Clear();
                PrintText(GenerateTextBox("Please Enter Roster Size"));

                if (!int.TryParse(Console.ReadLine(), out size) || size < 1)
                {
                    PrintText("Invalid input. Please enter a number greater than 0.");
                    Thread.Sleep(1000);
                }
            } while (size < 1);

            PrintText($"Creating {size} roster slots...");
            Thread.Sleep(2000);
            PrintText($"{size} slots successfully created!");
            Thread.Sleep(1000);

            return size;
        }

        /**
         *  Displays the main employee roster menu and ask user for an action to execute.
         *  
         *  @returns {int} The choice of action in a form of integer.
         */
        private int DisplayMainMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                PrintText(GenerateTextBox(new[] { "Employee Roster Menu", $"Slots available: {roster.GetSize() - roster.Count()}" }));
                PrintText(new[]
                {
                    "[1] Add Employee",
                    "[2] Delete Employee",
                    "[3] Other Menu",
                    "[0] Exit"
                }, 1, 6);

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
                {
                    PrintText("Invalid input. Please enter a number between 0 and 3.", 2);
                    Thread.Sleep(1000);
                }
            } while (choice < 0 || choice > 3);

            return choice;
        }

        /**
         * Handles the choice of action.
         */
        private void MainMenu()
        {
            int choice = DisplayMainMenu();

            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    DeleteEmployee();
                    break;
                case 3:
                    OtherMenu();
                    break;
                case 0:
                    PrintText("Shutting down...");
                    break;
                default:
                    PrintText("Invalid Input.");
                    MainMenu();
                    break;
            }
        }

        /**
         *  Ask for employee details and add it to the roster if a slot is available.
         */
        private void AddEmployee()
        {
            Console.Clear();

            if (roster.Count() >= roster.GetSize())
            {
                PrintText(GenerateTextBox(new[] { "I'm sorry,", "All slots are occupied" }));
                Thread.Sleep(1000);
                MainMenu();
                return;
            }

            PrintText(GenerateTextBox(new[] { "Add Employee Form", "Please fill up the required details" }));
            Console.WriteLine();

            string name = ValidateInput<string>("Name: ");
            string address = ValidateInput<string>("Address: ");
            string company = ValidateInput<string>("Company Name: ");
            int age = ValidateInput<int>("Age: ", "integer");

            int choice;
            do
            {
                PrintText(new[]
                {
                    "Type of Employee",
                    "[1] Commissioned Employee",
                    "[2] Hourly Employee",
                    "[3] Piece Worker"
                }, 1, 11);

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    PrintText("Invalid input. Please enter a number that corresponds to the type of employee", 2);
                    Thread.Sleep(1000);
                }
            } while (choice < 1 || choice > 3);

            switch (choice)
            {
                case 1:
                    AddCommissionedEmployee(name, address, company, age);
                    break;
                case 2:
                    AddHourlyEmployee(name, address, company, age);
                    break;
                case 3:
                    AddPieceWorker(name, address, company, age);
                    break;
            }

            if (roster.Count() >= roster.GetSize())
            {
                Console.Clear();
                PrintText(GenerateTextBox(new[] { "Warning!", "All slots are occupied" }));
                Thread.Sleep(1000);
                MainMenu();
                return;
            }

            Console.Write("Add more? (y to continue): ");
            if (Console.ReadLine().ToLower() == "y")
                AddEmployee();
            else
                MainMenu();
        }

        /**
         *  A subfunction of AddEmployee that adds an employee as a commissioned employee.
         */
        private void AddCommissionedEmployee(string name, string address, string company, int age)
        {
            decimal regularSalary = ValidateInput<decimal>("Regular salary: ", "float");
            int itemsSold = ValidateInput<int>("Number of sold items: ", "integer");
            int commissionRate = ValidateInput<int>("Commission rate per item: ", "integer");

            var employee = new CommissionEmployee(regularSalary, itemsSold, commissionRate, name, address, age, company);
            if (roster.Add(employee))
                PrintText("Employee added successfully\n", 1);
        }

        /**
         *  A subfunction of AddEmployee that adds an employee as an hourly employee.
         */
        private void AddHourlyEmployee(string name, string address, string company, int age)
        {
            int hoursWorked = ValidateInput<int>("Hours worked: ", "integer");
            int hourlyRate = ValidateInput<int>("Hourly Rate: ", "integer");

            var employee = new HourlyEmployee(hoursWorked, hourlyRate, name, address, age, company);
            if (roster.Add(employee))
                PrintText("Employee added successfully\n", 1);
        }

        /**
         *  A subfunction of AddEmployee that adds an employee as a piece worker.
         */
        private void AddPieceWorker(string name, string address, string company, int age)
        {
            int itemsProduced = ValidateInput<int>("Number of items produced: ", "integer");
            int wagePerItem = ValidateInput<int>("Wage per item: ", "integer");

            var employee = new PieceWorker(itemsProduced, wagePerItem, name, address, age, company);
            if (roster.Add(employee))
                PrintText("Employee added successfully\n", 1);
        }

        /**
         *  Asks user to delete an employee by its index and delete it simultaneously when found.
         */
        private void DeleteEmployee()
        {
            Console.Clear();
            PrintText(GenerateTextBox("Delete Employee"));
            var employees = roster.Display();
            DisplayEmployees(employees, true);

            if (employees.Count == 0)
            {
                Console.ReadLine();
                MainMenu();
                return;
            }

            PrintList(GenerateTextBox(new[] { "Enter Employee Number to Delete", "[0] Return" }));
            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                MainMenu();
                return;
            }

            if (index == 0)
            {
                MainMenu();
                return;
            }

            Console.Clear();
            if (roster.Remove(index - 1))
                PrintText(GenerateTextBox("Employee deleted successfully"), 1);
            else
                PrintText(GenerateTextBox("Employee not found"), 1);

            Thread.Sleep(1000);
            DeleteEmployee();
        }

        /**
         *  Displays the accessublity menu and ask user for an action to execute.
         */
        private void OtherMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                PrintText(GenerateTextBox(new[] { "Accessibility Menu" }));
                PrintText(new[]
                {
                    "[1] Display",
                    "[2] Count",
                    "[3] Payroll",
                    "[0] Return"
                }, 1, 5);

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
                {
                    PrintText("Invalid input. Please enter a number between 0 and 3.", 2);
                    Thread.Sleep(1000);
                }
            } while (choice < 0 || choice > 3);

            switch (choice)
            {
                case 1:
                    DisplayMenu();
                    break;
                case 2:
                    CountMenu();
                    break;
                case 3:
                    Payroll();
                    break;
                case 0:
                    MainMenu();
                    break;
                default:
                    PrintText("Invalid Input.");
                    OtherMenu();
                    break;
            }
        }

        /**
         *  Displays a menu for displaying employees and ask user for an action to execute.
         */
        private void DisplayMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                PrintText(GenerateTextBox("Display Employees"));
                PrintText(new[]
                {
                    "[1] Display All Employees",
                    "[2] Display Commissioned Employees",
                    "[3] Display Hourly Employees",
                    "[4] Display Piece Workers",
                    "[0] Return"
                }, 1, 5);

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
                {
                    PrintText("Invalid input. Please enter a number between 0 and 4.", 2);
                    Thread.Sleep(1000);
                }
            } while (choice < 0 || choice > 4);

            switch (choice)
            {
                case 1:
                    DisplayAllEmployees();
                    break;
                case 2:
                    DisplayCommissionedEmployees();
                    break;
                case 3:
                    DisplayHourlyEmployees();
                    break;
                case 4:
                    DisplayPieceWorkers();
                    break;
                case 0:
                    OtherMenu();
                    break;
            }
        }

        /**
         *  An action that displays all employees.
         */
        private void DisplayAllEmployees()
        {
            Console.Clear();
            PrintText(GenerateTextBox("All Employees"));
            var employees = roster.Display();
            DisplayEmployees(employees, true);
            Console.ReadLine();
            DisplayMenu();
        }

        /**
         *  An action that displays all commissioned employees.
         */
        private void DisplayCommissionedEmployees()
        {
            Console.Clear();
            PrintText(GenerateTextBox("Commissioned Employees"));
            var employees = roster.DisplayCE();
            DisplayEmployees(employees);
            Console.ReadLine();
            DisplayMenu();
        }

        /**
         *  An action that displays all hourly employees.
         */
        private void DisplayHourlyEmployees()
        {
            Console.Clear();
            PrintText(GenerateTextBox("Hourly Employees"));
            var employees = roster.DisplayHE();
            DisplayEmployees(employees);
            Console.ReadLine();
            DisplayMenu();
        }

        /**
         *  An action that displays all piece workers.
         */
        private void DisplayPieceWorkers()
        {
            Console.Clear();
            PrintText(GenerateTextBox("Piece Workers"));
            var employees = roster.DisplayPW();
            DisplayEmployees(employees);
            Console.ReadLine();
            DisplayMenu();
        }

        /**
         *  Displays a list of employees in a card manner.
         */
        private void DisplayEmployees(List<object[]> employees, bool all = false)
        {
            if (employees.Count == 0)
            {
                PrintText(GenerateTextBox("No Employees Found"), 1, 5);
                return;
            }

            for (int i = 0; i < employees.Count; i++)
            {
                var employee = employees[i];
                var card = new List<string>();

                if (all) card.Add($"Employee #{(int)employee[5] + 1}");
                else card.Add($"{i + 1}.");

                card.Add($"Name: {employee[0]}");
                card.Add($"Address: {employee[1]}");
                card.Add($"Age: {employee[2]}");
                card.Add($"Company Name: {employee[3]}");
                card.Add($"Type: {employee[4]}");

                PrintList(GenerateLeftAlignedTextBox(card));
            }
        }

        /**
         *  Displays a menu for counting employees and ask user for an action to execute.
         */
        private void CountMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                PrintText(GenerateTextBox("Count Employees"));
                PrintText(new[]
                {
                    "[1] Count All Employees",
                    "[2] Count Commissioned Employees",
                    "[3] Count Hourly Employees",
                    "[4] Count Piece Workers",
                    "[0] Return"
                }, 1, 5);

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4)
                {
                    PrintText("Invalid input. Please enter a number between 0 and 4.", 2);
                    Thread.Sleep(1000);
                }
            } while (choice < 0 || choice > 4);

            switch (choice)
            {
                case 1:
                    CountAllEmployees();
                    break;
                case 2:
                    CountCommissionedEmployees();
                    break;
                case 3:
                    CountHourlyEmployees();
                    break;
                case 4:
                    CountPieceWorkers();
                    break;
                case 0:
                    OtherMenu();
                    break;
            }
        }

        /**
         *  Counts all employees and display it to the screen
         */
        private void CountAllEmployees()
        {
            Console.Clear();
            int count = roster.Count();
            int max = roster.GetSize();
            PrintText(GenerateTextBox(new[]
            {
                "All Employees Listed",
                $"{count} out of {max}"
            }));
            Console.ReadLine();
            CountMenu();
        }

        /**
         *  Counts all commissioned employees and display it to the screen
         */
        private void CountCommissionedEmployees()
        {
            Console.Clear();
            int count = roster.CountCE();
            int max = roster.GetSize();
            PrintText(GenerateTextBox(new[]
            {
                "Commissioned Employees Listed",
                $"{count} out of {max}"
            }));
            Console.ReadLine();
            CountMenu();
        }

        /**
         *  Counts all hourly employees and display it to the screen
         */
        private void CountHourlyEmployees()
        {
            Console.Clear();
            int count = roster.CountHE();
            int max = roster.GetSize();
            PrintText(GenerateTextBox(new[]
            {
                "Hourly Employees Listed",
                $"{count} out of {max}"
            }));
            Console.ReadLine();
            CountMenu();
        }

        /**
         *  Counts all piece workers and display it to the screen
         */
        private void CountPieceWorkers()
        {
            Console.Clear();
            int count = roster.CountPW();
            int max = roster.GetSize();
            PrintText(GenerateTextBox(new[]
            {
                "Piece Workers Listed",
                $"{count} out of {max}"
            }));
            Console.ReadLine();
            CountMenu();
        }

        /**
         *  Displays all the employee details with their stats and calculated earnings.
         */
        private void Payroll()
        {
            Console.Clear();
            PrintText(GenerateTextBox("Pay Roll"));
            var employees = roster.Payroll();

            if (employees.Count == 0)
            {
                PrintText(GenerateTextBox("No Employees Found"), 1, 5);
                Console.ReadLine();
                OtherMenu();
                return;
            }

            for (int i = 0; i < employees.Count; i++)
            {
                var employee = employees[i];
                var card = new List<string>();

                card.Add($"Employee #{(int)employee[0] + 1}");
                card.Add($"Name: {employee[1]}");
                card.Add($"Address: {employee[2]}");
                card.Add($"Age: {employee[3]}");
                card.Add($"Company Name: {employee[4]}");

                if (employee[5].ToString() == "Commissioned Employee")
                {
                    card.Add($"Regular Salary: {employee[7]}");
                    card.Add($"Items Sold: {employee[8]}");
                    card.Add($"Commission Rate: {employee[9]}");
                }

                if (employee[5].ToString() == "Hourly Employee")
                {
                    card.Add($"Hours Worked: {employee[7]}");
                    card.Add($"Hourly Rate: {employee[8]}");
                }

                if (employee[5].ToString() == "Piece Worker")
                {
                    card.Add($"Items Produced: {employee[7]}");
                    card.Add($"Wage Per Item: {employee[8]}");
                }

                card.Add($"Earnings: {employee[6]}");

                PrintList(GenerateLeftAlignedTextBox(card));
            }

            Console.ReadLine();
            OtherMenu();
        }

        /**
         *  A helper function to generate a left aligned textbox.
         *  
         *  @param {List<string>} texts - a list of raw strings to be generated inside a box.
         *  @returns {List<string>} A generated textbox
         */
        private List<string> GenerateLeftAlignedTextBox(List<string> texts)
        {
            var box = new List<string>();
            int maxTextSize = 0;
            foreach (var text in texts)
            {
                if (text.Length > maxTextSize) maxTextSize = text.Length;
            }
            int padding = 2;

            for (int i = 0; i < texts.Count + 3; i++)
            {
                string current = i == 0 ? "." : "|";
                int textSize = i > 1 && i < texts.Count + 2 ? texts[i - 2].Length : maxTextSize;

                for (int j = 0; j < maxTextSize + (padding * 2); j++)
                {
                    current += (i == 0 || i == 2 + texts.Count) ? '_' :
                        ((i == 1 || j < padding || j >= padding + textSize) ? ' ' :
                        texts[i - 2][j - padding]);
                }

                current += i == 0 ? ". " : "|";
                box.Add(current);
            }

            return box;
        }

        /**
         *  A helper function to generate a center aligned textbox.
         *  
         *  @param {string[]} texts - an array of raw strings to be generated inside a box.
         *  @returns {List<string>} A generated textbox
         */
        private List<string> GenerateTextBox(string[] texts)
        {
            if (texts == null) texts = new[] { "" };

            var box = new List<string>();
            int maxTextSize = 0;
            foreach (var text in texts)
            {
                if (text.Length > maxTextSize) maxTextSize = text.Length;
            }
            int padding = 8;

            // row
            for (int i = 0; i < texts.Length + 3; i++)
            {
                string current = i == 0 ? "." : "|";
                int textSize = i > 1 && i < texts.Length + 2 ? texts[i - 2].Length : maxTextSize;
                bool isOdd = (maxTextSize - textSize) % 2 == 1;

                // col
                for (int j = 0; j < maxTextSize + (padding * 2); j++)
                {
                    current += (i == 0 || i == 2 + texts.Length) ? '_' :
                        ((i == 1 || j < padding + ((maxTextSize - textSize) / 2) ||
                        j >= padding + textSize + ((maxTextSize - textSize) / 2)) ? ' ' :
                        texts[i - 2][j - padding - (int)(((maxTextSize - textSize) + (isOdd ? 0 : 1)) / 2)]);
                }

                current += i == 0 ? ". " : "| ";
                box.Add(current);
            }

            return box;
        }

        /**
         *  A helper function to generate a center aligned textbox.
         *  
         *  @param {string} text - a string to be generated inside a box.
         *  @returns {List<string>} A generated textbox
         */
        private List<string> GenerateTextBox(string text)
        {
            return GenerateTextBox(new[] { text });
        }

        /**
         *  Prints an animated list of strings
         *  
         *  @param {List<string>} list - a list of string
         */
        private void PrintList(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
                Thread.Sleep(40);
            }
        }

        /**
         *  Prints an animated array of strings
         *  
         *  @param {string[]} text - an array of strings to be printed.
         *  @param {int} [duration = 1] - duration of the animation in seconds.
         *  @param {int} [startRow = 0] - a custom starting row to print and animate.
         */
        private void PrintText(string[] text, int duration = 1, int startRow = 0)
        {
            if (text == null || text.Length == 0) return;

            int rows = text.Length;
            int cols = text.Max(line => line.Length);
            int totalCharacters = rows * cols;
            double delay = (double)duration / totalCharacters;

            char[][] output = new char[rows][];
            for (int i = 0; i < rows; i++)
                output[i] = new string(' ', cols).ToCharArray();

            for (int d = 0; d < rows + (cols * 3); d++)
            {
                for (int row = 0; row <= d; row++)
                {
                    int col = d - row;
                    if (row < rows && col < text[row].Length)
                        output[row][col] = text[row][col];
                }

                for (int i = 0; i < rows; i++)
                {
                    Console.SetCursorPosition(0, startRow + i);
                    Console.Write(new string(output[i]).TrimEnd());
                }

                Thread.Sleep((int)(delay * 1000));
            }

            Console.WriteLine();
        }

        /**
         *  Prints an animated string.
         *  
         *  @param {string} text - a strings to be printed.
         *  @param {int} [duration = 1] - duration of the animation in seconds.
         *  @param {int} [startRow = 0] - a custom starting row to print and animate.
         */
        private void PrintText(string text, int duration = 1, int startRow = 0)
        {
            if (string.IsNullOrEmpty(text)) return;

            int textLength = text.Length;
            double delay = (double)duration / textLength;
            string current = "";

            for (int i = 0; i < textLength; i++)
            {
                Console.Write("\r" + (current += text[i]));
                Thread.Sleep((int)(delay * 1000));
            }

            Console.WriteLine();
        }

        /**
         *  Prints an animated list of strings
         *  
         *  @param {List<string>} text - a list of strings to be printed.
         *  @param {int} [duration = 1] - duration of the animation in seconds.
         *  @param {int} [startRow = 0] - a custom starting row to print and animate.
         */
        private void PrintText(List<string> text, int duration = 1, int startRow = 0)
        {
            if (text == null || text.Count == 0) return;

            int rows = text.Count;
            int cols = text.Max(line => line.Length);
            int totalCharacters = rows * cols;
            double delay = (double)duration / totalCharacters;

            char[][] output = new char[rows][];
            for (int i = 0; i < rows; i++)
                output[i] = new string(' ', cols).ToCharArray();

            for (int d = 0; d < rows + (cols * 3); d++)
            {
                for (int row = 0; row <= d; row++)
                {
                    int col = d - row;
                    if (row < rows && col < text[row].Length)
                        output[row][col] = text[row][col];
                }

                for (int i = 0; i < rows; i++)
                {
                    Console.SetCursorPosition(0, startRow + i);
                    Console.Write(new string(output[i]).TrimEnd());
                }

                Thread.Sleep((int)(delay * 1000));
            }

            Console.WriteLine();
        }

        /**
         *  A helper function to validate any user inputs.
         *  
         *  @param {string} label - a subject user input to be validated
         *  @param {string} [expectedType = "string"] - an expected type of a label
         *  @returns {T} a generic object of type T that contains the parsed input.
         */
        private T ValidateInput<T>(string label, string expectedType = "string")
        {
            while (true)
            {
                Console.Write(label);
                string input = Console.ReadLine();

                if (expectedType == "integer")
                {
                    if (int.TryParse(input, out int result) && result > 0)
                        return (T)(object)result;
                    PrintText("Input must be an integer greater than 0.");
                }
                else if (expectedType == "float")
                {
                    if (decimal.TryParse(input, out decimal result) && result > 0)
                        return (T)(object)result;
                    PrintText("Input must be a float/integer greater than 0.");
                }
                else // string
                {
                    if (!string.IsNullOrWhiteSpace(input))
                        return (T)(object)input;
                    PrintText("Input cannot be empty.");
                }

                Thread.Sleep(500);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }
    }
}