using CSNK.Common.Base.APIClient;
using CSNK.Services.API.Proxy.Domains;
using System.Collections.Generic;

namespace CSNK.Services.API.Proxy
{
    public interface ICustomerProxyRepository
    {
        List<CustomerDomain> GetCustomers();
        CustomerDomain GetCustomerByID(int ID);
    }
}
