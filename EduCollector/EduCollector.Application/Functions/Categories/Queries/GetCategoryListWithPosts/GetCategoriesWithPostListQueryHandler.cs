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
    public class GetCategoriesWithPostListQueryHandler : IRequestHandler<GetCategoriesWithPostListQuery, List<CategoryPostListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public GetCategoriesWithPostListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryPostListViewModel>> Handle(GetCategoriesWithPostListQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithPost(request.searchCategory);

            return _mapper.Map<List<CategoryPostListViewModel>>(list);
        }
    }
}
