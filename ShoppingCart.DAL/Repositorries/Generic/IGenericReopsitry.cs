﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL.Repositorries.Generic;

public interface IGenericReopsitry<TEntity>
    where TEntity : class
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);

    
}
