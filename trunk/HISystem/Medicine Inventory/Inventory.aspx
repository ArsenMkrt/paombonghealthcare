<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Medicine_Inventory_Inventory" %>

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
            AutoPostBack="True" DataSourceID="Category" 
            onselectedindexchanged="ddlCategoryForItemShow_SelectedIndexChanged" 
            style="top: 415px; left: 175px; position: absolute; height: 22px; width: 213px">
        </asp:DropDownList>
    </p>
    <p style="margin-left: 40px">
        &nbsp;Category<asp:DropDownList ID="ddlCategory0" runat="server" AutoPostBack="True" 
            DataSourceID="Category" DataTextField="CategoryName" 
            DataValueField="CategoryName" 
            onselectedindexchanged="ddlCategory_SelectedIndexChanged" 
            
            
            style="top: 75px; left: 164px; position: absolute; height: 22px; width: 225px">
        </asp:DropDownList>
    </p>
    <p style="margin-left: 40px">
        Show Items with Quantity Below
        <asp:TextBox ID="txtQuantityLimit" runat="server" AutoPostBack="True" 
            ontextchanged="txtQuantityLimit_TextChanged" 
            style="top: 452px; left: 258px; position: absolute; height: 22px; width: 72px">20</asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <asp:Panel ID="panelGridView2" runat="server" ScrollBars="Vertical" 
        style="top: 480px; left: 87px; position: absolute; height: 194px; width: 327px; right: 533px">
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
    <p>
    </p>
    <p>
    </p>
    <asp:SqlDataSource ID="Medicine" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
        SelectCommand="SELECT DISTINCT [MedicineId] FROM [Medicine] ORDER BY [MedicineId]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Category" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
        SelectCommand="SELECT DISTINCT [CategoryName] FROM [Category] ORDER BY [CategoryName]">
    </asp:SqlDataSource>
</asp:Content>

