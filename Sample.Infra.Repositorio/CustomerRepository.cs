using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Domain.ContractRepositories;
using Sample.Domain.Entidades;

namespace Sample.Infra.Data.Repository
{
    public class CustomerRepositorio : ICustomerRepository
    {
        public void Add(Domain.Entidades.Customer item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entidades.Customer item)
        {
            throw new NotImplementedException();
        }

        public void Modify(Domain.Entidades.Customer item)
        {
            throw new NotImplementedException();
        }

        public Domain.Entidades.Customer Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Entidades.Customer> GetAll()
        {

            List<Domain.Entidades.Customer> custList = new List<Customer>();

            var cust1 = new Sample.Domain.Entidades.Customer()
                {
                    Id = new Guid(),
                    FirstName = "Felipe",
                    LastName = "Cembranelli",
                    FullName = "Felipe Cembranelli",
                    Telephone = "12329",
                    Company = "Resource",
                    Country = new Country("Brazil","ISO-0101"),
                    Address = new Address("Campinas","12233","Rua x","")
                    
                };

            var cust2 = new Sample.Domain.Entidades.Customer()
            {
                Id = new Guid(),
                FirstName = "Felipe2",
                LastName = "Cembranelli",
                FullName = "Felipe2 Cembranelli",
                Telephone = "12329",
                Company = "Resource",
                Country = new Country("Brazil", "ISO-0101"),
                Address = new Address("Campinas", "12233", "Rua x", "")
                
            };

            custList.Add(cust1);
            custList.Add(cust2);

            return custList;

        }
    }
}
