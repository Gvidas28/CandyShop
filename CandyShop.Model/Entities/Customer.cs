using System;

namespace CandyShop.Model.Entities
{
    public class Customer
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public bool IsTest { get; set; }
    }
}