using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public class GetWEbinarsByDateQueryHandler : IRequestHandler<GetWebinarsByDateQuery, PageWebinarByDateViewModel>
    {
        private readonly IWebinarRepository _webinarRepository;
        private readonly IMapper _mapper;

        public GetWEbinarsByDateQueryHandler(IWebinarRepository webinarRepository, IMapper mapper)
        {
            _webinarRepository = webinarRepository;
            _mapper = mapper;
        }

        public async Task<PageWebinarByDateViewModel> Handle(GetWebinarsByDateQuery request, CancellationToken cancellationToken)
        {
            var list = await _webinarRepository.GetPagedWebinarsForDate(request.Options, request.Page, request.PageSize, request.Date);

            var webinars = _mapper.Map<List<WebinarsByDateViewModel>>(list);

            var count = await _webinarRepository.GetTotalCountOfWebinarsForDate(request.Options, request.Date);
            return new PageWebinarByDateViewModel()
            {
                AllCount = count,
                Webinars = webinars,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}
