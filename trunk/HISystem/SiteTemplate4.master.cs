using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;

public partial class SiteTemplate4 : System.Web.UI.MasterPage
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        // if(Context.Session != null && Context.Session.IsNewSession == true && Page.Request.Headers["Cookie"] != null && Page.Request.Headers["Cookie"].IndexOf("ASP.NET_SessionId") >= 0)


        //redirect to login in 5 seconds
        if (Request.Url.AbsolutePath.EndsWith("SessionExpired.aspx", StringComparison.InvariantCultureIgnoreCase))
        {
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "5; URL=./Login.aspx";
            Page.Header.Controls.Add(meta);
        }
        else if (!Request.Url.AbsolutePath.EndsWith("Login.aspx", StringComparison.InvariantCultureIgnoreCase))
        {
            HttpContext.Current.Response.AppendHeader("Refresh", Convert.ToString((Session.Timeout * 25)) + "; Url=./Public/SessionExpired.aspx");
        }
       // else
        //    HttpContext.Current.Response.AppendHeader("Refresh", Convert.ToString((Session.Timeout * 60)) + "; Url=./Public/SessionExpired.aspx");
    }

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




        if (Context.Session != null && Context.Session.IsNewSession == true && Page.Request.Headers["Cookie"] != null &&  Page.Request.Headers["Cookie"].IndexOf("ASP.NET_SessionId") >= 0)
        {
            // session has timed out, log out the user
            if (Page.Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
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
}
