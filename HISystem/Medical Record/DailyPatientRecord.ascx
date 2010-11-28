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
    .style28
    {
        font-size: medium;
        height: 38px;
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
        width: 635px;
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
        width: 635px;
        font-size: xx-small;
        height: 43px;
    }
    .style43
    {
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

<asp:Panel ID="Panel1" runat="server" Font-Bold="True" Font-Size="XX-Large" 
    Height="572px" Width="762px" BackColor="#FFFFCC" BorderColor="#666666" 
    BorderStyle="Solid">
    <table style="width:100%; height: 292px;" border="1">
        <tr>
            <td class="style65" colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Size="X-Large" 
                    Text="Daily Patient Record"></asp:Label>
            </td>
            <td class="style13" colspan="4">
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
                <asp:TextBox ID="txtDateNow" runat="server" ReadOnly="True" Width="137px"></asp:TextBox>
                </td>
            
        </tr>
        <tr>
            <td class="style13">
                Name<br /> (LN, FN, MN)</td>
            <td class="style10" colspan="5">
                <asp:TextBox ID="txtlname" runat="server" Width="121px"></asp:TextBox>
                ,
                <asp:TextBox ID="txtfname" runat="server" Width="128px"></asp:TextBox>
                ,&nbsp;<asp:TextBox ID="txtmname" runat="server" Width="79px"></asp:TextBox>
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
            <td class="style42" colspan="5">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="377px"></asp:TextBox>
            </td>
            <td class="style43" colspan="2">
                </td>
            
        </tr>
        <tr>
            <td class="style34">
                Birthdate</td>
            <td class="style35" colspan="5">
                Month:
                <asp:DropDownList ID="dropMonth" runat="server" Height="26px">
                </asp:DropDownList>
                &nbsp;Day:
                <asp:DropDownList ID="dropDay" runat="server" 
                    onselectedindexchanged="dropDay_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;Year: <asp:DropDownList ID="dropYear" runat="server" 
                    onselectedindexchanged="dropYear_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="style28" align="right">
                Age</td>
            <td class="style38">
                <asp:TextBox ID="txtAge" runat="server" Width="50px"></asp:TextBox>
                yrs old</td>
            
        </tr>
        <tr>
            <td class="style57" colspan="8">
                Vital Statistics </td>
            
            
        </tr>
        <tr>
            <td class="style48">
                Temp</td>
            <td class="style30" colspan="4">
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
            <td class="style64" colspan="4">
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
            <td class="style55" colspan="7">
                <asp:TextBox ID="txtDiagnosis" runat="server" Height="81px" TextMode="MultiLine" 
                    Width="415px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style49">
                Treatment/<br /> Recommendation</td>
            <td class="style51" colspan="7">
                <asp:TextBox ID="txtRecomendation" runat="server" Height="81px" TextMode="MultiLine" 
                    Width="415px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style61">
                &nbsp;</td>
            <td class="style63" colspan="2">
                <asp:Button ID="btnSave" runat="server" style="margin-left: 0px" Text="Save" 
                    Width="145px" />
            </td>
            <td class="style63">
                <asp:Button ID="btnReset" runat="server" style="margin-left: 0px" Text="Reset" 
                    Width="145px" />
            </td>
            <td class="style62" colspan="4">
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel>

