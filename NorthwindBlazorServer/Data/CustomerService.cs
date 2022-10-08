using Suntrack.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using System.Linq;

#nullable disable

namespace NorthwindBlazorServer.Data;

public class CustomerService : ICustomerRepository
{
    private Northwind dbContext;
    private static LinkedList<Customer> customerCache;

    public CustomerService(Northwind injectedDB)
    {
        dbContext = injectedDB;

        if (customerCache == null){
            customerCache = new LinkedList<Customer>(dbContext.Customers.ToArray());
        }

    }

    public Task<List<Customer>> RetrieveAllAsync() => Task.Run(() => { return customerCache.ToList();} );

    public Task<Customer> RetrieveAsync(string id){
        return Task.Run(() => {
            Customer getter = customerCache.AsParallel().FirstOrDefault(e => e.CustomerID == id);
            return (getter != null)? getter:null;
        });
    }

    public Task<Customer> CreateAsync(Customer customer){
        return Task.Run(() => {
            
            dbContext.Add(customer);

            if (dbContext.SaveChanges() == 1){
                LinkedListNode<Customer> newElement = new LinkedListNode<Customer>(customer);
                customerCache.AddLast(newElement);
                return customer;
            }else{
                return null;
            }
        });
    }
   
    public Task<Customer> UpdateAsync(Customer customer){
        return Task.Run(() => {
            
            int result = 0;
            // Try to Update in database
            try{
                dbContext.Customers.Update(customer);
                result = dbContext.SaveChanges();
            }catch(Exception ex){
                Console.WriteLine("\n\t\t [-] An error ocurred at CustoemrService.cs : 58 : said ->  "+ex.Message+"\n");
                return null;
            }
            
            // Check if it success
            if(result == 1){
                
                Console.WriteLine("\n\t\t [+] Trying to update in cache at CustoemrService.cs : 65 \n");
                // Then try to search in cache
                Customer exists = customerCache.FirstOrDefault<Customer>(e => e.CustomerID == customer.CustomerID);

                // If not found
                if (exists == null)
                    return null;

                // If found, Find the element and change ir value to new object 
                customerCache.Find(exists).Value = customer;

                // Everything is success return the updated element
                return customer;

            }else{
                // If update in database is fail then return null;
                Console.WriteLine("\n\t\t [-] Cannot update in database CustoemrService.cs : 80\n");
                return null;
            }
        });

    }

    public Task<bool> DeleteAsync(string id){
        return Task.Run(() => {
            
            int result = 0;

            // try remove in database
            try{
                
                Customer pointer = dbContext.Customers.FirstOrDefault(e => e.CustomerID == id);
                dbContext.Customers.Remove(pointer);
                result = dbContext.SaveChanges();
            }catch(DbUpdateException ex){
                Console.WriteLine("\n\t\t[-] Error trying to remove :{1}: at CustomerService.cs 101: {0}\n",id,ex.Message);
                return false;
            }

            // Check if it success
            if (result == 1){
                
                // Then remove in cache
                LinkedListNode<Customer> pointerNode = customerCache.Find(customerCache.First(e=>e.CustomerID == id));
                if (pointerNode == null)
                    return false;
                customerCache.Remove(pointerNode);

                // If everything is fine, Return true
                return true;
            }
            else 
                return false;
        });

    }



}