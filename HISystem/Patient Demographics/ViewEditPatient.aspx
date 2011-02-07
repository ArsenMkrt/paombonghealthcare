<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="ViewEditPatient.aspx.cs" Inherits="Patient_Demographics_ViewEditPatient" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2 style="background-color: #d3e7c5">
        Update Patient Information Page
    </h2>
    <br />
         <a href="#modalwindow2" name="modal" style="color: #990033; font-weight: bold;">List Of Patients</a>
        
        
  <div id="boxes">
                         <div id="modalwindow2" class="window2">
                         
                            <br />
                             <br />
                             <asp:TextBox ID="txtSearchPatient" runat="server" Height="28px" Width="187px"></asp:TextBox>
                             <asp:Button ID="btnSearch" runat="server" Text="Search Patient Last Name" Height="28px" 
                                 Width="175px" onclick="btnSearch_Click" />
                                 <br />
                                 <br />
        <asp:GridView ID="GridSearchName"  runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PatientID" DataSourceID="PatientList"
            AutoGenerateSelectButton="True" onselectedindexchanged="GridSearchName_SelectedIndexChanged">
        <Columns>
             <asp:BoundField DataField="PatientID" ItemStyle-HorizontalAlign="Center" HeaderText="Id" 
                InsertVisible="False" ReadOnly="True" SortExpression="PatientID" />
            <asp:BoundField DataField="PtFullname" ItemStyle-HorizontalAlign="Center" HeaderText="Patient Name" 
                SortExpression="PtFullname" />
            <asp:BoundField DataField="PtGender" ItemStyle-HorizontalAlign="Center" HeaderText="Gender" 
                SortExpression="PtGender" />
            <asp:BoundField DataField="PtBdate" ItemStyle-HorizontalAlign="Center" HeaderText="Birthdate" 
                SortExpression="PtBdate" />
        </Columns>
            <EmptyDataTemplate>No Data to show.</EmptyDataTemplate>
            <HeaderStyle BackColor="#009933" HorizontalAlign="Center" />
            <RowStyle ForeColor="#003300" HorizontalAlign="Center" />
    </asp:GridView>
                                
    <asp:SqlDataSource ID="Barangay0" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>"
                        SelectCommand="SELECT DISTINCT [BarangayName] FROM [Barangays] ORDER BY [BarangayName]">
                    </asp:SqlDataSource>         
    <asp:SqlDataSource ID="PatientSearchName" runat="server" 
        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>" 
        SelectCommand="SearchPatientByName" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name ="PatientLastName" DefaultValue="a"/>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="PatientList" runat="server" 
        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>" 
        SelectCommand="RetrievePatientAll" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
        
        
                
                         </div>
             <div id="mask"></div>
     </div>
    

    <br />
   
        <table 84%"="" bgcolor="#a2cc85" 
        style="height:93px;width: 129px; border:solid 2px #2c6402;" border="2">
            <tr>
                <td class="style3" colspan="2">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#000000" 
                Text="Patient Id"></asp:Label>
                <br />
                    <asp:TextBox ID="txtPatientId" runat="server" Width="114px" 
                       ></asp:TextBox>
                    <asp:Button ID="ButtonSearch" runat="server" onClick="ButtonSearch_Click" 
                        Text="Search" Width="86px" />
                </td>
                <td class="style3" colspan="4">
                    <center>
                        <asp:Image ID="Image3" runat="server" Height="42px" 
                            ImageUrl="~/images/image3.png" Width="52px" />
                        <asp:Image ID="Image4" runat="server" Height="42px" 
                            ImageUrl="~/images/image5.png" Width="54px" />
                    </center>
                </td>
                <td class="style3">
                    <asp:Label ID="Label21" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Barangay"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlBarangay" runat="server" datasourceid="Barangay0" 
                        DataTextField="BarangayName" DataValueField="BarangayName">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 161px; height: 52px;">
                    <asp:Label ID="Label22" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Name"></asp:Label>
                </td>
                <td class="style12" style="height: 52px" colspan="2">
                    <asp:TextBox ID="txtLName" runat="server" Height="21px" Width="203px" autocomplete="off"></asp:TextBox>
                    <br />
                    Last name<br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtLName" ErrorMessage="(cannot be empty)" 
                    Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
                <td class="style10" colspan="2" style="height: 52px">
                    <asp:TextBox ID="txtFName" runat="server" Width="147px" autocomplete="off"></asp:TextBox>
                    <br />
                    First name<br /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtFName" ErrorMessage="(cannot be empty)" 
                    Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
                <td class="style13" colspan="2">
                    <asp:TextBox ID="txtMName" runat="server" Width="107px" autocomplete="off"></asp:TextBox>
                    
                    <asp:TextBox ID="txtSuffix" runat="server" Height="23px" Width="71px" 
                        Visible="False"></asp:TextBox>
                    <br />
                    Middle name<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtMName" Display="Dynamic" ErrorMessage="(cannot be empty)" 
                    Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>
                    
                    </td>
            </tr>
            <tr>
                <td class="style1" style="width: 161px">
                    <asp:Label ID="Label23" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Contact Number"></asp:Label>
                </td>
                <td class="style5" colspan="3" style="width: 179px">
                    <asp:TextBox ID="txtContactNum" runat="server" autocomplete="off" Width="203px" MaxLength="11"
                     onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)"  
                        onpaste="return false;"></asp:TextBox>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="txtContactNum" ErrorMessage="(number too short)" 
                        Font-Italic="True" Font-Size="Small" ValidationExpression="\d{7}\d?\d?\d?\d?"></asp:RegularExpressionValidator>
                    <br />
                </td>
                <td class="style14">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" 
        ForeColor="Black" 
        Text="PhilHealth #"></asp:Label>
                </td>
                <td class="style6" colspan="2">
                    <asp:TextBox ID="txtFaxNum" autocomplete="off" runat="server" Width="227px"
                    
                   onKeyUp="javascript:return mask(this.value,this,'2,12','-');" 
                    onBlur="javascript:return mask(this.value,this,'2,12','-');" MaxLength="14" onpaste="return false;"></asp:TextBox>
                    <br />

                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtFaxNum" 
                    ErrorMessage="(input valid philhealth number format)" Font-Italic="True" 
                    Font-Size="Small" ValidationExpression="\b\d{2}-\d{9}-\d{1}"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 161px">
                    <asp:Label ID="Label25" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Sex"></asp:Label>
                </td>
                <td class="style12" colspan="3" style="width: 179px">
                    &nbsp;
                    <asp:RadioButton ID="radiobutton_Female" runat="server" Font-Bold="True" 
                        ForeColor="#000000" GroupName="genderList" 
                     Text="Female" />
                    <asp:RadioButton ID="radiobutton_Male" runat="server" Font-Bold="True" 
                        ForeColor="#000000" GroupName="genderList"  Text="Male" />
                </td>
                <td class="style14">
                    <asp:Label ID="Label26" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Civil Status"></asp:Label>
                </td>
                <td class="style6" colspan="2">
                    <asp:DropDownList ID="ddlCivilStatus" runat="server">
                        <asp:ListItem>Single</asp:ListItem>
                        <asp:ListItem>Divorced</asp:ListItem>
                        <asp:ListItem>Married</asp:ListItem>
                        <asp:ListItem>Widowed</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 161px">
                    <asp:Label ID="Label27" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Email Address"></asp:Label>
                </td>
                <td class="style5" colspan="3" style="width: 179px">
                    <asp:TextBox ID="txtEmailAdd" runat="server" Width="206px"></asp:TextBox>
                    <br />

                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtEmailAdd" ErrorMessage="(input valid email format)" 
                    Font-Italic="True" Font-Size="Small" 
                    ValidationExpression="([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})"></asp:RegularExpressionValidator>

                </td>
                <td class="style14">
                    <asp:Label ID="Label28" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="City"></asp:Label>
                </td>
                <td class="style6" colspan="2">
                    <asp:TextBox ID="txtCity" runat="server" Width="227px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 161px">
                    <asp:Label ID="Label29" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Birthdate"></asp:Label>
                </td>
                <td class="style5" colspan="3" style="width: 179px">
                      <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
               
               
                    <asp:TextBox runat="server" ID="txtDate" Height="23px" Width="97px" />
                    

                      
                <asp:CalendarExtender ID="calendarButtonExtender" runat="server" 
                     TargetControlID="txtDate" CssClass="MyCalendar"/>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/images/calendar.png" ToolTip="Choose Date" />
                <br />
               <asp:CompareValidator ID="CompareValidator2" runat="server" 
               ControlToValidate="txtDate" ErrorMessage="invalid date"
               Operator="DataTypeCheck" Type="Date" ValidationGroup="grpDate" 
                    Font-Italic="True" Font-Size="Small" Display="Dynamic" />
                <br />
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="CompareValidator2">
                </asp:ValidatorCalloutExtender>


            <%--    <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtDate" 
                    runat="server" ErrorMessage="Invalid date range" Type="Date" Display="Dynamic" 
                    Font-Italic="True" Font-Size="Small"></asp:RangeValidator>--%>
                
              <%--  <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RangeValidator1">
                </asp:ValidatorCalloutExtender>--%>
        


                </td>
                <td class="style14">
                    <asp:Label ID="Label30" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Birthplace"></asp:Label>
                </td>
                <td class="style6" colspan="2">
                    <asp:TextBox ID="txtBirthplace" runat="server" Width="227px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style7" style="width: 161px">
                    <asp:Label ID="Label31" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Address"></asp:Label>
                </td>
                <td class="style8" colspan="6">
                    <asp:TextBox ID="txtAddress" runat="server" Height="51px" Width="615px"></asp:TextBox>
                    <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtAddress" ErrorMessage="(cannot be empty)" 
                    Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 161px">
                    <asp:Label ID="Label32" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Company"></asp:Label>
                </td>
                <td class="style5" colspan="3" style="width: 179px">
                    <asp:TextBox ID="txtCompany" runat="server" Width="207px" autocomplete="off"></asp:TextBox>
                </td>
                <td class="style14">
                    <asp:Label ID="Label33" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Spouse Name"></asp:Label>
                </td>
                <td class="style6" colspan="2">
                    <asp:TextBox ID="txtSpouseName" autocomplete="off" runat="server" Width="228px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 161px">
                    <asp:Label ID="Label34" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Nationality"></asp:Label>
                </td>
                <td class="style12" colspan="3" style="width: 179px">
                    <asp:TextBox ID="txtNationality" runat="server" Width="208px"></asp:TextBox>
                </td>
                <td class="style14">
                    <asp:Label ID="Label35" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Doctor"></asp:Label>
                </td>
                <td class="style6" colspan="2">
                    <asp:TextBox ID="txtDoctor" runat="server" Width="227px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 161px">
                    &nbsp;</td>
                <td class="style5" colspan="3" style="width: 179px">
                    <asp:Button ID="Button1" runat="server" Height="36px" 
                        onclick="button_AddEdit_Click" Text="Save Patient Details" Width="219px" />
                </td>
                <td class="style9" colspan="3">
                <asp:Button ID="button_ProceedConsultation" runat="server" 
        onclick="button_ProceedConsultation_Click" 
       
        Text="Proceed to Consultation" Width="168px" Height="36px" />
                </td>
            </tr>
        </table>
    
       
<p>
</p>

</asp:Content>

