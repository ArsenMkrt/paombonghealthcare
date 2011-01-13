<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="PreviewReport.aspx.cs" Inherits="Reports_PreviewReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table style="width:100%;">
        <tr>
            <td style="width: 81px; text-align: center; height: 42px">
                Municipality: <strong>PAOMBONG</strong></td>
            <td style="width: 196px; height: 42px">
                Province: 
        <strong>Bulacan</strong></td>
            <td style="height: 42px; width: 78px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 81px; text-align: center; height: 42px">
                Type</td>
            <td style="width: 196px; height: 42px">
                </td>
            <td style="height: 42px; width: 78px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 81px">
                <asp:RadioButton ID="rdbtn_Reports" GroupName="TypeReport" runat="server" Text="Reports" 
                    oncheckedchanged="rdbtn_Reports_CheckedChanged" AutoPostBack="True" />
            </td>
            <td style="text-align: center" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Type of Report" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 81px; height: 23px;">
                </td>
            <td style="width: 196px; height: 23px;">
                <asp:Label ID="Label2" runat="server" Text="Quarter:" Visible="False"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlQuarter" runat="server" Height="20px" Width="123px" 
                    Visible="False">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>1st Quarter</asp:ListItem>
                    <asp:ListItem>2nd Quarter</asp:ListItem>
                    <asp:ListItem>3rd Quarter</asp:ListItem>
                    <asp:ListItem>4th Quarter</asp:ListItem>
        </asp:DropDownList>
            </td>
            <td style="width: 78px; height: 23px;">
            </td>
        </tr>
        <tr>
            <td style="width: 81px">
                &nbsp;</td>
            <td style="width: 196px">
                <asp:Label ID="Label3" runat="server" Text="Year:" Visible="False"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" 
              
                    Height="20px" Width="123px" Visible="False">
        </asp:DropDownList>
            </td>
            <td style="width: 78px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 81px">
                <asp:RadioButton ID="rdbtn_Inventory" GroupName="TypeReport" runat="server" 
                    Text="Inventory" Visible="False" />
            </td>
            <td style="width: 196px">
        <asp:Button ID="btn_runReport" runat="server" onclick="btn_runReport_Click"
            Text="Run Report" Width="120px" />
            </td>
            <td style="width: 78px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 81px">
                &nbsp;</td>
            <td style="width: 196px">
                &nbsp;</td>
            <td style="width: 78px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 81px">
                &nbsp;</td>
            <td style="width: 196px">
                &nbsp;</td>
            <td style="width: 78px">
                &nbsp;</td>
        </tr>
    </table>
</p>
<p>
    &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
     <asp:ScriptManager id="SM1" runat="server" />
<rsweb:ReportViewer ID="ReportPaombong" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="738px" 
        SizeToReportContent="True">
        <ServerReport ReportServerUrl="http://localhost:2705/HISystem/Report.rdlc" />
    <LocalReport ReportPath="Report.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="_MaternalCare" Name="MaternalCare" />
            <rsweb:ReportDataSource DataSourceId="_FamilyPlanning" Name="FamilyPlanning" />
            <rsweb:ReportDataSource DataSourceId="_ChildCare" Name="ChildCare" />
            <rsweb:ReportDataSource DataSourceId="_DentalCare" Name="DentalCare" />
            <rsweb:ReportDataSource DataSourceId="_Tuberculosis" Name="Tuberculosis" />
            <rsweb:ReportDataSource DataSourceId="_Malaria" Name="Malaria" />
            <rsweb:ReportDataSource DataSourceId="_Schisto" Name="Schisto" />
            <rsweb:ReportDataSource DataSourceId="_Leprosy" Name="Leprosy" />
            <rsweb:ReportDataSource DataSourceId="_Filariasis" Name="Filariasis" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
    <asp:ObjectDataSource ID="_MaternalCare" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
    TypeName="PaombongDataSetTableAdapters.MaternalCareTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
        </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="_Filariasis" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
    TypeName="PaombongDataSetTableAdapters.FilariasisTableAdapter">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
        <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
        <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="_Leprosy" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
    TypeName="PaombongDataSetTableAdapters.LeprosyTableAdapter">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
        <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
        <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="_Schisto" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
    TypeName="PaombongDataSetTableAdapters.SchistoTableAdapter">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
        <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
        <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="_Malaria" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
    TypeName="PaombongDataSetTableAdapters.MalariaTableAdapter">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
        <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
        <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="_Tuberculosis" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
    TypeName="PaombongDataSetTableAdapters.TuberculosisTableAdapter">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
        <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
        <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="_DentalCare" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
    TypeName="PaombongDataSetTableAdapters.DentalCareTableAdapter">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
        <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
        <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="_ChildCare" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
    TypeName="PaombongDataSetTableAdapters.ChildCareTableAdapter">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
        <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
        <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="_FamilyPlanning" runat="server" 
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
    TypeName="PaombongDataSetTableAdapters.FamilyPlanningTableAdapter">
    <SelectParameters>
        <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
        <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
        <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
    <asp:ObjectDataSource ID="fiBusinessObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.FilariasisTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="leBusinessObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.LeprosyTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="scBusinessObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.SchistoTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="maBusinessObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.MalariaTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2010" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="tbBusinessObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.TuberculosisTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dcBusinessObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.DentalCareTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ccBusinessObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.ChildCareTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="fpBusinessObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.FamilyPlanningTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="mcBusinessObject" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.MaternalCareTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
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


