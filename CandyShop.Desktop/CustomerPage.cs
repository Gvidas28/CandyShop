using CandyShop.Model.Entities;
using CandyShop.Model.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CandyShop.Desktop
{
    public partial class CustomerPage : Form
    {
        public int CustomerID { get; set; }

        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICommentRepository _commentRepository;

        public CustomerPage(
            IItemRepository itemRepository,
            IOrderRepository orderRepository,
            ICommentRepository commentRepository,
            int customerId
            )
        {
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            _commentRepository = commentRepository;
            CustomerID = customerId;
            InitializeComponent();
        }

        private void ShopItemsButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToCartButton.Visible = true;
                CancelOrderButton.Visible = false;
                ViewCommentsButton.Visible = true;
                ViewDetailsButton.Visible = true;

                var items = _itemRepository.GetItemList();
                var minimalItemList = items.Select(x => new ItemMinimal
                {
                    ID = x.ID,
                    Name = x.Name,
                    Price = x.Price
                }).ToList();

                CustomerDataTable.DataSource = minimalItemList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load shop items due to {ex}!");
            }
        }

        private void ViewDetailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCell = CustomerDataTable.SelectedCells[0].RowIndex;

                var selectedItemRow = CustomerDataTable.Rows[selectedCell].DataBoundItem as ItemMinimal;
                var selectedOrderRow = CustomerDataTable.Rows[selectedCell].DataBoundItem as OrderMinimal;

                var id = selectedItemRow?.ID ?? selectedOrderRow?.ItemId;
                if (id is null)
                {
                    MessageBox.Show($"Select a row you want to view details for!");
                    return;
                }

                var detailsPage = new ItemDetailsPage(_itemRepository, id.Value);
                detailsPage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open item details due to {ex}!");
            }
        }

        private void ShoppingCartButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddToCartButton.Visible = false;
                CancelOrderButton.Visible = true;
                ViewCommentsButton.Visible = false;
                ViewDetailsButton.Visible = false;

                var orders = _orderRepository.GetOrderList();
                var minimalOrderList = orders
                    .Where(x => x.CustomerId == CustomerID)
                    .Select(x => new OrderMinimal
                    {
                        ID = x.ID,
                        ItemId = x.ItemId,
                        ItemName = _itemRepository.GetItemById(x.ItemId).Name,
                        Status = x.Status,
                        Price = x.Price,
                        OrderDate = x.OrderDate
                    }).ToList();

                CustomerDataTable.DataSource = minimalOrderList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load shopping cart due to {ex}!");
            }
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCell = CustomerDataTable.SelectedCells[0].RowIndex;
                var selectedItemRow = CustomerDataTable.Rows[selectedCell].DataBoundItem as ItemMinimal;
                if (selectedItemRow is null)
                {
                    MessageBox.Show($"Please first select an item to add to cart!");
                    return;
                }

                var quantityPage = new QuantityPage(_itemRepository, _orderRepository, selectedItemRow.ID, CustomerID);
                quantityPage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add item to shopping cart due to {ex}");
            }
        }

        private void CancelOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCell = CustomerDataTable.SelectedCells[0].RowIndex;
                var selectedOrderRow = CustomerDataTable.Rows[selectedCell].DataBoundItem as OrderMinimal;
                if (selectedOrderRow is null)
                {
                    MessageBox.Show($"Please first select order to cancel!");
                    return;
                }

                if (selectedOrderRow.Status != "Waiting")
                {
                    MessageBox.Show($"Cannot remove an order that has already been processed! The status of your order is already {selectedOrderRow.Status}!");
                    return;
                }

                _orderRepository.DeleteOrder(selectedOrderRow.ID);

                var item = _itemRepository.GetItemById(selectedOrderRow.ItemId);
                item.Quantity++;
                _itemRepository.UpdateItem(item);

                var orders = _orderRepository.GetOrderList();
                var minimalOrderList = orders
                    .Where(x => x.CustomerId == CustomerID)
                    .Select(x => new OrderMinimal
                    {
                        ID = x.ID,
                        ItemId = x.ItemId,
                        ItemName = _itemRepository.GetItemById(x.ItemId).Name,
                        Status = x.Status,
                        Price = x.Price,
                        OrderDate = x.OrderDate
                    }).ToList();

                CustomerDataTable.DataSource = minimalOrderList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to cancel order due to {ex}");
            }
        }

        private void ViewCommentsButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCell = CustomerDataTable.SelectedCells[0].RowIndex;

                var selectedItemRow = CustomerDataTable.Rows[selectedCell].DataBoundItem as ItemMinimal;
                if (selectedItemRow is null)
                {
                    MessageBox.Show($"Select a item you want to view comments for!");
                    return;
                }

                var commentsPage = new CommentsPage(
                    _commentRepository,
                    selectedItemRow.ID,
                    false,
                    null,
                    CustomerID
                    );

                commentsPage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to view comments due to {ex}");
            }
        }

        private void CustomerPage_Load(object sender, EventArgs e)
        {
            ViewDetailsButton.Visible = false;
            ViewCommentsButton.Visible = false;
        }
    }
}