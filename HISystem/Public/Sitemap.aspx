<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Sitemap.aspx.cs" Inherits="Public_Sitemap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sitemap</title>
</head>
<body bgcolor="#99CCFF">
    <form id="form1" runat="server">
    <h2>Application Sitemap</h2>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/phis_name.png" 
        Width="273px" />
    <asp:Image ID="Image2" runat="server" Height="67px" 
        ImageUrl="~/images/image5.png" Width="77px" />
    <asp:Image ID="Image3" runat="server" Height="71px" 
        ImageUrl="~/images/image3.png" Width="76px" />
    <br />

    <div align="left">
    
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" 
            ImageSet="Arrows" Width="462px">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        
    </div>
    
    </form>
</body>
</html>


