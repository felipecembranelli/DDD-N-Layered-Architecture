using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Domain.ContractRepositories;

namespace Sample.Infra.Data.Repository
{
    public class OrderRepositorio : IOrderRepository
    {
        public void Add(Domain.Entidades.Order item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entidades.Order item)
        {
            throw new NotImplementedException();
        }

        public void Modify(Domain.Entidades.Order item)
        {
            throw new NotImplementedException();
        }

        public Domain.Entidades.Order Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entidades.Order> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
