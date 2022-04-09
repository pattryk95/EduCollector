using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public class WebinarsByDateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string FacebookEventUrl { get; set; }
        public string SliderUrl { get; set; }
        public string WatchFacebookLink { get; set; }
        public string WatchYouTubeLink { get; set; }
        public DateTime Date { get; set; }
    }
}
