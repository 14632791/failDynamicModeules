using System.Collections.Generic;
using Metro.DynamicModeules.Core.Model;

namespace Metro.DynamicModeules.Core.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
    }
}
