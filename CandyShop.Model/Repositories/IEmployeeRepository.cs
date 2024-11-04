using CandyShop.Model.Entities;
using System.Collections.Generic;

namespace CandyShop.Model.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeByUsername(string username);
        List<Employee> GetEmployeeList();
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}