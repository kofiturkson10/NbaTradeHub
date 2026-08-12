using NbaTradeHub_Api.Data.Enteties;

namespace NbaTradeHub_Api.Data.Interfaces
{
    public interface ICommentRepo
    {
        void AddComment(Comment comment); 

        List<Comment> GetCommentsByPostId(int blogPostId);
    }
}
