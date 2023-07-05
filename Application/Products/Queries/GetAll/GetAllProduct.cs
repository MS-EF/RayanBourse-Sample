using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Products.Queries.GetAll
{
    public class GetAllProduct : IRequest<IEnumerable<ProductDTO>>
    {

    }
}
