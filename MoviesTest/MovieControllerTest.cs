using System;
using System.Collections.Generic;
using System.Linq;
using Movie.API.Controllers;
using Xunit;
using Movie.MovieInterface;
using Movie.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace web_api_tests
{
    public class MovieControllerTest
    {
        MoviesController _controller;
        IMovie _service;

        public MovieControllerTest()
        {            
            _service = new MovieServiceFake();           
            var _mockLogger = new Mock<ILogger<MoviesController>>();           
            _controller = new MoviesController(_mockLogger.Object, _service);
        }

        [Fact]
        public void Get()
        {            
            var okResult = _controller.Get(1);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_ReturnsAllItems()
        {            
            var okResult = _controller.GetMovies(1,10) as OkObjectResult;
            var items = Assert.IsType<List<MovieEntity>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Add_ReturnedResponseHasCreatedItem()
        {
            var testItem = new MovieEntity { Id = 4, Title = "Interstellar", Director = "Christopher Nolan" };                      
            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as MovieEntity;
            Assert.IsType<MovieEntity>(item);
            Assert.Equal("Interstellar", item.Title);
        }

        [Fact]
        public void Add_ReturnsBadRequest()
        {
            var nameMissingItem = new MovieEntity { Id = 4, Title = "Interstellar", Director = "Christopher Nolan" };
            _controller.ModelState.AddModelError("Name", "Required");                        
            var badResponse = _controller.Post(nameMissingItem);          
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
    }
}
