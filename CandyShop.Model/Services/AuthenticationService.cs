using CandyShop.Model.Entities;
using CandyShop.Model.Entities.Enums;
using CandyShop.Model.Entities.Requests;
using CandyShop.Model.Entities.Responses;
using CandyShop.Model.Repositories;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CandyShop.Model.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAdminRepository _adminRepository;

        public AuthenticationService(
            ICustomerRepository customerRepository,
            IEmployeeRepository employeeRepository,
            IAdminRepository adminRepository
            )
        {
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _adminRepository = adminRepository;
        }

        public LoginResponse Login(LoginRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Username))
                    return new() { Success = false, ErrorMessage = "Username cannot be empty!" };

                if (string.IsNullOrWhiteSpace(request.Password))
                    return new() { Success = false, ErrorMessage = "Password cannot be empty!" };

                var hashedPasswordInput = HashPassword(request.Password);
                request.Password = hashedPasswordInput;

                return DetermineLoginResult(request);
            }
            catch (Exception ex)
            {
                return new() { Success = false, ErrorMessage = ex.Message };
            }
        }

        public RegisterResponse Register(RegisterRequest request)
        {
            try
            {
                var hashedPasswordInput = HashPassword(request.Password);

                var newCustomer = new Customer
                {
                    Username = request.Username,
                    Password = hashedPasswordInput,
                    Email = request.Email,
                    Name = request.Name,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    Address = request.Address,
                    IsTest = false
                };

                _customerRepository.AddCustomer(newCustomer);

                return new RegisterResponse() { Success = true };
            }
            catch (Exception ex)
            {
                return new() { Success = false, ErrorMessage = ex.Message };
            }
        }

        private LoginResponse DetermineLoginResult(LoginRequest request) => request.UserType switch
        {
            UserType.Customer => CheckCustomer(request),
            UserType.Employee => CheckEmployee(request),
            UserType.Admin => CheckAdmin(request),
            _ => throw new ArgumentException("Could not determine the user type!")
        };

        private LoginResponse CheckCustomer(LoginRequest request)
        {
            var customer = _customerRepository.GetCustomerByUsername(request.Username);
            return customer is not null && string.Equals(customer.Password, request.Password)
                ? new() { Success = true, CustomerId = customer.ID }
                : new() { Success = false, ErrorMessage = "Username or password incorrect!" };
        }

        private LoginResponse CheckEmployee(LoginRequest request)
        {
            var employee = _employeeRepository.GetEmployeeByUsername(request.Username);
            return employee is not null && string.Equals(employee.Password, request.Password)
                ? new() { Success = true, CustomerId = employee.ID }
                : new() { Success = false, ErrorMessage = "Username or password incorrect!" };
        }

        private LoginResponse CheckAdmin(LoginRequest request)
        {
            var admin = _adminRepository.GetAdminByUsername(request.Username);
            return admin is not null && string.Equals(admin.Password, request.Password)
                ? new() { Success = true }
                : new() { Success = false, ErrorMessage = "Username or password incorrect!" };
        }

        public string HashPassword(string password)
        {
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                var builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));

                return builder.ToString();
            }
        }
    }
}