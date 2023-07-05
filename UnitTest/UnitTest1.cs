using Application.Products.Commands.Create;
using Application.Products.Queries.GetAll;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using NSubstitute;
using System;
using System.Threading.Tasks;
using UnitTest.Factory;
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

        [Fact]
        public async Task AddNewProduct()
        {

            var product = ProductFactory.Create();

            await Mediator.Send(Arg.Any<CreateProduct>());
            await Repository.Add(product);

            await Repository.Received(1).Add(Arg.Is<Product>(p => p.Name == product.Name));
            await Repository.Received(1).Add(Arg.Is<Product>(p => p.ManufactureEmail == product.ManufactureEmail));
            await Repository.Received(1).Add(Arg.Is<Product>(p => p.ManufacturePhone == product.ManufacturePhone));
        }
    }
}
