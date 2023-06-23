using AutoMapper;
using BloggingAPI.DTOs;
using BloggingDomain.Interfaces;
using BloggingDomain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IDatabaseApiWrapper _databaseApiWrapper;
        private readonly IMapper _mapper;
        public BlogController(IDatabaseApiWrapper databaseApiWrapper, IMapper mapper)
        {
            _databaseApiWrapper = databaseApiWrapper;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult AddPost(BlogPostDTO request)
        {
            BlogPost blog = _mapper.Map<BlogPost>(request);
            _databaseApiWrapper.AddBlogPost(blog);

            return Ok();
        }
    }
}
