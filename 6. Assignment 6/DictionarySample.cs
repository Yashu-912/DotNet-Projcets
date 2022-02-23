[Serializable]
    public class EmployeeIdException : Exception
    {
        public EmployeeIdException(string message) : base(message)  { }
    }

    [Serializable]
    public struct EmployeeId : IEquatable<EmployeeId>
    {
        private readonly char prefix;
        private readonly int number;

        public EmployeeId(string id)
        {
            if (id == null) throw new ArgumentNullException("id");

            prefix = (id.ToUpper())[0];
            int numLength = id.Length - 1;
            try
            {
                number = int.Parse(id.Substring(1, numLength > 6 ? 6 : numLength));
            }
            catch (FormatException)
            {
                throw new EmployeeIdException("Invalid EmployeeId format");
            }
        }

        public override string ToString()
        {
            return prefix.ToString() + string.Format("{0,6:000000}", number);
        }

        public override int GetHashCode()
        {
            return (number ^ number << 16) * 0x15051505;
        }

        public bool Equals(EmployeeId other)
        {
            if (other == null) return false;

            return (prefix == other.prefix && number == other.number);
        }

        public override bool Equals(object obj)
        {
            return Equals((EmployeeId)obj);
        }

        public static bool operator ==(EmployeeId left, EmployeeId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EmployeeId left, EmployeeId right)
        {
            return !(left == right);
        }
    }

[Serializable]
    public class Employee1
    {
        private string name;
        private decimal salary;
        private readonly EmployeeId id;

        public Employee1(EmployeeId id, string name, decimal salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1, -20} {2:C}",
                  id.ToString(), name, salary);
        }
    }


internal class DictionarySample
    {
        internal static void DictionaryMain()
        {
            var employees = new Dictionary<EmployeeId, Employee1>(31);

            var idKyle = new EmployeeId("T3755");
            var kyle = new Employee1(idKyle, "Kyle Bush", 5443890.00m);
            employees.Add(idKyle, kyle);
            Console.WriteLine(kyle);

            var idCarl = new EmployeeId("F3547");
            var carl = new Employee1(idCarl, "Carl Edwards", 5597120.00m);
            employees.Add(idCarl, carl);
            Console.WriteLine(carl);

            var idJimmie = new EmployeeId("C3386");
            var jimmie = new Employee1(idJimmie, "Jimmie Johnson", 5024710.00m);
            employees.Add(idJimmie, jimmie);
            Console.WriteLine(jimmie);

            var idDale = new EmployeeId("C3323");
            var dale = new Employee1(idDale, "Dale Earnhardt Jr.", 3522740.00m);
            employees[idDale] = dale;
            Console.WriteLine(dale);

            var idJeff = new EmployeeId("C3234");
            var jeff = new Employee1(idJeff, "Jeff Burton", 3879540.00m);
            employees[idJeff] = jeff;
            Console.WriteLine(jeff);



            while (true)
            {
                Console.Write("Enter employee id (X to exit)> ");
                var userInput = Console.ReadLine();
                userInput = userInput.ToUpper();
                if (userInput == "X") break;

                EmployeeId id;
                try
                {
                    id = new EmployeeId(userInput);


                    Employee1 employee;
                    if (!employees.TryGetValue(id, out employee))
                    {
                        Console.WriteLine("Employee with id {0} does not exist", id);
                    }
                    else
                    {
                        Console.WriteLine(employee);
                    }
                }
                catch (EmployeeIdException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }