using BloggingInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingInfrastructure.Interfaces
{
    public interface IBlogPostRepository
    {
        void AddBlogPost(BlogPostTable blogPost);
        BlogPostTable GetBlogPostByTitle(string title);
        void DeleteBlogPost(BlogPostTable blogPost);

        BlogPostTable UpdateBlogPost(BlogPostTable blogPost);

    }
}
