using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Medicine_Inventory_Inventory : System.Web.UI.Page
{
    private DataAccess data;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["new"] == null)
        {
            data = new DataAccess();
            data.RefreshGridviewMedicine(gridviewMedicine);
            data.RefreshGridviewByQuantityLow(GridView1);
        }
    }
    protected void btnAddToList_Click(object sender, EventArgs e)
    {

    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["new"] = "NO";
        gridviewMedicine.DataSource = null;
        gridviewMedicine.DataBind();
        gridviewMedicine.Dispose();
      
        data = new DataAccess();
        data.RefreshGridviewMedicineByCategory(gridviewMedicine,ddlCategory.Text);
        
        data.RefreshGridviewByQuantityLow(GridView1);
    }
    protected void gridviewMedicine_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMedicineId.Text = gridviewMedicine.Rows[gridviewMedicine.SelectedIndex].Cells[1].Text;
        txtMedicineName.Text = gridviewMedicine.Rows[gridviewMedicine.SelectedIndex].Cells[2].Text;
    }
 
    protected void txtNameSearch_TextChanged(object sender, EventArgs e)
    {
        //Session["new"] = "NO";
        //gridviewMedicine.DataSource = null;
        //gridviewMedicine.DataBind();
        //gridviewMedicine.Dispose();

        //data = new DataAccess();
        //data.RefreshGridviewMedicineByName(gridviewMedicine, txtNameSearch.Text.Trim());
    }
    protected void ddlCategoryForItemShow_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["new"] = "NO";
        gridviewMedicine.DataSource = null;
        gridviewMedicine.DataBind();
        gridviewMedicine.Dispose();

        data = new DataAccess();
        data.RefreshGridviewMedicineByCategory(GridView1, ddlCategory.Text);

        data.RefreshGridviewMedicine(gridviewMedicine);
    }
    protected void txtQuantityLimit_TextChanged(object sender, EventArgs e)
    {
        Session["new"] = "NO";
        gridviewMedicine.DataSource = null;
        gridviewMedicine.DataBind();
        gridviewMedicine.Dispose();

        data = new DataAccess();
        data.RefreshGridviewByQuantityLowConfig(GridView1, Convert.ToInt32(txtQuantityLimit.Text.Trim()));

        data.RefreshGridviewMedicine(gridviewMedicine);
    }
}