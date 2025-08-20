using System;
using PX.Data;
using PX.Data.BQL;
using PX.Objects.IN;

namespace AcuBase
{
    [Serializable]
    [PXCacheName("Rental Order Line")]
    public partial class RCRentalOrderLine : IBqlTable
    {
        #region OrderNbr
        public abstract class orderNbr : BqlString.Field<orderNbr> { }
        [PXDBString(15, IsUnicode = true, IsKey = true)]
        [PXDBDefault(typeof(RCRentalOrder.orderNbr))]
        [PXParent(typeof(Select<RCRentalOrder, Where<RCRentalOrder.orderNbr, Equal<Current<RCRentalOrderLine.orderNbr>>>>))]
        [PXUIField(DisplayName = "Order Nbr", Enabled = false)]
        public virtual string OrderNbr { get; set; }
        #endregion

        #region LineNbr
        public abstract class lineNbr : BqlInt.Field<lineNbr> { }
        [PXDBInt(IsKey = true)]
        [PXLineNbr(typeof(RCRentalOrder.lineCntr))]
        [PXUIField(DisplayName = "Line Nbr", Enabled = false)]
        public virtual int? LineNbr { get; set; }
        #endregion

        #region InventoryID
        public abstract class inventoryID : BqlInt.Field<inventoryID> { }
        [PXDBInt]
        [PXUIField(DisplayName = "Inventory ID")]
        [PXSelector(typeof(Search<InventoryItem.inventoryID>),
            SubstituteKey = typeof(InventoryItem.inventoryCD),
            DescriptionField = typeof(InventoryItem.descr))]
        public virtual int? InventoryID { get; set; }
        #endregion

        #region TranDesc
        public abstract class tranDesc : BqlString.Field<tranDesc> { }
        [PXDBString(255, IsUnicode = true)]
        [PXUIField(DisplayName = "Description")]
        public virtual string TranDesc { get; set; }
        #endregion

        #region Qty
        public abstract class qty : BqlDecimal.Field<qty> { }
        [PXDBDecimal(6)]
        [PXDefault(TypeCode.Decimal, "1.0")]
        [PXUIField(DisplayName = "Qty")]
        public virtual decimal? Qty { get; set; }
        #endregion

        #region UnitPrice
        public abstract class unitPrice : BqlDecimal.Field<unitPrice> { }
        [PXDBDecimal(6)]
        [PXUIField(DisplayName = "Unit Price")]
        public virtual decimal? UnitPrice { get; set; }
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

        #region NoteID
        public abstract class noteID : BqlGuid.Field<noteID> { }
        [PXNote]
        public virtual Guid? NoteID { get; set; }
        #endregion

        #region tstamp
        public abstract class Tstamp : BqlByteArray.Field<Tstamp> { }
        [PXDBTimestamp]
        public virtual byte[] tstamp { get; set; }
        #endregion
    }
}

