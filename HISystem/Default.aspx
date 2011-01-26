<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


    <h2 style="background-color: #d3e7c5">
        Home
    </h2>
    
    

    <br />
    <br />
    <br />
    
    

    <br />

    <center>
<table border="1" cellpadding="1" cellspacing="1">
<tr>
<td rowspan="4">
    <div style="width: 488px">
        <p align="left" style="height: 31px">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" 
                Text="About &gt;&gt;                             "></asp:Label>
        </p>
        <p align="left">
            <b>Paombong Healthcare Information system</b><br />
            <br />
            is a Capstone project of Mapua Institute of Technology, School of Information 
            Technology students aimed to develop an information system to aid the nurses in 
            generating reports, collecting patient information, medicine and equipment 
            inventory and patient medical history.<br />
            <br />
            This system offers Recording and Management of Patient Information.<br />
            <br />
            Medical Records of such Patient Information.
            <br />
            Inventory of the Medicines of Paombong Healthcenter.
        </p>
    </div>
    </td>
<td>Patient Demographics</td>
<td><center><asp:Image ID="Image4" runat="server" ImageUrl="~/images/my.png" Height="71px" 
        Width="94px" /></center></td>
</tr>


<tr>
<td><center><asp:Image ID="Image3" runat="server" ImageUrl="~/images/a.png" Height="80px" /></center></td>
<td>Medical Records</td>
</tr>


<tr>
<td>Inventory</td>
<td><center><asp:Image ID="Image1" runat="server" ImageUrl="~/images/ax.png" Height="73px" 
        Width="82px" /></center></td>
</tr>


<tr>
<td><center><asp:Image ID="Image2" runat="server" ImageUrl="~/images/aa.png" Height="77px" 
        Width="86px" /></center></td>
<td>Reports</td>
    
</tr>

</table>
</center>
    <br />

    

<br />

    <%--<center>
    <img alt="" src="images/bg3.png" style="margin-top: 38px" />
    </center>--%>
    

</asp:Content>

