using MediatR;
using NSubstitute;
using System;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        public IMediator Mediator { get; private set; }

        public UnitTest1()
        {
            Mediator = Substitute.For<IMediator>();
        }

        [Fact]
        public void GetAllProduct()
        {

        }
    }
}
