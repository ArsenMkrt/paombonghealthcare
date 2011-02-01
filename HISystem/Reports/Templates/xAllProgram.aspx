<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate4.master" AutoEventWireup="true" CodeFile="xAllProgram.aspx.cs" Inherits="Reports_Templates_xAllProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LoginContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2 style="background-color: #d3e7c5">
        FHSIS Report Input Page
    </h2>
    <br />
    <br />
    <table border="1" 
        style="border-color: #008000; width:100%; table-layout: fixed;">
        <tr>
            <td style="width: 245px; color: #003300">
                FHSIS Report for the MONTH</td>
            <td style="width: 136px">
                <asp:Label ID="lbl_month" runat="server" 
                    style="text-align: center; font-weight: 700; color: #000000" Text="Label"></asp:Label>
            </td>
            <td style="width: 55px; color: #003300">
                YEAR</td>
            <td style="width: 63px">
                <asp:Label ID="lblYear" runat="server" 
                    style="text-align: center; font-weight: 700; color: #000000" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 245px; color: #003300">
                Name of BHS:</td>
            <td style="width: 136px">
                <asp:Label ID="lbl_Barangay" runat="server" 
                    style="font-weight: 700; color: #000000" Text="Label"></asp:Label>
            </td>
            <td style="width: 55px">
                &nbsp;</td>
            <td style="width: 63px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 245px; color: #003300">
                Municipality/City of:</td>
            <td style="width: 136px; color: #000000">
                <strong>Paombong</strong></td>
            <td style="width: 55px">
                &nbsp;</td>
            <td style="width: 63px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 245px; color: #003300">
                Province:</td>
            <td style="width: 136px; color: #000000">
                <strong>Bulacan</strong></td>
            <td style="width: 55px">
                &nbsp;</td>
            <td style="width: 63px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 245px; color: #003300">
                Projected Population of the Year:</td>
            <td style="width: 136px">
                <asp:Label ID="lbl_Population" runat="server" 
                    style="font-weight: 700; color: #000000" Text="Label"></asp:Label>
            </td>
            <td style="width: 55px">
                &nbsp;</td>
            <td style="width: 63px">
                &nbsp;</td>
        </tr>
    </table>

    

    <asp:Table ID="tblMaternal" GridLines ="Both" Width = "100%" runat="server">
    </asp:Table>
    <br />
    <asp:Table ID="tblMalaria" GridLines="Both" Width = "100%" runat="server">
    </asp:Table>
    <br />
    <asp:Table ID="tblDynamic" GridLines="Both" runat="server" Width="100%">
    </asp:Table>
    <br />
    <asp:Table ID="tblFamilyPlanning" GridLines="Both" runat="server" Width="100%">
    </asp:Table>

    <br />
 
    <br />
    <br />
        <asp:Button ID="Button1" EnableViewState="true" OnClick="Button1_Click" 
        runat="server" Text="Save" 
        Width="129px" />
        <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" 
        Text="Clear" Width="130px" />
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
    <br />
</asp:Content>

