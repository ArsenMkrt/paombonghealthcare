<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="UsersAndRoles.aspx.cs" Inherits="Admin_UsersAndRoles" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .Important
        {
            text-align: left;
        }
    </style>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


    
    
    

    
    
    
     <h2 style="background-color: #d3e7c5">User Role Management</h2>
    <p align="left">
        <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>
    </p>
        <hr style="height: -12px" />
        <table style="width: 308px" bgcolor="#D3E7C5">
            <tr>
                <td colspan="2" style="height: 41px">
                    
                        <center><h3>Manage Roles By User</h3></center>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 24px">
                </td>
            </tr>
            <tr>
                <td style="width: 152px">
                    <b>Select a User:</b></td>
                <td>
                    <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True" 
                        DataTextField="UserName" DataValueField="UserName" 
                        onselectedindexchanged="UserList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 152px">
                    <b>Choose Role:</b>&nbsp;&nbsp;</td>
                <td>
                    <asp:DropDownList ID="RoleList1" runat="server" 
                        onselectedindexchanged="RoleList1_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <center style="height: 33px">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        Text="Assign/Change Role" Width="187px" Height="29px" /></center>
                </td>
            </tr>
            </table>
    <br />





    
    
        <br/>

        <table style="width: 308px" bgcolor="#D3E7C5">
            <tr>
                <td colspan="2" style="height: 40px">
                    <center><h3>Manage Users By Role</h3></center>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 24px">
                    </td>
            </tr>
            <tr>
                <td style="width: 135px">
                    <b>Select a Role:</b></td>
                <td>
                    <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="RoleList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                   
                      <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False" 
                        EmptyDataText="No users belong to this role." 
                        onrowdatabound="RolesUserList_RowDataBound" 
                        onrowdeleting="RolesUserList_RowDeleting">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkBtn_Delete" runat="server" CausesValidation="True" 
                                        CommandName="Delete" Text="Remove"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Users">
                                <ItemTemplate>
                                    <asp:Label ID="UserNameLabel" runat="server" Text="<%# Container.DataItem %>"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblHint" runat="server" Font-Bold="False" Font-Size="Small" 
                        ForeColor="#666666" Visible="False">*You can only view users from this Role</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 135px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

    
    
    
    
    <br />






</asp:Content>

