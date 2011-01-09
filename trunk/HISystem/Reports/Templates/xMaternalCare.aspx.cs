using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Reports_Templates_xMaternalCare : System.Web.UI.Page
{
    private string program;
    private string p; //For DB Tables
    private int month;
    private int year;
    private string barangay;
    private int population;
    private DataAccess data;
    //private DataTable dt; 

    protected void Page_Load(object sender, EventArgs e)
    {
            data = new DataAccess();
            program = Request["program"].ToString().Trim();
            p = Request["p"].ToString().Trim();
            month = Int32.Parse(Request["month"].ToString().Trim());
            year = Int32.Parse(Request["year"].ToString().Trim());
            barangay = Request["barangay"].ToString().Trim();
            population = Int32.Parse(Request["population"].ToString().Trim());

            lbl_Barangay.Text = barangay;
            lbl_month.Text = month.ToString();
            lbl_Population.Text = population.ToString();
            lblYear.Text = year.ToString();
            lblProgram.Text = p.ToString();

            /*SQL CODE TO ADD DATA IN TABLE ADDED LAKHI*/
            SqlConnection connPatient = new SqlConnection(data.Dataconnection);
            List<string> indicatorData = new List<string>();
            connPatient.Open();

            SqlCommand cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID = " +
                "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)", connPatient);
            cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = p;
            SqlDataReader indicatorReader = cmdTxt.ExecuteReader();
            while (indicatorReader.Read())
            {
                indicatorData.Add(indicatorReader.GetString(0));
            }

            /*Create Header*/
            TableRow tRow = new TableRow();
            TableCell tCell = new TableCell();
            Label label1 = new Label();
            label1.ID = "lbl_" + p.ToString();
            label1.Text = p.ToString();
            tCell.Attributes["align"] = "Center";
            label1.Font.Bold = true;
            label1.Font.Size = FontUnit.Large;
            tCell.Controls.Add(label1);
            TableCell tCell2 = new TableCell();
            tCell2.Attributes["align"] = "Center";
            Label label2 = new Label();
            label2.ID = "lblNo";
            label2.Text = "No";
            label2.Font.Bold = true;
            label2.Font.Size = FontUnit.Large;
            tCell2.Controls.Add(label2);
            tRow.Cells.Add(tCell);
            tRow.Cells.Add(tCell2);
            //End
            tblDynamic.Controls.Add(tRow);

            for (int i = 0; i < data.CountIndicatorPerProgram(p); i++)
            {
                // Create row 1
                TableRow tr = new TableRow();
                
                // Create cell 1
                TableCell td1 = new TableCell();
                td1.Width = Unit.Pixel(564);

                //Create a label control dynamically
                Label label = new Label();
                label.ID = "lbl" + i.ToString();
                label.Text = indicatorData[i].ToString();
                // Add control to the table cell
                td1.Controls.Add(label);

                // Create column 2
                TableCell td2 = new TableCell();
                td2.Width = Unit.Pixel(162);
                td2.Attributes["align"] = "Center";
                TextBox text = new TextBox();
                text.ID = "txt_" + i.ToString();
                //text.Attributes["runat"] = "server";
                // Add control to the table cell
                td2.Controls.Add(text);

                // Add cell to the row
                tr.Cells.Add(td1);
                tr.Cells.Add(td2);

                // Add row to the table.
                tblDynamic.Rows.Add(tr);
            }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string data = "";
        Table table = new Table();
        
        table.ID = "tblDynamic";
        TableCell td2 = new TableCell();
        ListBox1.Items.Add(table.Rows.Count.ToString());
        for (int j = 0; j < table.Rows.Count; j++)
        {
            TextBox temp = td2.FindControl("txt_" + j.ToString()) as TextBox;
            data = temp.Text;
            //Session["txt" + j.ToString()] = temp.Text;
            Response.Write("<script type='text/javascript'>" + "alert(\"Accomplishment: " + table.Rows.Count.ToString() + "\");</script>");
            ListBox1.Items.Add(j.ToString());
            ListBox1.Items.Add(data);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < data.CountIndicatorPerProgram(p); i++)
        {
            //TextBox text = new TextBox();
            //text.ID = "txt_" + i.ToString();
            //text.Text = "";
             

        }
    }
}