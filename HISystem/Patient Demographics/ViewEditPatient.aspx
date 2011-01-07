﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="ViewEditPatient.aspx.cs" Inherits="Patient_Demographics_ViewEditPatient" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
<a href="#modalwindow" name="modal" style="color: #990033; font-weight: bold;">Search PatientID</a>
        <br />
         <a href="#modalwindow2" name="modal" style="color: #990033; font-weight: bold;">Search Patient</a>
        
        
  <div id="boxes">
             <div id="modalwindow" class="window">
            <br />
             
                 <table style="width: 87%;">
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td style="width: 375px">
                             Please select patient in table below.</td>
                         <td>
             
        &nbsp;&nbsp;&nbsp;
             
        <asp:Label ID="Label3" runat="server" Text="Display Selected PatientID :" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="txtbx_PatientID" runat="server" ReadOnly="true" style="margin-left: 13px"></asp:TextBox>
                         </td>
                     </tr>
                 </table>
    <br />
    <asp:GridView ID="grdvw_Users" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PatientID" DataSourceID="Patient" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            AutoGenerateSelectButton="True" onload="grdvw_Users_Load">
        <Columns>
            <asp:BoundField DataField="PatientID" HeaderText="PatientID" 
                InsertVisible="False" ReadOnly="True" SortExpression="PatientID" />
            <asp:BoundField DataField="PtFname" HeaderText="First name" 
                SortExpression="PtFname" />
            <asp:BoundField DataField="PtMname" HeaderText="Middle" 
                SortExpression="PtMname" />
            <asp:BoundField DataField="PtLname" HeaderText="Lastname" 
                SortExpression="PtLname" />
            <asp:BoundField DataField="PtGender" HeaderText="Gender" 
                SortExpression="PtGender" />
            <asp:BoundField DataField="PtBdate" HeaderText="Birthdate" 
                SortExpression="PtBdate" />
            <asp:BoundField DataField="PtAddress" HeaderText="Address" 
                SortExpression="PtAddress" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="Patient" runat="server" 
        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>" 
        
        
        SelectCommand="SELECT [PatientID], [PtFname], [PtMname], [PtLname], [PtGender], [PtBdate], [PtAddress] FROM [Patients]">
    </asp:SqlDataSource>
     <asp:Button ID="ButtonProceed" runat="server" Text="Proceed" Width="104px" onClick="ButtonProceed_Click" />
    
            </div>
                         <div id="modalwindow2" class="window2">
                         
                            <br />
                             <br />
                             <asp:TextBox ID="txtSearchPatient" AutoPostBack="true" OnTextChanged="txtSearchPatient_TextChanged" runat="server" Height="28px" Width="187px"></asp:TextBox>
                             <asp:Button ID="btnSearch" runat="server" Text="Search Patient Last Name" Height="28px" 
                                 Width="175px" onclick="btnSearch_Click" />
                                 <br/>
        <asp:GridView ID="GridSearchName"  runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PatientID" DataSourceID="PatientList"
            AutoGenerateSelectButton="True" onselectedindexchanged="GridSearchName_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="PatientID" HeaderText="PatientID" 
                InsertVisible="False" ReadOnly="True" SortExpression="PatientID" />
            <asp:BoundField DataField="PtFname" HeaderText="First name" 
                SortExpression="PtFname" />
            <asp:BoundField DataField="PtMname" HeaderText="Middle" 
                SortExpression="PtMname" />
            <asp:BoundField DataField="PtLname" HeaderText="Lastname" 
                SortExpression="PtLname" />
            <asp:BoundField DataField="PtGender" HeaderText="Gender" 
                SortExpression="PtGender" />
            <asp:BoundField DataField="PtBdate" HeaderText="Birthdate" 
                SortExpression="PtBdate" />
            <asp:BoundField DataField="PtAddress" HeaderText="Address" 
                SortExpression="PtAddress" />
        </Columns>
    </asp:GridView>
                                
             
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
                    <asp:SqlDataSource ID="Barangay0" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>"
                        SelectCommand="SELECT DISTINCT [BarangayName] FROM [Barangays] ORDER BY [BarangayName]">
                    </asp:SqlDataSource>
                        <asp:Image ID="Image3" runat="server" Height="42px" 
                            ImageUrl="~/images/image3.png" Width="52px" />
                        <asp:Image ID="Image2" runat="server" Height="43px" 
                            ImageUrl="~/images/phis_name.png" Width="244px" />
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
                    <asp:TextBox ID="txtLName" runat="server" Height="21px" Width="203px"></asp:TextBox>
                    <br />
                    Last name</td>
                <td class="style10" colspan="2" style="height: 52px">
                    <asp:TextBox ID="txtFName" runat="server" Width="147px"></asp:TextBox>
                    <br />
                    First name</td>
                <td class="style13">
                    <asp:TextBox ID="txtMName" runat="server" Width="107px"></asp:TextBox>
                    <br />
                    MI</td>
                <td class="style10" style="height: 52px">
                    <asp:TextBox ID="txtSuffix" runat="server" Height="23px" Width="71px" 
                        Visible="False"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="style1" style="width: 161px">
                    <asp:Label ID="Label23" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Contact Number"></asp:Label>
                </td>
                <td class="style5" colspan="3" style="width: 179px">
                    <asp:TextBox ID="txtContactNum" runat="server" Width="203px"></asp:TextBox>
                </td>
                <td class="style14">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" 
        ForeColor="Black" 
        Text="PhilHealth #"></asp:Label>
                </td>
                <td class="style6" colspan="2">
                    <asp:TextBox ID="txtFaxNum" runat="server" Width="227px"
                    
                    onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)" 
                        onpaste="return false;"></asp:TextBox>
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
                    <asp:DropDownList ID="ddlMonth" runat="server">
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
                    <asp:DropDownList ID="ddlYear" runat="server">
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
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 161px">
                    <asp:Label ID="Label32" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Company"></asp:Label>
                </td>
                <td class="style5" colspan="3" style="width: 179px">
                    <asp:TextBox ID="txtCompany" runat="server" Width="207px"></asp:TextBox>
                </td>
                <td class="style14">
                    <asp:Label ID="Label33" runat="server" Font-Bold="True" ForeColor="#000000" 
                        Text="Spouse Name"></asp:Label>
                </td>
                <td class="style6" colspan="2">
                    <asp:TextBox ID="txtSpouseName" runat="server" Width="228px"></asp:TextBox>
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

