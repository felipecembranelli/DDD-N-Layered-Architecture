using System;
using Sample.Application.Contracts;
using Sample.Application.DTO;
using Sample.Application.Util;
using Sample.Domain.ContractRepositories;
using Sample.Domain.Entidades;

namespace Sample.Application.Services
{
    class SalesAppService : ISalesAppService
    {
        #region Members

        readonly IOrderRepository _orderRepository;
        readonly IProductRepository _productRepository;
        readonly ICustomerRepository _customerRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of sales management service
        /// </summary>
        /// <param name="orderRepository">The associated order repository</param>
        /// <param name="productRepository">The associated product repository</param>
        /// <param name="customerRepository">The associated customer repository</param>
        public SalesAppService(IProductRepository productRepository,//associated product repository
                               IOrderRepository orderRepository,//associated order repository
                               ICustomerRepository customerRepository) //the associated customer repository
        {
            if (orderRepository == null)
                throw new ArgumentNullException("orderRepository");

            if (productRepository == null)
                throw new ArgumentNullException("productRepository");

            if (customerRepository == null)
                throw new ArgumentNullException("customerRepository");

            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;

        }
        #endregion

        #region Private Methods

        void SaveOrder(Order order)
        {
            if (order.IsValid())//if entity is valid save. 
            {
                //add order and commit changes
                _orderRepository.Add(order);
                //_orderRepository.UnitOfWork.Commit();
            }
            else // if not valid throw validation errors
                throw new ApplicationValidationErrorsException(order.GetInvalidMessages());
        }


        Order CreateNewOrder(OrderDTO dto, Customer associatedCustomer)
        {
            //Create a new order entity from factory
            Order newOrder = Order.CreateOrder(associatedCustomer,
                                                     dto.ShippingName,
                                                     dto.ShippingCity,
                                                     dto.ShippingAddress,
                                                     dto.ShippingZipCode);

            //if have lines..add
            if (dto.OrderLines != null)
            {
                foreach (var line in dto.OrderLines) //add order lines
                    newOrder.AddNewOrderLine(line.ProductId, line.Amount, line.UnitPrice, line.Discount / 100);
            }

            return newOrder;
        }


        void SaveProduct(Product product)
        {
            if (product.IsValid()) // if is valid
            {
                _productRepository.Add(product);
                //_productRepository.UnitOfWork.Commit();
            }
            else //if not valid, throw validation errors
                throw new ApplicationValidationErrorsException(product.GetInvalidMessages());
        }

        #endregion

        public System.Collections.Generic.List<DTO.OrderListDTO> FindOrders(int pageIndex, int pageCount)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<DTO.OrderListDTO> FindOrders(System.DateTime? dateFrom, System.DateTime? dateTo)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<DTO.OrderListDTO> FindOrders(System.Guid customerId)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<DTO.ProductDTO> FindProducts(int pageIndex, int pageCount)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<DTO.ProductDTO> FindProducts(string text)
        {
            throw new System.NotImplementedException();
        }

        public DTO.OrderDTO AddNewOrder(DTO.OrderDTO order)
        {
            throw new System.NotImplementedException();
        }
    }
}
