<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="PreviewReport.aspx.cs" Inherits="Reports_PreviewReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
    <br />
        <asp:Button ID="btn_runReport" runat="server" onclick="btn_runReport_Click" 
            style="top: 124px; left: 840px; position: absolute; height: 26px; width: 109px" 
            Text="Run Report" />
        <asp:DropDownList ID="ddlQuarter" runat="server" 
            style="top: 123px; left: 450px; position: absolute; height: 22px; width: 120px">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlYear" runat="server" 
            style="top: 121px; left: 624px; position: absolute; height: 30px; width: 114px">
        </asp:DropDownList>
</p>
<p>
    &nbsp;</p>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="738px">
    <LocalReport ReportPath="ReportTemplate.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="ChildCare" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="Maternal" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="Malaria" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="Leprosy" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource5" 
                Name="FamilyPlanning" />
            <rsweb:ReportDataSource DataSourceId="ObjectDataSource6" Name="DentalCare" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<asp:ObjectDataSource ID="ObjectDataSource6" runat="server" 
    SelectMethod="GetData" 
    TypeName="Report_QuarterlyTableAdapters.Report_DentalCareTableAdapter">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource5" runat="server" 
    SelectMethod="GetData" 
    TypeName="Report_QuarterlyTableAdapters.Report_FamilyPlanningTableAdapter">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
    SelectMethod="GetData" 
    TypeName="Report_QuarterlyTableAdapters.Report_LeprosyTableAdapter">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
    SelectMethod="GetData" 
    TypeName="Report_QuarterlyTableAdapters.Report_MalariaTableAdapter">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
    SelectMethod="GetData" 
    TypeName="Report_QuarterlyTableAdapters.Report_MaternalTableAdapter">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="GetData" 
    TypeName="Report_QuarterlyTableAdapters.Report_ChildDataTableAdapter">
</asp:ObjectDataSource>
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
<p>
</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginContent" Runat="Server">
</asp:Content>

