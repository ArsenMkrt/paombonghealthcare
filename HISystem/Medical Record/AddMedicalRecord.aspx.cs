using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Medical_Record_MedicalRecord : System.Web.UI.Page
{
    private DataAccess da;

    protected void Page_Load(object sender, EventArgs e)
    {
        checkbox_Disease.Items.Clear();
        da = new DataAccess();
        List<string> category = da.GetDiseaseCategory();
        checkbox_Disease.RepeatColumns = category.Count;
        for (int index = 0; index < category.Count; index++)
        {
            da.LoadCheckBoxList(checkbox_Disease, category[index]);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'>window.open('PopUp.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,width=850,height=800');</script>");
    }
}