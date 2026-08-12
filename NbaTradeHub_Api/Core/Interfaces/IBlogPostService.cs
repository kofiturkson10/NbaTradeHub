using NbaTradeHub_Api.Data.DTO;
using NbaTradeHub_Api.Data.Enteties;

namespace NbaTradeHub_Api.Core.Interfaces
{
    public interface IBlogPostService
    {
        IEnumerable<BlogPost> GetBlogPosts(string? title, int? categoryId);

        void AddBlogPost(BlogPost blogPost);

        bool UpdBlogPost(int blogPostId, UpdBlogPostDto dto, int userId);

        bool DeleteBlogPost(int blogPostId, int userId);
    }
}
