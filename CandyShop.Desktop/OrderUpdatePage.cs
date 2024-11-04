using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class OrderUpdatePage : Form
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Order _selectedOrder;

        public OrderUpdatePage(IOrderRepository orderRepository, Order selectedOrder)
        {
            _orderRepository = orderRepository;
            InitializeComponent();
            _selectedOrder = selectedOrder;
        }

        private void OrderUpdatePage_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            CustomerIdTextBox.Text = _selectedOrder.CustomerId.ToString();
            ItemIdTextBox.Text = _selectedOrder.ItemId.ToString();
            StatusTextBox.Text = _selectedOrder.Status;
            PriceTextBox.Text = _selectedOrder.Price.ToString();
            DatePicker.Value = _selectedOrder.OrderDate;
        }

        private void UpdateButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                _orderRepository.UpdateOrder(new Order
                {
                    ID = _selectedOrder.ID,
                    CustomerId = int.Parse(CustomerIdTextBox.Text),
                    ItemId = int.Parse(ItemIdTextBox.Text),
                    Status = StatusTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text),
                    OrderDate = DatePicker.Value,
                });
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add item due to {ex}");
            }
        }
    }
}