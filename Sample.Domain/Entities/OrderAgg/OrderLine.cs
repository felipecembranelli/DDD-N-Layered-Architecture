using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Domain.Entities;

namespace Sample.Domain.Entidades
{
    public class OrderLine : BaseEntity
    {

        #region Properties

       

        /// <summary>
        /// Get or set the current unit price of the product in this line
        /// <remarks>
        /// The unit price cannot be less than zero
        /// </remarks>
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Get or set the amount of units in this line
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Get or set the discount associated
        /// <remarks>
        /// Discount is a value between [0-1]
        /// </remarks>
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Get the total amount of money for this line
        /// </summary>
        public decimal TotalLine
        {
            get
            {
                return (UnitPrice * Amount) * (1 - (Discount / 100M));
            }
        }

        /// <summary>
        /// Related aggregate identifier
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Get or set the product identifier
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Get or set associated product 
        /// </summary>
        public Product Product { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets a product in this order line
        /// </summary>
        /// <param name="product">The related product for this order line</param>
        public void SetProduct(Product product)
        {
            
            //fix identifiers
            this.ProductId = product.Id;
            this.Product = product;
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
