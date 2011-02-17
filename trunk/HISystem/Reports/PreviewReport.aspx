<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="PreviewReport.aspx.cs" Inherits="Reports_PreviewReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2 style="background-color: #d3e7c5">
        cPreview Report Page
    </h2>
    
    <br />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
      
      <p>
       Municipality:
                <strong style="font-size: medium">Paombong</strong>
       <br />
       Province:
      <strong><span style="font-size: medium; text-align: center;">Bulacan</span></strong></p>
    <p>
                <strong style="text-align: center; font-size: medium;">Choose Type Of Report</strong>
            <br />
             <asp:RadioButton ID="rdbtn_Reports" GroupName="TypeReport" runat="server" Text="Reports" 
                    oncheckedchanged="rdbtn_Reports_CheckedChanged" 
                    Font-Size="Small" AutoPostBack="True" style="text-align: center" />
                <asp:RadioButton ID="rdbtn_Inventory" GroupName="TypeReport" runat="server" 
                    Text="Inventory" Font-Size="Small" AutoPostBack="True" 
                    oncheckedchanged="rdbtn_Inventory_CheckedChanged" />
                <asp:RadioButton ID="rdbtn_Consultation" GroupName="TypeReport" runat="server" 
                    style="font-size: small" Text="Consultation" AutoPostBack="True" 
                    oncheckedchanged="rdbtn_Consultation_CheckedChanged" />    
    </p>
    <asp:MultiView ID="MultiView2" runat="server" Visible="False">
        <asp:View ID="PaombongReportView" runat="server">
        <table>
        <tr>
        <td colspan="4" style="height: 31px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                style="font-size: medium; text-align: center;" Text="Filters" 
                Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label2" runat="server" 
                style="font-size: small; font-weight: 700;" Text="Quarter:" 
                Visible="False" Height="21px"></asp:Label>
            </td><td style="width: 204px">
                <asp:DropDownList ID="ddlQuarter" runat="server" Height="21px" Visible="False" 
                    Width="123px">
                    <asp:ListItem>1st Quarter</asp:ListItem>
                    <asp:ListItem>2nd Quarter</asp:ListItem>
                    <asp:ListItem>3rd Quarter</asp:ListItem>
                    <asp:ListItem>4th Quarter</asp:ListItem>
                </asp:DropDownList>
            </td>
        <td style="width: 61px">
            <asp:Label ID="Label3" runat="server" 
                style="font-size: small; font-weight: 700;" Text="Year:" Visible="False" 
                Height="21px"></asp:Label>
            </td><td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="21px" 
                    Visible="False" Width="123px">
                </asp:DropDownList>
            </td>
        </tr>
        </table>
        </asp:View>

       
        <asp:View ID="InventoryView" runat="server">
         <table>
        <tr>
        <td colspan="4" style="height: 30px">
            <asp:Label ID="Label4" runat="server" Font-Bold="True" style="font-size: medium" 
                Text="Filters" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label5" runat="server" 
                style="font-size: small; font-weight: 700;" Text="Log Type:" 
                Visible="False" Height="21px"></asp:Label>
            </td><td>
                <asp:DropDownList ID="ddlLogType" runat="server" DataSourceID="logData" 
                    DataTextField="LogType" DataValueField="LogType" Height="21px" Visible="False" 
                    Width="123px">
                </asp:DropDownList>
            </td><td>
                <asp:SqlDataSource ID="logData" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
                    SelectCommand="SELECT DISTINCT [LogType] FROM [MedicineLog]">
                </asp:SqlDataSource>
            </td>
        </tr>
        </table>
        </asp:View>


    </asp:MultiView>
    <br />
      

