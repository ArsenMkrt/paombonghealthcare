<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="ViewEditReport.aspx.cs" Inherits="Reports_ViewEditReport" %>

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
        <asp:DropDownList ID="ddlQuarter" runat="server" Enabled="False" 
            
            style="top: 197px; left: 121px; position: absolute; height: 20px; width: 184px">
            <asp:ListItem Selected="True" Value="1">1st Quarter (Jan,Feb,Mar)</asp:ListItem>
            <asp:ListItem Value="2">2nd Quarter (Apr,May,Jun)</asp:ListItem>
            <asp:ListItem Value="3">3rd Quarter (July,Aug,Sept)</asp:ListItem>
            <asp:ListItem Value="4">4th Quarter (Oct,Nov,Dec)</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" 
            style="top: 200px; left: 28px; position: absolute; height: 19px; width: 34px" 
            Text="Quarter"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:DropDownList ID="ddlProgram" runat="server" AutoPostBack="True" 
            DataSourceID="Program" DataTextField="ProgramData" DataValueField="ProgramData" 
            onselectedindexchanged="ddlProgram_SelectedIndexChanged" 
            style="top: 64px; left: 120px; position: absolute; height: 20px; width: 115px">
        </asp:DropDownList>
        <asp:Label ID="Label6" runat="server" 
            style="top: 136px; left: 30px; position: absolute; height: 19px; width: 34px" 
            Text="Year"></asp:Label>
        <asp:DropDownList ID="ddlYear" runat="server" 
            
            style="top: 130px; left: 120px; position: absolute; height: 20px; width: 117px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" 
            style="top: 64px; left: 28px; position: absolute; height: 19px; width: 52px; bottom: 611px" 
            Text="Program"></asp:Label>
    </p>
    <p>
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

