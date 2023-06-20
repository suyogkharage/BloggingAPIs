using BloggingInfrastructure.Data;
using BloggingInfrastructure.Interfaces;
using BloggingInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingInfrastructure.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly DataContext _dbcontext;

        public BlogPostRepository(DataContext dataContext)
        {
            _dbcontext = dataContext;
        }

        public void AddBlogPost(BlogPostTable blogPost)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlogPost(BlogPostTable blogPost)
        {
            throw new NotImplementedException();
        }

        public BlogPostTable GetBlogPostByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public BlogPostTable UpdateBlogPost(BlogPostTable blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
