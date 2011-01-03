using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class SiteTemplate4 : System.Web.UI.MasterPage
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Doctor"))
        {
            //make hyperlink invisible
            
            lbl_AdminPrivileges.Visible = false;
            imgBtn_addUser.Visible = false;
            imgBtn_ManageUser.Visible = false;

            return;
        }


    }
    protected void imgBtn_addUser_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Admin/Add Users.aspx");
    }
    protected void imgBtn_ManageUser_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Admin/UsersAndRoles.aspx");
    }
}
