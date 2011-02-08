using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;


/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage:System.Web.UI.MasterPage
{
    private static string _redirectUrl;
    public static string RedirectUrl
    {
        get { return _redirectUrl; }
        set { _redirectUrl = value; }
    }

        
	public BasePage()
	{
		_redirectUrl = string.Empty;
		
	}

    override protected void OnInit(EventArgs e)
    {
        //initialize our base class (System.Web,UI.Page)
        base.OnInit(e);

        if ((!Request.Url.AbsolutePath.EndsWith("SessionExpired.aspx", StringComparison.InvariantCultureIgnoreCase)) && (!Request.Url.AbsolutePath.EndsWith("Login.aspx", StringComparison.InvariantCultureIgnoreCase)) && (!Request.Url.AbsolutePath.EndsWith("Default.aspx", StringComparison.InvariantCultureIgnoreCase)) && Context.Session != null && Context.Session.IsNewSession == true && Page.Request.Headers["Cookie"] != null && Page.Request.Headers["Cookie"].IndexOf("ASP.NET_SessionId") >= 0)
        {

            //since it's a new session but a ASP.Net cookie exist we know
            //the session has expired so we need to redirect them

            // session has timed out, log out the user
            if (Page.Request.IsAuthenticated || HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Session.Clear();

            }
            Response.Redirect("~/Public/SessionExpired.aspx");

            

        }
        else if ((Request.Url.AbsolutePath.EndsWith("SessionExpired.aspx", StringComparison.InvariantCultureIgnoreCase)) && Context.Session != null && Context.Session.IsNewSession == true && Page.Request.Headers["Cookie"] != null && Page.Request.Headers["Cookie"].IndexOf("ASP.NET_SessionId") >= 0)
        {
            //redirect to login in 5 seconds
            if (Request.Url.AbsolutePath.EndsWith("SessionExpired.aspx", StringComparison.InvariantCultureIgnoreCase))
            {
                string url = Page.ResolveUrl(@"~/Public/Login.aspx");
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                //meta.Content = "5; URL=./Login.aspx";
                meta.Content = "5; URL="+url;
                Page.Header.Controls.Add(meta);
            }
        }
        else
        {
            if (Page.Request.IsAuthenticated)
            {
                string url = Page.ResolveUrl(@"~/Public/SessionExpired.aspx");
                HttpContext.Current.Response.AppendHeader("Refresh", Convert.ToString((Session.Timeout * 302)) + "; Url=" + url);
            }
            else if(!Page.Request.IsAuthenticated)
            {

            }
            else
                MessageBox.Show("debug if does not fall under first conditions");

        }
       
    }

    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-2d));
        Response.Cache.SetNoStore();
        Response.Cache.SetValidUntilExpires(false);
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-2d);
        Response.Expires = -1500;
        Response.AppendHeader("Pragma", "no-cache");
    }

  
}