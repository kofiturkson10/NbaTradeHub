using NbaTradeHub_Api.Data.Enteties;
using NbaTradeHub_Api.Data.Interfaces;

namespace NbaTradeHub_Api.Data.Repos
{
    public class CommentRepo : ICommentRepo
    {
        private readonly NbaTradesContext _context;

        public CommentRepo(NbaTradesContext context)
        {
            _context = context;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public List<Comment> GetCommentsByPostId(int blogPostId)
        {
            return _context.Comments
                   .Where(c => c.BlogPostId == blogPostId)
                   .ToList();
        }
    }
}
