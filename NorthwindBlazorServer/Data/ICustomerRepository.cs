using System.Threading.Tasks;
using System.Collections.Generic;
using Suntrack.Shared;

namespace NorthwindBlazorServer.Data{

    public interface ICustomerRepository{

        Task<List<Customer>> RetrieveAllAsync();
        Task<Customer> RetrieveAsync(string id);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(string id);

    }

}
