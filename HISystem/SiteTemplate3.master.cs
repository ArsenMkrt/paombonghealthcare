using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class SiteTemplate3 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Doctor"))
        {

            //make hyperlink invisible
            lbl_AdminPrivileges.Visible = false;
            HyperLinktoManageRoles.Visible = false;
            HyperLinktoAddUser.Visible = false;
            return;
        }
    }
}
