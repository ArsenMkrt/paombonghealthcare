<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="PreviewReport.aspx.cs" Inherits="Reports_PreviewReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
    <br />
        <asp:Button ID="btn_runReport" runat="server" onclick="btn_runReport_Click" 
            style="top: 199px; left: 776px; position: absolute; height: 26px; width: 109px" 
            Text="Run Report" />
        Quarter:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Year:<asp:SqlDataSource ID="DataYear" runat="server" 
        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>" 
        SelectCommand="SELECT DISTINCT [Year] FROM [ChildCare]">
    </asp:SqlDataSource>
</p>
<p>
    Municipality:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Paombong</strong><table 
        style="width:100%;">
        <tr>
            <td style="width: 120px; text-align: center; height: 42px">
                Type</td>
            <td style="width: 159px; height: 42px">
                </td>
            <td style="height: 42px; width: 78px">
                &nbsp;</td>
            <td style="height: 42px">
                </td>
        </tr>
        <tr>
            <td style="width: 120px">
                <asp:RadioButton ID="rdbtn_Reports" runat="server" Text="Reports" 
                    oncheckedchanged="rdbtn_Reports_CheckedChanged" />
            </td>
            <td style="width: 159px; text-align: center">
                Type of Report</td>
            <td style="width: 78px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 120px">
                &nbsp;</td>
            <td style="width: 159px">
                <asp:RadioButton ID="RadioButton3" runat="server" Text="Month" 
                    oncheckedchanged="RadioButton3_CheckedChanged" Visible="False" />
            </td>
            <td style="width: 78px">
                <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="123px" 
                    Visible="False">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 120px">
                &nbsp;</td>
            <td style="width: 159px">
                <asp:RadioButton ID="RadioButton4" runat="server" Text="Quarter" 
                    oncheckedchanged="RadioButton4_CheckedChanged" Visible="False" />
            </td>
            <td style="width: 78px">
        <asp:DropDownList ID="ddlQuarter" runat="server" Height="20px" Width="123px" 
                    Visible="False">
            <asp:ListItem>All</asp:ListItem>
            <asp:ListItem>1st Quarter</asp:ListItem>
            <asp:ListItem>2nd Quarter</asp:ListItem>
            <asp:ListItem>3rd Quarter</asp:ListItem>
            <asp:ListItem>4th Quarter</asp:ListItem>
        </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 120px">
                &nbsp;</td>
            <td style="width: 159px">
                <asp:RadioButton ID="RadioButton5" runat="server" Text="Year" 
                    oncheckedchanged="RadioButton5_CheckedChanged" Visible="False" />
            </td>
            <td style="width: 78px">
                <asp:DropDownList ID="DropDownList1" runat="server" 
             DataSourceID = "DataYear" DataValueField="Year" DataTextField="Year" 
                    Height="20px" Width="123px" Visible="False">
        </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 120px">
                <asp:RadioButton ID="rdbtn_Inventory" runat="server" Text="Inventory" />
            </td>
            <td style="width: 159px">
                &nbsp;</td>
            <td style="width: 78px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </p>
    <p>
        Province: <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Bulacan</strong></p>
     <asp:ScriptManager id="SM1" runat="server" />
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="738px" 
        SizeToReportContent="True">
        <ServerReport ReportServerUrl="http://localhost:2705/HISystem/ReportTemplate.rdlc" />
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


