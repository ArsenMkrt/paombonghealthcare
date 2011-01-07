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
        
        //HtmlTable table = new HtmlTable();
        for (int i = 0; i < data.CountIndicatorPerProgram(p); i++)
        {
            
            //HtmlTableRow tableR = new HtmlTableRow();
            //HtmlTableCell tc = new HtmlTableCell();
            //tc.Width = "564px";

            //table.Border = 1;
            //table.CellPadding = 3;
            //table.CellSpacing = 3;
            //table.BorderColor = "red";

            //// Create a label control dynamically
            //Label label = new Label();
            //label.ID = "lbl" + i.ToString();
            //label.Text = indicatorData[i].ToString();
            //// Add control to the table cell
            //tc.Controls.Add(label);


            //HtmlTableCell tc2 = new HtmlTableCell();
            //tc2.Width = "162px";
            //// Create a label control dynamically
            //TextBox text = new TextBox();
            //text.ID = "txt_" + i.ToString();
            ////// Add control to the table cell
            //this.Page.Controls.Add("txt_" + i.ToString());

            //tc2.Controls.Add(text);

            //tableR.Cells.Add(tc);
            //tableR.Cells.Add(tc2);

            //table.Rows.Add(tableR);
            //this.Controls.Add(table);

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
            TextBox text = new TextBox();
            text.ID = "txt_" + i.ToString();
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
        Table table = new Table();

        table.ID = "tblDynamic";
        table.Attributes["runat"] = "server";
        TableRowCollection actualRow = tblDynamic.Rows;
        string[] quantity = new string[actualRow.Count];
        int k = 0;

        for (int i = 0; i < data.CountIndicatorPerProgram(p); i++)
        {
            TableRow currentRow = actualRow[i];

            for (int j = 0; j < currentRow.Cells.Count; j++)
            {
                TableCell currentCell = currentRow.Cells[j];

                TextBox temp = currentCell.FindControl("txt_" + i) as TextBox;
                quantity[k] = temp.Text;
                k++;
                Response.Write("<script> window.alert('txt_" + temp.Text + ".')</script>");
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < data.CountIndicatorPerProgram(p); i++)
        {
            TextBox text = new TextBox();
            text.ID = "txt_" + i.ToString();
            text.Text = "";
        }
    }
}