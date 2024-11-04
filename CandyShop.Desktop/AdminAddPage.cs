using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using CandyShop.Model.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class AdminAddPage : Form
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAuthenticationService _authenticationService;

        public AdminAddPage(
            IAdminRepository adminRepository,
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _adminRepository = adminRepository;
            InitializeComponent();
        }

        private void AdminAddPage_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var hashedPassword = _authenticationService.HashPassword(PasswordTextBox.Text);

                _adminRepository.AddAdmin(new Admin
                {
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
