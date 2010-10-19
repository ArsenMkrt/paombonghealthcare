using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Medical_Record_PopUp : System.Web.UI.Page
{
    private DataAccess data;

    protected void Page_Load(object sender, EventArgs e)
    {
        data = new DataAccess();
        data.LoadPatientGrid(GridViewPatient);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void GridViewPatient_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void GridViewPatient_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes.Add("onclick", "javascript:GetRowValue('" + GridViewPatient.Rows[GridViewPatient.SelectedIndex].Cells[0].Text + "')");
    }
}