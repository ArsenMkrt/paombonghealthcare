<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="DeleteMedicine.aspx.cs" Inherits="Medicine_Inventory_DeleteMedicine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
        <asp:TextBox ID="txtMedicineId" runat="server" 
            style="top: 133px; left: 400px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" 
            style="top: 133px; left: 263px; position: absolute; height: 19px; width: 112px" 
            Text="Medicine ID"></asp:Label>
    </p>
    <p>
        <asp:ListBox ID="listboxMedicine" runat="server" AutoPostBack="True" 
            DataSourceID="Medicine" DataTextField="MedicineName" 
            DataValueField="MedicineName" 
            onselectedindexchanged="listboxMedicine_SelectedIndexChanged" 
            style="top: 180px; left: 401px; position: absolute; height: 106px; width: 125px">
        </asp:ListBox>
    </p>
    <p>
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
            style="top: 131px; left: 569px; position: absolute; height: 26px; width: 79px" 
            Text="Delete" />
        <asp:SqlDataSource ID="Medicine" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [MedicineName] FROM [Medicine] ORDER BY [MedicineName]">
        </asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

