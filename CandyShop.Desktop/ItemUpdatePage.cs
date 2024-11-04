using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class ItemUpdatePage : Form
    {
        private readonly IItemRepository _itemRepository;
        private readonly Item _selectedItem;

        public ItemUpdatePage(IItemRepository itemRepository, Item selectedItem)
        {
            _itemRepository = itemRepository;
            InitializeComponent();
            _selectedItem = selectedItem;
        }

        private void ItemUpdatePage_Load(object sender, EventArgs e)
        {
            MinimizeBox = false;
            MaximizeBox = false;
            NameTextBox.Text = _selectedItem.Name;
            DescriptionTextBox.Text = _selectedItem.Description;
            PriceTextBox.Text = _selectedItem.Price.ToString();
            QuantityTextBox.Text = _selectedItem.Quantity.ToString();
            ImageTextBox.Text = _selectedItem.Image?.ToString();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                _itemRepository.UpdateItem(new Item
                {
                    ID = _selectedItem.ID,
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