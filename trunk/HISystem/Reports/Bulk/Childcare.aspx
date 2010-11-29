<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="Childcare.aspx.cs" Inherits="Reports_Bulk_Childcare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <asp:Label ID="lbl_Indicator" runat="server" Text="Choose Indicator:"></asp:Label>
&nbsp;
    <asp:DropDownList ID="dropIndicator" runat="server" Height="28px" 
    Width="139px">
        <asp:ListItem>Infant given vit A</asp:ListItem>
        <asp:ListItem>Infant given ...</asp:ListItem>
    </asp:DropDownList>
    
    <br />
    <br />
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <table cellpadding="3" cellspacing="0" rules="all" 
                style="border: solid 2px #336699;">
                <tr style="background-color: #336699; color: White;">
                    <th>
                        BrgyID</th>
                    <th>
                        Barangay</th>
                    <th>
                        Population</th>
                    <th>
                        Male</th>
                    <th>
                        Female</th>
                    <th>
                        Total</th>
                    <th>
                        Percent</th>
                </tr>
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="lblBrgyID" runat="server" Text='<%# Bind("BarangayID") %>' />
                </td>
                <td>
                    <asp:Label ID="lblBrgy" runat="server" Text='<%# Bind("BarangayName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="txtPopu" runat="server" 
                        onkeydown="javascript:return CalculateValue(this);" Text="0" />
                </td>
                <td>
                    <asp:TextBox ID="txtMale" runat="server" 
                        onkeyup="javascript:return CalculateValue(this);" Text="0" 
                        ValidationGroup="check" Width="69px" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtMale" Display="Dynamic" ErrorMessage="X" 
                        ForeColor="Maroon" SetFocusOnError="True" ValidationExpression="[0-9]*" 
                        ValidationGroup="check"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtFemale" runat="server" 
                        onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)" 
                        onpaste="return false;" Text="0" Width="69px" />
                </td>
                <td>
                    <asp:TextBox ID="txtTotal" runat="server" ReadOnly="true" Text="0" 
                        Width="85px" />
                </td>
                <td>
                    <asp:TextBox ID="txtPercent" runat="server" ReadOnly="true" Text="0" 
                        Width="85px" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:Button ID="btnSave" runat="server" onclick="Button1_Click" Text="Save" 
        Width="136px" />
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:geraldNov30 %>" 
        SelectCommand="SELECT [BarangayID], [BarangayName] FROM [Barangays]">
    </asp:SqlDataSource>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>

