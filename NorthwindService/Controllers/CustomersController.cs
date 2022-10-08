using Microsoft.AspNetCore.Mvc;
using NorthwindService.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Suntrack.Shared;

namespace NorthwindService.Controllers
{
    // ~/api/customers
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        
        private ICustomerRepository repository;
        private Northwind dbContext;

        public CustomersController(Northwind db,ICustomerRepository injectedRepo){
            repository = injectedRepo;
            dbContext = db;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Customer>))]
        public async Task<IEnumerable<Customer>> GetAll(string country){
            if (string.IsNullOrEmpty(country))
                return await repository.RetrieveAllAsync();
            else
                return (await repository.RetrieveAllAsync()).Where(each => each.Country == country);
            
        }

        // Http GET ~/api/customers/[id]
        // named : 'GetByID'
        [HttpGet("{id}",Name = nameof(GetByID))]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetByID(string id){
            Customer retrived = await repository.RetrieveAsync(id);
            if (retrived == null)
                return NotFound(); // 404 Resource not found
            
            return Ok(retrived); // this will return status 200 Ok with the customer in body
        }

        // Http POST: ~/api/customers
        // Http Body: Customer (JSON , XML) 
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Customer c){
            // Check for if the object is null, then return BadRequest to the client.
            if (c == null)
                return BadRequest();
            
            // Check for invalid state, if not, then return BadRequest with 'Customer' instance that come with the http request.
            if (!ModelState.IsValid)
                return BadRequest(c); 
            
            Customer created = await repository.CreateAsync(c);

            return CreatedAtRoute(
                routeName: nameof(GetByID),
                routeValues: new {id = created.CustomerID},
                value: created
            );

        }


        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(string id,[FromBody] Customer customer){
            
            id = id.ToUpper();
            customer.CustomerID = customer.CustomerID.ToUpper();

            // Check model state
            if (!ModelState.IsValid )
                return BadRequest(ModelState); // 400 Model is invalid

            // Check customer ID
            if ( customer == null || id != customer.CustomerID)
                return BadRequest(); 

            Customer exists = await repository.RetrieveAsync(id);
            if (exists == null){
                return NotFound(); // 404 Not found result to update
            }
            await repository.UpdateAsync(id,customer);

            return new NoContentResult(); // 204 No content
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(string id){
            
            bool result = await repository.DeleteAsync(id); // Try to delete

            if (result) // Check result
                return new NoContentResult(); // 204 No Content returned

            return NotFound(); // 404 Not found the result object to delete
        }

    }
}