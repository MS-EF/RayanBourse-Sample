using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProduct>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            await _productRepository.Add(_mapper.Map<CreateProduct, Product>(request));
            await _productRepository.Save();

            return await Task.FromResult(Unit.Value);
        }
    }
}
