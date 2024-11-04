using CandyShop.Model.Entities.Requests;
using CandyShop.Model.Services;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class RegisterPage : Form
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterPage(
            IAuthenticationService authenticationService
            )
        {
            _authenticationService = authenticationService;
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    string.IsNullOrWhiteSpace(UsernameTextBox.Text)
                    || string.IsNullOrWhiteSpace(PasswordTextBox.Text)
                    || string.IsNullOrWhiteSpace(EmailTextBox.Text)
                    || string.IsNullOrWhiteSpace(NameTextBox.Text)
                    || string.IsNullOrWhiteSpace(LastNameTextBox.Text)
                    || string.IsNullOrWhiteSpace(AddressTextBox.Text))
                {
                    MessageBox.Show("Please fill all of the mandatory fields!");
                    return;
                }

                var res = _authenticationService.Register(new RegisterRequest
                {
                    Username = UsernameTextBox.Text,
                    Password = PasswordTextBox.Text,
                    Email = EmailTextBox.Text,
                    Name = NameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    DateOfBirth = DatePicker.Value,
                    Address = AddressTextBox.Text
                });

                if (!res.Success)
                {
                    MessageBox.Show(res.ErrorMessage);
                    return;
                }

                MessageBox.Show($"Registration successful! Welcome to the CandyShop, {UsernameTextBox.Text}! Please log in.");
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed due to {ex}");
            }
        }
    }
}
