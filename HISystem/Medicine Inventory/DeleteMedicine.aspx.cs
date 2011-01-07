using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Medicine_Inventory_DeleteMedicine : System.Web.UI.Page
{
    private DataAccess data;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        txtMedicineId.Enabled = true;
        txtMedicineId.ReadOnly = false;
    }
 
    protected void btn_delMedicine_Click(object sender, EventArgs e)
    {
        data = new DataAccess();
        if (txtMedicineId.Text == null || txtMedicineId.Text == "")
            Response.Write("<script> window.alert('No Medicine to Delete.')</script>");
        else
        {
            if (data.HasMedicine(data.GetMedicineName(Int32.Parse(txtMedicineId.Text))))
            {
                data.DeleteMedicine(txtMedicineId.Text);
                Response.Redirect("DeleteMedicine.aspx");
            }
            else
                Response.Write("<script> window.alert('Medicine Does not Exist in the list of Medicine, Try Other Medicine Id.')</script>");
        }
    }

    protected void gridViewMedicine_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMedicineId.Text = gridViewMedicine.Rows[gridViewMedicine.SelectedIndex].Cells[1].Text;
        txtMedicineId.ReadOnly = true;
        txtMedicineId.Enabled = false;
    }
    
}