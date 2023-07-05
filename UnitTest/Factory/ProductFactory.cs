using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Factory
{
    public class ProductFactory
    {
        public static Product Create()
        {
            return new Product
            {
                Name = "erfani",
                ManufactureEmail = "msef.mail@gmail.com",
                ManufacturePhone = "09127180919",
                IsActive = true,
                ID = 1
            };
        }
    }
}
