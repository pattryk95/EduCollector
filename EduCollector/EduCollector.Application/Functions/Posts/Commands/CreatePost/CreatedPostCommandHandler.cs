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
    public class CreatedPostCommandHandler : IRequestHandler<CreatedPostCommand, CreatedPostCommandResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatedPostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CreatedPostCommandResponse> 
            Handle(CreatedPostCommand request, 
            CancellationToken cancellationToken)
        {
            var validator = new CreatedPostCommandValidator(_postRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreatedPostCommandResponse(validatorResult);

            var post = _mapper.Map<Post>(request);
            post = await _postRepository.AddAsync(post);

            return new CreatedPostCommandResponse(post.PostId);
        }
    }
}
