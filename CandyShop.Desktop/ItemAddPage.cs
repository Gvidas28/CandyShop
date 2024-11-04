using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class ItemAddPage : Form
    {
        private readonly IItemRepository _itemRepository;

        public ItemAddPage(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
            InitializeComponent();
        }

        private void ItemAddPage_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void AddButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                _itemRepository.AddItem(new Item
                {
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text),
                    Quantity = int.Parse(QuantityTextBox.Text),
                    Image = ImageTextBox.Text
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