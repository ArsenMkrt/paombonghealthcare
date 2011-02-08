<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="AccessDenied.aspx.cs" Inherits="Public_AccessDenied" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <h2 style="background-color: #d3e7c5">
       Unauthorized Access</h2>
    <p style="font-size: medium">
        <span style="font-size: medium">You have attempted to access a page that you are not authorized to view.
        </span>
       <br style="font-size: medium" /> <span style="font-size: medium">Please login. &nbsp;
        </span>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Public/Login.aspx" 
            Font-Underline="True" ForeColor="Blue" style="font-size: medium">Click Here</asp:HyperLink>
    </p>
    <p style="font-size: small">
        If you have any questions, please contact the site administrator.
    </p>
    </asp:Content>

