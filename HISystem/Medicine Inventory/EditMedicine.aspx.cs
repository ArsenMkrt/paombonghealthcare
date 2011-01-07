﻿using System;
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
    protected void SearchMedicine()
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        data = new DataAccess();
        data.UpdateMedicine(Convert.ToInt32(txtMedicineId.Text.Trim()),txtMedicineName.Text.Trim(),
            ddlCategory.Text.Trim(),Convert.ToInt32(txtQuantity.Text.Trim()));
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditMedicine.aspx");
    }

    protected void gridViewMedicine_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMedicineId.Text = gridViewMedicine.Rows[gridViewMedicine.SelectedIndex].Cells[1].Text;
        txtMedicineId.ReadOnly = true;
        SearchMedicine();
    }
}