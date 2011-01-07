<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="Add Users.aspx.cs" Inherits="Admin_Add_Users" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


<br />
<center>
    
        <table align="left" class="webparts" bgcolor="#a2cc85" style="width: 470px">
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
                    <table style="width: 316px">
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
                                User Name*
                                <br />
                                <asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="required field" 
                                    Font-Italic="True" Font-Size="Small" ControlToValidate="username"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="username" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="detailheader">
                                Password*
                                <br />

                                <asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator2" runat="server" ErrorMessage="required field" 
                                    Font-Italic="True" Font-Size="Small" ControlToValidate="password"></asp:RequiredFieldValidator>

                                </td>
                            <td>
                                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="detailheader">
                                Email*
                                <br />
                                
                                <asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="required field" 
                                    Font-Italic="True" Font-Size="Small" ControlToValidate="email"></asp:RequiredFieldValidator>
                                
                                </td>
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
                                &nbsp;<asp:Button ID="btn_addUser" runat="server" 
                                    Text="Add User" onclick="btn_addUser_Click" Width="67px" />
                                &nbsp;
                                <input type="reset" style="width: 60px" />
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

