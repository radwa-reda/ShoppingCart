﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BL.Dtos.Auth;

public record RegisterDto(string UserName,
    string Email,
    string type,
    string Password);
