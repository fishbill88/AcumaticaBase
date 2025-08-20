using System;
using PX.Data;
using PX.Data.BQL;
using PX.Objects.AR;

namespace AcuBase
{
    [Serializable]
    [PXCacheName("Rental Order")]
    [PXPrimaryGraph(typeof(Graphs.RentalOrderEntry))]
    public partial class RCRentalOrder : IBqlTable
    {
        #region OrderNbr
        public abstract class orderNbr : BqlString.Field<orderNbr> { }
        [PXDBString(15, IsUnicode = true, IsKey = true, InputMask = ">CCCCCCCCCCCCCCC")]
        [PXUIField(DisplayName = "Order Nbr")]
        public virtual string OrderNbr { get; set; }
        #endregion

        #region CustomerID
        public abstract class customerID : BqlInt.Field<customerID> { }
        [PXDBInt]
        [PXUIField(DisplayName = "Customer")]
        [PXSelector(typeof(Search<Customer.bAccountID>),
            SubstituteKey = typeof(Customer.acctCD),
            DescriptionField = typeof(Customer.acctName))]
        public virtual int? CustomerID { get; set; }
        #endregion

        #region OrderDate
        public abstract class orderDate : BqlDateTime.Field<orderDate> { }
        [PXDBDate]
        [PXDefault(typeof(AccessInfo.businessDate))]
        [PXUIField(DisplayName = "Order Date")]
        public virtual DateTime? OrderDate { get; set; }
        #endregion

        #region DueDate
        public abstract class dueDate : BqlDateTime.Field<dueDate> { }
        [PXDBDate]
        [PXUIField(DisplayName = "Due Date")]
        public virtual DateTime? DueDate { get; set; }
        #endregion

        #region Status
        public abstract class status : BqlString.Field<status> { }
        [PXDBString(1, IsFixed = true)]
        [PXUIField(DisplayName = "Status", Enabled = false)]
        [PXDefault(RentalOrderStatuses.Hold)]
        [PXStringList(new[] { RentalOrderStatuses.Hold, RentalOrderStatuses.Open, RentalOrderStatuses.Closed, RentalOrderStatuses.Canceled },
                      new[] { "On Hold", "Open", "Closed", "Canceled" })]
        public virtual string Status { get; set; }
        #endregion

        #region LineCntr
        public abstract class lineCntr : BqlInt.Field<lineCntr> { }
        [PXDBInt]
        [PXDefault(0)]
        [PXUIField(DisplayName = "Line Cntr", Enabled = false)]
        public virtual int? LineCntr { get; set; }
        #endregion

        #region NoteID
        public abstract class noteID : BqlGuid.Field<noteID> { }
        [PXNote]
        public virtual Guid? NoteID { get; set; }
        #endregion


        #region System Columns
        public abstract class createdByID : BqlGuid.Field<createdByID> { }
        [PXDBCreatedByID]
        public virtual Guid? CreatedByID { get; set; }

        public abstract class createdByScreenID : BqlString.Field<createdByScreenID> { }
        [PXDBCreatedByScreenID]
        public virtual string CreatedByScreenID { get; set; }

        public abstract class createdDateTime : BqlDateTime.Field<createdDateTime> { }
        [PXDBCreatedDateTime]
        public virtual DateTime? CreatedDateTime { get; set; }

        public abstract class lastModifiedByID : BqlGuid.Field<lastModifiedByID> { }
        [PXDBLastModifiedByID]
        public virtual Guid? LastModifiedByID { get; set; }

        public abstract class lastModifiedByScreenID : BqlString.Field<lastModifiedByScreenID> { }
        [PXDBLastModifiedByScreenID]
        public virtual string LastModifiedByScreenID { get; set; }

        public abstract class lastModifiedDateTime : BqlDateTime.Field<lastModifiedDateTime> { }
        [PXDBLastModifiedDateTime]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        #endregion

        #region tstamp
        public abstract class Tstamp : BqlByteArray.Field<Tstamp> { }
        [PXDBTimestamp]
        public virtual byte[] tstamp { get; set; }
        #endregion
    }

    public static class RentalOrderStatuses
    {
        public const string Hold = "H";
        public const string Open = "N";
        public const string Closed = "C";
        public const string Canceled = "X";
    }
}

