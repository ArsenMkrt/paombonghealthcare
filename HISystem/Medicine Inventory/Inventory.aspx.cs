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
    private int quantity = 0;

    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }

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
        //gerald try
        //bool hasSameItem = false;
        //int getindex = 0;
        //int count = gridViewList.Rows.Count;
        //data = new DataAccess();
        //for (int index = 0; index < count; index++)
        //{
        //    if (ddlMedicineId.Text == gridViewList.Rows[index].Cells[0].Text.ToString())
        //    {
        //        hasSameItem = true;
        //        getindex = index;

        //    }
        //}

        //if (getindex != 0)
        //{

        //    int newQuantity = Int32.Parse(txtQuantity.Text) + Int32.Parse(gridViewList.Rows[getindex].Cells[0].Text);
        //    gridViewList.Rows[getindex].Cells[0].Text = newQuantity.ToString();

        //    //Convert.ToInt32(gridViewList.Rows[index].Cells[2].Text.ToString());
        //}

        //end try
        
        if (Int32.Parse(txtQuantity.Text) > Int32.Parse(gridviewMedicine.Rows[gridviewMedicine.SelectedIndex].Cells[3].Text))
        {
            Response.Write("<script> window.alert('Quantity to add to list is below than the quantity of " +
                gridviewMedicine.Rows[gridviewMedicine.SelectedIndex].Cells[1].Text + "'.')</script>");
        }
        else
        {
            //int medicineQuant = Int32.Parse(gridViewList.Rows[x].Cells[3].Text);
            //for(int x = 0;x<gridViewList.Rows.Count;x++)
            //{
              //  if (ddlMedicineId.Text == gridViewList.Rows[x].Cells[1].Text)
            //        medicineQuant = Int32.Parse(gridViewList.Rows[x].Cells[3].Text) + Int32.Parse(txtQuantity.Text);
            //}
            if (txtMedicineName.Text.Trim() != null && txtQuantity.Text.Trim() != null)
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
            else
                Response.Write("<script> window.alert('Input fields cannot be empty. Please Try Again.')</script>");
        }
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
    

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        int count = gridViewList.Rows.Count;
        data = new DataAccess();
        for (int index = 0; index < count; index++)
        {
            data.UpdateStock(Convert.ToInt32(gridViewList.Rows[index].Cells[0].Text.ToString()), Convert.ToInt32(gridViewList.Rows[index].Cells[2].Text.ToString()));
            data.SaveMedicineLog(Convert.ToInt32(gridViewList.Rows[index].Cells[0].Text.ToString()),gridViewList.Rows[index].Cells[1].Text.ToString(), 
                Convert.ToInt32(gridViewList.Rows[index].Cells[2].Text.ToString()), Page.User.Identity.Name,"CheckOut");
        }

        Session["List"] = null;
        gridViewList.DataSource = null;
        gridViewList.DataBind();
        gridViewList.Dispose();
        data.RefreshGridviewMedicine(gridviewMedicine);
        data.RefreshGridviewByQuantityLowConfig(GridView1, Convert.ToInt32(txtQuantityLimit.Text));
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["List"] = null;
        gridViewList.DataSource = null;
        gridViewList.DataBind();
        gridViewList.Dispose();
    }

    protected void btn_belowQty_Click(object sender, EventArgs e)
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
}