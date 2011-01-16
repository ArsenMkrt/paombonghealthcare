using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_UsersAndRoles : System.Web.UI.Page
{


    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Bind the users and roles
            BindUsersToUserList();
            BindRolesToList();

            // Check the selected user's roles
            CheckRolesForSelectedUser();

            // Display those users belonging to the currently selected role
            DisplayUsersBelongingToRole();
        }
        
    }

    private void BindRolesToList()
    {
        // Get all of the roles
        string[] roles = Roles.GetAllRoles();
      

        RoleList.DataSource = roles;
        RoleList1.DataSource = roles;
        RoleList.DataBind();
        RoleList1.DataBind();
    }

    #region 'By User' Interface-Specific Methods
    private void BindUsersToUserList()
    {
        // Get all of the user accounts
        MembershipUserCollection users = Membership.GetAllUsers();
        UserList.DataSource = users;
        UserList.DataBind();
    }

    protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckRolesForSelectedUser();
    }

    private void CheckRolesForSelectedUser()
    {
        // Determine what roles the selected user belongs to
        string selectedUserName = UserList.SelectedValue;
        string[] selectedUsersRoles = Roles.GetRolesForUser(selectedUserName);
        
        if (Roles.IsUserInRole(selectedUserName, "Doctor"))
        {
            RoleList1.SelectedValue = "Doctor";
            Session["selectedUsersRole"] = "Doctor";
        }
        else if (Roles.IsUserInRole(selectedUserName, "Nurse"))
        {
            RoleList1.SelectedValue = "Nurse";
            Session["selectedUsersRole"] = "Nurse";
        }
        else if (Roles.IsUserInRole(selectedUserName, "Midwife"))
        {
            RoleList1.SelectedValue = "Midwife";
           Session["selectedUsersRole"] = "Midwife";
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["selectedUsersRole"] != null)
        {
            if (Session["selectedUsersRole"] != "Doctor")
            {
            Roles.RemoveUserFromRole(UserList.SelectedValue, Session["selectedUsersRole"].ToString());
            Roles.AddUserToRole(UserList.SelectedValue, RoleList1.SelectedValue);
            ActionStatus.Text = "Successfully assigned/changed to role!";
            }
            else
                ActionStatus.Text = "You are not allowed to demote or lower the rank of another doctor account.";
        }
        else
            ActionStatus.Text = "Please select User first.";
    }
    protected void RoleCheckBox_CheckChanged(object sender, EventArgs e)
    {
        // Reference the CheckBox that raised this event
        CheckBox RoleCheckBox = sender as CheckBox;

        // Get the currently selected user and role 
        string selectedUserName = UserList.SelectedValue;
        string roleName = RoleCheckBox.Text;

        // Determine if we need to add or remove the user from this role
        if (RoleCheckBox.Checked)
        {
            // Add the user to the role
            Roles.AddUserToRole(selectedUserName, roleName);

            // Display a status message
            ActionStatus.Text = string.Format("User {0} was added to role {1}.", selectedUserName, roleName);
        }
        else
        {
            // Remove the user from the role
            Roles.RemoveUserFromRole(selectedUserName, roleName);

            // Display a status message
            ActionStatus.Text = string.Format("User {0} was removed from role {1}.", selectedUserName, roleName);
        }

        // Refresh the "by role" interface
        DisplayUsersBelongingToRole();
    }
    #endregion

    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }

    #region 'By Role' Interface-Specific Methods
    protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayUsersBelongingToRole();
    }

    private void DisplayUsersBelongingToRole()
    {
        // Get the selected role
        string selectedRoleName = RoleList.SelectedValue;

        // Get the list of usernames that belong to the role
        string[] usersBelongingToRole = Roles.GetUsersInRole(selectedRoleName);

        // Bind the list of users to the GridView
        RolesUserList.DataSource = usersBelongingToRole;
        RolesUserList.DataBind();
    }

    protected void RolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        // Get the selected role
        string selectedRoleName = RoleList.SelectedValue;
        if (selectedRoleName != "Doctor")
        {
            // Reference the UserNameLabel
            Label UserNameLabel = RolesUserList.Rows[e.RowIndex].FindControl("UserNameLabel") as Label;

            // Remove the user from the role
            Roles.RemoveUserFromRole(UserNameLabel.Text, selectedRoleName);

            // Refresh the GridView
            DisplayUsersBelongingToRole();

            // Display a status message
            ActionStatus.Text = string.Format("User {0} was removed from role {1}.", UserNameLabel.Text, selectedRoleName);

            // Refresh the "by user" interface
            CheckRolesForSelectedUser();
        }
        else
        {
            ActionStatus.Text = "You cannot remove a user from Doctor role.";
        }
    }

    //protected void AddUserToRoleButton_Click(object sender, EventArgs e)
    //{
    //    // Get the selected role and username
    //    string selectedRoleName = RoleList.SelectedValue;
    //    string userNameToAddToRole = UserNameToAddToRole.Text;

    //    // Make sure that a value was entered
    //    if (userNameToAddToRole.Trim().Length == 0)
    //    {
    //        ActionStatus.Text = "You must enter a username in the textbox.";
    //        return;
    //    }

    //    // Make sure that the user exists in the system
    //    MembershipUser userInfo = Membership.GetUser(userNameToAddToRole);
    //    if (userInfo == null)
    //    {
    //        ActionStatus.Text = string.Format("The user {0} does not exist in the system.", userNameToAddToRole);
    //        return;
    //    }

    //    // Make sure that the user doesn't already belong to this role
    //    if (Roles.IsUserInRole(userNameToAddToRole, selectedRoleName))
    //    {
    //        ActionStatus.Text = string.Format("User {0} already is a member of role {1}.", userNameToAddToRole, selectedRoleName);
    //        return;
    //    }

    //    // If we reach here, we need to add the user to the role
    //    Roles.AddUserToRole(userNameToAddToRole, selectedRoleName);

        

    //    // Refresh the GridView
    //    DisplayUsersBelongingToRole();

    //    // Display a status message
    //    ActionStatus.Text = string.Format("User {0} was added to role {1}.", userNameToAddToRole, selectedRoleName);

    //    // Refresh the "by user" interface
    //    CheckRolesForSelectedUser();
    //}
    #endregion
    protected void RoleList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
}