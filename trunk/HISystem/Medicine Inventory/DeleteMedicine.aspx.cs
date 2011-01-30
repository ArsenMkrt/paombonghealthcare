using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Medicine_Inventory_DeleteMedicine : System.Web.UI.Page
{
    private Inventory med;

    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        txtMedicineId.Enabled = true;
        txtMedicineId.ReadOnly = false;
    }
 
    protected void btn_delMedicine_Click(object sender, EventArgs e)
    {
        med = new Inventory();
        if (txtMedicineId.Text == null || txtMedicineId.Text == "")
            Response.Write("<script> window.alert('No Medicine to Delete.')</script>");
        else
        {
            if (med.HasMedicine(Int32.Parse(txtMedicineId.Text)))
            {
                med.DeleteMedicine(txtMedicineId.Text);
                string MedicineName = med.GetMedicineName(Int32.Parse(txtMedicineId.Text));
                
                med.SaveMedicineLog(Int32.Parse(txtMedicineId.Text), MedicineName, med.GetMedicineQuantity(Int32.Parse(txtMedicineId.Text))
                    , Page.User.Identity.Name, "Delete");
                Response.Redirect("DeleteMedicine.aspx");
            }
            else
            {
                Response.Write("<script> window.alert('Medicine Does not Exist in the list of Medicine, Try Other Medicine Id.')</script>");
                txtMedicineId.Text = "";
            }
        }
    }

    protected void gridViewMedicine_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMedicineId.Text = gridViewMedicine.Rows[gridViewMedicine.SelectedIndex].Cells[1].Text;
        txtMedicineId.ReadOnly = true;
        txtMedicineId.Enabled = false;
    }
    
}