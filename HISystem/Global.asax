<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        
        

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs


       
        Exception objErr = Server.GetLastError().GetBaseException();
        string err = "Error in: " + Request.Url.ToString() +
                          ". Error Message:" + objErr.Message.ToString();

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

        //if (!Request.Url.AbsolutePath.EndsWith("Public/SessionExpired.aspx", StringComparison.InvariantCultureIgnoreCase)) 
        //{ 
        //    Response.Redirect("~/Public/Login.aspx"); 
        //}
        
        
        
        //Session["UserID"] =UserID;

        //Session["Password"] Password;
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.



        Session.Abandon();
        //FormsAuthentication.SignOut();

    }
       
</script>
