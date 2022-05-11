using EduCollector.Application;
using EduCollector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF
{
    internal class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(EduCollectorContext dbContext) : base(dbContext)
        {

        }
        public Task<bool> IsNameAndAuthorAlreadyExist(string title, string author)
        {
            var matches = _dbContext.Posts.Any(a => a.Title.Equals(title) && a.Author.Equals(author));

            return Task.FromResult(matches);
        }
    }
}
