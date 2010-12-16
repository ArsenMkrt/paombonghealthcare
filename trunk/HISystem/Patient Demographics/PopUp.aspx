<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUp.aspx.cs" Inherits="Patient_Demographics_PopUp" %>

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
            style="top: 105px; left: 78px; position: absolute; height: 19px; width: 67px" 
            Text="Last Name"></asp:Label>
        <asp:TextBox ID="txtLName" runat="server" 
            style="top: 104px; left: 186px; position: absolute; height: 22px; width: 201px"></asp:TextBox>
        <asp:TextBox ID="txtFName" runat="server" 
            style="top: 105px; left: 526px; position: absolute; height: 22px; width: 205px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" 
            style="top: 56px; left: 77px; position: absolute; height: 19px; width: 34px" 
            Text="Barangay"></asp:Label>
        <asp:Label ID="Label5" runat="server" 
            style="top: 106px; left: 442px; position: absolute; height: 19px; width: 78px" 
            Text="First Name"></asp:Label>

            <asp:Panel ID="panelGridView" runat="server" ScrollBars="Vertical" 
        style="top: 183px; left: 70px; position: absolute; height: 433px; width: 822px">
        <asp:GridView ID="GridViewPatient" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="PatientID" Height="433px" Width="817px">
            <Columns>
                <asp:BoundField DataField="PatientID" HeaderText="Patient Id" 
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
            &nbsp;
             <asp:Button ID="Button1" runat="server" 
            style="top: 646px; left: 373px; position: absolute; height: 26px; width: 129px" 
            Text="Close" /></div>
    </form>
</body>
</html>
