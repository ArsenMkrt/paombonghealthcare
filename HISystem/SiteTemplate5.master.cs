using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;

public partial class SiteTemplate3 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Doctor") && Page.Request.IsAuthenticated)
        //{
        //    //make hyperlink invisible
        //    lbl_AdminPrivileges.Visible = true;
        //    imgBtn_addUser.Visible = true;
        //    imgBtn_ManageUser.Visible = true;


        //    img_UserRole.ImageUrl = "~/images/doctor.png";
        //    img_UserRole.ToolTip = "You are logged in as Doctor!";
        //    return;
        //}
        //else if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Midwife") && Page.Request.IsAuthenticated)
        //{
        //    img_UserRole.ImageUrl = "~/images/midwife.png";
        //    img_UserRole.ToolTip = "You are logged in as Midwife!";

        //}
        //else if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Nurse") && Page.Request.IsAuthenticated)
        //{
        //    img_UserRole.ImageUrl = "~/images/nurse.png";
        //    img_UserRole.ToolTip = "You are logged in as Nurse!";
        //}





        //redirect to login in 5 seconds
        if (Request.Url.AbsolutePath.EndsWith("SessionExpired.aspx", StringComparison.InvariantCultureIgnoreCase))
        {
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "5; URL=./Login.aspx";
            Page.Header.Controls.Add(meta);
        }
        //    //do not redirect if page is login
        else if (Request.IsAuthenticated || HttpContext.Current.User.Identity.IsAuthenticated)
        {

            string url = Page.ResolveUrl(@"~/Public/SessionExpired.aspx");
            HttpContext.Current.Response.AppendHeader("Refresh", Convert.ToString((Session.Timeout * 10)) + "; Url=" + url);

        }


    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        // if(Context.Session != null && Context.Session.IsNewSession == true && Page.Request.Headers["Cookie"] != null && Page.Request.Headers["Cookie"].IndexOf("ASP.NET_SessionId") >= 0)



       


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
