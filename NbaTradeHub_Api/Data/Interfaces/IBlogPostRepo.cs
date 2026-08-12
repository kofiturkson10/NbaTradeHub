using NbaTradeHub_Api.Data.Enteties;

namespace NbaTradeHub_Api.Data.Interfaces
{
    public interface IBlogPostRepo
    {
        IEnumerable<BlogPost> GetBlogPosts();

        public BlogPost? GetById(int id);

        void AddBlogPost(BlogPost blogPost);

        bool UpdBlogPost(BlogPost blogPost);

        void DeleteBlogPost(int id);
    }
}
