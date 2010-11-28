<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="UsersAndRoles.aspx.cs" Inherits="Admin_UsersAndRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .Important
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <br />
     <br /> 
    <asp:Panel ID="Panel1" runat="server" Height="542px" Width="428px" 
        BackColor="#00CCFF">
    
    
     <h2>User Role Management</h2>
    <p align="center">
        <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>
    </p>
        <hr style="height: -12px" />
        <h3>
            Manage Roles By User</h3>
    <p>
        <b>Select a User:</b>
        <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True" 
            DataTextField="UserName" DataValueField="UserName" 
            onselectedindexchanged="UserList_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Repeater ID="UsersRoleList" runat="server">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="RoleCheckBox" AutoPostBack="true" Text='<%# Container.DataItem %>' OnCheckedChanged="RoleCheckBox_CheckChanged" />
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </p>
    
        <hr style="height: -12px" />
    
    <h3>Manage Users By Role</h3>
    <p>
        <b>Select a Role:</b>
        <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="true" 
            onselectedindexchanged="RoleList_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False" 
            EmptyDataText="No users belong to this role." 
            onrowdeleting="RolesUserList_RowDeleting">
            <Columns>
                <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
                <asp:TemplateField HeaderText="Users">
                    <ItemTemplate>
                        <asp:Label runat="server" id="UserNameLabel" Text='<%# Container.DataItem %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </p>

    <table>
    <tr>
    <td><b>UserName:</b></td>
    <td> <asp:TextBox ID="UserNameToAddToRole" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td colspan="2">
     <asp:Button ID="AddUserToRoleButton" runat="server" Text="Add User to Role" 
            onclick="AddUserToRoleButton_Click" Width="208px" />
    </td>
    </tr>
    </table>
    <p>
        
       
        <br />
       
    </p>
    <br />
    </asp:Panel>




</asp:Content>

