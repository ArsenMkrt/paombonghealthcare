<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate4.master" AutoEventWireup="true" CodeFile="MedicalHistory.aspx.cs" Inherits="Medical_Record_MedicalHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LoginContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
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
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                            Text="Display Selected PatientID :"></asp:Label>
                        <asp:TextBox ID="txtbx_PatientID" runat="server" ReadOnly="true" 
                            style="margin-left: 13px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            F<asp:Button ID="ButtonProceed" runat="server" onClick="ButtonProceed_Click" 
                Text="Proceed" Width="104px" />
        </div>


                 <%--        <div id="modalwindow2" class="window2">
                         <br />
                         <br />
                         <table border="1" cellpadding="1" cellspacing="1">
                         <tr>
                         <td>Select Barangay</td>
                         <td> <asp:DropDownList ID="ddlBarangay0" runat="server" 
                            DataSourceID="Barangay0" DataTextField="BarangayName" 
                            DataValueField="BarangayName" Height="22px" Width="184px">
                             </asp:DropDownList></td>
                         </tr>
                         <tr>
                         <td>
                         <asp:TextBox ID="txtSearchPatient" runat="server" Height="28px" Width="187px"></asp:TextBox>
                         </td>
                         <td>
                         <asp:Button ID="btnSearch" runat="server" Text="Search Patient Name" Height="28px" 
                                 Width="182px" />
                         </td>
                         </tr>
                         <tr>
                         
                         <td colspan="2">
                                                      <asp:SqlDataSource ID="Barangay0" runat="server" 
                                                        ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
                                                        SelectCommand="SELECT DISTINCT [BarangayName] FROM [Barangays] ORDER BY [BarangayName]">
                                                        </asp:SqlDataSource>
                           
                            
                         
                             
                                 
                                                         <asp:GridView ID="GridSearchName" runat="server">
                                                         </asp:GridView>
                                
                
                                <asp:SqlDataSource ID="PatientSearchName" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>" 
        
                                                             SelectCommand="SELECT [PatientID], [PtFname], [PtMname], [PtLname], [PtGender], [PtBdate], [PtAddress] FROM [Patients]">
                                </asp:SqlDataSource>
                                
                         
                         </td>
                         </tr>
                         </table>
                        
                
                         </div>--%>




                             <div id="modalwindow2" class="window2">
                         
                            <br />
                             <br />
                             <asp:TextBox ID="txtSearchPatient" OnTextChanged="txtSearchPatient_TextChanged" runat="server" Height="28px" Width="187px"></asp:TextBox>
                             <asp:Button ID="btnSearch" runat="server" Text="Search Patient Name" Height="28px" 
                                 Width="149px" onclick="btnSearch_Click" />
                                 <br/>
        <asp:GridView ID="GridSearchName"  runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PatientID" DataSourceID="PatientSearchName"
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
            <asp:Parameter Name ="PatientLastName" DefaultValue="A"/>
        </SelectParameters>
    </asp:SqlDataSource>
        
                
</div>



                      
        <div id="mask">
        </div>
    </div>
    
    <br/>

    
<table style="width: 365px">
<tr>
<td>
        <a href="#modalwindow" name="modal" style="color: #990033; font-weight: bold;">Search PatientID</a>
    <asp:SqlDataSource ID="Medicine2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>" 
        
        
        SelectCommand="SELECT [PatientID], [PtFname], [PtMname], [PtLname], [PtGender], [PtBdate], [PtAddress] FROM [Patients]">
    </asp:SqlDataSource>
        
        </td>

<td>
       
         <a href="#modalwindow2" name="modal" style="color: #990033; font-weight: bold;">Search Patient</a>
        
        </td>

</tr>
</table>
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="GridView1" runat="server" Width="300px" 
        AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged1">
        <Columns>
            <asp:BoundField DataField="PtFname" HeaderText="First Name" 
                SortExpression="PtFname" />
            <asp:BoundField DataField="PtLname" HeaderText="Last Name" 
                SortExpression="PtLname" />
            <asp:BoundField DataField="PtMname" HeaderText="Middle Name" 
                SortExpression="PtMname" />
            <asp:BoundField DataField="BarangayName" HeaderText="Brgy of Residence" 
                SortExpression="BarangayName" />
            <asp:BoundField DataField="EncounterDateTime" HeaderText="Consultation DateTime" 
                SortExpression="EncounterDateTime" />
            <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
            <asp:BoundField DataField="Temp" HeaderText="Temp" SortExpression="Temp" />
            <asp:BoundField DataField="Weight" HeaderText="Weight" 
                SortExpression="Weight" />
            <asp:BoundField DataField="Height" HeaderText="Height" 
                SortExpression="Height" />
            <asp:BoundField DataField="BP" HeaderText="BP" SortExpression="BP" />
            <asp:BoundField DataField="Diagnosis" HeaderText="Diagnosis" 
                SortExpression="Diagnosis" />
            <asp:BoundField DataField="Treatment" HeaderText="Treatment" 
                SortExpression="Treatment" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>" SelectCommand="SELECT DISTINCT a.PtFname, a.PtLname, a.PtMname, b.BarangayName, c.EncounterDateTime, c.Age, c.Temp, c.Weight, c.Height, c.BP, c.Diagnosis, c.Treatment
FROM            Encounters AS c INNER JOIN
                         Patients AS a ON c.PatientID = a.PatientID CROSS JOIN
                         Barangays AS b INNER JOIN
                         PatientsLocation AS pl ON b.BarangayID = pl.BarangayID
WHERE        (a.PatientID = @PatientID)
ORDER BY c.EncounterDateTime ASC">
        <SelectParameters>
            <asp:Parameter DefaultValue="13" Name="PatientID" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br/>
   
    <br />
    <br />

</asp:Content>

