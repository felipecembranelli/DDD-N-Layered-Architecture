using System;
using System.Collections.Generic;
using System.Linq;
using Sample.Application.Contracts;
using Sample.Application.DTO;
using Sample.Application.Resources;
using Sample.Application.Util;
using Sample.Domain.ContractRepositories;
using Sample.Domain.Entidades;
using Sample.Infra.Data.Repository;

namespace Sample.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        #region Members
        readonly ICountryRepository _countryRepository;
        readonly ICustomerRepository _customerRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of Customer Management Service
        /// </summary>
        /// <param name="customerRepository">Associated CustomerRepository, intented to be resolved with DI</param>
        public CustomerAppService(ICustomerRepository customerRepository, ICountryRepository countryRepository) //the customer repository                               
        {
            if (customerRepository == null)
                throw new ArgumentNullException("customerRepository");

            if (countryRepository == null)
                throw new ArgumentNullException("countryRepositorio");

            _customerRepository = customerRepository;
            _countryRepository = countryRepository;
        }

        public CustomerAppService()
        {
            _customerRepository = new CustomerRepositorio();
            _countryRepository = new CountryRepository();
        }

        #endregion

        #region ICustomerAppService Members

        public CustomerDTO AddNewCustomer(CustomerDTO customerDTO)
        {
            //check preconditions
            if (customerDTO == null || customerDTO.CountryId == Guid.Empty)
                throw new ArgumentException(Messages.warning_CannotAddCustomerWithEmptyInformation);

            var country = _countryRepository.Get(customerDTO.CountryId);

            if (country != null)
            {
                //Create the entity and the required associated data
                var address = new Address(customerDTO.AddressCity, customerDTO.AddressZipCode, customerDTO.AddressAddressLine1, customerDTO.AddressAddressLine2);

                //TODO: usar factory
                var customer = Customer.CreateCustomer(customerDTO.FirstName,
                                                       customerDTO.LastName,
                                                       customerDTO.Telephone,
                                                       customerDTO.Company,
                                                       country,
                                                       address);
            
                //save entity
                SaveCustomer(customer);

                //return the data with id and assigned default values
                //return customer.ProjectedAs<CustomerDTO>();

                // TODO: fazer codigo de mapeamento ou usar mapper
                return customerDTO;

            }
            else
                return null;
        }

        public void UpdateCustomer(CustomerDTO customerDTO)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        //public List<CustomerListDTO> FindCustomers(int pageIndex, int pageCount)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<CustomerListDTO> FindCustomers(string text)
        //{
        //    throw new NotImplementedException();
        //}

        public CustomerDTO FindCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        //public List<CountryDTO> FindCountries(int pageIndex, int pageCount)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<CountryDTO> FindCountries(string text)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<CustomerDTO> FindAllCustomers()
        {
            var customerList = _customerRepository.GetAll();

            return customerList.Select(c => new CustomerDTO
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Telephone = c.Telephone,
                    AddressAddressLine1 = c.Address.AddressLine1,
                    AddressAddressLine2 = c.Address.AddressLine2,
                    AddressCity = c.Address.City,
                    CountryCountryName = c.Country.CountryName,
                    CountryId = c.Country.Id
                });
        }

        #endregion

        #region Private Methods

        void SaveCustomer(Customer customer)
        {
            ////recover validator
            //var validator = EntityValidatorFactory.CreateValidator();

            if (customer.IsValid()) //if customer is valid
            {
                //add the customer into the repository
                _customerRepository.Add(customer);

                //commit the unit of work
                //_customerRepository.UnitOfWork.Commit();
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(customer.GetInvalidMessages());
        }


        #endregion


    }
}
