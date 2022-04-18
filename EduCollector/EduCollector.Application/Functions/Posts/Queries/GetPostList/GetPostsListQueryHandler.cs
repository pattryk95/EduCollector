using AutoMapper;
using EduCollector.Domain;
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
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public GetPostsListQueryHandler(IAsyncRepository<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;

        }
        public async Task<List<PostInListViewModel>> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
        {
            var all = await _postRepository.GetAllAsync();
            var allordered = all.OrderBy(x => x.Date);

            return _mapper.Map<List<PostInListViewModel>>(all);
        }
    }
}
