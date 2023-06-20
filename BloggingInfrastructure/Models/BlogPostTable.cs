﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingInfrastructure.Models
{
    public class BlogPostTable
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishDate { get; set; }
        public string Author { get; set; }
        public string? ImageUrl { get; set; }
    }
}
