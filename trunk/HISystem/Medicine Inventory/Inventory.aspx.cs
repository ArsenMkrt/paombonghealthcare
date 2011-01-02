using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;

public partial class Medicine_Inventory_Inventory : System.Web.UI.Page
{
    private DataAccess data;
    private DataTable dt;
    private DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        /*Lakhi Finished*/

        if (Session["new"] == null)
        {
            data = new DataAccess();
            data.RefreshGridviewMedicine(gridviewMedicine);
            data.RefreshGridviewByQuantityLowConfig(GridView1,Convert.ToInt32(txtQuantityLimit.Text));
        }
        ds = new DataSet();
        dt = new DataTable();
        dt.Columns.Add("MedicineId");
        dt.Columns.Add("MedicineName");
        dt.Columns.Add("Quantity");
        Session["Quantity"] = txtQuantityLimit.Text;
        Session["Category"] = ddlCategory.Text;
        Session["MedicineName"] = txtMedicineName.Text;
    }
    protected void btnAddToList_Click(object sender, EventArgs e)
    {
        gridViewList.DataSource = null;
        gridViewList.DataBind();
        gridViewList.Dispose();
        if (Session["List"] == null)
            dt.Rows.Add(ddlMedicineId.Text, txtMedicineName.Text, txtQuantity.Text);
        else
        {
            dt = (DataTable)Session["List"];
            dt.Rows.Add(ddlMedicineId.Text, txtMedicineName.Text, txtQuantity.Text);
        }
        Session["List"] = dt;
        ds.Tables.Add(dt);
        gridViewList.DataSource = ds;
        gridViewList.DataBind();
        ds.Tables.Clear();
        ds.Dispose();
        dt.Dispose();
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["new"] = "NO";
        gridviewMedicine.DataSource = null;
        gridviewMedicine.DataBind();
        gridviewMedicine.Dispose();
      
        data = new DataAccess();
        data.RefreshGridviewMedicineByCategory(gridviewMedicine,ddlCategory.Text);
        if (Session["Quantity"] == null)
        {
            data.RefreshGridviewByQuantityLow(GridView1);
        }
        else
            data.RefreshGridviewByQuantityLowConfig(GridView1, Convert.ToInt32(Session["Quantity"]));

        Session["Quantity"] = txtQuantityLimit.Text;
        Session["Category"] = ddlCategory.Text;
        Session["CategoryQuantLimit"] = ddlCategoryForItemShow.Text;
        Session["MedicineName"] = txtMedicineName.Text;
    }
    protected void gridviewMedicine_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMedicineId.Text = gridviewMedicine.Rows[gridviewMedicine.SelectedIndex].Cells[1].Text;
        txtMedicineName.Text = gridviewMedicine.Rows[gridviewMedicine.SelectedIndex].Cells[2].Text;
    }
 
    protected void txtNameSearch_TextChanged(object sender, EventArgs e)
    {
        Session["new"] = "NO";
        gridviewMedicine.DataSource = null;
        gridviewMedicine.DataBind();
        gridviewMedicine.Dispose();

        data = new DataAccess();
        data.RefreshGridviewMedicineByName(gridviewMedicine, txtNameSearch.Text.Trim());
        if (Session["Quantity"] == null)
        {
            data.RefreshGridviewByQuantityLow(GridView1);
        }
        else
            data.RefreshGridviewByQuantityLowConfig(GridView1, Convert.ToInt32(Session["Quantity"]));

        Session["Quantity"] = txtQuantityLimit.Text;
        Session["Category"] = ddlCategory.Text;
        Session["MedicineName"] = txtMedicineName.Text;
        Session["CategoryQuantLimit"] = ddlCategoryForItemShow.Text;
    }
    protected void ddlCategoryForItemShow_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["new"] = "NO";
        gridviewMedicine.DataSource = null;
        gridviewMedicine.DataBind();
        gridviewMedicine.Dispose();

        data = new DataAccess();

        data.RefreshGridviewByCategoryAndQuantityLow(GridView1, (string)Session["CategoryQuantLimit"],Convert.ToInt32(Session["Quantity"]));
        
        /*For GridView Medicine*/
        if (Session["Category"] == null || Session["MedicineName"] == null)
        {
            data.RefreshGridviewMedicine(gridviewMedicine);
            MessageBox.Show("1");
        }
        else 
        {
            if (ddlCategory.Text != "")
            {
                data.RefreshGridviewMedicineByCategory(gridviewMedicine, (string)Session["Category"]);
                MessageBox.Show("2");
            }
            else if (txtMedicineName.Text != "")
            {
                data.RefreshGridviewMedicineByName(gridviewMedicine, (string)Session["MedicineName"]);
                MessageBox.Show("3");
            }
        }
        
        Session["Quantity"] = txtQuantityLimit.Text;
        Session["Category"] = ddlCategory.Text;
        Session["MedicineName"] = txtMedicineName.Text;
        Session["CategoryQuantLimit"] = ddlCategoryForItemShow.Text;
    }
    protected void txtQuantityLimit_TextChanged(object sender, EventArgs e)
    {
        Session["new"] = "NO";
        gridviewMedicine.DataSource = null;
        gridviewMedicine.DataBind();
        gridviewMedicine.Dispose();

        data = new DataAccess();
        data.RefreshGridviewByQuantityLowConfig(GridView1, Convert.ToInt32(txtQuantityLimit.Text.Trim()));

        if (Session["Category"] == null || Session["MedicineName"] == null)
        {
            data.RefreshGridviewMedicine(gridviewMedicine);
        }
        else
        {
            if (ddlCategory.Text != "")
                data.RefreshGridviewMedicineByCategory(gridviewMedicine, (string)Session["Category"]);
            else if (txtMedicineName.Text != "")
                data.RefreshGridviewMedicineByName(gridviewMedicine, (string)Session["MedicineName"]);
        }

        Session["Quantity"] = txtQuantityLimit.Text;
        Session["Category"] = ddlCategory.Text;
        Session["MedicineName"] = txtMedicineName.Text;
        Session["CategoryQuantLimit"] = ddlCategoryForItemShow.Text;
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        int count = gridViewList.Rows.Count;
        data = new DataAccess();
        for (int index = 0; index < count; index++)
        {
            data.UpdateStock(Convert.ToInt32(gridViewList.Rows[index].Cells[0].Text.ToString()), Convert.ToInt32(gridViewList.Rows[index].Cells[2].Text.ToString()));
        }
        Session["List"] = null;
        gridViewList.DataSource = null;
        gridViewList.DataBind();
        gridViewList.Dispose();
        data.RefreshGridviewMedicine(gridviewMedicine);
        data.RefreshGridviewByQuantityLowConfig(GridView1, Convert.ToInt32(txtQuantityLimit.Text));
        //if (Session["Category"] == null || Session["MedicineName"] == null)
        //{
        //    data.RefreshGridviewMedicine(gridviewMedicine);
        //}
        //else
        //{
        //    if (ddlCategory.Text != "")
        //        data.RefreshGridviewMedicineByCategory(gridviewMedicine, (string)Session["Category"]);
        //    else if (txtMedicineName.Text != "")
        //        data.RefreshGridviewMedicineByName(gridviewMedicine, (string)Session["MedicineName"]);
        //}
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["List"] = null;
        gridViewList.DataSource = null;
        gridViewList.DataBind();
        gridViewList.Dispose();
    }
    
}