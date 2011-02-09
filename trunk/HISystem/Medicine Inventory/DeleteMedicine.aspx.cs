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

    

    protected void Page_Load(object sender, EventArgs e)
    {
        txtMedicineId.Enabled = true;
        txtMedicineId.ReadOnly = false;
    }
 
    protected void btn_delMedicine_Click(object sender, EventArgs e)
    {
        med = new Inventory();
        string DeletedMedicineName;
        int MedicineDeletedQuantity;
        if (txtMedicineId.Text.Trim() == null || txtMedicineId.Text.Trim() == "")
            Response.Write("<script> window.alert('No Medicine to Delete.')</script>");
        else
        {
            if (med.HasMedicine(Int32.Parse(txtMedicineId.Text)))
            {
                MedicineDeletedQuantity = med.GetMedicineQuantity(Int32.Parse(txtMedicineId.Text));
                DeletedMedicineName = med.GetMedicineName(Int32.Parse(txtMedicineId.Text));
                med.DeleteMedicine(txtMedicineId.Text);
                
                med.SaveMedicineLog(Int32.Parse(txtMedicineId.Text), DeletedMedicineName, MedicineDeletedQuantity
                    , Page.User.Identity.Name, "Delete");
                Response.Write("<script> window.alert('Medicine '"+DeletedMedicineName+" has been deleted.')</script>");
                gridViewMedicine.DataBind();
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
        txtMedicineName.Text = gridViewMedicine.Rows[gridViewMedicine.SelectedIndex].Cells[2].Text;
        btn_delMedicine_ConfirmButtonExtender.ConfirmText = "Are you sure you want to delete "+txtMedicineName.Text+"?";
        txtMedicineId.ReadOnly = true;
        txtMedicineId.Enabled = false;
        txtMedicineName.ReadOnly = true;
    }
    
}