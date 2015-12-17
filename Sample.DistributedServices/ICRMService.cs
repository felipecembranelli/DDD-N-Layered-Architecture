using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Sample.Application;
using Sample.Application.DTO;

namespace Sample.DistributedServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICRMService
    {

        [OperationContract()]
        [FaultContract(typeof(ApplicationServiceError))]
        CustomerDTO AddNewCustomer(CustomerDTO customer);
    }
    
}
