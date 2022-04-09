using EduCollector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public interface IWebinarRepository : IAsyncRepository<Webinar>
    {
        Task<List<Webinar>> GetPagedWebinarsForDate(SearchOptionsWebinars options, int page, int pageSize, DateTime? date);
        Task<int> GetTotalCountOfWebinarsForDate(SearchOptionsWebinars options, DateTime? date);
    }
}
