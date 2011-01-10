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

public partial class Reports_Templates_xFamilyPlanning : System.Web.UI.Page
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
        label2.ID = "lblSU";
        label2.Text = "Start User";
        label2.Font.Bold = true;
        label2.Font.Size = FontUnit.Large;
        tCell2.Controls.Add(label2);
        TableCell tCell3 = new TableCell();
        tCell3.Attributes["align"] = "Center";
        Label label3 = new Label();
        label3.ID = "lblNew";
        label3.Text = "New";
        label3.Font.Bold = true;
        label3.Font.Size = FontUnit.Large;
        tCell3.Controls.Add(label3);
        TableCell tCell4 = new TableCell();
        tCell4.Attributes["align"] = "Center";
        Label label4 = new Label();
        label4.ID = "lblOthers";
        label4.Text = "Others";
        label4.Font.Bold = true;
        label4.Font.Size = FontUnit.Large;
        tCell4.Controls.Add(label4);
        TableCell tCell5 = new TableCell();
        tCell5.Attributes["align"] = "Center";
        Label label5 = new Label();
        label5.ID = "lblDO";
        label5.Text = "Drop Out";
        label5.Font.Bold = true;
        label5.Font.Size = FontUnit.Large;
        tCell5.Controls.Add(label5);
        TableCell tCell6 = new TableCell();
        tCell6.Attributes["align"] = "Center";
        Label label6 = new Label();
        label6.ID = "lblEU";
        label6.Text = "End User";
        label6.Font.Bold = true;
        label6.Font.Size = FontUnit.Large;
        tCell6.Controls.Add(label6);

        tRow.Cells.Add(tCell);
        tRow.Cells.Add(tCell2);
        tRow.Cells.Add(tCell3);
        tRow.Cells.Add(tCell4);
        tRow.Cells.Add(tCell5);
        tRow.Cells.Add(tCell6);
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

            // Create column 2 Start User
            TableCell td2 = new TableCell();
            td2.Width = Unit.Pixel(162);
            td2.Attributes["align"] = "Center";
            TextBox text = new TextBox();
            text.ID = "txtSU_" + i.ToString();
            text.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            text.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            text.Attributes["onpaste"] = "return false";
            text.Width = Unit.Pixel(45);
            text.Text = "0";
            RequiredFieldValidator rfv = new RequiredFieldValidator();
            rfv.ID = "SURFV_" + i.ToString();
            rfv.Display = ValidatorDisplay.Dynamic;
            rfv.ControlToValidate = text.ID;
            rfv.ErrorMessage = "*";
            rfv.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td2.Controls.Add(text);
            td2.Controls.Add(rfv);

            // Create column 3 New
            TableCell td3 = new TableCell();
            td3.Width = Unit.Pixel(120);
            td3.Attributes["align"] = "Center";
            TextBox text2 = new TextBox();
            text2.ID = "txtNew_" + i.ToString();
            text2.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            text2.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            text2.Attributes["onpaste"] = "return false";
            text2.Width = Unit.Pixel(45);
            text2.Text = "0";
            RequiredFieldValidator rfv2 = new RequiredFieldValidator();
            rfv2.ID = "NewRFV" + i.ToString();
            rfv2.Display = ValidatorDisplay.Dynamic;
            rfv2.ControlToValidate = text2.ID;
            rfv2.ErrorMessage = "*";
            rfv2.Font.Size = FontUnit.Small;
            td3.Controls.Add(text2);
            td3.Controls.Add(rfv2);

            // Create column 4 Others
            TableCell td4 = new TableCell();
            td4.Width = Unit.Pixel(120);
            td4.Attributes["align"] = "Center";
            TextBox text3 = new TextBox();
            text3.ID = "txtOthers_" + i.ToString();
            text3.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            text3.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            text3.Attributes["onpaste"] = "return false";
            text3.Width = Unit.Pixel(45);
            text3.Text = "0";
            RequiredFieldValidator rfv3 = new RequiredFieldValidator();
            rfv3.ID = "OthersRFV" + i.ToString();
            rfv3.Display = ValidatorDisplay.Dynamic;
            rfv3.ControlToValidate = text3.ID;
            rfv3.ErrorMessage = "*";
            rfv3.Font.Size = FontUnit.Small;
            td4.Controls.Add(text3);
            td4.Controls.Add(rfv3);

            // Create column 5 DropOut
            TableCell td5 = new TableCell();
            td5.Width = Unit.Pixel(120);
            td5.Attributes["align"] = "Center";
            TextBox text4 = new TextBox();
            text4.ID = "txtDO_" + i.ToString();
            text4.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            text4.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            text4.Attributes["onpaste"] = "return false";
            text4.Width = Unit.Pixel(45);
            text4.Text = "0";
            RequiredFieldValidator rfv4 = new RequiredFieldValidator();
            rfv4.ID = "DORFV" + i.ToString();
            rfv4.Display = ValidatorDisplay.Dynamic;
            rfv4.ControlToValidate = text4.ID;
            rfv4.ErrorMessage = "*";
            rfv4.Font.Size = FontUnit.Small;
            td5.Controls.Add(text4);
            td5.Controls.Add(rfv4);

            // Create column 6 End User
            TableCell td6 = new TableCell();
            td6.Width = Unit.Pixel(120);
            td6.Attributes["align"] = "Center";
            TextBox text5 = new TextBox();
            text5.ID = "txtEU_" + i.ToString();
            text5.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            text5.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            text5.Attributes["onpaste"] = "return false";
            text5.Width = Unit.Pixel(45);
            text5.Text = "0";
            RequiredFieldValidator rfv5 = new RequiredFieldValidator();
            rfv5.ID = "EURFV" + i.ToString();
            rfv5.Display = ValidatorDisplay.Dynamic;
            rfv5.ControlToValidate = text5.ID;
            rfv5.ErrorMessage = "*";
            rfv5.Font.Size = FontUnit.Small;
            td6.Controls.Add(text5);
            td6.Controls.Add(rfv5);

            // Add cell to the row
            tr.Cells.Add(td1);
            tr.Cells.Add(td2);
            tr.Cells.Add(td3);
            tr.Cells.Add(td4);
            tr.Cells.Add(td5);
            tr.Cells.Add(td6);

            // Add row to the table.
            tblDynamic.Rows.Add(tr);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string startUser = "";
        string _new = "";
        string others = "";
        string dropOut = "";
        string endUser = "";
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

                TextBox temp = tblDynamic.FindControl("txtSU_" + j.ToString()) as TextBox;
                startUser = temp.Text;
                TextBox temp2 = tblDynamic.FindControl("txtNew_" + j.ToString()) as TextBox;
                _new = temp2.Text;
                TextBox temp3 = tblDynamic.FindControl("txtOthers_" + j.ToString()) as TextBox;
                others = temp3.Text;
                TextBox temp4 = tblDynamic.FindControl("txtDO_" + j.ToString()) as TextBox;
                dropOut = temp4.Text;
                TextBox temp5 = tblDynamic.FindControl("txtEU_" + j.ToString()) as TextBox;
                endUser = temp5.Text;
                Label label = tblDynamic.FindControl("lbl" + j.ToString()) as Label;
                indicatorData = label.Text;

                data.InsertFPReport(indicatorData,Int32.Parse(startUser),Int32.Parse(_new),Int32.Parse(others),Int32.Parse(dropOut),Int32.Parse(endUser), data.GetBarangayID(lbl_Barangay.Text),
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
            TextBox male = new TextBox();
            male.ID = "txt_" + i.ToString();
            male.Text = "0";
            TextBox female = new TextBox();
            female.ID = "txt2_" + i.ToString();
            female.Text = "0";
        }
    }
}