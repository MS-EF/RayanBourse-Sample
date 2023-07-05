using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Products.Commands.Delete
{
    public class DeleteProduct : IRequest
    {
        public int ID { get; private set; }
        public DeleteProduct(int id)
        {
            ID = id;
        }
    }
}
