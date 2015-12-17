using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Domain.ContractRepositories;

namespace Sample.Infra.Data.Repository
{
    public class ProductRepositorio : IProductRepository
    {
        public void Add(Domain.Entidades.Product item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entidades.Product item)
        {
            throw new NotImplementedException();
        }

        public void Modify(Domain.Entidades.Product item)
        {
            throw new NotImplementedException();
        }

        public Domain.Entidades.Product Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entidades.Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
