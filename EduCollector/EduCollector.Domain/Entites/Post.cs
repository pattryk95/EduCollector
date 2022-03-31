using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Domain.Entites
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Data { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public int Rate { get; set; }
    }
}
