using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.DistributedServices
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Default ServiceError
    /// </summary>
    [DataContract(Name = "ServiceError", Namespace = "Microsoft.Samples.DistributedServices.Core")]
    public class ApplicationServiceError
    {
        /// <summary>
        /// Error message that flow to client services
        /// </summary>
        [DataMember(Name = "ErrorMessage")]
        public string ErrorMessage { get; set; }
    }
}
