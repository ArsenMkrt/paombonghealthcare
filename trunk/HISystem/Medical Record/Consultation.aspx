<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate4.master" AutoEventWireup="true" CodeFile="Consultation.aspx.cs" Inherits="Medical_Record_Consultation" %>








<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    

    
    <br />
        <a href="#modalwindow" name="modal" style="color: #990033; font-weight: bold;">List Of Patients</a>
    <br />
         <a href="#modalwindow2" name="modal"  style="color: #990033; font-weight: bold;">List Of Patients Search By Name</a>
   
     <div id="boxes">
             <div id="modalwindow" class="window">
            <br />
             
                 <table style="width: 75%;">
                     <tr>
                         <td>
                             &nbsp;</td>
                         <td style="width: 270px">
                             Select Patient on table below.</td>
                         <td>
             
        <asp:Label ID="Label3" runat="server" Text="Display Selected PatientID :" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="txtbx_PatientID" runat="server" ReadOnly="true" style="margin-left: 13px"></asp:TextBox>
                         </td>
                     </tr>
                 </table>
    <br />
    <asp:GridView ID="grdvw_Users" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PatientID" DataSourceID="PatientList" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            AutoGenerateSelectButton="True" onload="grdvw_Users_Load">
        <Columns>
            <asp:BoundField DataField="PatientID" HeaderText="PatientID" 
                InsertVisible="False" ReadOnly="True" SortExpression="PatientID" />
            <asp:BoundField DataField="PtFullname" HeaderText="Name" 
                SortExpression="PtFullname" />
            <asp:BoundField DataField="PtGender" HeaderText="Gender" 
                SortExpression="PtGender" />
            <asp:BoundField DataField="PtBdate" HeaderText="Birthdate" 
                SortExpression="PtBdate" />
        </Columns>
    </asp:GridView>
 
            </div>

                       <div id="modalwindow2" class="window2">
                         
                            <br />
                             <br />
                             <asp:TextBox ID="txtSearchPatient" AutoPostBack="true" OnTextChanged="txtSearchPatient_TextChanged" runat="server" Height="28px" Width="187px"></asp:TextBox>
                             <asp:Button ID="btnSearch" runat="server" Text="Search Patient Name" Height="28px" 
                                 Width="149px" onclick="btnSearch_Click" CausesValidation="False" />
                                 <br/>
        <asp:GridView ID="GridSearchName"  runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PatientID" DataSourceID="PatientList"
            AutoGenerateSelectButton="True" onselectedindexchanged="GridSearchName_SelectedIndexChanged">
        <Columns>
         <asp:BoundField DataField="PatientID" HeaderText="PatientID" 
                InsertVisible="False" ReadOnly="True" SortExpression="PatientID" />
            <asp:BoundField DataField="PtFullname" HeaderText="Name" 
                SortExpression="PtFullname" />
            <asp:BoundField DataField="PtGender" HeaderText="Gender" 
                SortExpression="PtGender" />
            <asp:BoundField DataField="PtBdate" HeaderText="Birthdate" 
                SortExpression="PtBdate" />
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


    <table style="width:100%; height: 292px;" border="1" bgcolor="#a2cc85">
        <tr>
            <td class="style65" colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Size="X-Large" 
                    Text="Patient Consultation" Font-Bold="True" ForeColor="#006600"></asp:Label>
            </td>
            <td class="style13" colspan="5">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image1" runat="server" Height="59px" 
                    ImageUrl="~/images/image3.png" Width="64px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image3" runat="server" Height="57px" 
                    ImageUrl="~/images/phis_name.png" Width="110px" />
                &nbsp;&nbsp;
                <asp:Image ID="Image2" runat="server" Height="57px" 
                    ImageUrl="~/images/image5.png" Width="74px" />
            </td>
            <td class="style11">
                Date</td>
            <td class="style37">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_dateToday" runat="server" Text="mm/dd/yyyy" Font-Bold="True"></asp:Label>
                </td>
            
        </tr>
        <tr>
            <td class="style13">
                Name<br /> (LN, FN, MN)</td>
            <td class="style10" colspan="6">
                <asp:TextBox ID="txtlname" runat="server" Width="166px" ReadOnly="True"></asp:TextBox>
                ,
                <asp:TextBox ID="txtfname" runat="server" Width="182px" ReadOnly="True"></asp:TextBox>
                ,&nbsp;<asp:TextBox ID="txtmname" runat="server" Width="130px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style11">
                Philhealth #</td>
            <td class="style37">
                <asp:TextBox ID="txtPhilhealthNum" runat="server" Width="137px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style20">
                Address</td>
            <td class="style42" colspan="8">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="784px" 
                    Height="32px"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td class="style34">
                Birthdate</td>
            <td class="style35" colspan="4">
                    <asp:DropDownList ID="ddlMonth" runat="server" Enabled="False">
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
                    <asp:DropDownList ID="ddlDay" runat="server" style="margin-left: 15px" 
                        Enabled="False">
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
                    <asp:DropDownList ID="ddlYear" runat="server" style="margin-left: 21px" 
                        Enabled="False">
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
            <td class="style35" colspan="3">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Barangay<br />
                <asp:DropDownList ID="ddlBarangay" runat="server" 
        DataSourceID="Barangay" DataTextField="BarangayName" 
        DataValueField="BarangayName" 
                    
                    style="margin-left: 56px" Enabled="False">
                </asp:DropDownList>
            &nbsp;<asp:SqlDataSource ID="Barangay" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
        
                
                
                    SelectCommand="SELECT DISTINCT [BarangayName] FROM [Barangays] ORDER BY [BarangayName]">
                </asp:SqlDataSource>
            </td>
            <td class="style38">
                Age<br />
                <asp:TextBox ID="txtAge" runat="server" Width="50px" 
                    onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)" 
                        onpaste="return false;" Enabled="False"></asp:TextBox>
                yrs old</td>
            
        </tr>
        <tr>
            <td class="style57" colspan="9">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" 
                    ForeColor="#006600" Text="Consultation Specifics"></asp:Label>
            </td>
            
            
        </tr>
        <tr>
            <td class="style48">
                Temp*</td>
            <td class="style30" colspan="5">
                <asp:TextBox ID="txtTemp" runat="server" Width="121px" 
                    onkeydown="return isDecimal(event.keyCode);" onkeyup="keyUPDecimal(event.keyCode)" 
                        onpaste="return false;"></asp:TextBox>
                &nbsp;<span class="style18">Celsius<br />
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ControlToValidate="txtTemp" ErrorMessage="(please input number from35-40)" 
                    Font-Italic="True" Font-Size="Small" MaximumValue="40" MinimumValue="35" 
                    Display="Dynamic" Type="Integer"></asp:RangeValidator>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="txtTemp" ErrorMessage="(enter temp)" Font-Italic="True" 
                    Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                </span></td>
            <td align="right" class="style45">
                Weight*</td>
            <td class="style29" colspan="2">
                <asp:TextBox ID="txtWt" runat="server" Width="121px" 
                    onkeydown="return isDecimal(event.keyCode);" onkeyup="keyUPDecimal(event.keyCode)" 
                        onpaste="return false;" MaxLength="6"></asp:TextBox>
                &nbsp;lbs<br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtWt" Display="Dynamic" 
                    ErrorMessage="( invalid weight input)" ValidationExpression="\d\d\d?.?\d?\d?"></asp:RegularExpressionValidator>
                <br />

                <span class="style18">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtWt" ErrorMessage="(enter weight)" Font-Italic="True" 
                    Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                </span>
            </td>
        </tr>
        <tr>
            <td class="style52">
                Height</td>
            <td class="style64" colspan="5">
                <asp:TextBox ID="txtHt_feet" runat="server" Width="40px" MaxLength="1" onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)" 
                        onpaste="return false;"></asp:TextBox>
                ft*<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtHt_feet" ErrorMessage="(enter feet)" Font-Italic="True" 
                    Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
