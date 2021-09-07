using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movie.API.Controllers;
using Xunit;

namespace MovieTest
{
    public class MovieControllerTest
    {
        //private readonly ILogger _logger;
        //private readonly IMovie _movie;
        //public MovieControllerTest(ILogger<MoviesController> logger, IMovie movie)
        //{
        //    _logger = logger;
        //    _movie = movie;
        //}

        [Fact]
        public void Get_Test()
        {
            //MoviesController controller = new MoviesController(_logger,_movie);
            //var result = controller.GetById(1);
            //Assert.NotNull(result);
        }


        //[TestMethod]
        //public void PlaceOrder_StockAvailable_CallsProcessPayment()
        //{
        //    var fakePaymentGateway = new Mock<IPaymentGateway>();

        //    var fakeStockService = new Mock<IStockService>();
        //    fakeStockService.Setup(t => t.IsStockAvailable(It.IsAny<Order>()))
        //                    .Returns(true);
        //    var orderService = new OrderService(fakePaymentGateway.Object, fakeStockService.Object);

        //    var order = new Order();
        //    orderService.PlaceOrder(order);

        //    fakePaymentGateway.Verify(t => t.ProcessPayment(order), Times.Once);
        //}
    }
}

