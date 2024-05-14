using Microsoft.EntityFrameworkCore;
using ShoppingCart.DAL.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ShoppingCart.DAL.Repositorries.Generic;

public class GenericReopsitry<TEntity> : IGenericReopsitry<TEntity>
    where TEntity : class
{
    private readonly ProductContext _context;

    public GenericReopsitry(ProductContext context) {
        _context=context;
    }
    public void Add(TEntity entity)
    {
       _context.Set<TEntity>()
            .Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>()
         .Remove(entity);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>()
           .AsNoTracking();
    }

    public TEntity? GetById(int id)
    {
        return _context.Set<TEntity>()
            .Find(id);
    }

   

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>()
       .Update(entity);
    }
}
