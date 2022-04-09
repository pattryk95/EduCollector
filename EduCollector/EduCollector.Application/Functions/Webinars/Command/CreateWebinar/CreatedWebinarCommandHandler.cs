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
    public class CreatedWebinarCommandHandler : IRequestHandler<CreatedWebinarCommand, CreatedWebinarCommandResponse>
    {
        private IWebinarRepository _webinarRepository;
        private IMapper _mapper;

        public CreatedWebinarCommandHandler(IWebinarRepository webinarRepository, IMapper mapper)
        {
            _webinarRepository = webinarRepository;
            _mapper = mapper;
        }
        public async Task<CreatedWebinarCommandResponse> Handle(CreatedWebinarCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatedWebinarCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return new CreatedWebinarCommandResponse(validatorResult);
            }

            var webinar = _mapper.Map<Webinar>(request);

            webinar = await _webinarRepository.AddAsync(webinar);

            return new CreatedWebinarCommandResponse(webinar.Id);

        }
    }

}
