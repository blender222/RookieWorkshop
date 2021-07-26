using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RookieWorkshop.Context;
using RookieWorkshop.Table;

namespace RookieWorkshop.Repository.FooBarQix
{
    public class FooBarQixRepository : IFooBarQixRepository
    {
        private readonly DataDbContext _dataDbContext;

        public FooBarQixRepository(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public void Insert(Data data)
        {
            _dataDbContext.Data.Add(data);

            _dataDbContext.SaveChanges();
        }
    }
}
