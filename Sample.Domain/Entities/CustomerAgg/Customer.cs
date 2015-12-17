using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Domain.Entidades;
using Sample.Domain.Entities;
using Sample.Domain.Resources;

namespace Sample.Domain.Entidades 
{
    public class Customer : BaseEntity
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
            get
            {
                return string.Format("{0}, {1}", this.LastName, this.FirstName);
            }
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

        #region Public Methods

        ///// <summary>
        ///// Disable customer
        ///// </summary>
        //public void Disable()
        //{
        //    if (IsEnabled)
        //        this._IsEnabled = false;
        //}

        ///// <summary>
        ///// Enable customer
        ///// </summary>
        //public void Enable()
        //{
        //    if (!IsEnabled)
        //        this._IsEnabled = true;
        //}

        /// <summary>
        /// Associate existing country to this customer
        /// </summary>
        /// <param name="country"></param>
        public void SetTheCountryForThisCustomer(Country country)
        {
            if (country == null)
            {
                throw new ArgumentException(Messages.exception_CannotAssociateTransientOrNullCountry);
            }

            //fix relation
            this.CountryId = country.Id;

            this.Country = country;
        }

        /// <summary>
        /// Set the country reference for this customer
        /// </summary>
        /// <param name="countryId"></param>
        public void SetTheCountryReference(Guid countryId)
        {
            if (countryId != Guid.Empty)
            {
                //fix relation
                this.CountryId = countryId;

                this.Country = null;
            }
        }

        ///// <summary>
        ///// Change the customer credit limit
        ///// </summary>
        ///// <param name="newCredit">the new credit limit</param>
        //public void ChangeTheCurrentCredit(decimal newCredit)
        //{
        //    if (IsEnabled)
        //        this.CreditLimit = newCredit;
        //}

    
        public static Customer CreateCustomer(string firstName, 
                                                string lastName, 
                                                string telephone,
                                                string company,
                                                Country country, 
                                                Address address)
        {
            //create new instance and set identity
            var customer = new Customer();

            //set data

            customer.FirstName = firstName;
            customer.LastName = lastName;

            customer.Company = company;
            customer.Telephone = telephone;

            //set address
            customer.Address = address;

            //TODO: By default this is the limit for customer credit, you can set this 
            //parameter customizable via configuration or other system
            customer.CreditLimit = 10000;

            //set the country for this customer
            customer.SetTheCountryForThisCustomer(country);

            return customer;
        }


        #endregion

        #region Base entities members

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> GetInvalidMessages()
        {
            throw new NotImplementedException();
        }

        #endregion

       
    }
}
