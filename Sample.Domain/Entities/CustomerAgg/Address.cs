using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Domain.Entities;

namespace Sample.Domain.Entidades
{
    public class Address : BaseEntity
    {
        /// For this Domain-Model, the Address is a Value-Object
        /// 'sets' are private as Value-Objects must be immutable, 
        /// so the only way to set properties is using the constructor 

        #region Properties

        /// <summary>
        /// Get or set the city of this address 
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Get or set the zip code
        /// </summary>
        public string ZipCode { get; private set; }

        /// <summary>
        /// Get or set address line 1
        /// </summary>
        public string AddressLine1 { get; private set; }

        /// <summary>
        /// Get or set address line 2
        /// </summary>
        public string AddressLine2 { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of address specifying its values
        /// </summary>
        /// <param name="city"></param>
        /// <param name="zipCode"></param>
        /// <param name="addressLine1"></param>
        /// <param name="addressLine2"></param>
        public Address(string city, string zipCode, string addressLine1, string addressLine2)
        {
            this.City = city;
            this.ZipCode = zipCode;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
        }

        private Address() { }  //required for EF

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
