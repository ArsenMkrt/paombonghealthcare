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
        txtMedicineId.Enabled = false;
        txtMedicineId.ReadOnly = true;
    }
    protected void listboxMedicine_SelectedIndexChanged(object sender, EventArgs e)
    {
        data = new DataAccess();

        int x = listboxMedicine.SelectedIndex;
        int medId = data.GetMedicineId(listboxMedicine.Items[x].Value.ToString());

        txtMedicineId.Text = medId.ToString().Trim();
    }
  
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        data = new DataAccess();
        if (txtMedicineId.Text == null || txtMedicineId.Text == "")
            MessageBox.Show("No Medicine To Delete");
        else
        {
            data.DeleteMedicine(txtMedicineId.Text);
            Response.Redirect("DeleteMedicine.aspx");
        }
    }
}