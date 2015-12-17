using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.DTO
{
    public class ProductDTO
    {
        /// <summary>
        /// Get or set the identifier
        /// </summary>
        public Guid Id { get; set; }

        /// Get or set the long description for this product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Get or set the product title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get or set the unit price for this product
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Get or set the stock items of this product
        /// </summary>
        public int AmountInStock { get; set; }
    }
}
