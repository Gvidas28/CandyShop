using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using CandyShop.Model.Services;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class CustomerUpdatePage : Form
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly Customer _selectedCustomer;

        public CustomerUpdatePage(
            ICustomerRepository customerRepository,
            IAuthenticationService authenticationService,
            Customer selectedCustomer
            )
        {
            _customerRepository = customerRepository;
            _authenticationService = authenticationService;
            _selectedCustomer = selectedCustomer;
            InitializeComponent();
        }

        private void CustomerUpdatePage_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            UsernameTextBox.Text = _selectedCustomer.Username;
            PasswordTextBox.Text = string.Empty;
            EmailTextBox.Text = _selectedCustomer.Email;
            NameTextBox.Text = _selectedCustomer.Name;
            LastNameTextBox.Text = _selectedCustomer.LastName;
            DatePicker.Value = _selectedCustomer.DateOfBirth ?? DateTime.Now;
            AddressTextBox.Text = _selectedCustomer.Address;
            IsTestCheckbox.Checked = _selectedCustomer.IsTest;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var hashedPassword = !string.IsNullOrWhiteSpace(PasswordTextBox.Text) ?
                    _authenticationService.HashPassword(PasswordTextBox.Text)
                    : string.Empty;

                _customerRepository.UpdateCustomer(new Customer
                {
                    ID = _selectedCustomer.ID,
                    Username = UsernameTextBox.Text,
                    Password = hashedPassword,
                    Email = EmailTextBox.Text,
                    Name = NameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    DateOfBirth = DatePicker.Value,
                    Address = AddressTextBox.Text,
                    IsTest = IsTestCheckbox.Checked
                });
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add customer due to {ex}");
            }
        }
    }
}