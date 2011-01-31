<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="AddPatient.aspx.cs" Inherits="Patient_Demographics_AddEditPatient" %>


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
                <asp:DropDownList ID="ddlMonth" runat="server" 
        >
                    <asp:ListItem>Jan</asp:ListItem>
                    <asp:ListItem>Feb</asp:ListItem>
                    <asp:ListItem>Mar</asp:ListItem>
                    <asp:ListItem>Apr</asp:ListItem>
                    <asp:ListItem>May</asp:ListItem>
                    <asp:ListItem>Jun</asp:ListItem>
                    <asp:ListItem>Jul</asp:ListItem>
                    <asp:ListItem>Aug</asp:ListItem>
                    <asp:ListItem>Sept</asp:ListItem>
                    <asp:ListItem>Oct</asp:ListItem>
                    <asp:ListItem>Nov</asp:ListItem>
                    <asp:ListItem>Dec</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlDay" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server" 
        >
                     <asp:ListItem>1970</asp:ListItem>
                    <asp:ListItem>1971</asp:ListItem>
                    <asp:ListItem>1972</asp:ListItem>
                    <asp:ListItem>1973</asp:ListItem>
                    <asp:ListItem>1974</asp:ListItem>
                    <asp:ListItem>1975</asp:ListItem>
                    <asp:ListItem>1976</asp:ListItem>
                    <asp:ListItem>1977</asp:ListItem>
                    <asp:ListItem>1978</asp:ListItem>
                    <asp:ListItem>1979</asp:ListItem>
                    <asp:ListItem>1980</asp:ListItem>
                    <asp:ListItem>1981</asp:ListItem>
                    <asp:ListItem>1982</asp:ListItem>
                    <asp:ListItem>1983</asp:ListItem>
                    <asp:ListItem>1984</asp:ListItem>
                    <asp:ListItem>1985</asp:ListItem>
                    <asp:ListItem>1986</asp:ListItem>
                    <asp:ListItem>1987</asp:ListItem>
                    <asp:ListItem>1988</asp:ListItem>
                    <asp:ListItem>1989</asp:ListItem>
                    <asp:ListItem>1990</asp:ListItem>
                    <asp:ListItem>1991</asp:ListItem>
                    <asp:ListItem>1992</asp:ListItem>
                    <asp:ListItem>1993</asp:ListItem>
                    <asp:ListItem>1994</asp:ListItem>
                    <asp:ListItem>1995</asp:ListItem>
                    <asp:ListItem>1996</asp:ListItem>
                    <asp:ListItem>1997</asp:ListItem>
                    <asp:ListItem>1998</asp:ListItem>
                    <asp:ListItem>1999</asp:ListItem>
                    <asp:ListItem>2000</asp:ListItem>
                    <asp:ListItem>2001</asp:ListItem>
                    <asp:ListItem>2002</asp:ListItem>
                    <asp:ListItem>2003</asp:ListItem>
                    <asp:ListItem>2004</asp:ListItem>
                    <asp:ListItem>2005</asp:ListItem>
                    <asp:ListItem>2006</asp:ListItem>
                    <asp:ListItem>2007</asp:ListItem>
                    <asp:ListItem>2008</asp:ListItem>
                    <asp:ListItem>2009</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                </asp:DropDownList>
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

