using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.Services;

public partial class SiteTemplate3 : BasePage
{

    

    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Page.Request.IsAuthenticated)
            {
                if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Doctor") && Page.Request.IsAuthenticated)
                {
                    //make hyperlink invisible
                    lbl_AdminPrivileges.Visible = true;
                    imgBtn_addUser.Visible = true;
                    imgBtn_ManageUser.Visible = true;
                    imgbtn_manage.Visible = true;


                    img_UserRole.ImageUrl = "~/images/doctor.png";
                    img_UserRole.ToolTip = "You are logged in as Doctor!";
                    menu.DataSourceID = "SiteMapDataSource1";
                    return;
                }
                else if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Midwife") && Page.Request.IsAuthenticated)
                {
                    img_UserRole.ImageUrl = "~/images/midwife.png";
                    img_UserRole.ToolTip = "You are logged in as Midwife!";
                    menu.DataSourceID = "SiteMapDataSource3";

                }
                else if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Nurse") && Page.Request.IsAuthenticated)
                {
                    img_UserRole.ImageUrl = "~/images/nurse.png";
                    img_UserRole.ToolTip = "You are logged in as Nurse!";
                    menu.DataSourceID = "SiteMapDataSource2";
                }
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


    protected void imgbtn_manage_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Admin/Manage.aspx");
    }
}
