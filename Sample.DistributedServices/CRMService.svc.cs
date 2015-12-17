using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Sample.Application;
using Sample.Application.Contracts;
using Sample.Application.DTO;


namespace Sample.DistributedServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CRMService : ICRMService
    {
        #region Members

        readonly  ICustomerAppService _customerAppService;

        #endregion

        #region Constructor

        public CRMService(ICustomerAppService customerAppService)
        {
            if (customerAppService == null)
                throw new ArgumentNullException("customerAppService");

            _customerAppService = customerAppService;
        }

        #endregion

        public Application.DTO.CustomerDTO AddNewCustomer(Application.DTO.CustomerDTO customer)
        {
            return _customerAppService.AddNewCustomer(customer);
        }
    }
}
