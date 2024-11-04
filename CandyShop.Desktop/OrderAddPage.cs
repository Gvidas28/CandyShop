using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class OrderAddPage : Form
    {
        private readonly IOrderRepository _orderRepository;

        public OrderAddPage(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            InitializeComponent();
        }

        private void OrderAddPage_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                _orderRepository.AddOrder(new Order
                {
                    CustomerId = int.Parse(CustomerIdTextBox.Text),
                    ItemId = int.Parse(ItemIdTextBox.Text),
                    Status = StatusTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text),
                    OrderDate = DatePicker.Value
                });
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add order due to {ex}");
            }
        }
    }
}