using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using CandyShop.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class AdminPage : Form
    {
        private readonly IAdminRepository _adminRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly bool IsEmployee;

        public AdminPage(
            IAdminRepository adminRepository,
            ICustomerRepository customerRepository,
            IEmployeeRepository employeeRepository,
            IItemRepository itemRepository,
            IOrderRepository orderRepository,
            IAuthenticationService authenticationService,
            bool isEmployee)

        {
            _adminRepository = adminRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            _authenticationService = authenticationService;
            InitializeComponent();
            IsEmployee = isEmployee;
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            ManagePermissions(IsEmployee);
        }

        private void AdminListButton_Click(object sender, EventArgs e)
        {
            var admins = _adminRepository.GetAdminList();
            AdminDataTable.DataSource = admins;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            switch (AdminDataTable.DataSource)
            {
                case List<Admin>:
                    var adminAddPage = new AdminAddPage(_adminRepository, _authenticationService);
                    adminAddPage.Show();
                    adminAddPage.FormClosed += (senderForm, eForm) =>
                    {
                        var admins = _adminRepository.GetAdminList();
                        AdminDataTable.DataSource = admins;
                    };
                    break;
                case List<Customer>:
                    if (IsEmployee)
                    {
                        MessageBox.Show("You do not have permission to do that!");
                        return;
                    }
                    var customerAddPage = new CustomerAddPage(_customerRepository, _authenticationService);
                    customerAddPage.Show();
                    customerAddPage.FormClosed += (senderForm, eForm) =>
                    {
                        var customers = _customerRepository.GetCustomerList();
                        AdminDataTable.DataSource = customers;
                    };
                    break;
                case List<Employee>:
                    var employeeAddPage = new EmployeeAddPage(_employeeRepository, _authenticationService);
                    employeeAddPage.Show();
                    employeeAddPage.FormClosed += (senderForm, eForm) =>
                    {
                        var employees = _employeeRepository.GetEmployeeList();
                        AdminDataTable.DataSource = employees;
                    };
                    break;
                case List<Item>:
                    var itemAddPage = new ItemAddPage(_itemRepository);
                    itemAddPage.Show();
                    itemAddPage.FormClosed += (senderForm, eForm) =>
                    {
                        var items = _itemRepository.GetItemList();
                        AdminDataTable.DataSource = items;
                    };
                    break;
                case List<Order>:
                    var orderAddPage = new OrderAddPage(_orderRepository);
                    orderAddPage.Show();
                    orderAddPage.FormClosed += (senderForm, eForm) =>
                    {
                        var orders = _orderRepository.GetOrderList();
                        AdminDataTable.DataSource = orders;
                    };
                    break;
                default:
                    MessageBox.Show("Please select a list of data!");
                    break;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (AdminDataTable.DataSource)
                {
                    case List<Admin>:
                        var selectedCell = AdminDataTable.SelectedCells[0].RowIndex;
                        var selectedRow = AdminDataTable.Rows[selectedCell].DataBoundItem as Admin;
                        if (selectedRow is null)
                        {
                            MessageBox.Show("Please select a row to update!");
                            return;
                        }
                        var selectedAdmin = _adminRepository.GetAdminByUsername(selectedRow.Username);
                        var adminUpdatePage = new AdminUpdatePage(_adminRepository, _authenticationService, selectedAdmin);
                        adminUpdatePage.Show();
                        adminUpdatePage.FormClosed += (senderForm, eForm) =>
                        {
                            var admins = _adminRepository.GetAdminList();
                            AdminDataTable.DataSource = admins;
                        };
                        break;
                    case List<Customer>:
                        var selectedCell1 = AdminDataTable.SelectedCells[0].RowIndex;
                        var selectedRow1 = AdminDataTable.Rows[selectedCell1].DataBoundItem as Customer;
                        if (selectedRow1 is null)
                        {
                            MessageBox.Show("Please select a row to update!");
                            return;
                        }
                        var selectedCustomer = _customerRepository.GetCustomerByUsername(selectedRow1.Username);
                        var customerUpdatePage = new CustomerUpdatePage(_customerRepository, _authenticationService, selectedCustomer);
                        customerUpdatePage.Show();
                        customerUpdatePage.FormClosed += (senderForm, eForm) =>
                        {
                            var customers = _customerRepository.GetCustomerList();
                            AdminDataTable.DataSource = customers;
                        };
                        break;
                    case List<Employee>:
                        var selectedCell2 = AdminDataTable.SelectedCells[0].RowIndex;
                        var selectedRow2 = AdminDataTable.Rows[selectedCell2].DataBoundItem as Employee;
                        if (selectedRow2 is null)
                        {
                            MessageBox.Show("Please select a row to update!");
                            return;
                        }
                        if (IsEmployee)
                        {
                            MessageBox.Show("You do not have permission to do that!");
                            return;
                        }
                        var selectedEmployee = _employeeRepository.GetEmployeeByUsername(selectedRow2.Username);
                        var employeeUpdatePage = new EmployeeUpdatePage(_employeeRepository, _authenticationService, selectedEmployee);
                        employeeUpdatePage.Show();
                        employeeUpdatePage.FormClosed += (senderForm, eForm) =>
                        {
                            var employees = _employeeRepository.GetEmployeeList();
                            AdminDataTable.DataSource = employees;
                        };
                        break;
                    case List<Item>:
                        var selectedCell3 = AdminDataTable.SelectedCells[0].RowIndex;
                        var selectedRow3 = AdminDataTable.Rows[selectedCell3].DataBoundItem as Item;
                        if (selectedRow3 is null)
                        {
                            MessageBox.Show("Please select a row to update!");
                            return;
                        }
                        var selectedItem = _itemRepository.GetItemById(selectedRow3.ID);
                        var itemUpdatePage = new ItemUpdatePage(_itemRepository, selectedItem);
                        itemUpdatePage.Show();
                        itemUpdatePage.FormClosed += (senderForm, eForm) =>
                        {
                            var items = _itemRepository.GetItemList();
                            AdminDataTable.DataSource = items;
                        };
                        break;
                    case List<Order>:
                        var selectedCell4 = AdminDataTable.SelectedCells[0].RowIndex;
                        var selectedRow4 = AdminDataTable.Rows[selectedCell4].DataBoundItem as Order;
                        if (selectedRow4 is null)
                        {
                            MessageBox.Show("Please select a row to update!");
                            return;
                        }
                        var selectedOrder = _orderRepository.GetOrderList().FirstOrDefault(x => x.ID == selectedRow4.ID);
                        var orderUpdatePage = new OrderUpdatePage(_orderRepository, selectedOrder);
                        orderUpdatePage.Show();
                        orderUpdatePage.FormClosed += (senderForm, eForm) =>
                        {
                            var orders = _orderRepository.GetOrderList();
                            AdminDataTable.DataSource = orders;
                        };
                        break;
                    default:
                        MessageBox.Show("Please select a list of data!");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Please select a row to update! {ex}");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (AdminDataTable.DataSource)
                {
                    case List<Admin>:
                        var selectedCell = AdminDataTable.SelectedCells[0].RowIndex;
                        var selectedRow = AdminDataTable.Rows[selectedCell].DataBoundItem as Admin;
                        if (selectedRow is null)
                        {
                            MessageBox.Show("Please select a row to update!");
                            return;
                        }
                        _adminRepository.DeleteAdmin(selectedRow.ID);
                        var admins = _adminRepository.GetAdminList();
                        AdminDataTable.DataSource = admins;
                        break;
                    case List<Customer>:
                        var selectedCell1 = AdminDataTable.SelectedCells[0].RowIndex;
                        var selectedRow1 = AdminDataTable.Rows[selectedCell1].DataBoundItem as Customer;
                        if (selectedRow1 is null)
                        {
                            MessageBox.Show("Please select a row to update!");
                            return;
                        }
                        _customerRepository.DeleteCustomer(selectedRow1.ID);
                        var customers = _customerRepository.GetCustomerList();
                        AdminDataTable.DataSource = customers;
                        break;
                    case List<Employee>:
                        var selectedCell2 = AdminDataTable.SelectedCells[0].RowIndex;
                        var selectedRow2 = AdminDataTable.Rows[selectedCell2].DataBoundItem as Employee;
                        if (selectedRow2 is null)
                        {
                            MessageBox.Show("Please select a row to update!");
                            return;
                        }
                        if (IsEmployee)
                        {
                            MessageBox.Show("You do not have permission to do that!");
                            return;
                        }
                        _employeeRepository.DeleteEmployee(selectedRow2.ID);
                        var employees = _employeeRepository.GetEmployeeList();
                        AdminDataTable.DataSource = employees;
                        break;
                    case List<Item>:
                        var selectedCell3 = AdminDataTable.SelectedCells[0].RowIndex;
                        var selectedRow3 = AdminDataTable.Rows[selectedCell3].DataBoundItem as Item;
                        if (selectedRow3 is null)
                        {
                            MessageBox.Show("Please select a row to update!");
                            return;
                        }
                        _itemRepository.DeleteItem(selectedRow3.ID);
                        var items = _itemRepository.GetItemList();
                        AdminDataTable.DataSource = items;
                        break;
                    case List<Order>:
                        var selectedCell4 = AdminDataTable.SelectedCells[0].RowIndex;
                        var selectedRow4 = AdminDataTable.Rows[selectedCell4].DataBoundItem as Order;
                        if (selectedRow4 is null)
                        {
                            MessageBox.Show("Please select a row to update!");
                            return;
                        }
                        if (selectedRow4.Status != "Waiting" && IsEmployee)
                        {
                            MessageBox.Show("Cannot delete an order that has an action already taken!");
                            return;
                        }
                        _orderRepository.DeleteOrder(selectedRow4.ID);
                        var orders = _orderRepository.GetOrderList();
                        AdminDataTable.DataSource = orders;
                        break;
                    default:
                        MessageBox.Show("Please select a list of data!");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Please select a row to delete! {ex}");
            }
        }

        private void CustomerListButton_Click(object sender, EventArgs e)
        {
            var customers = _customerRepository.GetCustomerList();
            AdminDataTable.DataSource = customers;
        }

        private void EmployeeListButton_Click(object sender, EventArgs e)
        {
            var employees = _employeeRepository.GetEmployeeList();
            AdminDataTable.DataSource = employees;
        }

        private void ItemsButton_Click(object sender, EventArgs e)
        {
            var items = _itemRepository.GetItemList();
            AdminDataTable.DataSource = items;
        }

        private void OrderList_Click(object sender, EventArgs e)
        {
            var orders = _orderRepository.GetOrderList();
            AdminDataTable.DataSource = orders;
        }

        private void ManagePermissions(bool isEmployee)
        {
            if (!isEmployee)
                return;

            AdminListButton.Visible = false;
            EmployeeListButton.Visible = false;
        }

        private void CriticalOrdersButton_Click(object sender, EventArgs e)
        {
            var orders = _orderRepository.GetOrderList();
            var oneDayAgo = DateTime.Now.AddDays(-1);
            orders = orders.Where(x => x.Status == "Waiting" && x.OrderDate < oneDayAgo).ToList();
            AdminDataTable.DataSource = orders;
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            try
            {
                var orders = _orderRepository.GetOrderList();

                if (int.TryParse(ItemIDFilter.Text, out int itemId))
                    orders = orders.Where(x => x.ItemId == itemId).ToList();

                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    orders = orders.Where(x => x.Status.Contains(textBox1.Text)).ToList();

                orders = orders.Where(x => x.OrderDate >= new DateTime(DateFromFilter.Value.Year, DateFromFilter.Value.Month, DateFromFilter.Value.Day) && x.OrderDate <= new DateTime(DateToFilter.Value.Year, DateToFilter.Value.Month, DateToFilter.Value.Day)).ToList();

                AdminDataTable.DataSource = orders;

                ItemsSoldLabel.Text = $"Items Sold: {orders.Count}";
                WaitingOrdersLabel.Text = $"Waiting Orders: {orders.Where(x => x.Status == "Waiting").ToList().Count}";
                MoneyMadeLabel.Text = $"Money Made: {orders.Sum(x => x.Price)}";
                BestCustomerLabel.Text = $"Best customer: {orders.GroupBy(x => x.CustomerId).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured while filtering {ex}");
            }
        }
    }
}