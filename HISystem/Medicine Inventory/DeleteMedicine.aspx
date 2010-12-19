<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="DeleteMedicine.aspx.cs" Inherits="Medicine_Inventory_DeleteMedicine" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
        <asp:TextBox ID="txtMedicineId" runat="server" 
            
            style="top: 212px; left: 464px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" 
            style="top: 213px; left: 371px; position: absolute; height: 19px; width: 112px" 
            Text="Medicine ID"></asp:Label>
    </p>
    <p>
        <asp:ListBox ID="listboxMedicine" runat="server" AutoPostBack="True" 
            DataSourceID="Medicine" DataTextField="MedicineName" 
            DataValueField="MedicineName" 
            onselectedindexchanged="listboxMedicine_SelectedIndexChanged" 
            
            style="top: 256px; left: 465px; position: absolute; height: 106px; width: 125px">
        </asp:ListBox>
    </p>
    <p>
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
            style="top: 211px; left: 620px; position: absolute; height: 26px; width: 79px" 
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

