using CandyShop.Model.Entities;
using System.Collections.Generic;

namespace CandyShop.Model.Repositories
{
    public interface IAdminRepository
    {
        Admin GetAdminByUsername(string username);
        List<Admin> GetAdminList();
        void AddAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(int id);
    }
}