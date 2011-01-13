﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Public_SessionExpired : System.Web.UI.Page
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}