using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class SiteTemplate : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {   //is logged user a doctor
            if (!Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Doctor"))
            {

                //make hyperlink invisible
                lbl_AdminPrivileges.Visible = false;
                HyperLinktoManageRoles.Visible = false;
                HyperLinktoAddUser.Visible = false;
                return;
            }
        }
        catch (HttpException exc)
        {
            //display error msg
            return;
        }

    }
}
