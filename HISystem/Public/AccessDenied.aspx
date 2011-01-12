<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="AccessDenied.aspx.cs" Inherits="Public_AccessDenied" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Unauthorized Access</h2>
    <p>
        You have attempted to access a page that you are not authorized to view.
       <br /> Please login. &nbsp;
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Public/Login.aspx" 
            Font-Underline="True" ForeColor="Blue">Click Here</asp:HyperLink>
    </p>
    <p>
        If you have any questions, please contact the site administrator.
    </p>
    </asp:Content>

