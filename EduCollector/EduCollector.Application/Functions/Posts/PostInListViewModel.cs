using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public class PostInListViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime Data { get; set; }
        public string ImageUrl { get; set; }
        public int Rate { get; set; }
    }
}
