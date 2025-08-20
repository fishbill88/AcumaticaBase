<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormView.master" AutoEventWireup="true" ValidateRequest="false" Inherits="PX.Web.UI.PXPage" %>
<%@ MasterType VirtualPath="~/MasterPages/FormView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="server">
	<px:PXDataSource ID="ds" runat="server" TypeName="AcuBase.Graphs.RentalOrderEntry" PrimaryView="Document">
		<CallbackCommands>
			<px:PXDSCallbackCommand Name="Save" PostData="Self" />
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>

<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Document" Width="100%" Caption="Rental Order">
		<Template>
			<px:PXLayoutRule runat="server" StartColumn="True" LabelsWidth="SM" ControlSize="M" />
			<px:PXSelector ID="edOrderNbr" runat="server" DataField="OrderNbr" />
			<px:PXSelector ID="edCustomerID" runat="server" DataField="CustomerID" />
			<px:PXDateTimeEdit ID="edOrderDate" runat="server" DataField="OrderDate" />
			<px:PXDateTimeEdit ID="edDueDate" runat="server" DataField="DueDate" />
			<px:PXDropDown ID="edStatus" runat="server" DataField="Status" Enabled="False" />
		</Template>
		<CallbackCommands>
			<px:PXDSCallbackCommand Name="PutOnHold" Visible="True" />
			<px:PXDSCallbackCommand Name="ReleaseFromHold" Visible="True" />
			<px:PXDSCallbackCommand Name="CloseOrder" Visible="True" />
			<px:PXDSCallbackCommand Name="CancelOrder" Visible="True" />
		</CallbackCommands>
	</px:PXFormView>
</asp:Content>

<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Width="100%" SkinID="Details" Height="300px" AllowPaging="True">
		<Levels>
			<px:PXGridLevel DataMember="Details">
				<Columns>
					<px:PXGridColumn DataField="OrderNbr" Visible="False" />
					<px:PXGridColumn DataField="LineNbr" Width="80px" />
					<px:PXGridColumn DataField="InventoryID" Width="140px" />
					<px:PXGridColumn DataField="TranDesc" Width="260px" />
					<px:PXGridColumn DataField="Qty" Width="100px" TextAlign="Right" />
					<px:PXGridColumn DataField="UnitPrice" Width="120px" TextAlign="Right" />
				</Columns>
			</px:PXGridLevel>
		</Levels>
		<ActionBar>
			<CustomItems>
				<px:PXToolBarButton CommandName="PutOnHold" Text="Put On Hold" />
				<px:PXToolBarButton CommandName="ReleaseFromHold" Text="Release From Hold" />
				<px:PXToolBarButton CommandName="CloseOrder" Text="Close" />
				<px:PXToolBarButton CommandName="CancelOrder" Text="Cancel" />
			</CustomItems>
		</ActionBar>
	</px:PXGrid>
</asp:Content>

