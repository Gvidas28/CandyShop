using CandyShop.Model.Repositories;
using System;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class ItemDetailsPage : Form
    {
        public int ItemID { get; set; }

        private readonly IItemRepository _itemRepository;

        public ItemDetailsPage(
            IItemRepository itemRepository,
            int itemId
            )
        {
            _itemRepository = itemRepository;
            ItemID = itemId;
            InitializeComponent();
        }

        private void ItemDetailsPage_Load(object sender, EventArgs e)
        {
            try
            {
                var itemInfo = _itemRepository.GetItemById(ItemID);
                if (itemInfo is null)
                {
                    MessageBox.Show($"Item {ItemID} not found!");
                    return;
                }

                ItemName.Text = itemInfo.Name;
                ItemImage.ImageLocation = itemInfo.Image;
                ItemDescription.Text = $"Description: \n{itemInfo.Description}";
                Price.Text = $"Price: \n{itemInfo.Price}";
                Quantity.Text = $"Quantity: \n{itemInfo.Quantity}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load item details page due to {ex}!");
            }
        }
    }
}
