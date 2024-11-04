using CandyShop.Model.Entities.Enums;
using System;

namespace CandyShop.Model.Services
{
    public static class HelperService
    {
        public static UserType DetermineUserType(bool isEmployee, bool isAdmin) => (isEmployee, isAdmin) switch
        {
            (false, false) => UserType.Customer,
            (true, false) => UserType.Employee,
            (false, true) => UserType.Admin,
            _ => throw new ArgumentOutOfRangeException("Could not determine the user type!")
        };

        public static UserType DetermineUserType(int userType) => userType switch
        {
            1 => UserType.Customer,
            2 => UserType.Employee,
            3 => UserType.Admin,
            _ => throw new ArgumentOutOfRangeException("Could not determine the user type!")
        };
    }
}