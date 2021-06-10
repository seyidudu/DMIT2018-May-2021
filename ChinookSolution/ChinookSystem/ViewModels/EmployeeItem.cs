using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.ViewModels
{
    public class EmployeeItem
    {
        public String FullName { get; set; }
        public String Title { get; set; }
        public int NumberOfCustomers { get; set; }
        public List<CustomerItem> CustomerList { get; set; }
    }
}
