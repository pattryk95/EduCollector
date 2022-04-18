using AutoMapper;
using MediatR;

namespace EduCollector.Application
{
    public class GetCategoriesWithPostListQueryHandler : IRequestHandler<GetCategoriesWithPostListQuery, List<CategoryPostListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesWithPostListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
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
