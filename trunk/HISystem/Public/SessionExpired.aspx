<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate4.master" AutoEventWireup="true" CodeFile="SessionExpired.aspx.cs" Inherits="Public_SessionExpired" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LoginContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


<h2>
        Session Expired</h2>
    <p>
        Your Session has Timed-Out due to inactivity.
       <br /> Please login. &nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Public/Login.aspx">Click Here</asp:HyperLink>
    </p>
    <p>
        If you have any questions, please contact the site administrator.
    </p>
</asp:Content>

