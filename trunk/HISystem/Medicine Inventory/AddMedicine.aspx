<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="AddMedicine.aspx.cs" Inherits="Medicine_Inventory_AddMedicine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" 
            style="top: 172px; left: 271px; position: absolute; height: 19px; width: 107px" 
            Text="Medicine Name"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" 
            style="top: 228px; left: 272px; position: absolute; height: 19px; width: 34px" 
            Text="Category"></asp:Label>
        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="Category" 
            DataTextField="CategoryName" DataValueField="CategoryName" 
            style="top: 225px; left: 455px; position: absolute; height: 22px; width: 126px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Category" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [CategoryName] FROM [Category] ORDER BY [CategoryName]">
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:TextBox ID="txtMedicineName" runat="server" 
            style="top: 172px; left: 453px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" 
            style="top: 285px; left: 275px; position: absolute; height: 19px; width: 34px" 
            Text="Quantity"></asp:Label>
    </p>
    <p>
    </p>
    <p>


    <!-- Validations for numbers only-->
        <asp:TextBox ID="txtQuantity" runat="server"  onpaste = "return false;" onkeyup ="keyUP(event.keyCode)" onkeydown = "return isNumeric(event.keyCode);" 
        style="top: 283px; left: 455px; position: absolute; height: 22px; width: 128px" ></asp:TextBox>
        <asp:Button ID="btnClear" runat="server" 
            style="top: 354px; left: 473px; position: absolute; height: 26px; width: 97px" 
            Text="Clear" />
    </p>
    <p>
        <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" 
            style="top: 355px; left: 293px; position: absolute; height: 26px; width: 105px" 
            Text="Add" />
    </p>
    <p>
    </p>
    <p>
    </p>

</asp:Content>

