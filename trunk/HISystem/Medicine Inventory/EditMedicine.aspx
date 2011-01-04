<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="EditMedicine.aspx.cs" Inherits="Medicine_Inventory_EditMedicine" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" 
            style="top: 177px; left: 435px; position: absolute; height: 19px; width: 78px" 
            Text="Medicine ID "></asp:Label>
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" 
            style="top: 301px; left: 439px; position: absolute; height: 19px; width: 34px" 
            Text="Quantity"></asp:Label>
        <asp:TextBox ID="txtMedicineId" runat="server" 
            
            
            style="top: 177px; left: 528px; position: absolute; height: 22px; width: 128px"
            
            onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)" 
                        onpaste="return false;"
            ></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" 
            style="top: 237px; left: 411px; position: absolute; height: 19px; width: 112px" 
            Text="Medicine Name"></asp:Label>
        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="Category" 
            DataTextField="CategoryName" DataValueField="CategoryName" 
            
            
            
            
            style="top: 269px; left: 527px; position: absolute; height: -4px; width: 126px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server" 
            style="top: 266px; left: 438px; position: absolute; height: 19px; width: 58px" 
            Text="Category"></asp:Label>
        <asp:TextBox ID="txtMedicineName" runat="server" 
            
            
            style="top: 239px; left: 526px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
        <%--number validations--%>
        <asp:TextBox ID="txtQuantity" runat="server" style="top: 303px; left: 524px; position: absolute; height: 22px; width: 128px" 
            
            
            
            onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)" 
                        onpaste="return false;"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnSave" runat="server" 
            style="top: 335px; left: 524px; position: absolute; height: 26px; width: 85px" 
            Text="Save" onclick="btnSave_Click" />
        <asp:Button ID="btnClear" runat="server" 
            style="top: 335px; left: 628px; position: absolute; height: 26px; width: 73px" 
            Text="Clear" />
        <asp:SqlDataSource ID="Category" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [CategoryName] FROM [Category] ORDER BY [CategoryName]">
        </asp:SqlDataSource>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        <asp:Button ID="btnSearch" runat="server" 
            style="top: 176px; left: 667px; position: absolute; height: 26px; width: 89px" 
            Text="Search" onclick="btnSearch_Click" />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

