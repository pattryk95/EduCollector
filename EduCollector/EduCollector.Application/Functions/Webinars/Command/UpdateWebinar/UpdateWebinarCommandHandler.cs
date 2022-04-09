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
    public class UpdateWebinarCommandHandler : IRequestHandler<UpdateWebinarCommand>
    {
        private readonly IWebinarRepository _webinarRepository;
        private readonly IMapper _mapper;

                public UpdateWebinarCommandHandler(IWebinarRepository webinarRepository,
            IMapper mapper)
        {
            _webinarRepository = webinarRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWebinarCommand request,
            CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Webinar>(request);

            await _webinarRepository.UpdateAsync(post);

            return Unit.Value;
        }


    }
}
