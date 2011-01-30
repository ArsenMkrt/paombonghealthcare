using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Reports_Bulk_Childcare : System.Web.UI.Page
{
    private DataAccess data;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        data = new DataAccess();
        
        //string constr = data.Dataconnection;
        string constr = "";
        string query = "SELECT BarangayID, BarangayName FROM Barangays";

        SqlDataAdapter da = new SqlDataAdapter(query, constr);
        DataTable table = new DataTable();

        da.Fill(table);

        ListView1.DataSource = table;
        ListView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (dropIndicator.SelectedValue != null && dropIndicator.SelectedItem!=null)
        {
            data = new DataAccess();
            //string constr = data.Dataconnection;
            foreach (ListViewDataItem lv in this.ListView1.Items)

            {


                //ListViewItem item = ListView1.Items;
                Label LBrgyID = (Label)lv.FindControl("lblBrgyID");

                Label LBrgy = (Label)lv.FindControl("lblBrgy");
                TextBox tMale = (TextBox)lv.FindControl("txtMale");
                TextBox tFemale = (TextBox)lv.FindControl("txtFemale");
                TextBox tTotal1 = (TextBox)lv.FindControl("txtTotal");

                string constr = "";

                // insert records into database
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    //eto yung ayaw mainsert
                    string Sql = "insert into cChildCare1 (ChildData, BarangayID, [1st_Male], [1st_Female], [1st_Total]) values (@progIndicator, @BgyID, @Male, @Female, @Total1)";

                    //eto yung naiinsert pag wala na ung int values sice allow null naman ung tinangall ko
                    //string Sql = "insert into cChildCare (ChildData, BarangayID) values (@BName, @BgyID)";
                    conn.Open();
                    using (SqlCommand dCmd = new SqlCommand(Sql, conn))
                    {
                        if (dropIndicator.SelectedItem.ToString() != null)
                        {
                            dCmd.Parameters.AddWithValue("progIndicator", dropIndicator.SelectedItem.ToString());
                        }
                        else if (dropIndicator.SelectedItem.ToString() == null)
                        {
                            dCmd.Parameters.AddWithValue("progIndicator",LBrgy.Text);
                        }
                        
                        dCmd.Parameters.AddWithValue("@BgyID", LBrgyID.Text);


                        dCmd.Parameters.AddWithValue("@Male", Convert.ToInt32(tMale.Text.Trim()));
                        dCmd.Parameters.AddWithValue("@Female", Convert.ToInt32(tFemale.Text.Trim()));
                        dCmd.Parameters.AddWithValue("@Total1", Convert.ToInt32(tTotal1.Text.Trim()));




                        dCmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                
                
            }
            Response.Write("<script> window.alert('Records Inserted Successfully.')</script>");
        }
        else
            Response.Write("<script> window.alert('Please supply program')</script>");    
        

    }
}