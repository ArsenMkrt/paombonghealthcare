<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="Childcare.aspx.cs" Inherits="Reports_Bulk_Childcare" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <h2>Consolidated Report</h2>
    <asp:Label ID="lbl_Indicator" runat="server" Text="Choose Indicator:"></asp:Label>
&nbsp;
    <asp:DropDownList ID="dropIndicator" runat="server" Height="20px" 
    Width="261px" DataSourceID="Indicator" DataTextField="IndicatorData" 
        DataValueField="IndicatorData">
    </asp:DropDownList>
    
    <br />
    <br />
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <table cellpadding="3" cellspacing="0" rules="all" 
                style="border: solid 2px #2c6402;" bgcolor="#a2cc85">
                <tr style="background-color: #2c6402; color: White;">
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
    <asp:SqlDataSource ID="Indicator" runat="server" 
        ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString2 %>" 
        
        SelectCommand="SELECT [IndicatorData] FROM [Indicator] WHERE [ProgramCategoryID]='3333'">
    </asp:SqlDataSource>

    




   


</asp:Content>

