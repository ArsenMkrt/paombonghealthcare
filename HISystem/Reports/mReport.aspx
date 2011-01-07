<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate4.master" AutoEventWireup="true" CodeFile="mReport.aspx.cs" Inherits="Reports_AddReport" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <asp:SqlDataSource ID="Program" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [ProgramData] FROM [ProgramCategory] ORDER BY [ProgramData]">
        </asp:SqlDataSource>
         <asp:SqlDataSource ID="Barangay" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [BarangayName] FROM [Barangays] ORDER BY [BarangayName]">
        </asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <br />
    </p>
        <table style="width: 100%; height: 133px;">
            <tr>
                <td style="width: 239px">
                    Program</td>
                <td style="width: 153px">
                    &nbsp;</td>
                <td style="width: 366px">
        <asp:DropDownList ID="ddlProgram" runat="server" 
            DataSourceID="Program" DataTextField="ProgramData" DataValueField="ProgramData" 
                        Height="20px" Width="122px">
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 239px">
                      Month</td>
                <td style="width: 153px">
                      &nbsp;</td>
                <td style="width: 366px">
                    <asp:DropDownList ID="ddlMonth" runat="server" Height="20px" Width="122px">
                        <asp:ListItem Value="1">January</asp:ListItem>
                        <asp:ListItem Value="2">February</asp:ListItem>
                        <asp:ListItem Value="3">March</asp:ListItem>
                        <asp:ListItem Value="4">April</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">June</asp:ListItem>
                        <asp:ListItem Value="7">July</asp:ListItem>
                        <asp:ListItem Value="8">August</asp:ListItem>
                        <asp:ListItem Value="9">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 239px">
                    Year</td>
                <td style="width: 153px">
                    &nbsp;</td>
                <td style="width: 366px">
                    <asp:DropDownList ID="ddlYear" runat="server" Height="20px" Width="123px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 239px">
                    Barangay</td>
                <td style="width: 153px">
                    &nbsp;</td>
                <td style="width: 366px">
                    <asp:DropDownList ID="ddlBarangay" runat="server" DataSourceID="Barangay" 
                        DataKeyNames="BarangayName" DataValueField="BarangayName" DataTextField="BarangayName" Height="20px" Width="122px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 239px">
                    Project Population for The Year</td>
                <td style="width: 153px">
                    &nbsp;</td>
                <td style="width: 366px">
                    <asp:TextBox ID="txtPopulation" runat="server" 
                        onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)" 
                        onpaste="return false;" Height="23px" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 239px">
                    &nbsp;</td>
                <td style="width: 153px">
                    &nbsp;</td>
                <td style="width: 366px">
        <asp:Button ID="btnNext" runat="server" onclick="btnNext_Click" 
            Text="Next" Height="23px" Width="127px" />
                    <asp:Button ID="Button1" runat="server" Height="23px" Text="Clear" 
                        Width="127px" onclick="Button1_Click" />
                </td>
            </tr>
        </table>
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

