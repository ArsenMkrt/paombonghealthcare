<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="mReport.aspx.cs" Inherits="Reports_AddReport" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <asp:SqlDataSource ID="Program" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [ProgramData] FROM [ProgramCategory] ORDER BY [ProgramData]">
        </asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <br />
        <table style="width: 100%; height: 142px;">
            <tr>
                <td style="width: 107px">
        <asp:Label ID="Label4" runat="server"  
            Text="Program"></asp:Label>
                </td>
                <td style="width: 54px">
        <asp:DropDownList ID="ddlProgram" runat="server" 
            DataSourceID="Program" DataTextField="ProgramData" DataValueField="ProgramData" 
            onselectedindexchanged="ddlProgram_SelectedIndexChanged" Height="20px" Width="122px">
        </asp:DropDownList>
                </td>
                <td style="width: 366px">
        <asp:Button ID="btnNext" runat="server" onclick="btnNext_Click" 
            Text="Next" Height="28px" Width="127px" />
                </td>
            </tr>
            <tr>
                <td style="width: 107px">
                      &nbsp;</td>
                <td style="width: 54px">
                      <asp:Button ID="btnManagePopulation" runat="server"  
            Text="Manage Population" Visible="False" />
                    </td>
                <td style="width: 366px">
                    &nbsp;</td>
            </tr>
            </table>
    </p>
    <p>
  
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

