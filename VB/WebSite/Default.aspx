<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to register a custom filter function and use it in ASPxGridView</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			Type "1-5" in the Numbers column to see how a custom function operates. ASPxGridView
			will display rows which contain numbers from "1" to "5".
			<dx:ASPxGridView ID="Grid" ClientInstanceName="gv" runat="server" AutoGenerateColumns="False"
				DataSourceID="AccessDataSource1" KeyFieldName="CategoryID"
				OnProcessColumnAutoFilter="Grid_ProcessColumnAutoFilter"
				OnAutoFilterCellEditorInitialize="Grid_AutoFilterCellEditorInitialize">
				<Columns>
					<dx:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="0">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="1">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn FieldName="Numbers" VisibleIndex="2">
					</dx:GridViewDataTextColumn>
				</Columns>
				<Settings ShowFilterRow="true" />
			</dx:ASPxGridView>
			<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/data.mdb"
				SelectCommand="SELECT [CategoryID], [CategoryName], [Numbers] FROM [Categories]">
			</asp:AccessDataSource>
		</div>
	</form>
</body>
</html>