<br />

    <div style="height: 190px; width: 784px">
        <div id="leftpane" style="float:left; width: 258px; height: 167px;">
            
            <asp:MultiView ID="MultiView3" runat="server" Visible="False">
                <asp:View ID="ConsultFilterView" runat="server">

                <asp:Label ID="Label6" runat="server" 
                style="font-size: small; font-weight: 700; text-align: center;" 
                Text="Report Filters" Visible="False" Height="21px"></asp:Label>
            <br />
            <asp:TextBox ID="txtFilterby" runat="server" Height="21px" Width="161px"></asp:TextBox>
            <br />
            <asp:Panel ID="Panel1" runat="server" CssClass="popupControl" Height="102px" Width="163px">
               
                    <asp:RadioButton ID="rdbtn_Barangay" runat="server" AutoPostBack="True" 
                        GroupName="ConsultType" oncheckedchanged="rdbtn_Barangay_CheckedChanged" 
                        style="font-size: small" Text="Barangay" Visible="False" />
                    <br />
                    <asp:RadioButton ID="rdbtn_Disease" runat="server" AutoPostBack="True" 
                        GroupName="ConsultType" oncheckedchanged="rdbtn_Disease_CheckedChanged" 
                        style="font-size: small" Text="Disease" Visible="False" />
                    <br />
                    <asp:RadioButton ID="rdbtn_Age" runat="server" AutoPostBack="True" 
                        GroupName="ConsultType" oncheckedchanged="rdbtn_Age_CheckedChanged" 
                        style="font-size: small" Text="Age Bracket" Visible="False" />
                    <br />
                    <asp:RadioButton ID="rdbtn_Month" runat="server" AutoPostBack="True" 
                        GroupName="ConsultType" oncheckedchanged="rdbtn_Month_CheckedChanged" 
                        style="font-size: small" Text="Month" Visible="False" />
                    <br />
                    <asp:RadioButton ID="rdbtn_Year" runat="server" AutoPostBack="True" 
                        GroupName="ConsultType" oncheckedchanged="rdbtn_Year_CheckedChanged" 
                        style="font-size: small" Text="Year" />
                
            </asp:Panel>
            <asp:PopupControlExtender ID="txtFilterby_PopupControlExtender" runat="server" 
                PopupControlID="Panel1" Position="Bottom" TargetControlID="txtFilterby">
        </asp:PopupControlExtender>
                </asp:View>
            </asp:MultiView>
            
        </div>
        <div id="rightpane" 
            style="float:right; height: 222px; width: 488px; overflow: auto;">
            
    <asp:MultiView ID="MultiView1" runat="server" Visible="False">
                <asp:View ID="BrgyView" runat="server">
                    <br />
                    <table>
                    <tr>
                     <td><asp:Label ID="Label7" runat="server" 
                        style="font-size: small; font-weight: 700;" Text="Barangay:" Height="21px"></asp:Label></td>
                    <td> 
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="Barangay" 
                        DataTextField="BarangayName" DataValueField="BarangayName" Height="21px" 
                        Width="123px" style="margin-left: 0px">
                    </asp:DropDownList></td>
                    </tr>
                   
                    <tr>
                    <td> 
                        <asp:Label ID="Label12" runat="server" Font-Bold="True" 
                        style="font-size: small" Text="Month:" Height="21px"></asp:Label></td>
                    <td> 
                        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="getMonths" 
                        DataTextField="MonthsText" DataValueField="MonthsValue" Height="21px" Visible="False" 
                        Width="123px" style="margin-left: 0px">
                    </asp:DropDownList></td>
                    </tr>
                    <tr>
                <td><asp:Label ID="Label16" runat="server" Font-Bold="True" 
                        style="font-size: small" Text="Year:" Height="21px"></asp:Label></td>
                <td>
                <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="getYears" 
                        DataTextField="Years" DataValueField="Years" Height="21px" Visible="False" 
                        Width="123px" style="margin-left: 19px">
                    </asp:DropDownList></td>
                </tr>
                    </table>
                    
                   <br />
                   
                   
                    
                </asp:View>


                <asp:View ID="DiseaseView" runat="server">
                <br />
                <table>
                <tr>
                <td><asp:Label ID="Label8" runat="server" 
                        style="font-size: small; font-weight: 700" Text="Disease:" Height="21px"></asp:Label></td>
                <td><asp:DropDownList ID="ddlDisease" runat="server" DataSourceID="Disease" 
                        DataTextField="DiseaseName" DataValueField="DiseaseName" Height="21px" 
                        Visible="False" Width="123px" style="margin-left: 16px">  </asp:DropDownList></td>
                </tr>
                <tr>
                <td><asp:Label ID="Label13" runat="server" Font-Bold="True" 
                        style="font-size: small" Text="Month:" Height="21px"></asp:Label></td>
                <td> 
                    <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="getMonths" 
                        DataTextField="MonthsText" DataValueField="MonthsValue" Height="21px" Visible="False" 
                        Width="123px" style="margin-left: 16px">
                    </asp:DropDownList></td>
                </tr>
                <tr>
                <td><asp:Label ID="Label15" runat="server" Font-Bold="True" 
                        style="font-size: small" Text="Year:" Height="21px"></asp:Label></td>
                <td> 
                    <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="getYears" 
                        DataTextField="Years" DataValueField="Years" Height="21px" Visible="False" 
                        Width="123px" style="margin-left: 16px">
                    </asp:DropDownList></td>
                </tr>
                </table>
                    
                 
                </asp:View>



                <asp:View ID="AgeView" runat="server">
                 <br />
                 <table>
                <tr>
                <td>  <asp:Label ID="Label9" runat="server" 
                        style="font-size: small; font-weight: 700" Text="Age Bracket:" 
                        Height="21px"></asp:Label></td>
                <td><asp:DropDownList ID="ddlAge" runat="server" Height="21px" Visible="False" 
                        Width="123px" style="margin-left: 19px">
                    <asp:ListItem Value="1">0-15</asp:ListItem>
                    <asp:ListItem Value="2">16-30</asp:ListItem>
                    <asp:ListItem Value="3">31-48</asp:ListItem>
                    <asp:ListItem Value="4">49-65</asp:ListItem>
                    <asp:ListItem Value="5">66-89</asp:ListItem>
                    <asp:ListItem Value="6">90 and Above</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                <td><asp:Label ID="Label14" runat="server" Font-Bold="True" 
                        style="font-size: small" Text="Month:" Height="21px"></asp:Label></td>
                <td><asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="getMonths" 
                        DataTextField="MonthsText" DataValueField="MonthsValue" Height="21px" Visible="False" 
                        Width="123px" style="margin-left: 19px">
                    </asp:DropDownList></td>
                </tr>
                </table>


                  
                    
                    
                    
                </asp:View>
                <asp:View ID="MonthView" runat="server">
                <br />
                    <asp:Label ID="Label10" runat="server" 
                        style="font-size: small; font-weight: 700" Text="Month:" Height="21px"></asp:Label>
                    <asp:DropDownList ID="ddlMonth" runat="server" DataSourceID="getMonths" 
                        DataTextField="MonthsText" DataValueField="MonthsValue" Height="21px" Visible="False" 
                        Width="122px" style="margin-left: 18px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="getMonths" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
                        SelectCommand="SelectMonthPresent" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                    
                <asp:Label ID="Label17" runat="server" Font-Bold="True" 
                        style="font-size: small" Text="Year:" Height="21px"></asp:Label>
                 
                    <asp:DropDownList ID="DropDownList8" runat="server" DataSourceID="getYears" 
                        DataTextField="Years" DataValueField="Years" Height="21px" Visible="False" 
                        Width="123px" style="margin-left: 16px">
                    </asp:DropDownList>
                
                </asp:View>
               
               
                <asp:View ID="YearView" runat="server">
                 <br />
                 <table>
                <tr>
                <td> 
                    <asp:Label ID="Label11" runat="server" 
                        style="font-size: small; font-weight: 700" Text="Year:" Height="21px"></asp:Label></td>
                <td> 
                    <asp:DropDownList ID="ddlYear" runat="server" DataSourceID="getYears" 
                        DataTextField="Years" DataValueField="Years" Height="21px" Visible="False" 
                        Width="123px" style="margin-left: 19px">
                    </asp:DropDownList></td>
                </tr>
                <tr>
                <td></td>
                <td><asp:SqlDataSource ID="getYears" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
                        SelectCommand="SelectYearPresent" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource></td>
                </tr>
                </table>



                   
                   
                    
                </asp:View>
            </asp:MultiView>
            
        </div>
    </div>
                <asp:Button ID="btn_runReport" runat="server" onclick="btn_runReport_Click"
                    Text="Run Report" Width="186px" style="text-align: center" 
        Height="28px" />
    <br />

