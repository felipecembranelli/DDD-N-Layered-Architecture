using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Application.DTO;
using Sample.Domain.Entidades;

namespace Sample.Web.Models
{
    public class CustomerListVM
    {

        public IEnumerable<CustomerDTO> Customers { get; set; }

        public static CustomerListVM FillViewModel(IEnumerable<CustomerDTO> customers)
        {
            return new CustomerListVM() { Customers = customers };
        
        }

    }
}