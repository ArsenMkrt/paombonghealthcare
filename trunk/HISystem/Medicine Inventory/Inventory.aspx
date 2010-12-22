<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Medicine_Inventory_Inventory" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
    </p>
    <p>
        <table style="width:100%; height: 239px;">
            <tr>
                <td style="width: 100px">
                    Category</td>
                <td style="width: 548px">
        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" 
            DataSourceID="Category" DataTextField="CategoryName" 
            DataValueField="CategoryName" 
            onselectedindexchanged="ddlCategory_SelectedIndexChanged" Height="16px" Width="174px">
        </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">
                    Search Name</td>
                <td style="width: 548px">
                    <asp:TextBox 
            ID="txtNameSearch" runat="server" AutoPostBack="True" 
            ontextchanged="txtNameSearch_TextChanged" Width="171px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 246px; width: 100px;">
                    Medicine Inventory<br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    Medicine Id<br />
                    <br />
                    <br />
                    Medicine Name<br />
                    <br />
                    <br />
                    Quantity<br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    </td>
                <td style="width: 548px; height: 246px;">
                    <table style="width: 100%; height: 616px;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
        <asp:Button ID="btnAddToList" runat="server" onclick="btnAddToList_Click" 
            style="top: 443px; left: 667px; position: absolute; height: 26px; width: 137px" 
            Text="Add To List" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>

    <asp:Panel ID="panel_Gridview" runat="server" 
        ScrollBars="Vertical" 
        style="top: 191px; left: 438px; position: absolute; width: 397px; height: 188px;">
        <asp:GridView ID="gridviewMedicine" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" DataKeyNames="MedicineId" 
            onselectedindexchanged="gridviewMedicine_SelectedIndexChanged" 
            AutoGenerateSelectButton="True" HorizontalAlign="Center" 
            
            
            style="top: 3px; left: 6px; position: absolute; height: 183px; width: 391px;">
            <Columns>
                <asp:BoundField DataField="MedicineId" HeaderText="MedicineId" 
                    InsertVisible="False" ReadOnly="True" SortExpression="MedicineId" />
                <asp:BoundField DataField="MedicineName" HeaderText="MedicineName" 
                    SortExpression="MedicineName" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                    SortExpression="Quantity" />
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
    </asp:Panel>
                                <asp:TextBox ID="txtMedicineName" runat="server" 
                                    style="top: 473px; left: 446px; position: absolute; height: 22px" Width="170px"></asp:TextBox>
                                <asp:TextBox ID="txtQuantity" runat="server" 
                                    style="top: 530px; left: 444px; position: absolute; height: 22px; width: 168px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
    
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    </td>
                <td style="height: 246px">
                    </td>
            </tr>
        </table>
        <table style="width:100%;">
            <asp:Panel ID="panelList" runat="server" 
        
        
        
        style="top: 592px; left: 433px; position: absolute; height: 253px; width: 409px">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; List<asp:Button ID="btnCheckOut" runat="server" onclick="btnCheckOut_Click" 
            style="top: 212px; left: 59px; position: absolute; height: 26px; width: 81px" 
            Text="Check Out" />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            style="top: 214px; left: 207px; position: absolute; height: 26px; width: 87px" 
            Text="Remove All" />
        <asp:GridView ID="gridViewList" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" DataKeyNames="MedicineId" GridLines="None" 
            Height="124px" HorizontalAlign="Center" Width="331px">
            <Columns>
                <asp:BoundField DataField="MedicineId" HeaderText="MedicineId" 
                    InsertVisible="False" ReadOnly="True" SortExpression="MedicineId" />
                <asp:BoundField DataField="MedicineName" HeaderText="MedicineName" 
                    SortExpression="MedicineName" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                    SortExpression="Quantity" />
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
    </asp:Panel>
        </table>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
    <p style="margin-left: 40px">
        &nbsp;</p>
    <p>
    
        <asp:DropDownList ID="ddlMedicineId" runat="server" DataSourceID="Medicine" 
            DataTextField="MedicineId" DataValueField="MedicineId" 
            
            style="top: 415px; left: 446px; position: absolute; width: 170px; height: 7px; border-style: Double" 
            Enabled="False">
        </asp:DropDownList>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                CellPadding="3" CellSpacing="1" DataKeyNames="MedicineId" GridLines="None" 
                Height="189px" HorizontalAlign="Center" Width="323px">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="MedicineId" HeaderText="MedicineId" 
                        InsertVisible="False" ReadOnly="True" SortExpression="MedicineId" />
                    <asp:BoundField DataField="MedicineName" HeaderText="MedicineName" 
                        SortExpression="MedicineName" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                        SortExpression="Quantity" />
                </Columns>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>
        </p>
    
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<p>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:DropDownList ID="ddlCategoryForItemShow" runat="server" 
            AutoPostBack="True" DataSourceID="Category2" 
            onselectedindexchanged="ddlCategoryForItemShow_SelectedIndexChanged" 
            
            style="top: 934px; left: 746px; position: absolute; height: 22px; width: 213px" 
            DataTextField="CategoryName" DataValueField="CategoryName">
        </asp:DropDownList>
    </p>
    <p style="margin-left: 40px">
        <asp:Label ID="Label3" runat="server" 
            style="top: 412px; left: 41px; position: absolute; height: 24px; width: 34px" 
            Text="Category"></asp:Label>
    </p>
    <p style="margin-left: 40px">
        &nbsp;
        
        
        <!-- Validations for numbers only-->

        <asp:TextBox ID="txtQuantityLimit" runat="server" AutoPostBack="True" 
            onpaste = "return false;" onkeyup ="keyUP(event.keyCode)" onkeydown = "return isNumeric(event.keyCode);" 
        style="top: 551px; left: 849px; position: absolute; height: 22px; width: 72px">20</asp:TextBox>
        <asp:Label ID="Label4" runat="server" 
            style="top: 459px; left: 36px; position: absolute; height: 19px; width: 170px" 
            Text="Show Items Below Quantity"></asp:Label>
    </p>
    <p>
        </p>
    
    <p>
    </p>
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