<br />
<rsweb:ReportViewer ID="ReportPaombong" runat="server" Font-Names="Verdana" 
    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
    WaitMessageFont-Names="Verdana" 
        WaitMessageFont-Size="14pt" Width="738px" 
        SizeToReportContent="True" ExportContentDisposition="AlwaysAttachment" 
        PageCountMode="Actual" Visible="False">
        <ServerReport ReportServerUrl="http://localhost:2705/HISystem/Report.rdlc" 
            ReportPath="Report.rdlc" />
    <LocalReport ReportPath="Reports\Report_SearchByBarangay.rdlc" 
            DisplayName="PaombongQuarterlyReport">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="Barangay" Name="SearchByBarangay" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
    <asp:ObjectDataSource ID="_MedicineLog_" runat="server" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.MedicineLogTableAdapter">
        <InsertParameters>
            <asp:Parameter Name="MedicineId" Type="Int32" />
            <asp:Parameter Name="MedicineName" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int64" />
            <asp:Parameter Name="DateOfCheckOut" Type="DateTime" />
            <asp:Parameter Name="FacilitatedBy" Type="String" />
            <asp:Parameter Name="LogType" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="CheckOut" Name="logtype" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
        <asp:SqlDataSource ID="Barangay" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
             SelectCommand="SelectBarangayPresentInEncounter" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    
        <asp:SqlDataSource ID="Disease" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SelectDiseasePresent" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
    <asp:ObjectDataSource ID="_YearConsult" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.SearchByYearTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="2011" Name="yearParam" Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>

     <%--<asp:ScriptManager id="SM1" runat="server" />--%>
    
    <asp:ObjectDataSource ID="_MonthConsult" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.SearchByMonthTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="monthParam" Type="Decimal" />
            <asp:Parameter DefaultValue="2011" Name="yearParam" Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="_Barangay" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.SearchByBarangayNameTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="Binakod" Name="barangayName" Type="String" />
            <asp:Parameter DefaultValue="1" Name="month" Type="Decimal" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="_AgeBracket" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.SearchByAgeBracketTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="48" Name="ageParam" Type="String" />
            <asp:Parameter DefaultValue="31" Name="ageParam2" Type="String" />
            <asp:Parameter DefaultValue="1" Name="month" Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="_SearchByDiseaseName" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.SearchByDiseaseNameTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="Mumps" Name="diseaseName" Type="String" />
            <asp:Parameter DefaultValue="1" Name="month" Type="Decimal" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Decimal" />
        </SelectParameters>
    </asp:ObjectDataSource>
<%--    <asp:ObjectDataSource ID="_Header" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="PaombongDataSetTableAdapters.HeaderTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="month1" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="month" Type="Int32" />
            <asp:Parameter DefaultValue="2011" Name="year" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
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


