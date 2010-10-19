<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Medicine_Inventory_Inventory" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p style="margin-left: 40px">
        Category</p>
    <p>
        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" 
            DataSourceID="Category" DataTextField="CategoryName" 
            DataValueField="CategoryName" 
            onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
            
            style="top: 75px; left: 164px; position: absolute; height: 22px; width: 225px">
        </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Medicine Name<asp:TextBox 
            ID="txtNameSearch" runat="server" AutoPostBack="True" 
            ontextchanged="txtNameSearch_TextChanged" 
            style="top: 113px; left: 165px; position: absolute; height: 22px; width: 223px"></asp:TextBox>
    </p>
    <p style="margin-left: 40px">
        Items</p>
    <p>
        &nbsp;</p>
    <asp:Panel ID="panel_Gridview" runat="server" Height="211px" 
        ScrollBars="Vertical" 
        style="top: 175px; left: 85px; position: absolute; width: 330px">
        <asp:GridView ID="gridviewMedicine" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" DataKeyNames="MedicineId"
            Height="211px" onselectedindexchanged="gridviewMedicine_SelectedIndexChanged" 
            Width="330px" AutoGenerateSelectButton="True">
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
    <p>
        &nbsp;</p>
    <asp:Panel ID="panelAddToList" runat="server" 
        style="top: 211px; left: 480px; position: absolute; width: 358px; height: 169px">
        <asp:DropDownList ID="ddlMedicineId" runat="server" DataSourceID="Medicine" 
            DataTextField="MedicineId" DataValueField="MedicineId" 
            
            style="top: 16px; left: 163px; position: absolute; width: 132px; height: 22px; border-style: Double" 
            Enabled="False">
        </asp:DropDownList>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Medicine Id<asp:TextBox 
            ID="txtQuantity" runat="server" 
            
            style="top: 95px; left: 164px; position: absolute; width: 131px; height: 22px; border-style: Double"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Medicine Name<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Quantity<asp:TextBox ID="txtMedicineName" runat="server" 
            Enabled="False" ReadOnly="True" 
            style="top: 55px; left: 165px; position: absolute; width: 128px; height: 22px"></asp:TextBox>
    </asp:Panel>
    <p>
    </p>
    <p>
        <asp:Button ID="btnAddToList" runat="server" onclick="btnAddToList_Click" 
            style="top: 339px; left: 599px; position: absolute; height: 26px; width: 137px" 
            Text="Add To List" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:DropDownList ID="ddlCategoryForItemShow" runat="server" 
            AutoPostBack="True" DataSourceID="Category2" 
            onselectedindexchanged="ddlCategoryForItemShow_SelectedIndexChanged" 
            
            style="top: 415px; left: 175px; position: absolute; height: 22px; width: 213px" 
            DataTextField="CategoryName" DataValueField="CategoryName">
        </asp:DropDownList>
    </p>
    <p style="margin-left: 40px">
        <asp:Label ID="Label3" runat="server" 
            style="top: 412px; left: 41px; position: absolute; height: 24px; width: 34px" 
            Text="Category"></asp:Label>
    </p>
    <p style="margin-left: 40px">
        &nbsp;<asp:TextBox ID="txtQuantityLimit" runat="server" AutoPostBack="True" 
            ontextchanged="txtQuantityLimit_TextChanged" 
            style="top: 452px; left: 258px; position: absolute; height: 22px; width: 72px">20</asp:TextBox>
        <asp:Label ID="Label4" runat="server" 
            style="top: 459px; left: 36px; position: absolute; height: 19px; width: 170px" 
            Text="Show Items Below Quantity"></asp:Label>
    </p>
    <p>
        </p>
    <asp:Panel ID="panelList" runat="server" 
        style="top: 419px; left: 484px; position: absolute; height: 253px; width: 355px">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; List<asp:Panel ID="panelGridView" runat="server" 
            ScrollBars="Vertical" 
            style="top: 46px; left: 11px; position: absolute; height: 156px; width: 336px">
            <asp:GridView ID="gridViewList" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                CellPadding="3" CellSpacing="1" DataKeyNames="MedicineId" GridLines="None" 
                Height="124px" Width="331px">
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
        <asp:Button ID="btnCheckOut" runat="server" onclick="btnCheckOut_Click" 
            style="top: 212px; left: 59px; position: absolute; height: 26px; width: 81px" 
            Text="Check Out" />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            style="top: 214px; left: 207px; position: absolute; height: 26px; width: 87px" 
            Text="Remove All" />
    </asp:Panel>
    <asp:Panel ID="panelGridView2" runat="server" ScrollBars="Vertical" 
        
        style="top: 488px; left: 89px; position: absolute; height: 194px; width: 327px; right: 531px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
            CellPadding="3" CellSpacing="1" DataKeyNames="MedicineId" GridLines="None" 
            Height="189px" Width="323px">
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
    </asp:Panel>
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

