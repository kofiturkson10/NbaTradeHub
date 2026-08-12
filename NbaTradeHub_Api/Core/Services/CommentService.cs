using NbaTradeHub_Api.Core.Interfaces;
using NbaTradeHub_Api.Data.Enteties;
using NbaTradeHub_Api.Data.Interfaces;

namespace NbaTradeHub_Api.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IBlogPostRepo _blogPostRepo;

        public CommentService(ICommentRepo commentRepo, IBlogPostRepo blogPostRepo)
        {
            _commentRepo = commentRepo;
            _blogPostRepo = blogPostRepo;
        }


        public bool AddComment(Comment comment)
        {
            var blogPost = _blogPostRepo.GetById(comment.BlogPostId);

            if (blogPost == null)
                return false;

            if (blogPost.UserId == comment.UserId)
                return false;

            _commentRepo.AddComment(comment);
            return true;
        }


        public List<Comment> GetCommentsByPostId(int blogPostId)
        {
            return _commentRepo.GetCommentsByPostId(blogPostId);
        }
    }
}
