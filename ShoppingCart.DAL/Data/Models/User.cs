using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ShoppingCart.DAL.Data.Models;

public class User: IdentityUser
{
    public string type { get; set; } = string.Empty;
}
