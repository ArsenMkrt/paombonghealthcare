<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="AddMedicine.aspx.cs" Inherits="Medicine_Inventory_AddMedicine" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
    </p>
        <asp:SqlDataSource ID="Category" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [CategoryName] FROM [Category] ORDER BY [CategoryName]">
        </asp:SqlDataSource>
    <p>
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" 
            style="top: 177px; left: 352px; position: absolute; height: 19px; width: 107px" 
            Text="Medicine Name"></asp:Label>
        <asp:Label ID="Label5" runat="server" 
            style="top: 267px; left: 352px; position: absolute; height: 23px; width: 65px" 
            Text="Quantity"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" 
            style="top: 226px; left: 352px; position: absolute; height: 19px; width: 34px" 
            Text="Category"></asp:Label>
        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="Category" 
            DataTextField="CategoryName" DataValueField="CategoryName" 
            
            style="top: 224px; left: 571px; position: absolute; height: 22px; width: 126px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:TextBox ID="txtMedicineName" runat="server" 
            
            style="top: 174px; left: 572px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
    </p>
    <p>
    </p>
    <p>


    <!-- Validations for numbers only-->
        <asp:TextBox ID="txtQuantity" runat="server"  onpaste = "return false;" 
            onkeyup ="keyUP(event.keyCode)" onkeydown = "return isNumeric(event.keyCode);" 
        
            style="top: 272px; left: 571px; position: absolute; height: 22px; width: 128px" ></asp:TextBox>
        <asp:Button ID="btnClear" runat="server" 
            style="top: 316px; left: 577px; position: absolute; height: 26px; width: 97px" 
            Text="Clear" />
    </p>
    <p>
        <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" 
            style="top: 317px; left: 427px; position: absolute; height: 26px; width: 105px" 
            Text="Add" />
    </p>
    <p>
    </p>
    <p>
    </p>

</asp:Content>

