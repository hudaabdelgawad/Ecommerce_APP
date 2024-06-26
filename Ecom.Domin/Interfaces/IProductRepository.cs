﻿using Ecom.Core.Dtos;
using Ecom.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.Interfaces
{
    public interface IProductRepository:IGenericRepository<Product>
    {//FUTURE CODE
        public Task<bool> AddAsync(CreateProductDto dto);
        public Task<bool> UpdateAsync( int id,UpdateProductDto dto);
        public Task<bool> DeleteAsyncWithPicture(int id);
    }
}
