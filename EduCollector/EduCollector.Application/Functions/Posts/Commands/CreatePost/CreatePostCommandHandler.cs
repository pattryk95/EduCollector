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
    public class CreatePostCommandHandler : IRequestHandler<CreatedPostCommand, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public async Task<int> Handle(CreatedPostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request);
            post = await _postRepository.AddAsync(post);

            return post.PostId;
        }
    }
}
