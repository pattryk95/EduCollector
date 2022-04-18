﻿using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EduCollector.Application.UnitTest
{
    public class CreatePostTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockPostRepository;

        public CreatePostTest()
        {
            _mockPostRepository = RepositoryMocks.GetPostRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidPost_AddedToPostRepo()
        {
            var handle = new CreatedPostCommandHandler(_mockPostRepository.Object, _mapper);

            var allPostsBeforeCount = (await _mockPostRepository.Object.GetAllAsync()).Count;

            var command = new CreatedPostCommand()
            {
                Title = "TestTest",
                Date = DateTime.Now.AddDays(-14),
                Rate = 9,
                Author = "AAA"
            };

            var response = await handle.Handle(command, CancellationToken.None);

            var allPosts = await _mockPostRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allPosts.Count.ShouldBe(allPostsBeforeCount + 1);
            response.PostId.ShouldNotBeNull();

        }

        [Fact]
        public async Task Handle_Not_ValidPost_TooLongTitle_81Characters_NotAddedToPostRepo()
        {
            var handler = new CreatedPostCommandHandler(_mockPostRepository.Object, _mapper);

            var allPostsBeforeCound = (await _mockPostRepository.Object.GetAllAsync()).Count;

            var command = new CreatedPostCommand()
            {
                Title = new string('*', 81),
                Date = DateTime.Now.AddDays(-14),
                Rate = 9,
                Author = "AAAA"
            };

            var response = await handler.Handle(command, CancellationToken.None);
            var allPosts = await _mockPostRepository.Object.GetAllAsync();

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            allPosts.Count.ShouldBe(allPostsBeforeCound);
            response.PostId.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_Not_ValidPost_FutureDate_2DaysIntoTheFuture_NotAddedToPostRepo()
        {
            var handler = new CreatedPostCommandHandler(_mockPostRepository.Object, _mapper);

            var allPostsBeforeCount = (await _mockPostRepository.Object.GetAllAsync()).Count;

            var command = new CreatedPostCommand()
            {
                Title = new string('*', 80),
                Date = DateTime.Now.AddDays(2),
                Rate = 9,
                Author = "AAAA"
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allPosts = await _mockPostRepository.Object.GetAllAsync();

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            allPosts.Count.ShouldBe(allPostsBeforeCount);
            response.PostId.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_Not_ValidPost_RateToBig_NotAddedToPostRepo()
        {
            var handler = new CreatedPostCommandHandler(_mockPostRepository.Object, _mapper);

            var allPostsBeforeCount = (await _mockPostRepository.Object.GetAllAsync()).Count;

            var command = new CreatedPostCommand()
            {
                Title = new string('*', 80),
                Date = DateTime.Now.AddDays(-12),
                Rate = 101,
                Author = "AAAA"
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allPosts = await _mockPostRepository.Object.GetAllAsync();

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            allPosts.Count.ShouldBe(allPostsBeforeCount);
            response.PostId.ShouldBeNull();
        }
    }
}
