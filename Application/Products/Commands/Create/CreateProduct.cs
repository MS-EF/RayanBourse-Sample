using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Application.Products.Commands.Create
{
    public class CreateProduct : IRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Invalid phone number")]
        public string ManufacturePhone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string ManufactureEmail { get; set; }

        public bool IsActive { get; set; }

        public string AppUserId { get; set; }

    }
}