&nbsp;<asp:TextBox ID="txtHt_inch" runat="server" Width="37px" MaxLength="2" onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)" 
                        onpaste="return false;"></asp:TextBox>
                &nbsp;in <span class="style18">
                <asp:RangeValidator ID="RangeValidator2" runat="server" 
                    ControlToValidate="txtHt_inch" ErrorMessage="(inch input exceeded)" 
                    Font-Italic="True" Font-Size="Small" MaximumValue="11" MinimumValue="1" 
                    Display="Dynamic" Type="Integer"></asp:RangeValidator>
                <br />
                <asp:RangeValidator ID="RangeValidator3" runat="server" 
                    ControlToValidate="txtHt_feet" ErrorMessage="(height input exceeded)" 
                    Font-Italic="True" Font-Size="Small" MaximumValue="8" MinimumValue="1" 
                    Display="Dynamic" Type="Integer"></asp:RangeValidator>
                </span>&nbsp;</td>
            <td class="style46" align="right">
                Blood Pressure*</td>
            <td class="style53" colspan="2">
                <asp:TextBox ID="txtBpressure" runat="server" Width="37px" MaxLength="3" 
                    onpaste="return false;" onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)"></asp:TextBox>
                <asp:Label ID="Lbl_slash" runat="server" Font-Bold="True" Font-Size="X-Large" 
                    Text="/"></asp:Label>
                <asp:TextBox ID="txtBpressure0" runat="server" Width="37px"  MaxLength="3" 
                    onpaste="return false;" Height="22px"  onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)"></asp:TextBox>
            &nbsp;
                <asp:Label ID="Lbl_BPunit" runat="server" Font-Bold="False" Font-Size="Medium" 
                    Text="mmHg"></asp:Label><br />

                <span class="style18">
                <asp:RangeValidator ID="BPRangeValidator1" runat="server" 
                    ControlToValidate="txtBpressure" ErrorMessage="(invalid blood pressure1)" 
                    Font-Italic="True" Font-Size="Small" MaximumValue="190" Display="Dynamic" 
                    MinimumValue="90" Type="Integer"></asp:RangeValidator>
                <br />
                <asp:RangeValidator ID="BPRangeValidator2" runat="server" 
                    ControlToValidate="txtBpressure0" ErrorMessage="(invalid blood pressure2)" 
                    Font-Italic="True" Font-Size="Small" MaximumValue="120" MinimumValue="60" 
                    Display="Dynamic" Type="Integer"></asp:RangeValidator>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtBpressure" ErrorMessage="(required blood pressure1)" Font-Italic="True" 
                    Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="txtBpressure0" 
                    ErrorMessage="(required blood pressure2)" Font-Italic="True" 
                    Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                </span>
            </td>
        </tr>
        <tr>
            <td class="style52">
                Illness/Disease</td>
            <td class="style64" colspan="5">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:CheckBoxList ID="checkbox_DiseaseList" runat="server" 
                        DataSourceID="SqlData_diseases" DataTextField="DiseaseName" 
                        DataValueField="DiseaseName" RepeatColumns="3">
                    </asp:CheckBoxList>
                    <asp:SqlDataSource ID="SqlData_diseases" runat="server" 
    ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString2 %>" 
    SelectCommand="select DiseaseName from diseases"></asp:SqlDataSource>
                </asp:Panel>
            </td>
            <td class="style46" align="right">
                &nbsp;</td>
            <td class="style53" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style56">
                Chief Complaint*</td>
            <td class="style55" colspan="8">
                <asp:TextBox ID="txtDiagnosis" runat="server" Height="81px" TextMode="MultiLine" 
                    Width="686px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="txtDiagnosis" ErrorMessage="(enter chief complaint)" 
                    Font-Italic="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style49">
                Treatment/<br /> Recommendation*</td>
            <td class="style51" colspan="8">
                <asp:TextBox ID="txtRecomendation" runat="server" Height="81px" TextMode="MultiLine" 
                    Width="685px"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtRecomendation" ErrorMessage="(enter recommendation)" 
                    Font-Italic="True" Font-Size="Small" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style61">
                &nbsp;</td>
            <td class="style63" colspan="2">
                <asp:Button ID="btnSave" runat="server" style="margin-left: 0px" Text="Save" 
                    Width="145px" onclick="btnSave_Click" />
            </td>
            <td class="style63">
                <asp:Button ID="btnReset" runat="server" style="margin-left: 0px" Text="Reset" 
                    Width="145px" onclick="btnReset_Click" CausesValidation="false" />
            </td>
            <td class="style62" colspan="5">
                &nbsp;</td>
        </tr>
    </table>


<br />
   
   


</asp:Content>

