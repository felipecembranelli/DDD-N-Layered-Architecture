using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Domain.ContractRepositories;

namespace Sample.Infra.Data.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public void Add(Domain.Entidades.Country item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entidades.Country item)
        {
            throw new NotImplementedException();
        }

        public void Modify(Domain.Entidades.Country item)
        {
            throw new NotImplementedException();
        }

        public Domain.Entidades.Country Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entidades.Country> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
