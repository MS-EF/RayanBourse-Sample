using Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            await _productRepository.Delete(request.ID);
            await _productRepository.Save();

            return await Task.FromResult(Unit.Value);
        }
    }
}
