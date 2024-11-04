using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using CandyShop.Model.Services;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class EmployeeUpdatePage : Form
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly Employee _selectedEmployee;

        public EmployeeUpdatePage(
            IEmployeeRepository employeeRepository,
            IAuthenticationService authenticationService,
            Employee selectedEmployee)
        {
            _employeeRepository = employeeRepository;
            _authenticationService = authenticationService;
            _selectedEmployee = selectedEmployee;
            InitializeComponent();
        }

        private void EmployeeUpdatePage_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            UsernameTextBox.Text = _selectedEmployee.Username;
            PasswordTextBox.Text = string.Empty;
            EmailTextBox.Text = _selectedEmployee.Email;
            NameTextBox.Text = _selectedEmployee.Name;
            LastNameTextBox.Text = _selectedEmployee.LastName;
            DatePicker.Value = _selectedEmployee.StartDate ?? DateTime.Now;
            SectorTextBox.Text = _selectedEmployee.Sector;
        }

        private void UpdateButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                var hashedPassword = !string.IsNullOrWhiteSpace(PasswordTextBox.Text) ?
                    _authenticationService.HashPassword(PasswordTextBox.Text)
                    : string.Empty;

                _employeeRepository.UpdateEmployee(new Employee
                {
                    ID = _selectedEmployee.ID,
                    Username = UsernameTextBox.Text,
                    Password = hashedPassword,
                    Email = EmailTextBox.Text,
                    Name = NameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    StartDate = DatePicker.Value,
                    Sector = SectorTextBox.Text,
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