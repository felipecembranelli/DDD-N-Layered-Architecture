using System;
using System.Collections.Generic;
using Sample.Application.DTO;

namespace Sample.Application.Contracts
{
    interface ISalesAppService
    {
        /// <summary>
        /// Find orders in specific page
        /// </summary>
        /// <param name="pageIndex">The page index</param>
        /// <param name="pageCount">The number of elements in each page</param>
        /// <returns>A collection of orders representation</returns>
        List<OrderListDTO> FindOrders(int pageIndex, int pageCount);

        /// <summary>
        /// Find order in date range
        /// </summary>
        /// <param name="dateFrom">The date from</param>
        /// <param name="dateTo">The date to</param>
        /// <returns>A collection of orders representation</returns>
        List<OrderListDTO> FindOrders(DateTime? dateFrom, DateTime? dateTo);

        /// <summary>
        /// Find orders by customer identifier
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        /// <returns>A collection of orders representation</returns>
        List<OrderListDTO> FindOrders(Guid customerId);

        /// <summary>
        /// Find products in specific page
        /// </summary>
        /// <param name="pageIndex">The page index</param>
        /// <param name="pageCount">The number of elements in each page</param>
        /// <returns></returns>
        List<ProductDTO> FindProducts(int pageIndex, int pageCount);

        /// <summary>
        /// Find products 
        /// </summary>
        /// <param name="text">The text to find in title or product description</param>
        /// <returns>The products with title or description that contains <paramref name="text"/></returns>
        List<ProductDTO> FindProducts(string text);

        /// <summary>
        /// Add new order
        /// </summary>
        /// <param name="order">The order representation to add</param>
        OrderDTO AddNewOrder(OrderDTO order);

     

   
    }
}
