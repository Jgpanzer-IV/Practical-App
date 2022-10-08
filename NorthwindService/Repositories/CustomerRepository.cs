using Suntrack.Shared;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System;

using NorthwindService.Static;

namespace NorthwindService.Repository{

    public class CustomerRepository : ICustomerRepository{

        private Northwind dbContext;
       
        // use a static thread-safe dictionary field to cache the customers
        private static ConcurrentDictionary<string, Customer> customerCache;

        public CustomerRepository(Northwind dbInjected){
            
            dbContext = dbInjected;
            /*
            pre-load customers from database as a normal Dictionary with CustomerID as the key
            then convert to a thread-safe ConcurrentDictionary
            */ 
            if (customerCache == null){
                customerCache = new ConcurrentDictionary<string, Customer>
                    (dbContext.Customers.ToDictionary(c => c.CustomerID));
            }
            
        }
     
        public async Task<Customer> CreateAsync(Customer c){
            c.CustomerID = c.CustomerID.ToUpper();

            // Add to database using EFcore
            EntityEntry<Customer> added = await dbContext.Customers.AddAsync(c);
            int affected = await dbContext.SaveChangesAsync();
            if (affected == 1){
            
                // If the customer added is new, then add it to the cache, else call UpdateCache Method 
                // to update the added customer in the cache.
                return customerCache.AddOrUpdate(c.CustomerID, c, UpdateCache);
            }else{
                return null;
            }
        }


        public Task<IEnumerable<Customer>> RetrieveAllAsync() {
            return Task.Run<IEnumerable<Customer>>( () => customerCache.Values);
        }


        public Task<Customer> RetrieveAsync(string id) => Task.Run(
            () => {
                // Check id parameter
                if(string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id) || id == "")
                    return null;
                
                // Check user
                id.ToUpper();
                if (customerCache.TryGetValue(id,out Customer c))
                    return c;
                
                // If not found the user
                return null;
            }
        );

        public async Task<Customer> UpdateAsync(string id, Customer c){
            
            // normalize customer ID to upper case
            //c.CustomerID = c.CustomerID.ToUpper();
            id = id.ToUpper();
            c.CustomerID = c.CustomerID.ToUpper();
            
            int affected = 0;

            // Update in database
            dbContext.Customers.Update(c);
            affected = await dbContext.SaveChangesAsync();

            // Update in Cache
            if (affected == 1)
                return UpdateCache(id,c);
            // return null if it not found the customer-id to update
            else 
                return null;
        }

        public async Task<bool> DeleteAsync(string id){
            
            id.ToUpper();

            // Remove in database
            Customer c = dbContext.Customers.Find(id);
            dbContext.Customers.Remove(c);
            int affected = await dbContext.SaveChangesAsync();

            if (affected == 1){

                // Remove in cache
                if (customerCache.TryRemove(id,out c))
                    return true;
            }
            return false;
        }
        private Customer UpdateCache(string id, Customer c){
            Customer old;
            if (customerCache.TryGetValue(id,out old)){
                if (customerCache.TryUpdate(id,c,old))
                    return c;
            }
            return null;
        }
    }
}