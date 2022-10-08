using Suntrack.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NorthwindService.Repository{

    public interface ICustomerRepository{
        Task<Customer> CreateAsync(Customer c);
        Task<IEnumerable<Customer>> RetrieveAllAsync();
        Task<Customer> RetrieveAsync(string id);
        Task<Customer> UpdateAsync(string id,Customer c);
        Task<bool> DeleteAsync(string id);
    }


}