using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Public_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //check if page was redirected to login from restricted access
        if (!Page.IsPostBack)
        {

            if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                Response.Redirect("AccessDenied.aspx");
            if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                Response.Redirect("AccessDenied.aspx");

        }
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }
    protected void ClearButton_Click(object sender, EventArgs e)
    {
        
        
    }
}