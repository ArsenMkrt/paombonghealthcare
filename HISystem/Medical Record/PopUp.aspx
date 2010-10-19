<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUp.aspx.cs" Inherits="Medical_Record_PopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 682px; width: 902px">
        <p>
        <asp:SqlDataSource ID="Barangay" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [BarangayName] FROM [Barangays] ORDER BY [BarangayName]">
        </asp:SqlDataSource>
        <br />
    </p>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="Barangay" 
            DataTextField="BarangayName" DataValueField="BarangayName" 
            style="top: 54px; left: 185px; position: absolute; height: 22px; width: 201px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" 
            style="top: 55px; left: 460px; position: absolute; height: 19px; width: 67px" 
            Text="Last Name"></asp:Label>
        <asp:TextBox ID="txtLName" runat="server" 
            
            style="top: 54px; left: 594px; position: absolute; height: 22px; width: 201px"></asp:TextBox>

        <asp:Label ID="Label3" runat="server" 
            style="top: 56px; left: 77px; position: absolute; height: 19px; width: 34px" 
            Text="Barangay"></asp:Label>
        <p>

            &nbsp;<asp:Panel 
            ID="panelGridView" runat="server" ScrollBars="Vertical" 
        
            
            style="top: 123px; left: 72px; position: absolute; height: 397px; width: 822px">
        
        <script type="text/javascript">
            function GetRowValue(val) {
                // hardcoded value used to minimize the code.
                // ControlID can instead be passed as query string to the popup window
                window.opener.document.getElementById("txtPatient").value = val;                
                window.close();
            }
        </script>
        
        
        <asp:GridView ID="GridViewPatient" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="PatientID" Height="403px" Width="817px" 
                onrowdatabound="GridViewPatient_RowDataBound" 
                onselectedindexchanged="GridViewPatient_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="PatientID" HeaderText="PatientId" 
                    InsertVisible="False" ReadOnly="True" SortExpression="PatientID" />
                <asp:BoundField DataField="PtFname" HeaderText="Name" 
                    SortExpression="PtFname" />
                <asp:BoundField DataField="PtMname" HeaderText="Barangay" 
                    SortExpression="PtMname" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="Patient" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT * FROM [Patients]"></asp:SqlDataSource>
    </asp:Panel>
             <asp:Button ID="Button1" runat="server" 
            style="top: 580px; left: 386px; position: absolute; height: 26px; width: 129px" 
            Text="Close" onclick="Button1_Click" /></div>
    </form>
</body>
</html>
