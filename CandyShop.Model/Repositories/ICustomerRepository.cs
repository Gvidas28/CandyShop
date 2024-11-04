using CandyShop.Model.Entities;
using System.Collections.Generic;

namespace CandyShop.Model.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerByUsername(string username);
        List<Customer> GetCustomerList();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}