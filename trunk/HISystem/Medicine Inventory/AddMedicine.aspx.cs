using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Medicine_Inventory_AddMedicine : System.Web.UI.Page
{
    private DataAccess data;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        data = new DataAccess();
        data.AddMedicine(txtMedicineName.Text,ddlCategory.Text,Convert.ToInt32(txtQuantity.Text.Trim()));
        Response.Redirect("AddMedicine.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMedicine.aspx");
    }
}