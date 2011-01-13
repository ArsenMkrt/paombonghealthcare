<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Medicine_Inventory_Inventory" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   
   
       <div id="originalContent"> 
    <table style="width: 43%;" border="1" align="center">
        <tr>
            <td colspan="3">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" 
                        Text="CheckOut Medicine/Update Inventory"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 280px">
                    Category</td>
            <td colspan="2">
                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" 
            DataSourceID="Category" DataTextField="CategoryName" 
            DataValueField="CategoryName" 
            onselectedindexchanged="ddlCategory_SelectedIndexChanged" Height="16px" Width="174px">
        </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 280px">
                    Name</td>
            <td colspan="2">
                <asp:TextBox 
            ID="txtNameSearch" runat="server" AutoPostBack="True" 
            ontextchanged="txtNameSearch_TextChanged" Width="231px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 280px">
        Items</td>
            <td colspan="2">
                <asp:GridView ID="gridviewMedicine" runat="server" AutoGenerateColumns="False" DataKeyNames="MedicineId"
            Height="193px" onselectedindexchanged="gridviewMedicine_SelectedIndexChanged" 
            Width="229px" AutoGenerateSelectButton="True" HorizontalAlign="Center" 
                    BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
                    CellPadding="4" GridLines="Horizontal">
                    <Columns>
                        <asp:BoundField DataField="MedicineId" HeaderText="MedicineId" 
                    InsertVisible="False" ReadOnly="True" SortExpression="MedicineId" />
                        <asp:BoundField DataField="MedicineName" HeaderText="MedicineName" 
                    SortExpression="MedicineName" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                    SortExpression="Quantity" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 280px">
                &nbsp;</td>
            <td style="width: 246px">
                  <a href="#modalwindow" name="modal" style="color: #990033">add checkout item</a><br/>
             </td>
            <td>
           
        <a href="#modalwindow2" name="modal" style="color: #990033">view checkout items</a></td>
        </tr>
    </table>
      
        &nbsp;<br />
        <br />

        <table style="width: 37%;" border="1" align="center">
            <tr>
                <td class="style2" colspan="2">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" 
                        Text="Monitor Inventory Items Quantity"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" style="width: 54px">
        <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label>
                </td>
                <td class="style1">
        <asp:DropDownList ID="ddlCategoryForItemShow" runat="server" 
            AutoPostBack="True" DataSourceID="Category2" 
            onselectedindexchanged="ddlCategoryForItemShow_SelectedIndexChanged" 
            
           
            DataTextField="CategoryName" DataValueField="CategoryName">
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2" style="width: 54px">
        <asp:Label ID="Label4" runat="server" Text="Show Items Below Quantity"></asp:Label>
                </td>
                <td class="style1">

        <asp:TextBox ID="txtQuantityLimit" runat="server" 
            onpaste = "return false;" onkeyup ="keyUP(event.keyCode)" 
                        onkeydown = "return isNumeric(event.keyCode);" 
       >20</asp:TextBox>
                    <asp:Button ID="btn_belowQty" runat="server" Height="23px" 
                        onclick="btn_belowQty_Click" Text="Enter" />
                </td>
            </tr>
            <tr>
                <td class="style2" style="width: 54px">
                    &nbsp;</td>
                <td class="style1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MedicineId" 
            Height="189px" Width="323px" HorizontalAlign="Center" BackColor="White" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                        GridLines="Horizontal">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="MedicineId" HeaderText="MedicineId" 
                    InsertVisible="False" ReadOnly="True" SortExpression="MedicineId" />
                <asp:BoundField DataField="MedicineName" HeaderText="MedicineName" 
                    SortExpression="MedicineName" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                    SortExpression="Quantity" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
                </td>
            </tr>
        </table>


    </div>
    
    
   
    <br/>
    <br/>


    <br/>
    <br/>


    <div id="boxes">
            <div id="modalwindow" class="window" style="margin-bottom: 0px">
               
        <table style="width:46%;" border="1">
            <tr>
                <td class="style5" colspan="2">
                    Adding Items for Checkout</td>
            </tr>
            <tr>
                <td class="style5">
                    Medicine Id</td>
                <td>
        <asp:DropDownList ID="ddlMedicineId" runat="server" DataSourceID="Medicine" 
            DataTextField="MedicineId" DataValueField="MedicineId" Enabled="False" Height="16px" 
                        Width="179px">
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    Medicine Name</td>
                <td>
                    <asp:TextBox 
            ID="txtMedicineName" runat="server" 
            Enabled="False" ReadOnly="True" Width="184px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;Quantity</td>
                <td>
        <asp:TextBox ID="txtQuantity" runat="server" onpaste = "return false;" 
            onkeyup ="keyUP(event.keyCode)" onkeydown = "return isNumeric(event.keyCode);" 
                        Width="183px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td>
        <asp:Button ID="btnAddToList" runat="server" onclick="btnAddToList_Click" 
                        Text="Add To List" Width="128px" />
                </td>
            </tr>
        </table>
   
  


               
            </div>
           
           
           
            <!-- div for checkout cart -->
            <div id="modalwindow2" class="window2">
            <br />
   
    <table style="width: 46%;" border="1">
            <tr>
                <td class="style3" colspan="2">
                    &nbsp;
                    &nbsp;&nbsp; List of Checkout Items</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                    &nbsp;
                <asp:GridView ID="gridViewList" runat="server" AutoGenerateColumns="False" DataKeyNames="MedicineId" 
                Height="124px" Width="331px" HorizontalAlign="Center" BackColor="White" 
                        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                        GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="MedicineId" HeaderText="MedicineId" 
                        InsertVisible="False" ReadOnly="True" SortExpression="MedicineId" />
                    <asp:BoundField DataField="MedicineName" HeaderText="MedicineName" 
                        SortExpression="MedicineName" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                        SortExpression="Quantity" />
                </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;
                <asp:Button ID="btnCheckOut" runat="server" onclick="btnCheckOut_Click" 
                 Text="Check Out" style="margin-left: 23px" Width="94px" />
                </td>
                <td>
                    &nbsp;
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Remove All" />
                </td>
            </tr>
        </table>

            </div>
            
            
            <!-- Mask to cover the whole screen -->
            <div id="mask"></div>
    </div>




   

        
<br />

    

    <asp:SqlDataSource ID="Medicine2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CategoryConnectionstring %>" 
        SelectCommand="SELECT DISTINCT [MedicineId], [MedicineName], [Quantity] FROM [Medicine] ORDER BY [MedicineName]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Category2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CategoryConnectionstring %>" 
        SelectCommand="SELECT DISTINCT [CategoryName] FROM [Category] ORDER BY [CategoryName]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Medicine" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CategoryConnectionstring %>" 
        SelectCommand="SELECT DISTINCT [MedicineId] FROM [Medicine] ORDER BY [MedicineId]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Category" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CategoryConnectionstring %>" 
        SelectCommand="SELECT DISTINCT [CategoryName] FROM [Category] ORDER BY [CategoryName]">
    </asp:SqlDataSource>

    




   


</asp:Content>

