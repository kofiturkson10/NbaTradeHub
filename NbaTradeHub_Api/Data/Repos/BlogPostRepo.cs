using NbaTradeHub_Api.Data.Enteties;
using NbaTradeHub_Api.Data.Interfaces;

namespace NbaTradeHub_Api.Data.Repos
{
    public class BlogPostRepo : IBlogPostRepo
    {
        private readonly NbaTradesContext _context;

        public BlogPostRepo(NbaTradesContext context)
        {
            _context = context;
        }


        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return _context.BlogPosts.ToList();
        }


        public BlogPost? GetById(int id)
        {
            return _context.BlogPosts
                   .SingleOrDefault(b => b.BlogPostId == id);
        }


        public void AddBlogPost(BlogPost blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            _context.SaveChanges();
        }


        public bool UpdBlogPost(BlogPost blogPost)
        {
            var blogPostOrg = _context.BlogPosts
                              .SingleOrDefault(b => b.BlogPostId == blogPost.BlogPostId);

            if (blogPostOrg == null)
            {
                return false;
            }

            _context.Entry(blogPostOrg)
                        .CurrentValues
                        .SetValues(blogPost);

            _context.SaveChanges();

            return true;
        }


        public void DeleteBlogPost(int id)
        {
            var blogPost = _context.BlogPosts
                           .FirstOrDefault(b => b.BlogPostId == id);
            if (blogPost == null)
            {
                return;
            }
            
            _context.BlogPosts.Remove(blogPost);
            _context.SaveChanges();
        }
    }
}
