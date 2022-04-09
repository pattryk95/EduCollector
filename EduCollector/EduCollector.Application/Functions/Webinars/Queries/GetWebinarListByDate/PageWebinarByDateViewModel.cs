using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public class PageWebinarByDateViewModel
    {
        public int PageSize { get; set; }

        public int Page { get; set; }

        public int AllCount { get; set; }

        public ICollection<WebinarsByDateViewModel> Webinars { get; set; }
    }
}
