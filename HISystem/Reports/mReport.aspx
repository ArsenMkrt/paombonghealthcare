<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="mReport.aspx.cs" Inherits="Reports_AddReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:SqlDataSource ID="Program" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [ProgramData] FROM [ProgramCategory] ORDER BY [ProgramData]">
        </asp:SqlDataSource>
        <br />
    </p>
    <p>
        <asp:Button ID="btnManagePopulation" runat="server" 
            style="top: 109px; left: 48px; position: absolute; height: 22px; width: 142px" 
            Text="Manage Population" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:DropDownList ID="ddlProgram" runat="server" 
            DataSourceID="Program" DataTextField="ProgramData" DataValueField="ProgramData" 
            onselectedindexchanged="ddlProgram_SelectedIndexChanged" 
            
            style="top: 64px; left: 120px; position: absolute; height: 20px; width: 115px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" 
            style="top: 64px; left: 28px; position: absolute; height: 19px; width: 52px; bottom: 611px" 
            Text="Program"></asp:Label>
        <asp:Button ID="btnNext" runat="server" onclick="btnNext_Click" 
            style="top: 289px; left: 289px; position: absolute; height: 26px; width: 187px" 
            Text="Next" />
    </p>
    <p>
    </p>
    <p>
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

