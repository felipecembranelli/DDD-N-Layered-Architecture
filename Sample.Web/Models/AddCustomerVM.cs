using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Application.DTO;
using Sample.Domain.Entidades;

namespace Sample.Web.Models
{
    public class AddCustomerVM
    {
        #region Properties


        /// <summary>
        /// Get or set the Given name of this customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Get or set the surname of this customer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Get or set the full name of this customer
        /// </summary>
        public string FullName
        {
            get { return string.Format("{0}, {1}", this.LastName, this.FirstName); }
            set { }

        }

        /// <summary>
        /// Get or set the telephone 
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Get or set the company name
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Get or set the address of this customer
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Get or set the current credit limit for this customer
        /// </summary>
        public decimal CreditLimit { get; private set; }

        ///// <summary>
        ///// Get or set if this customer is enabled
        ///// </summary>
        //public bool IsEnabled
        //{
        //    get
        //    {
        //        return _IsEnabled;
        //    }
        //    private set
        //    {
        //        _IsEnabled = value;
        //    }
        //}

        /// <summary>
        /// Get or set associated country identifier
        /// </summary>
        public Guid CountryId { get; private set; }

        /// <summary>
        /// Get the current country for this customer
        /// </summary>
        public virtual Country Country { get; set; }



        #endregion

        #region methods

        public static IEnumerable<AddCustomerVM> FillViewModel(IEnumerable<CustomerDTO> customers)
        {
            return customers.Select(c => new AddCustomerVM
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = new Address(c.AddressAddressLine1, c.AddressAddressLine2, c.AddressCity, c.AddressZipCode),
                    Company = c.Company
                });
        }

        public bool IsValid()
        {
            return true;
        }

        public CustomerDTO FillDTO(AddCustomerVM customer)
        {
            return new CustomerDTO
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    AddressAddressLine1 = customer.Address.AddressLine1,
                    AddressAddressLine2 = customer.Address.AddressLine2,
                    AddressCity = customer.Address.City,
                    AddressZipCode = customer.Address.ZipCode,
                    Company = customer.Company,
                    CountryCountryName = customer.Country.CountryName,
                    CountryId = customer.Country.Id
                };
        }


        #endregion

    }
}