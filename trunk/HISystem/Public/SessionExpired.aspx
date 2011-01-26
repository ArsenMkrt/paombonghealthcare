<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate5.master" AutoEventWireup="true" CodeFile="SessionExpired.aspx.cs" Inherits="Public_SessionExpired" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


<h2 style="background-color: #d3e7c5">Session has expired</h2>
    <p>
        Your Session has timed out.
       For increased security on this application, login credentials expire after 5 
        minutes of inactivity or being idle.
    </p>
    <p>
        You will be automatically redirected to Login page in<b> 5 seconds</b>. 
    </p>
    <p>
        If you do not get redirected Please
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Public/Login.aspx" 
            ForeColor="#0000CC">Click Here</asp:HyperLink>
        .</p>
    <p>
        <br /> 
    </p>
    <p>
        If you have any questions, please contact the site administrator.
    </p>
</asp:Content>

