using System;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace AcuBase.Graphs
{
    public class RentalOrderEntry : PXGraph<RentalOrderEntry, AcuBase.RCRentalOrder>
    {
        public SelectFrom<AcuBase.RCRentalOrder>.View Document;
        public SelectFrom<AcuBase.RCRentalOrderLine>
            .Where<AcuBase.RCRentalOrderLine.orderNbr.IsEqual<AcuBase.RCRentalOrder.orderNbr.FromCurrent>>.View Details;

        #region Actions
        public PXAction<AcuBase.RCRentalOrder> PutOnHold;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Put On Hold", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        protected virtual void putOnHold()
        {
            var doc = Document.Current;
            if (doc == null) return;
            if (doc.Status != AcuBase.RentalOrderStatuses.Closed && doc.Status != AcuBase.RentalOrderStatuses.Canceled)
            {
                doc.Status = AcuBase.RentalOrderStatuses.Hold;
                Document.Update(doc);
                Actions.PressSave();
            }
        }

        public PXAction<AcuBase.RCRentalOrder> ReleaseFromHold;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Release From Hold", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        protected virtual void releaseFromHold()
        {
            var doc = Document.Current;
            if (doc == null) return;
            if (doc.Status == AcuBase.RentalOrderStatuses.Hold)
            {
                doc.Status = AcuBase.RentalOrderStatuses.Open;
                Document.Update(doc);
                Actions.PressSave();
            }
        }

        public PXAction<AcuBase.RCRentalOrder> CloseOrder;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Close", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        protected virtual void closeOrder()
        {
            var doc = Document.Current;
            if (doc == null) return;
            if (doc.Status == AcuBase.RentalOrderStatuses.Open)
            {
                doc.Status = AcuBase.RentalOrderStatuses.Closed;
                Document.Update(doc);
                Actions.PressSave();
            }
        }

        public PXAction<AcuBase.RCRentalOrder> CancelOrder;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Cancel", MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        protected virtual void cancelOrder()
        {
            var doc = Document.Current;
            if (doc == null) return;
            if (doc.Status != AcuBase.RentalOrderStatuses.Closed)
            {
                doc.Status = AcuBase.RentalOrderStatuses.Canceled;
                Document.Update(doc);
                Actions.PressSave();
            }
        }
        #endregion

        #region Event Handlers
        protected virtual void _(Events.RowSelected<AcuBase.RCRentalOrder> e)
        {
            var row = e.Row;
            if (row == null) return;
            PutOnHold.SetEnabled(row.Status != AcuBase.RentalOrderStatuses.Hold && row.Status != AcuBase.RentalOrderStatuses.Closed);
            ReleaseFromHold.SetEnabled(row.Status == AcuBase.RentalOrderStatuses.Hold);
            CloseOrder.SetEnabled(row.Status == AcuBase.RentalOrderStatuses.Open);
            CancelOrder.SetEnabled(row.Status != AcuBase.RentalOrderStatuses.Closed);
        }
        #endregion
    }
}

