using Aniventi.BLL.Services.Interfaces;
using Aniventi.BLL.Services.Repositories;
using Aniventi.DAL.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.BLL.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }


        private AniventiECommerceContext _aniventiECommerceContext;

        public UnitOfWork(AniventiECommerceContext aniventiECommerceContext)
        {
            _aniventiECommerceContext = aniventiECommerceContext;

            CategoryRepository = new CategoryRepository(_aniventiECommerceContext);
            ProductRepository = new ProductRepository(_aniventiECommerceContext);
        }


        //Hata geldiğinde yakalamamız gerek!
        public void Commit()
        {
            _aniventiECommerceContext.SaveChanges();
        }


    }
}
