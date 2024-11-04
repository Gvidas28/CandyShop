using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class QuantityPage : Form
    {
        public int ItemID { get; set; }
        public int CustomerID { get; set; }

        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;

        public QuantityPage(
            IItemRepository itemRepository,
            IOrderRepository orderRepository,
            int itemId,
            int customerId
            )
        {
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            ItemID = itemId;
            CustomerID = customerId;
            InitializeComponent();
        }

        private void BuyButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!int.TryParse(QuantityTextBox.Text, out int quantity))
                {
                    MessageBox.Show($"Please enter quantity in a valid form (number)");
                    return;
                }

                var item = _itemRepository.GetItemById(ItemID);
                if (item.Quantity - quantity < 0)
                {
                    MessageBox.Show($"Only {item.Quantity} {item.Name} available in stock!");
                    return;
                }

                item.Quantity = item.Quantity - quantity;
                _itemRepository.UpdateItem(item);

                for (int i = 0; i < quantity; i++)
                    _orderRepository.AddOrder(new Order
                    {
                        CustomerId = CustomerID,
                        ItemId = ItemID,
                        Status = "Waiting",
                        Price = item.Price,
                        OrderDate = DateTime.Now
                    });

                MessageBox.Show($"Order of {quantity} {item.Name} successful! Thank you for choosing CandyShop!");
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to buy item due to {ex}");
            }
        }
    }
}