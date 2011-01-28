<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="AddMedicine.aspx.cs" Inherits="Medicine_Inventory_AddMedicine" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <h2 style="background-color: #d3e7c5">
        Add Medicine Page
    </h2>
   <br />
    
        <table style="width: 437px">
            <tr>
                <td>
        <asp:Label ID="Label3" runat="server" 
            
            Text="Medicine Name" AssociatedControlID="txtMedicineName"></asp:Label>
                </td>
                <td colspan="2">
        <asp:TextBox ID="txtMedicineName" runat="server" 
            
           ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label4" runat="server" 
            
            Text="Category" AssociatedControlID="ddlCategory"></asp:Label>
                </td>
                <td colspan="2">
        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="Category" 
            DataTextField="CategoryName" DataValueField="CategoryName" 
            
            
           >
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label5" runat="server" 
           
            Text="Quantity" AssociatedControlID="txtQuantity"></asp:Label>
                </td>
                <td colspan="2">
        <asp:TextBox ID="txtQuantity" runat="server"  onpaste = "return false;" 
            onkeyup ="keyUP(event.keyCode)" onkeydown = "return isNumeric(event.keyCode);" 
        
            ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:SqlDataSource ID="Category" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [CategoryName] FROM [Category] ORDER BY [CategoryName]">
        </asp:SqlDataSource>
                </td>
                <td>
        <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" 
           
            Text="Add" Width="93px" />
                </td>
                <td>
        <asp:Button ID="btnClear" runat="server" 
           
            Text="Clear" onclick="btnClear_Click" Width="104px" />
                </td>
            </tr>
        </table>
    
   


   

</asp:Content>

