<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <dx:ASPxGridView ID="gvCategories" runat="server" AutoGenerateColumns="False" DataSourceID="dsCategories"
            KeyFieldName="CategoryID" OnCustomColumnDisplayText="gvOrders_CustomColumnDisplayText" OnCustomUnboundColumnData="gvOrders_CustomUnboundColumnData" OnHeaderFilterFillItems="gvOrders_HeaderFilterFillItems">
            <Columns>
                <dx:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="0">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CustomDescription" VisibleIndex="2" UnboundType="String" Caption="Tags">
                    <Settings AllowHeaderFilter="True" HeaderFilterMode="CheckedList" />
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsPopup>
                <HeaderFilter Height="300px" />
            </SettingsPopup>
        </dx:ASPxGridView>
        <asp:AccessDataSource ID="dsCategories" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]">
        </asp:AccessDataSource>
    
    </div>
    </form>
</body>
</html>
