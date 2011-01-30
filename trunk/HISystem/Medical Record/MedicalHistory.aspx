<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate4.master" AutoEventWireup="true" CodeFile="MedicalHistory.aspx.cs" Inherits="Medical_Record_MedicalHistory" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div id="boxes">
     <div id="modalwindow2" class="window2">
                         
                            <br />
                             <br />
                             <asp:TextBox ID="txtSearchPatient" OnTextChanged="txtSearchPatient_TextChanged" runat="server" Height="28px" Width="187px"></asp:TextBox>
                             <asp:Button ID="btnSearch" runat="server" Text="Search Patient Name" Height="28px" 
                                 Width="149px" onclick="btnSearch_Click" CausesValidation="False" />
                                 <br/>
        <asp:GridView ID="GridSearchName"  runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PatientID" DataSourceID="PatientList"
            AutoGenerateSelectButton="True" onselectedindexchanged="GridSearchName_SelectedIndexChanged">
        <Columns>
         <asp:BoundField DataField="PatientID" HeaderText="Id" 
                InsertVisible="False" ReadOnly="True" SortExpression="PatientID" />
            <asp:BoundField DataField="PtFullname" HeaderText="Name" 
                SortExpression="PtFullname" />
            <asp:BoundField DataField="PtGender" HeaderText="Gender" 
                SortExpression="PtGender" />
            <asp:BoundField DataField="PtBdate" HeaderText="Birthdate" 
                SortExpression="PtBdate" />
        </Columns>
            <HeaderStyle BackColor="#009933" HorizontalAlign="Center" />
            <RowStyle ForeColor="#003300" HorizontalAlign="Center" />
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




                      
        <div id="mask">
        </div>
    </div>
    
    <br/>

    
<table style="width: 365px">
<tr>
<td>
    <asp:SqlDataSource ID="Medicine2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>" 
        
        
        SelectCommand="SELECT [PatientID], [PtFname], [PtMname], [PtLname], [PtGender], [PtBdate], [PtAddress] FROM [Patients]">
    </asp:SqlDataSource>
        
        </td>

<td>
       
         <a href="#modalwindow2" name="modal" style="color: #990033; font-weight: bold;">List Of Patients</a>
        
        </td>

</tr>
</table>
    <table style="width:49%;">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Name:</td>
            <td>
                <asp:Label ID="lbl_PatientName" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Brangay of Residence:</td>
            <td>
                <asp:Label ID="lbl_PatientBarangay" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
    </table>
    <br />

    

    <br />
    <asp:GridView ID="GridView1" runat="server" Width="696px" 
        AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataSourceID="SqlDataSource1" 
        AllowPaging="True" 
        onselectedindexchanged="GridView1_SelectedIndexChanged1" 
        DataKeyNames="EncounterID">
        <AlternatingRowStyle BackColor="#A2CC85" />
        <Columns>
        <asp:BoundField DataField="EncounterID" HeaderText = "Consultation Reference No"
                SortExpression="EncounterID" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="EncounterDateTime" HeaderText="Consultation Date and Time" 
                SortExpression="EncounterDateTime" />
            <asp:BoundField DataField="Facilitatedby" HeaderText="Facilitated By" 
                SortExpression="Facilitatedby" />
        </Columns>
        <RowStyle HorizontalAlign="Center" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>" 
        SelectCommand="SELECT DISTINCT  c.EncounterID,c.EncounterDateTime, c.Facilitatedby
FROM            Encounters AS c INNER JOIN
                         Patients AS a ON c.PatientID = a.PatientID CROSS JOIN
                         Barangays AS b INNER JOIN
                         PatientsLocation AS pl ON b.BarangayID = pl.BarangayID
WHERE        (a.PatientID = @PatientID)
ORDER BY c.EncounterDateTime ASC">
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="PatientID" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br/>
   
    <br />
    <br />

</asp:Content>

