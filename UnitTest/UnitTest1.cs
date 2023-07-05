using Application.Products.Queries.GetAll;
using Domain.Repositories;
using MediatR;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        public IMediator Mediator { get; private set; }
        public IProductRepository Repository { get; private set; }

        public UnitTest1()
        {
            Mediator = Substitute.For<IMediator>();
            Repository = Substitute.For<IProductRepository>();
        }

        [Fact]
        public async Task GetAllProduct()
        {
            await Mediator.Send(Arg.Any<GetAllProduct>());

            await Repository.GetAll();

            await Repository.Received().GetAll();
        }
    }
}
