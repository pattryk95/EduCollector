using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Domain.Entites
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
