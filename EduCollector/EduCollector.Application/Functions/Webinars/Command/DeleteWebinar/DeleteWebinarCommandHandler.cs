using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application.Functions.Webinars.Command.DeleteWebinar
{
    public class DeleteWebinarCommandHandler : IRequestHandler<DeleteWebinarCommand>
    {
        private readonly IWebinarRepository _webinarRepository;
        private readonly IMapper _mapper;

        public DeleteWebinarCommandHandler(IWebinarRepository webinarRepository, IMapper mapper)
        {
            _webinarRepository = webinarRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteWebinarCommand request, CancellationToken cancellationToken)
        {
            var posttodelete = await _webinarRepository.GetByIdAsync(request.WebinarId);
            await _webinarRepository.DeleteAsync(posttodelete);
            return Unit.Value;
        }
    }
}
