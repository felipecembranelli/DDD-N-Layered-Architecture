using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Domain.Entities
{
    public abstract class BaseEntity
    {
        #region Members

        int? _requestedHashCode;
        Guid _id;

        #endregion

        /// <summary>
        /// Get the persisten object identifier
        /// </summary>
        public virtual Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public abstract bool IsValid();

        public abstract IEnumerable<string> GetInvalidMessages();
    }
}
