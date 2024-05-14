﻿using AutoMapper;
using Ecom.Core.Interfaces;
using Ecom.Infrastructure.Data;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;

        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }
        public UnitOfWork(ApplicationDbContext context,IMapper mapper,IFileProvider fileProvider)

        {
            _context = context;
            _mapper = mapper;
            _fileProvider = fileProvider;
            CategoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProductRepository(_context,_mapper,_fileProvider);
        }
    }
   
}
