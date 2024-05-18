﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BL.Dtos.Products;

public class UpdateProductDto
{
    public int Id { get; set; }
    
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public IFormFile URL { get; set; }
}
