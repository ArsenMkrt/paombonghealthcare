<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate5.master" AutoEventWireup="true" CodeFile="SessionExpired.aspx.cs" Inherits="Public_SessionExpired" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


<h2 style="background-color: #d3e7c5">Session has expired</h2>
    <p style="font-size: medium; width: 545px">
        Login credentials expire after 5 minutes of inactivity or being idle for 
        increased security on this application.</p>
    <p style="font-size: medium; width: 540px; margin-left: 0px; margin-top: 58px">
        You will be automatically redirected to Login page in<b> 
        <span style="color: #990000">5 seconds</span></b>. 
        If you do not get redirected Please
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Public/Login.aspx" 
            ForeColor="#0000CC">Click Here</asp:HyperLink>
        .</p>
    <p>
        <br /> 
    </p>
    <p style="font-size: medium; margin-top: 112px">
        If you have any questions, please contact the site administrator.
    </p>
</asp:Content>

