<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="AddPatient.aspx.cs" Inherits="Patient_Demographics_AddEditPatient" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2 style="background-color: #d3e7c5">
        Add Patient Page
    </h2>
    <br />
   
    <table 84%"="" bgcolor="#a2cc85" 
        style="height:93px;width: 129px; border:solid 2px #2c6402;" border="2">
        <tr>
            <td class="style1" colspan="4">
                <asp:SqlDataSource ID="Barangay" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
        
                
                
                    SelectCommand="SELECT DISTINCT [BarangayName] FROM [Barangays] ORDER BY [BarangayName]">
                </asp:SqlDataSource>
                <center>
                <asp:Image ID="Image3" runat="server" Height="42px" 
                    ImageUrl="~/images/image3.png" Width="52px" />
                <asp:Image ID="Image2" runat="server" Height="43px" 
                    ImageUrl="~/images/phis_name.png" Width="244px" />
                <asp:Image ID="Image4" runat="server" Height="42px" 
                    ImageUrl="~/images/image5.png" Width="54px" />
                    </center>
            </td>
            <td class="style13" style="width: 109px">
                <asp:Label ID="Label20" runat="server" Font-Bold="True" 
        ForeColor="#000000" 
        Text="Barangay"></asp:Label>
            </td>
            <td class="style10">
                <asp:DropDownList ID="ddlBarangay" runat="server" 
        DataSourceID="Barangay" DataTextField="BarangayName" 
        DataValueField="BarangayName">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 161px; height: 52px;">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#000000" 
                    Text="Name"></asp:Label>
                *</td>
            <td class="style12" style="height: 52px">
                <asp:TextBox ID="txtLName" runat="server" Height="21px" Width="203px"></asp:TextBox>
                <br />
                Last name
                <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtLName" ErrorMessage="(cannot be empty)" 
                    Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>
            </td>
            <td class="style10" colspan="2" style="height: 52px">
                <asp:TextBox ID="txtFName" runat="server" Width="147px"></asp:TextBox>
                <br />
                First name<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtFName" ErrorMessage="(cannot be empty)" 
                    Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>
            </td>
            <td class="style13" style="height: 52px;" colspan="2">
                <asp:TextBox ID="txtMName" runat="server" Width="107px" style="margin-top: 0px"></asp:TextBox>
                &nbsp;<asp:TextBox ID="txtSuffix" runat="server" Width="51px" Height="23px" 
                    Visible="False" ></asp:TextBox>
                <br />
                Middle name<br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtMName" Display="Dynamic" ErrorMessage="(cannot be empty)" 
                    Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>
                <br />
                </td>
        </tr>
        <tr>
            <td class="style1" style="width: 161px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" 
        ForeColor="#000000" Text="Contact Number"></asp:Label>
            </td>
            <td class="style5" colspan="2" style="width: 179px">
                <asp:TextBox ID="txtContactNum" runat="server" Width="203px" 
                    onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)"  
                        onpaste="return false;" MaxLength="11"></asp:TextBox>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtContactNum" ErrorMessage="(number too short)" 
                    Font-Italic="True" Font-Size="Small" ValidationExpression="\d{7}\d?\d?\d?\d?"></asp:RegularExpressionValidator>
                <br />
            </td>
            <td class="style11" style="width: 137px">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" 
        ForeColor="Black" 
        Text="PhilHealth #"></asp:Label>
            </td>
            <td class="style6" colspan="2">
                <asp:TextBox ID="txtFaxNum" runat="server" Width="227px" 
                    onKeyUp="javascript:return mask(this.value,this,'2,12','-');" 
                    onBlur="javascript:return mask(this.value,this,'2,12','-');" MaxLength="14" onpaste="return false;"></asp:TextBox><br />

                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtFaxNum" 
                    ErrorMessage="(input valid philhealth number format)" Font-Italic="True" 
                    Font-Size="Small" ValidationExpression="\b\d{2}-\d{9}-\d{1}"></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 161px">
                <asp:Label ID="Label13" runat="server" Font-Bold="True" 
        ForeColor="#000000" Text="Sex"></asp:Label>
                *</td>
            <td class="style12" colspan="2" style="width: 179px">
                &nbsp;
                <asp:RadioButton GroupName="genderList" ID="radiobutton_Female" runat="server" 
        Font-Bold="True" ForeColor="#000000" Text="Female" />
                <asp:RadioButton GroupName="genderList" ID="radiobutton_Male" runat="server" 
        Font-Bold="True" ForeColor="#000000" Text="Male" />
            </td>
            <td class="style11" style="width: 137px">
                <asp:Label ID="Label14" runat="server" Font-Bold="True" 
        ForeColor="#000000" 
       
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
                <asp:Label ID="Label4" runat="server" Font-Bold="True" 
        ForeColor="#000000" 
         
        Text="Email Address"></asp:Label>
            </td>
            <td class="style5" colspan="2" style="width: 179px">
                <asp:TextBox ID="txtEmailAdd" runat="server" Width="206px" 
       ></asp:TextBox><br />

                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtEmailAdd" ErrorMessage="(input valid email format)" 
                    Font-Italic="True" Font-Size="Small" 
                    ValidationExpression="([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})"></asp:RegularExpressionValidator>

            </td>
            <td class="style11" style="width: 137px">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" 
        ForeColor="#000000" 
        
        Text="City"></asp:Label>
            </td>
            <td class="style6" colspan="2">
                <asp:TextBox ID="txtCity" runat="server" Width="227px" 
        ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 161px">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" 
        ForeColor="#000000"  
        Text="Birthdate"></asp:Label>
            </td>
            <td class="style5" colspan="2" style="width: 179px">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

                    <asp:TextBox runat="server" ID="txtDate" Height="23px" Width="97px" />
        
                    <asp:CalendarExtender ID="calendarButtonExtender" runat="server" 
                     TargetControlID="txtDate" CssClass="MyCalendar"/>
                         <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                    TargetControlID="txtDate" BehaviorID="behave1" ClearMaskOnLostFocus="False" Mask="99/99/9999" CultureName="" UserDateFormat="DayMonthYear" MaskType="Date">
                </asp:MaskedEditExtender>
                <asp:Image ID="Image5" runat="server" ImageUrl="~/images/calendar.png" ToolTip="Choose Date"/>
                <br />
                <asp:CompareValidator ID="CompareValidator2" runat="server" 
               ControlToValidate="txtDate" ErrorMessage="invalid date"
               Operator="DataTypeCheck" Type="Date" ValidationGroup="grpDate" 
                    Font-Italic="True" Font-Size="Small" Display="Dynamic" />
                <br />
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="CompareValidator2">
                </asp:ValidatorCalloutExtender>


                <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtDate" 
                    runat="server" ErrorMessage="Invalid date range" Type="Date" Display="Dynamic" 
                    Font-Italic="True" Font-Size="Small"></asp:RangeValidator>
                
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RangeValidator1">
                </asp:ValidatorCalloutExtender>

                <br />
            </td>
            <td class="style11" style="width: 137px">
                <asp:Label ID="Label18" runat="server" Font-Bold="True" 
        ForeColor="#000000" 
        
        Text="Birthplace"></asp:Label>
            </td>
            <td class="style6" colspan="2">
                <asp:TextBox ID="txtBirthplace" runat="server" Width="227px" 
       ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7" style="width: 161px">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" 
        ForeColor="#000000" Text="Address"></asp:Label>
                *
            </td>
            <td class="style8" colspan="5">
                <asp:TextBox ID="txtAddress" runat="server" Height="51px" Width="601px" 
        ></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtAddress" ErrorMessage="(cannot be empty)" 
                    Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 161px">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" 
        ForeColor="#000000" 
      
        Text="Company"></asp:Label>
            </td>
            <td class="style5" colspan="2" style="width: 179px">
                <asp:TextBox ID="txtCompany" runat="server" Width="207px" ></asp:TextBox>
            </td>
            <td class="style11" style="width: 137px">
                <asp:Label ID="Label19" runat="server" Font-Bold="True" 
        ForeColor="#000000" 
       
        Text="Spouse Name"></asp:Label>
            </td>
            <td class="style6" colspan="2">
                <asp:TextBox ID="txtSpouseName" runat="server" Width="228px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 161px">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" 
        ForeColor="#000000" 
       
        Text="Nationality"></asp:Label>
            </td>
            <td class="style12" colspan="2" style="width: 179px">
                <asp:TextBox ID="txtNationality" runat="server" Width="208px" 
       ></asp:TextBox>
            </td>
            <td class="style11" style="width: 137px">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" 
        ForeColor="#000000" 
       
        Text="Doctor"></asp:Label>
            </td>
            <td class="style6" colspan="2">
                <asp:TextBox ID="txtDoctor" runat="server" Width="227px" 
        ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" style="width: 161px">
                &nbsp;</td>
            <td class="style5" colspan="2" style="width: 179px">
                <asp:Button ID="button_AddEdit0" runat="server" 
        onclick="button_AddEdit_Click" 
       
        Text="Save Patient Details" Width="219px" Height="36px" />
            </td>
            <td class="style9" colspan="2">
                <asp:Button ID="button_Clear" runat="server" 
        onclick="button_Clear_Click" 
        
        Text="Clear Details" Width="209px" Height="38px" />
            </td>
            <td class="style10">
                <asp:Button ID="button_ProceedConsultation" runat="server" 
        onclick="button_ProceedConsultation_Click" 
       
        Text="Proceed to Consultation &gt;&gt;" Width="168px" Height="36px" />
            </td>
        </tr>
    </table>
   
</asp:Content>

