using CSNK.Services.Features.Student.Model;
using System.Collections.Generic;

namespace CSNK.Services.Features.Student
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetCustomers();
        CustomerModel GetCustomer(int ID);
    }
}
