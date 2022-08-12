﻿using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public async Task<IQueryable<T>> FindAll(bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();
        public async Task< IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expresion, bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().Where(expresion).AsNoTracking() : RepositoryContext.Set<T>().Where(expresion);

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext?.Set<T>().Update(entity);
        public void Delete(T entity) {
            RepositoryContext.Entry(entity).State = EntityState.Deleted;
            RepositoryContext.Set<T>().Remove(entity);
        } 

    }
}
