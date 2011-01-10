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

public partial class Reports_Templates_xSchistomiasis : System.Web.UI.Page
{
    private string program; //For DB Tables
    private string p;
    private int month;
    private string monthName;
    private int year;
    private string barangay;
    private int population;
    private DataAccess data;
    private MonthConverter mc;

    protected void Page_Load(object sender, EventArgs e)
    {
        mc = new MonthConverter();
        data = new DataAccess();
        program = Request["program"].ToString().Trim();
        p = Request["p"].ToString().Trim();
        monthName = Request["month"].ToString().Trim();
        month = mc.MonthNameToIndex(monthName);
        year = Int32.Parse(Request["year"].ToString().Trim());
        barangay = Request["barangay"].ToString().Trim();
        population = Int32.Parse(Request["population"].ToString().Trim());

        lbl_Barangay.Text = barangay;
        lbl_month.Text = monthName;
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
        label2.ID = "lblMale";
        label2.Text = "Male";
        label2.Font.Bold = true;
        label2.Font.Size = FontUnit.Large;
        tCell2.Controls.Add(label2);
        TableCell tCell3 = new TableCell();
        tCell3.Attributes["align"] = "Center";
        Label label3 = new Label();
        label3.ID = "lbl_Female";
        label3.Text = "Female";
        label3.Font.Bold = true;
        label3.Font.Size = FontUnit.Large;
        tCell3.Controls.Add(label3);
        tRow.Cells.Add(tCell);
        tRow.Cells.Add(tCell2);
        tRow.Cells.Add(tCell3);
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

            // Create column 2 Male
            TableCell td2 = new TableCell();
            td2.Width = Unit.Pixel(162);
            td2.Attributes["align"] = "Center";
            TextBox text = new TextBox();
            text.ID = "txt_" + i.ToString();
            text.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            text.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            text.Attributes["onpaste"] = "return false";
            text.Text = "0";
            // Add control to the table cell
            RequiredFieldValidator rfv = new RequiredFieldValidator();
            rfv.ID = "maleRFV_" + i.ToString();
            rfv.Display = ValidatorDisplay.Dynamic;
            rfv.ControlToValidate = text.ID;
            rfv.ErrorMessage = "*";
            rfv.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td2.Controls.Add(text);
            td2.Controls.Add(rfv);

            // Create column 3 Female
            TableCell td3 = new TableCell();
            td3.Width = Unit.Pixel(162);
            td3.Attributes["align"] = "Center";
            TextBox text2 = new TextBox();
            text2.ID = "txt2_" + i.ToString();
            text2.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            text2.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            text2.Attributes["onpaste"] = "return false";
            text2.Text = "0";
            RequiredFieldValidator rfv2 = new RequiredFieldValidator();
            rfv2.ID = "femRFV_" + i.ToString();
            rfv2.Display = ValidatorDisplay.Dynamic;
            rfv2.ControlToValidate = text2.ID;
            rfv2.ErrorMessage = "*";
            rfv2.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td3.Controls.Add(text2);
            td3.Controls.Add(rfv2);

            // Add cell to the row
            tr.Cells.Add(td1);
            tr.Cells.Add(td2);
            tr.Cells.Add(td3);

            // Add row to the table.
            tblDynamic.Rows.Add(tr);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string male = "";
        string female = "";
        string indicatorData = "";
        data = new DataAccess();
        mc = new MonthConverter();

        if (data.HasDataPARAM_MonthYear(month, year, program, data.GetBarangayID(barangay)))
            Response.Write("<script type='text/javascript'>" + "alert(\"Month " + lbl_month.Text + " and Year " +
            year + " exists in the database. Please Try other Month and Year.\");</script>");
        else
        {
            for (int j = 0; j < data.CountIndicatorPerProgram(p); j++)
            {

                TextBox temp = tblDynamic.FindControl("txt_" + j.ToString()) as TextBox;
                male = temp.Text;
                TextBox temp2 = tblDynamic.FindControl("txt2_" + j.ToString()) as TextBox;
                female = temp2.Text;
                Label label = tblDynamic.FindControl("lbl" + j.ToString()) as Label;
                indicatorData = label.Text;

                data.InsertSchisReport(indicatorData, Int32.Parse(male), Int32.Parse(female), data.GetBarangayID(lbl_Barangay.Text),
                    month, year);
            }

            //Get ProgramCategory - Lakhi
            SqlConnection connPatient = new SqlConnection(data.Dataconnection);
            connPatient.Open();

            SqlCommand cmdTxt = new SqlCommand("SELECT ProgramCategoryID FROM Indicator WHERE IndicatorData = " +
                "@indicatorData", connPatient);
            cmdTxt.Parameters.Add("@indicatorData", SqlDbType.VarChar).Value = indicatorData;
            SqlDataReader indicatorReader = cmdTxt.ExecuteReader();
            indicatorReader.Read();
            int indicatorID = indicatorReader.GetInt32(0);
            indicatorReader.Close();
            //End

            //InsertPopulation Lakhi 
            //NOT YET FINISHED TARGET
            //
            data.InsertPopulation(data.GetBarangayID(lbl_Barangay.Text), Int32.Parse(lbl_Population.Text),
                Int32.Parse("0"), month, Int32.Parse(lblYear.Text), indicatorID);

            Response.Write("<script type='text/javascript'>" + "alert(\"Inserted Successfully\");</script>");

        }


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < data.CountIndicatorPerProgram(p); i++)
        {
            TextBox text = new TextBox();
            text.ID = "txt_" + i.ToString();
            text.Text = "0";
        }
    }
}