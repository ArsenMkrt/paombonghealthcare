<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="EditMedicine.aspx.cs" Inherits="Medicine_Inventory_EditMedicine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" 
            style="top: 74px; left: 71px; position: absolute; height: 19px; width: 78px" 
            Text="Medicine ID "></asp:Label>
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" 
            style="top: 277px; left: 223px; position: absolute; height: 19px; width: 34px" 
            Text="Quantity"></asp:Label>
        <asp:TextBox ID="txtMedicineId" runat="server" 
            style="top: 76px; left: 185px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" 
            style="top: 170px; left: 221px; position: absolute; height: 19px; width: 112px" 
            Text="Medicine Name"></asp:Label>
        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="Category" 
            DataTextField="CategoryName" DataValueField="CategoryName" 
            
            style="top: 221px; left: 372px; position: absolute; height: 16px; width: 126px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Category" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [CategoryName] FROM [Category] ORDER BY [CategoryName]">
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server" 
            style="top: 222px; left: 224px; position: absolute; height: 19px; width: 34px" 
            Text="Category"></asp:Label>
        <asp:TextBox ID="txtMedicineName" runat="server" 
            style="top: 170px; left: 370px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
        <asp:TextBox ID="txtQuantity" runat="server" 
            style="top: 279px; left: 371px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSave" runat="server" 
            style="top: 335px; left: 235px; position: absolute; height: 26px; width: 85px" 
            Text="Save" />
        <asp:Button ID="btnClear" runat="server" 
            style="top: 335px; left: 396px; position: absolute; height: 26px; width: 73px" 
            Text="Clear" />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        <asp:Button ID="btnSearch" runat="server" 
            style="top: 75px; left: 352px; position: absolute; height: 26px; width: 72px" 
            Text="Search" onclick="btnSearch_Click" />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

