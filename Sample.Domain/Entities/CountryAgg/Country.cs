using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Domain.Entities;

namespace Sample.Domain.Entidades
{
    public class Country : BaseEntity
    {
       
        #region Properties

        /// <summary>
        /// Get or set the Country Name
        /// </summary>
        public string CountryName { get; private set; }

        /// <summary>
        /// Get or set the Country ISO Code
        /// </summary>
        public string CountryISOCode { get; private set; }

        #endregion

        #region Constructor

        //required by EF
        private Country() { }

        public Country(string countryName, string countryISOCode)
        {
            if (String.IsNullOrWhiteSpace(countryName))
                throw new ArgumentNullException("countryName");

            if (String.IsNullOrWhiteSpace(countryISOCode))
                throw new ArgumentNullException("countryISOCode");

            this.CountryName = countryName;
            this.CountryISOCode = countryISOCode;
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
