using CandyShop.Model.Entities;
using System.Collections.Generic;

namespace CandyShop.Model.Repositories
{
    public interface IItemRepository
    {
        Item GetItemById(int id);
        List<Item> GetItemList();
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
    }
}