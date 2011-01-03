<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate4.master" AutoEventWireup="true" CodeFile="Consultation.aspx.cs" Inherits="Medical_Record_Consultation" %>



<%@ Register src="DailyPatientRecord.ascx" tagname="DailyPatientRecord" tagprefix="uc1" %>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<table style="width: 107px">
<tr>
<td>
        <a href="#modalwindow" name="modal" style="color: #990033; font-weight: bold;">Get Patient</a>
        
        </td>

</tr>
</table>
     <div id="boxes">
             <div id="modalwindow" class="window">
            <br />
             
        <asp:Label ID="Label3" runat="server" Text="PatientID :" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="txtbx_PatientID" runat="server" style="margin-left: 13px"></asp:TextBox>
    <br />
    <asp:GridView ID="grdvw_Users" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PatientID" DataSourceID="Medicine2" 
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
     <asp:Button ID="Button1" runat="server" Text="Proceed" Width="104px" />
    
            </div>

             <div id="mask"></div>
     </div>
    <br />

    
  
   
    <br />
    <asp:SqlDataSource ID="Medicine2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>" 
        SelectCommand="SELECT [PatientID], [PtFname], [PtMname], [PtLname], [PtGender], [PtBdate], [PtAddress] FROM [Patients]">
    </asp:SqlDataSource>
    <br />
    <br />


    <table style="width:100%; height: 292px;" border="1" bgcolor="#a2cc85">
        <tr>
            <td class="style65" colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Size="X-Large" 
                    Text="Daily Patient Record" Font-Bold="True" ForeColor="#006600"></asp:Label>
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
                <asp:TextBox ID="txtlname" runat="server" Width="166px"></asp:TextBox>
                ,
                <asp:TextBox ID="txtfname" runat="server" Width="182px"></asp:TextBox>
                ,&nbsp;<asp:TextBox ID="txtmname" runat="server" Width="130px"></asp:TextBox>
            </td>
            <td class="style11">
                Philhealth #</td>
            <td class="style37">
                <asp:TextBox ID="txtPhilhealthNum" runat="server" Width="137px"></asp:TextBox>
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
                Month:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                Day:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Year:<br />
&nbsp;<asp:DropDownList ID="dropMonth" runat="server" Height="26px" 
                    onselectedindexchanged="dropMonth_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;
                <asp:DropDownList ID="dropDay" runat="server" 
                    onselectedindexchanged="dropDay_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp; <asp:DropDownList ID="dropYear" runat="server" 
                    onselectedindexchanged="dropYear_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style35" colspan="3">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Barangay<br />
                <asp:DropDownList ID="ddlBarangay" runat="server" 
        DataSourceID="Barangay" DataTextField="BarangayName" 
        DataValueField="BarangayName" 
                    onselectedindexchanged="ddlBarangay_SelectedIndexChanged" 
                    style="margin-left: 56px">
                </asp:DropDownList>
            &nbsp;<asp:SqlDataSource ID="Barangay" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
        
                
                
                    SelectCommand="SELECT DISTINCT [BarangayName] FROM [Barangays] ORDER BY [BarangayName]">
                </asp:SqlDataSource>
            </td>
            <td class="style38">
                Age<br />
                <asp:TextBox ID="txtAge" runat="server" Width="50px"></asp:TextBox>
                yrs old</td>
            
        </tr>
        <tr>
            <td class="style57" colspan="9">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" 
                    ForeColor="#006600" Text="Vital Statistics "></asp:Label>
            </td>
            
            
        </tr>
        <tr>
            <td class="style48">
                Temp</td>
            <td class="style30" colspan="5">
                <asp:TextBox ID="txtTemp" runat="server" Width="121px"></asp:TextBox>
                &nbsp;<span class="style18">Celsius</span></td>
            <td align="right" class="style45">
                Weight</td>
            <td class="style29" colspan="2">
                <asp:TextBox ID="txtWt" runat="server" Width="121px"></asp:TextBox>
                &nbsp;lbs</td>
        </tr>
        <tr>
            <td class="style52">
                Height</td>
            <td class="style64" colspan="5">
                <asp:TextBox ID="txtHt_feet" runat="server" Width="40px"></asp:TextBox>
                ft
                <asp:TextBox ID="txtHt_inch" runat="server" Width="37px"></asp:TextBox>
                &nbsp;in</td>
            <td class="style46" align="right">
                Blood Pressure</td>
            <td class="style53" colspan="2">
                <asp:TextBox ID="txtBpressure" runat="server" Width="121px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style56">
                Diagnosis</td>
            <td class="style55" colspan="8">
                <asp:TextBox ID="txtDiagnosis" runat="server" Height="81px" TextMode="MultiLine" 
                    Width="780px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style49">
                Treatment/<br /> Recommendation</td>
            <td class="style51" colspan="8">
                <asp:TextBox ID="txtRecomendation" runat="server" Height="81px" TextMode="MultiLine" 
                    Width="779px"></asp:TextBox>
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
                    Width="145px" />
            </td>
            <td class="style62" colspan="5">
                &nbsp;</td>
        </tr>
    </table>


<br />
   <%-- <uc1:DailyPatientRecord ID="DailyPatientRecord1" runat="server" />--%>
   


</asp:Content>

