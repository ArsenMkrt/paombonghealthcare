using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Medicine_Inventory_EditMedicine : System.Web.UI.Page
{
    private Inventory med;
    private DataTable medicineData;

    //protected void Page_Init(object Sender, EventArgs e)
    //{
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
    //    Response.Cache.SetNoStore();
    //}
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SearchMedicine()
    {
        med = new Inventory();
        medicineData = new DataTable();
        medicineData.Columns.Add("MedicineName");
        medicineData.Columns.Add("Quantity");
        medicineData.Columns.Add("CategoryName");
  
        medicineData = med.GetMedicine(txtMedicineId.Text.Trim());
        txtMedicineId.Enabled = false;

        if (medicineData.Rows.Count > 0)
        {
            foreach (DataRow dr in medicineData.Rows)
            {
                txtMedicineName.Text = dr["MedicineName"].ToString().Trim();
                txtQuantity.Text = dr["Quantity"].ToString().Trim();
                ddlCategory.Text = dr["CategoryName"].ToString().Trim();
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        med = new Inventory();
        if (txtMedicineId.Text == "" || txtMedicineId.Text == null)
        {
            Response.Write("<script> window.alert('Please Select a Medicine to Edit before Saving.')</script>");
        }
        else
        {
            if (txtMedicineName.Text == "" || txtMedicineName.Text == null)
            {
                Response.Write("<script> window.alert('Medicine Field Should not be Empty.')</script>");
            }
            else
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    Response.Write("<script> window.alert('Quantity Field Should not be Empty.')</script>");
                }
                else
                {
                    bool checker = med.UpdateMedicine(Convert.ToInt32(txtMedicineId.Text.Trim()), txtMedicineName.Text.Trim(),
                       ddlCategory.Text.Trim(), Convert.ToInt32(txtQuantity.Text.Trim()));
                    if (checker == true)
                        Response.Write("<script> window.alert('Updated Medicine Successful.')</script>");
                    else
                        Response.Write("<script> window.alert('Updating is Unsuccessful.')</script>");
                    
                    gridViewMedicine.DataBind();
                        
                }
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditMedicine.aspx");
    }

    protected void gridViewMedicine_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMedicineId.Text = gridViewMedicine.Rows[gridViewMedicine.SelectedIndex].Cells[1].Text;
        txtMedicineId.ReadOnly = false;
        txtMedicineName.ReadOnly = false;
        ddlCategory.Enabled = true;
        txtQuantity.ReadOnly = false;
        SearchMedicine();
    }
}