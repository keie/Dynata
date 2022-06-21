﻿using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class BaseRepositoryAsync<T>:RepositoryBase<T>,IDynataRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        public BaseRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
