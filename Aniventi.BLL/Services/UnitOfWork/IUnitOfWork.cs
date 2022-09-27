using Aniventi.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.BLL.Services.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IUserRepository UserRepository { get; }

        void Commit();
    }
}
