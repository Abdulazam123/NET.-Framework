// Employee class stores employee information
class Employee
{
    // Property for Employee Id
    public int Id { get; set; }

    // Property for Employee First Name
    public string FirstName { get; set; }

    // Property for Employee Last Name
    public string LastName { get; set; }

    // Overloading == operator to compare Employee objects by Id
    public static bool operator ==(Employee emp1, Employee emp2)
    {
        // Check if both employee IDs are equal
        return emp1.Id == emp2.Id;
    }

    // Overloading != operator because comparison operators must be overloaded in pairs
    public static bool operator !=(Employee emp1, Employee emp2)
    {
        // Check if both employee IDs are not equal
        return emp1.Id != emp2.Id;
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // Creating first Employee object
        Employee employee1 = new Employee();

        // Assigning values to first employee
        employee1.Id = 1;
        employee1.FirstName = "John";
        employee1.LastName = "Smith";

        // Creating second Employee object
        Employee employee2 = new Employee();

        // Assigning values to second employee
        employee2.Id = 1;
        employee2.FirstName = "Michael";
        employee2.LastName = "Brown";

        // Comparing both employees using overloaded == operator
        if (employee1 == employee2)
        {
            Console.WriteLine("Both employees are equal.");
        }
        else
        {
            Console.WriteLine("Employees are not equal.");
        }

        // Comparing both employees using overloaded != operator
        if (employee1 != employee2)
        {
            Console.WriteLine("Employees are different.");
        }
        else
        {
            Console.WriteLine("Employees are the same.");
        }
    }
}