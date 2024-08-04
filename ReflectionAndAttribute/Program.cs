using ReflectionAndAttribute.Models;
using ReflectionAndAttribute.Repository;

namespace ReflectionAndAttribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mapping using Reflection
            Employee employee = new Employee() { Name = "Meghana", Department = "Delivery" };
            EmployeeDetails employeeDetails = new EmployeeDetails();

            EmployeeDetailsRepository employeeDetailsRepository = new EmployeeDetailsRepository();
            employeeDetailsRepository.Map(employee, employeeDetails);

            Console.WriteLine($"Employee Details data{employeeDetails.Name}, {employeeDetails.Department}");

        }
    }
}
