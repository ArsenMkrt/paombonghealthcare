<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DailyPatientRecord.ascx.cs" Inherits="Medical_Record_LifestyleCheck" %>
<style type="text/css">
    .style10
    {
        width: 635px;
        height: 34px;
    }
    .style11
    {
        height: 34px;
        font-size: medium;
        width: 268435488px;
    }
    .style13
    {
        font-size: medium;
        height: 34px;
    }
    .style18
    {
        font-size: medium;
    }
    .style20
    {
        width: 286px;
        font-size: medium;
        height: 43px;
    }
    .style29
    {
        font-size: medium;
        height: 47px;
    }
    .style30
    {
        width: 194px;
        font-size: xx-small;
        height: 47px;
    }
    .style34
    {
        width: 286px;
        font-size: medium;
        height: 38px;
    }
    .style35
    {
        font-size: medium;
        height: 38px;
    }
    .style37
    {
        width: 296px;
        font-size: medium;
        height: 34px;
    }
    .style38
    {
        width: 296px;
        font-size: medium;
        height: 38px;
    }
    .style42
    {
        font-size: xx-small;
        height: 43px;
    }
    .style45
    {
        width: 485px;
        font-size: medium;
        height: 47px;
    }
    .style46
    {
        width: 485px;
        font-size: medium;
        height: 30px;
    }
    .style48
    {
        width: 286px;
        font-size: medium;
        height: 47px;
    }
    .style49
    {
        width: 286px;
        font-size: medium;
        height: 77px;
    }
    .style51
    {
        font-size: medium;
        height: 77px;
    }
    .style52
    {
        width: 286px;
        font-size: medium;
        height: 30px;
    }
    .style53
    {
        font-size: medium;
        height: 30px;
    }
    .style55
    {
        font-size: medium;
        height: 46px;
    }
    .style56
    {
        width: 286px;
        font-size: medium;
        height: 46px;
    }
    .style57
    {
        font-size: large;
        height: 23px;
    }
    .style61
    {
        width: 62px;
        font-size: medium;
        height: 28px;
    }
    .style62
    {
        font-size: medium;
        height: 28px;
    }
    .style63
    {
        width: 103px;
        font-size: medium;
        height: 28px;
    }
    .style64
    {
        font-size: medium;
        height: 30px;
        width: 194px;
    }
    .style65
    {
        width: 113px;
        font-size: medium;
        height: 34px;
    }
</style>


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
&nbsp;<asp:DropDownList ID="dropMonth" runat="server" Height="26px">
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
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                Barangay<br />
                <asp:DropDownList ID="ddlBarangay" runat="server" 
        DataSourceID="Barangay" DataTextField="BarangayName" 
        DataValueField="BarangayName" style="margin-left: 56px">
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


