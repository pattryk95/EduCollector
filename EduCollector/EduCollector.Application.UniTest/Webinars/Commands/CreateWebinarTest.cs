using AutoMapper;
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
    public class CreateWebinarTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IWebinarRepository> _mockWebinarRepository;

        public CreateWebinarTest()
        {
            _mockWebinarRepository = RepositoryMocks.GetWebinarRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task Handle_ValidWebinar_AddedToWebinarRepo()
        {
            var handler = new CreatedWebinarCommandHandler(_mockWebinarRepository.Object, _mapper);

            var allWebinarsBeforeCount = (await _mockWebinarRepository.Object.GetAllAsync()).Count;

            var command = new CreatedWebinarCommand()
            {
                ImageUrl = "TestTest",
                Title = new string('*', 80),
                FacebookEventUrl = "TestTest",
                Date = DateTime.Now.AddDays(-14),
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allWebinars = await _mockWebinarRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allWebinars.Count.ShouldBe(allWebinarsBeforeCount + 1);
            response.Id.ShouldNotBeNull();

        }
    }
}
