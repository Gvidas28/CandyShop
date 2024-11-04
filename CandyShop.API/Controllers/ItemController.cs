using CandyShop.Model.Entities;
using CandyShop.Model.Entities.Requests;
using CandyShop.Model.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CandyShop.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(
            IItemRepository itemRepository
            )
        {
            _itemRepository = itemRepository;
        }

        [HttpGet("list")]
        public List<Item> List() => _itemRepository.GetItemList();

        [HttpGet("details")]
        public Item List(int id) => _itemRepository.GetItemById(id);
    }
}