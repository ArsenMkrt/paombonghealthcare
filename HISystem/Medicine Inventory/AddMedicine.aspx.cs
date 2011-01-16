using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Medicine_Inventory_AddMedicine : System.Web.UI.Page
{
    private DataAccess data;
    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        data = new DataAccess();
        if (data.HasMedicineName(txtMedicineName.Text))
            Response.Write("<script> window.alert('Medicine Exists.')</script>");
        else
        {
            data.AddMedicine(txtMedicineName.Text,ddlCategory.Text,Convert.ToInt32(txtQuantity.Text.Trim()));
            Response.Write("<script> window.alert('Medicine Successfully Added.')</script>");
            Response.Redirect("AddMedicine.aspx");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMedicine.aspx");
    }
}