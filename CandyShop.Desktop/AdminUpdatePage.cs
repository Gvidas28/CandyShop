using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using CandyShop.Model.Services;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class AdminUpdatePage : Form
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly Admin _selectedAdmin;

        public AdminUpdatePage(
            IAdminRepository adminRepository,
            IAuthenticationService authenticationService,
            Admin selectedAmin
            )
        {
            _adminRepository = adminRepository;
            _authenticationService = authenticationService;
            _selectedAdmin = selectedAmin;
            InitializeComponent();
        }

        private void AdminUpdatePage_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            UsernameTextBox.Text = _selectedAdmin.Username;
            PasswordTextBox.Text = string.Empty;
            EmailTextBox.Text = _selectedAdmin.Email;
            NameTextBox.Text = _selectedAdmin.Name;
            LastNameTextBox.Text = _selectedAdmin.LastName;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var hashedPassword = !string.IsNullOrWhiteSpace(PasswordTextBox.Text) ?
                    _authenticationService.HashPassword(PasswordTextBox.Text)
                    : string.Empty;

                _adminRepository.UpdateAdmin(new Admin
                {
                    ID = _selectedAdmin.ID,
                    Username = UsernameTextBox.Text,
                    Password = hashedPassword,
                    Email = EmailTextBox.Text,
                    Name = NameTextBox.Text,
                    LastName = LastNameTextBox.Text
                });
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add admin due to {ex}");
            }
        }
    }
}