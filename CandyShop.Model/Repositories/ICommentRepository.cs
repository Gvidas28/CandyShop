using CandyShop.Model.Entities;
using System.Collections.Generic;

namespace CandyShop.Model.Repositories
{
    public interface ICommentRepository
    {
        Comment GetCommentById(int id);
        List<Comment> GetCommentsByItemId(int itemId);
        bool AddComment(Comment comment);
        bool UpdateComment(Comment comment);
        bool DeleteComment(int id);
    }
}