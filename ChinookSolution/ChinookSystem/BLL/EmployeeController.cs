using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using ChinookSystem.DAL;
using ChinookSystem.Entities;
using ChinookSystem.ViewModels;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class EmployeeController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<EmployeeItem> Employee_EmployeeCustomers()
        {
            using (var context = new ChinookSystemContext())
            {
				IEnumerable<EmployeeItem> results = from x in context.Employees
													 where x.Title.Contains("Sales Support")
													 orderby x.LastName, x.FirstName
													 select new EmployeeItem
													 {
														 FullName = x.LastName + ", " + x.FirstName,
														 Title = x.Title,
														 NumberOfCustomers = x.Customers.Count(),
														 CustomerList = (from y in x.Customers
																		 select new CustomerItem
																		 {
																			 FullName = y.LastName + ", " + y.FirstName,
																			 Phone = y.Phone,
																			 City = y.City,
																			 State = y.State
																		 }).ToList()
													 };
				return results.ToList();


			}
        }
    }
}
