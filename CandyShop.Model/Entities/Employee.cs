using System;

namespace CandyShop.Model.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? StartDate { get; set; }
        public string Sector { get; set; }
    }
}