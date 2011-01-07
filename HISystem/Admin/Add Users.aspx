<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="Add Users.aspx.cs" Inherits="Admin_Add_Users" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


<br />
<br />
<center>
    
        <table align="left" class="webparts" bgcolor="#a2cc85" style="width: 1000px">
            <tr>
                <th class="style1">
                    Add User</th>
            </tr>
            <tr>
                <td class="details" valign="top">
                    <h3>
                        Roles:</h3>
                    <asp:CheckBoxList ID="UserRoles" runat="server" />
                    <h3>
                        Main Info:</h3>
                    <table>
                        <tr>
                            <td class="detailheader">
                                Active User</td>
                            <td>
                                <asp:CheckBox ID="isapproved" runat="server" 
                            Checked="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="detailheader">
                                User Name</td>
                            <td>
                                <asp:TextBox ID="username" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="detailheader">
                                Password</td>
                            <td>
                                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="detailheader">
                                Email</td>
                            <td>
                                <asp:TextBox ID="email" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="detailheader">
                                Description</td>
                            <td>
                                <asp:TextBox ID="comment" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <input type="submit" value="Add User" />
                                &nbsp;
                                <input type="reset" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="ConfirmationMessage" runat="server" 
                            class="alert">
                                </div>
                            </td>
                        </tr>
                    </table>
                    <asp:ObjectDataSource ID="MemberData" runat="server" 
                DataObjectTypeName="System.Web.Security.MembershipUser" SelectMethod="GetUser" 
                TypeName="System.Web.Security.Membership" UpdateMethod="UpdateUser">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="username" 
                        QueryStringField="username" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        </center>
    




</asp:Content>

