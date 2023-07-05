using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetAll
{
    public class GetAllProductHandler : IRequestHandler<GetAllProduct, IEnumerable<ProductDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetAllProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProduct request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>
                        (await _productRepository.GetAllWithUserName(request.UserName));
        }
    }
}
