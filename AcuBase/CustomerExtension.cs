using System;
using PX.Data;
using PX.Objects.AR;

namespace AcuBase
{
    /// <summary>
    /// Extension to add custom fields to the Customer DAC.
    /// This extends the Customer class to add a "Specs" field as a string with database persistence.
    /// </summary>
    public class CustomerExtension : PXCacheExtension<Customer>
    {
        #region UsrSpecs
        public abstract class usrSpecs : PX.Data.BQL.BqlString.Field<usrSpecs> { }
        
        [PXDBString(255)]
        [PXUIField(DisplayName = "Specs")]
        public virtual string UsrSpecs { get; set; }
        #endregion
    }
}
