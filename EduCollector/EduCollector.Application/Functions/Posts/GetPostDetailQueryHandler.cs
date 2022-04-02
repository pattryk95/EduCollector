﻿using AutoMapper;
using EduCollector.Domain;
using MediatR;

namespace EduCollector.Application
{
    public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailQuery, PostDetailViewModel>
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetPostDetailQueryHandler(IAsyncRepository<Post> postRepository, IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<PostDetailViewModel> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);
            var postdetail = _mapper.Map<PostDetailViewModel>(post);

            var category = await _categoryRepository.GetByIdAsync(post.CategoryId);

            postdetail.Category = _mapper.Map<CategoryDto>(category);

            return postdetail;
        }
    }
}