using NbaTradeHub_Api.Core.Interfaces;
using NbaTradeHub_Api.Data.DTO;
using NbaTradeHub_Api.Data.Enteties;
using NbaTradeHub_Api.Data.Interfaces;

namespace NbaTradeHub_Api.Core.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepo _repo;

        public BlogPostService(IBlogPostRepo repo)
        {
            _repo = repo;
        }


        public IEnumerable<BlogPost> GetBlogPosts(string? title, int? categoryId)
        {
            IEnumerable<BlogPost> blogPosts = _repo.GetBlogPosts();

            if (!string.IsNullOrWhiteSpace(title))
                blogPosts = blogPosts.Where(p =>
                    p.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

            if (categoryId.HasValue)
                blogPosts = blogPosts.Where(p => p.CategoryId == categoryId.Value);

            return blogPosts;
        }


        public void AddBlogPost(BlogPost blogPost)
        {
            _repo.AddBlogPost(blogPost);
        }


        public bool UpdBlogPost(int blogPostId, UpdBlogPostDto dto, int userId)
        {
            var blogPost = _repo.GetById(blogPostId);

            if (blogPost == null)
                return false;

            if (blogPost.UserId != userId)
                return false; // ej ägare

            blogPost.Title = dto.Title;
            blogPost.Text = dto.Text;
            blogPost.CategoryId = dto.CategoryId;

            return _repo.UpdBlogPost(blogPost);
        }


        public bool DeleteBlogPost(int blogPostId, int userId)
        {
            var blogPost = _repo.GetById(blogPostId);

            if (blogPost == null)
                return false;

            if (blogPost.UserId != userId)
                return false; //ej ägare

            _repo.DeleteBlogPost(blogPostId);
            return true;
        }
    }
}
