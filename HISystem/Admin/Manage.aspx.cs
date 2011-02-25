using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int year = 2010; year <= 2100; year++)
        {
            ddlYear.Items.Add(year.ToString());
            ddlYear0.Items.Add(year.ToString());
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
    
    protected void btnEdit_Click(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
}