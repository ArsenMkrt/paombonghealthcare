using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Medicine_Inventory_EditMedicine : System.Web.UI.Page
{
    private DataAccess data;
    private DataTable medicineData;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        data = new DataAccess();
        medicineData = new DataTable();
        medicineData.Columns.Add("MedicineName");
        medicineData.Columns.Add("Quantity");
        medicineData.Columns.Add("CategoryName");
  
        medicineData = data.GetMedicine(txtMedicineId.Text.Trim());
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
}