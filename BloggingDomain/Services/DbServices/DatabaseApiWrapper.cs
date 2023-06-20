using Azure.Identity;
using BloggingDomain.Interfaces;
using BloggingDomain.Models;
using BloggingInfrastructure.Interfaces;
using BloggingInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingDomain.Services.DbServices
{
    public class DatabaseApiWrapper : IDatabaseApiWrapper
    {
        private readonly IUserRespository _userRepository;
        private readonly IBlogPostRepository _blogPostRepository;
        public DatabaseApiWrapper(IUserRespository userRespository, IBlogPostRepository blogPostRepository)
        {
            _userRepository = userRespository;
            _blogPostRepository = blogPostRepository;
        }

        public bool RegisterUser(User user)
        {
            UserTable infraUser = new UserTable() {Username = user.Username, PasswordHash = user.PasswordHash, PasswordSalt = user.PasswordSalt };
            return _userRepository.Register(infraUser);
        }

        public bool CheckIfUsernameIsTaken(string username)
        {
            return _userRepository.IsUsernameTaken(username);
        }

        public UserTable GetUser(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public void AddBlogPost(BlogPost blogPost)
        {
            BlogPostTable blogPostTable = new BlogPostTable() 
            { Author = blogPost.Author, Content = blogPost.Content, PublishDate = blogPost.PublishDate, Title = blogPost.Title, ImageUrl = blogPost.ImageUrl };
            _blogPostRepository.AddBlogPost(blogPostTable);
        }

    }
}
