namespace Factory_Pattern
{
    /// <summary>
    /// this is demonstration of Factory pattern where dedicates the responsiblity of creating the objects to Factory class or method.
    /// We made constructor private to avoid new keyword in the code, so that no one can create objects
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private Employee() { }

        private Employee(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static class EmployeeFactory
        {
            public static Employee NewEmployee(int id, string name)
            {
                return new Employee(id, name);
            }
        }

        public override string ToString()
        {
            return $"Employee Name: {this.Name} Employee ID: {this.Id}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = Employee.EmployeeFactory.NewEmployee(1, "Aejaz");
            Console.WriteLine(employee.ToString());
        }
    }
}
