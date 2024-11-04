using CandyShop.Model.Entities;
using CandyShop.Model.Entities.Requests;
using CandyShop.Model.Entities.Responses;
using CandyShop.Model.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CandyShop.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class CommentController : Controller
    {

        private readonly ICommentRepository _commentRepository;

        public CommentController(
            ICommentRepository commentRepository
            )
        {
            _commentRepository = commentRepository;
        }

        [HttpGet("listByItem")]
        public List<Comment> ListByItem(int itemId) => _commentRepository.GetCommentsByItemId(itemId);

        [HttpGet("getById")]
        public Comment GetById(int commentId) => _commentRepository.GetCommentById(commentId);

        [HttpPut("update")]
        public bool Update([FromBody]Comment comment) => _commentRepository.UpdateComment(comment);

        [HttpPost("add")]
        public bool Add([FromBody] Comment comment) => _commentRepository.AddComment(comment);

        [HttpDelete("delete")]
        public bool Delete(int commentId) => _commentRepository.DeleteComment(commentId);
    }
}