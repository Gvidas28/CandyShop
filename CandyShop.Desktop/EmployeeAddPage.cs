using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using CandyShop.Model.Services;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class EmployeeAddPage : Form
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAuthenticationService _authenticationService;

        public EmployeeAddPage(
            IEmployeeRepository employeeRepository,
            IAuthenticationService authenticationService
            )
        {
            _employeeRepository = employeeRepository;
            _authenticationService = authenticationService;
            InitializeComponent();
        }

        private void EmployeeAddPage_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var hashedPassword = _authenticationService.HashPassword(PasswordTextBox.Text);

                _employeeRepository.AddEmployee(new Employee
                {
                    Username = UsernameTextBox.Text,
                    Password = hashedPassword,
                    Email = EmailTextBox.Text,
                    Name = NameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    StartDate = DatePicker.Value,
                    Sector = SectorTextBox.Text
                });
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add employee due to {ex}");
            }
        }
    }
}