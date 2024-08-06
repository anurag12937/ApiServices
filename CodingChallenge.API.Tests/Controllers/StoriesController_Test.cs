using AutoFixture;
using CodingChallenge.Controllers;
using CodingChallenge.Core.Models;
using CodingChallenge.Core.Services.StoriesServices.Interface;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;

namespace CodingChallenge.API.Tests.Controllers
{
    public class StoriesController_Test
    {
        private readonly IFixture _fixture;
        private readonly StoriesController _controller;
        private readonly Mock<IStoriesService> _serviceMock;
        public StoriesController_Test()
        {
            _fixture = new Fixture();
            _serviceMock = new Mock<IStoriesService>();
            _controller = new StoriesController(_serviceMock.Object);
        }
        [Fact]
        public async Task GetAllStories_Should_Return_List_Of_Stories_If_Request_Params_Provided()
        {
            var request = _fixture.Create<PagingParameters>();
          
            try
            {
                var result = await _controller.GetAllStories(request).ConfigureAwait(false);

                result.Should().NotBeNull();

                _serviceMock.Verify(x => x.GetTopAllStories(request), Times.Once());
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Shoulds the return list of Stories if request parameter is not provided set default value (PageNumber/PazeSize).
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllStories_Should_Return_List_Of_Stories_If_Request_Params_isnull()
        {
            //Given
            var request = _fixture.Create<PagingParameters>();

            var results = await _controller.GetAllStories(request).ConfigureAwait(false);
            //When
            _serviceMock.Verify(x => x.GetTopAllStories(request), Times.Never());
            //Then
            results.Should().BeNull();
        }
    }
}
