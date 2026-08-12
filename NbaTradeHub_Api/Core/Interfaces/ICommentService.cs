using NbaTradeHub_Api.Data.Enteties;

namespace NbaTradeHub_Api.Core.Interfaces
{
    public interface ICommentService
    {
        bool AddComment(Comment comment);

        List<Comment> GetCommentsByPostId(int blogPostId);
    }
}