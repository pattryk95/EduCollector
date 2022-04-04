using EduCollector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
        Task<bool> IsNameAndAuthorAlreadyExist(string title, string author);
    }
}
