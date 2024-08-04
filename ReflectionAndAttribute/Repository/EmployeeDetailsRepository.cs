using ReflectionAndAttribute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttribute.Repository
{
    public class EmployeeDetailsRepository
    {
        public void Map(Employee employee , EmployeeDetails employeeDetails)
        {
            Type employeeType = employee.GetType();
            Type employeeDetailsType = employeeDetails.GetType();
            var employeeProperties = employeeType.GetProperties();
            var employeeDetailsProperties = employeeDetailsType.GetProperties();

            var commonproperties = from ep in employeeProperties
                                   join edp in employeeDetailsProperties on new { ep.Name, ep.PropertyType } equals
                                       new { edp.Name, edp.PropertyType }
                                   select new { ep, edp };

            foreach (var match in commonproperties)
            {
                match.edp.SetValue(employeeDetails, match.ep.GetValue(employee, null), null);
            }
            employeeDetails.CreatedDate = DateTime.Now;
        }
    }
}
