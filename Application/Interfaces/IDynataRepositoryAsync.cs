﻿using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDynataRepositoryAsync<T>:IReadRepositoryBase<T> where T : class
    {
    }
}
