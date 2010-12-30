<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="PreviewReport.aspx.cs" Inherits="Reports_PreviewReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
    <br />
        <asp:Button ID="btn_runReport" runat="server" onclick="btn_runReport_Click" 
            style="top: 197px; left: 801px; position: absolute; height: 26px; width: 109px" 
            Text="Run Report" />
        <asp:DropDownList ID="ddlQuarter" runat="server" 
            
            
            style="top: 199px; left: 380px; position: absolute; height: 20px; width: 120px">
            <asp:ListItem>1st Quarter</asp:ListItem>
            <asp:ListItem>2nd Quarter</asp:ListItem>
            <asp:ListItem>3rd Quarter</asp:ListItem>
            <asp:ListItem>4th Quarter</asp:ListItem>
        </asp:DropDownList>
        Quarter:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Year:<asp:DropDownList ID="DropDownList1" runat="server" 
            
            style="top: 200px; left: 605px; position: absolute; height: 24px; width: 120px">
            <asp:ListItem>2010</asp:ListItem>
        </asp:DropDownList>
</p>
<p>
    Municipality:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Paombong</strong></p>
    <p>
        Province: <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Bulacan</strong></p>
     <asp:ScriptManager id="SM1" runat="server" />
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="738px" 
        SizeToReportContent="True">
    <LocalReport ReportPath="ReportTemplate.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="MalariaObject2" Name="Malaria" />
            <rsweb:ReportDataSource DataSourceId="LeprosyObject2" Name="Leprosy" />
            <rsweb:ReportDataSource DataSourceId="MaternalCareObject2" Name="Maternal" />
            <rsweb:ReportDataSource DataSourceId="ChildCareObject2" Name="ChildCare" />
            <rsweb:ReportDataSource DataSourceId="DentalObject" Name="DentalCare" />
            <rsweb:ReportDataSource DataSourceId="FamilyPlanObject" Name="FamilyPlanning" />
            <rsweb:ReportDataSource DataSourceId="TuberObject" Name="Tuberculosis" />
            <rsweb:ReportDataSource DataSourceId="SchistoObject" Name="Schistomiasis" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
    <asp:ObjectDataSource ID="LeprosyObject2" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.Report_LeprosyTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2010" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MalariaObject2" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.Report_MalariaTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2010" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ChildCareObject2" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.ChildCareTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2010" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SchistoObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.SchistomiasisTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2010" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TuberObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.TuberculosisTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2010" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
        SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.SchistomiasisTableAdapter">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.TuberculosisTableAdapter">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="DentalObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.DentalCareTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2010" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="FamilyPlanObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.FamilyPlanningTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2010" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MaternalCareObject2" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.MaternalCareTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2010" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="pracChild" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.ChildCareTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="month1" Type="Int32" />
            <asp:Parameter Name="month" Type="Int32" />
            <asp:Parameter Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MaternalCareObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.MaternalCareTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="month1" Type="Int32" />
            <asp:Parameter Name="month" Type="Int32" />
            <asp:Parameter Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ChildCareDataObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.ChildCareTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2010" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="DentalCareObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.Report_DentalCareTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="2010" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="FamilyPlanningObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.Report_FamilyPlanningTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="month1" Type="Int32" />
            <asp:Parameter Name="month" Type="Int32" />
            <asp:Parameter Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LeprosyObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.Report_LeprosyTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="month" Type="Int32" />
            <asp:Parameter Name="month1" Type="Int32" />
            <asp:Parameter Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MalariaObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.Report_MalariaTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="month" Type="Int32" />
            <asp:Parameter Name="month1" Type="Int32" />
            <asp:Parameter Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MaternalObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="Report_QuarterlyTableAdapters.Report_MaternalTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="month" Type="Int32" />
            <asp:Parameter Name="month1" Type="Int32" />
            <asp:Parameter Name="year" Type="Int32" />
        </SelectParameters>
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


