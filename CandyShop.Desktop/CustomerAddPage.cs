using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using CandyShop.Model.Services;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class CustomerAddPage : Form
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAuthenticationService _authenticationService;

        public CustomerAddPage(
            ICustomerRepository customerRepository,
            IAuthenticationService authenticationService
            )
        {
            _customerRepository = customerRepository;
            _authenticationService = authenticationService;
            InitializeComponent();
        }

        private void CustomerAddPage_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var hashedPassword = _authenticationService.HashPassword(PasswordTextBox.Text);

                _customerRepository.AddCustomer(new Customer
                {
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