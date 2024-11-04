using CandyShop.Model.Entities.Enums;
using CandyShop.Model.Entities.Requests;
using CandyShop.Model.Repositories;
using CandyShop.Model.Services;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class LoginPage : Form
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAdminRepository _adminRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICommentRepository _commentRepository;

        public LoginPage(
            IAuthenticationService authenticationService,
            IAdminRepository adminRepository,
            ICustomerRepository customerRepository,
            IEmployeeRepository employeeRepository,
            IItemRepository itemRepository,
            IOrderRepository orderRepository,
            ICommentRepository commentRepository
            )
        {
            _authenticationService = authenticationService;
            _adminRepository = adminRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            _commentRepository = commentRepository;
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, System.EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            EmployeeCheckBox.Visible = false;
            AdminCheckBox.Visible = false;
        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            var userType = HelperService.DetermineUserType(EmployeeCheckBox.Checked, AdminCheckBox.Checked);
            var loginRequest = new LoginRequest
            {
                Username = UsernameTextBox.Text,
                Password = PasswordTextBox.Text,
                UserType = userType
            };

            var loginResult = _authenticationService.Login(loginRequest);
            if (!loginResult.Success)
            {
                MessageBox.Show(loginResult.ErrorMessage);
                return;
            }

            switch (userType)
            {
                case UserType.Customer:
                    var customerPage = new CustomerPage(
                        _itemRepository,
                        _orderRepository,
                        _commentRepository,
                        loginResult.CustomerId.Value
                        );
                    Hide();
                    customerPage.Show();
                    break;
                case UserType.Employee:
                    var employeePage = new AdminPage(
                        _adminRepository,
                        _customerRepository,
                        _employeeRepository,
                        _itemRepository,
                        _orderRepository,
                        _authenticationService,
                        isEmployee: true
                        );
                    Hide();
                    employeePage.Show();
                    break;
                case UserType.Admin:
                    var adminPage = new AdminPage(
                        _adminRepository,
                        _customerRepository,
                        _employeeRepository,
                        _itemRepository,
                        _orderRepository,
                        _authenticationService,
                        isEmployee: false
                        );
                    Hide();
                    adminPage.Show();
                    break;
                default:
                    break;
            }
        }

        private void UsernameTextBox_TextChanged(object sender, System.EventArgs e)
        {
            if (string.Equals(UsernameTextBox.Text, "iamanemployee"))
            {
                AdminCheckBox.Checked = false;
                AdminCheckBox.Visible = false;
                EmployeeCheckBox.Checked = true;
                EmployeeCheckBox.Visible = true;
            }

            else if (string.Equals(UsernameTextBox.Text, "iamanadmin"))
            {
                EmployeeCheckBox.Checked = false;
                EmployeeCheckBox.Visible = false;
                AdminCheckBox.Checked = true;
                AdminCheckBox.Visible = true;
            }
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            var registerPage = new RegisterPage(_authenticationService);
            registerPage.Show();
        }
    }
}