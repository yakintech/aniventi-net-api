using Aniventi.BLL.Services.Interfaces;
using Aniventi.BLL.Services.Repositories.General;
using Aniventi.DAL.ORM.Context;
using Aniventi.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.BLL.Services.Repositories
{

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AniventiECommerceContext context) : base(context)
        {

        }
    }
}
