using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_Add_Users : System.Web.UI.Page
{

    MembershipUser user;

    private void Page_Load()
    {
        if (!Page.IsPostBack)
        {
            // Bind the users and roles
            
            BindRolesToList();

       
            
        }
    }

    private void BindRolesToList()
    {
        // Get all of the roles
        string[] roles = Roles.GetAllRoles();


        
        RoleList1.DataSource = roles;
        
        RoleList1.DataBind();
    }
    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void AddUser()
    {
        // Add User.
        MembershipUser newUser = Membership.CreateUser(username.Text, password.Text, email.Text);
        newUser.Comment = comment.Text;
        Membership.UpdateUser(newUser);


        Roles.AddUserToRole(username.Text, RoleList1.SelectedValue);
        

       
        Response.Write("<script> window.alert('Added User Successfully.')</script>");


        //clear textboxes
        username.Text = string.Empty;
        password.Text = string.Empty;
        email.Text = string.Empty;
        comment.Text = string.Empty;


    }

       protected void btn_addUser_Click(object sender, EventArgs e)
    {

        try
        {
            AddUser();
           
            // Response.Redirect("~/Public/Login.aspx");
        }
        catch (Exception ex)
        {
            ConfirmationMessage.InnerText = "Insert Failure: " + ex.Message;
        }
       
    }
    protected void RoleList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}