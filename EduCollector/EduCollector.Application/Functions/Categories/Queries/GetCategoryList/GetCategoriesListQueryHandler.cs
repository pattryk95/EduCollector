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
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryInListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public GetCategoriesListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryInListViewModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var all = await _categoryRepository.GetAllAsync();
            var ordered = all.OrderBy(a=> a.Name);

            return _mapper.Map<List<CategoryInListViewModel>>(ordered);
        }
    }
}
