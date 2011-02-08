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
            
            Text="Medicine Name" AssociatedControlID="txtMedicineName" Font-Size="Small"></asp:Label>
                </td>
                <td colspan="2">
        <asp:TextBox ID="txtMedicineName" runat="server" Height="23px" Width="140px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label4" runat="server" 
            Text="Category" AssociatedControlID="ddlCategory" Font-Size="Small"></asp:Label>
                </td>
                <td colspan="2">
        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="Category" 
            DataTextField="CategoryName" DataValueField="CategoryName" Height="23px" Width="140px">
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Label ID="Label5" runat="server" 
           
            Text="Quantity" AssociatedControlID="txtQuantity" Font-Size="Small"></asp:Label>
                </td>
                <td colspan="2">
        <asp:TextBox ID="txtQuantity" runat="server"  onpaste = "return false;" 
            onkeyup ="keyUP(event.keyCode)" onkeydown = "return isNumeric(event.keyCode);" 
                        Height="23px" Width="140px" 
        
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
                <td><center>
        <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" Width="93px" /></center>
                </td>
                <td><center>
        <asp:Button ID="btnClear" runat="server" Text="Clear" onclick="btnClear_Click" Width="104px" /></center>
                </td>
            </tr>
        </table>
    
   


   

</asp:Content>

