using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public class GetPostsListQueryHandler : IRequestHandler<GetPostsListQuery, List<PostInListViewModel>>
    {
        public Task<List<PostInListViewModel>> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
