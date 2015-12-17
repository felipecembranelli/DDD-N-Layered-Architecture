using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Domain.Entities;

namespace Sample.Domain.Entidades
{
    public class Product : BaseEntity
    {
        

        #region Properties

        /// <summary>
        /// Get or set the long description for this product
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// Get or set the product title
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// Get or set the unit price for this product
        /// </summary>
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// Get or set the stock items of this product
        /// </summary>
        public int AmountInStock { get; private set; }


        #endregion

        #region Public Methods

        /// <summary>
        /// Change the unit price
        /// </summary>
        /// <param name="unitPrice">The new unit price</param>
        public void ChangeUnitPrice(decimal unitPrice)
        {
            this.UnitPrice = unitPrice;
        }

        /// <summary>
        /// Increment the stock of this product
        /// </summary>
        /// <param name="units">The added items to stock</param>
        public void IncrementStock(int units = 0)
        {
            this.AmountInStock += units;
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
