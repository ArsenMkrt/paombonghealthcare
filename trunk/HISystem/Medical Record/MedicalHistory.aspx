<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate4.master" AutoEventWireup="true" CodeFile="MedicalHistory.aspx.cs" Inherits="Medical_Record_MedicalHistory" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

     <h2 style="background-color: #d3e7c5">
        Patient Medical Records/History Page    </h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <br />

    <div id="boxes">
     <div id="modalwindow2x" class="window2x">

                             hndi na modal iseperate page na yung search at view<br />
    


                             <asp:TextBox ID="txtSearchPatient" OnTextChanged="txtSearchPatient_TextChanged" 
                                 runat="server" Height="23px" Width="280px" autocomplete="off"></asp:TextBox>



                              <asp:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" 
         TargetControlID="txtSearchPatient" MinimumPrefixLength="1" 
                                DelimiterCharacters=",:" 
                                CompletionInterval="1000"
                                CompletionSetCount="15"
                                UseContextKey="false"
                                ServiceMethod="GetLastNames" OnClientHiding="OnClientCompleted"
    OnClientPopulated="OnClientCompleted" OnClientPopulating="OnClientPopulating" 
         ServicePath="~/WebService.asmx">
     </asp:AutoCompleteExtender>


                             <asp:Button ID="btnSearch" runat="server" Text="Search by LastName" Height="28px" 
                                 Width="141px" onclick="btnSearch_Click" CausesValidation="False" />
                                 <br />
                                 <br />
                             <br />
                             <asp:Panel ID="Panel1" runat="server" Height="132px" Width="722px" 
                                 ScrollBars="Vertical">
                                 <asp:GridView ID="GridSearchName"  runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PatientID" DataSourceID="PatientList"
            AutoGenerateSelectButton="True" 
    onselectedindexchanged="GridSearchName_SelectedIndexChanged" Width="693px">
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

                             </asp:Panel>
                                
                
              
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
     <br />
                <p>Name:
                <asp:Label ID="lbl_PatientName" runat="server" Font-Bold="True"></asp:Label><br />
                Brangay of Residence: 
                <asp:Label ID="lbl_PatientBarangay" runat="server" Font-Bold="True"></asp:Label><br />
                </p>
                
    <asp:Panel ID="pnlGridview" ScrollBars="Vertical" runat="server" Height="152px" 
         Width="732px">
        <asp:GridView ID="GridView1" runat="server" Width="708px" 
            AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataSourceID="SqlDataSource1" 
            onselectedindexchanged="GridView1_SelectedIndexChanged1" 
            DataKeyNames="EncounterID" CellPadding="2" CellSpacing="1">
            <AlternatingRowStyle BackColor="#A2CC85" />
            <Columns>
                <asp:BoundField DataField="EncounterID" HeaderText = "Consultation Reference No"
                    SortExpression="EncounterID" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="EncounterDateTime" HeaderText="Consultation Date and Time" 
                    SortExpression="EncounterDateTime" />
                <asp:BoundField DataField="Facilitatedby" HeaderText="Facilitated By" 
                    SortExpression="Facilitatedby" />
            </Columns>
            <HeaderStyle BackColor="#009933" />
            <RowStyle HorizontalAlign="Center" />
            <EmptyDataTemplate>No Data to show.</EmptyDataTemplate>
        </asp:GridView>
    </asp:Panel>
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

