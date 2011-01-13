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

public partial class Reports_Templates_xAllProgram : System.Web.UI.Page
{
    //private string program; //For DB Tables
    //private string p;
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
        //program = Request["program"].ToString().Trim();
        //p = Request["p"].ToString().Trim();
        monthName = Request["month"].ToString().Trim();
        month = mc.MonthNameToIndex(monthName);
        year = Int32.Parse(Request["year"].ToString().Trim());
        barangay = Request["barangay"].ToString().Trim();
        population = Int32.Parse(Request["population"].ToString().Trim());

        lbl_Barangay.Text = barangay;
        lbl_month.Text = monthName;
        lbl_Population.Text = population.ToString();
        lblYear.Text = year.ToString();
        //lblProgram.Text = p.ToString();

        /*
         * MONTHLY REPORTS FOR PAOMBONG MUNICIPALITY
         * 1.MATERNAL CARE
         * 2.CHILD CARE
         * 3.DENTAL CARE
         * 4.MALARIA
         * 5.LEPROSY
         * 6.FAMILY PLANNING
         * 7.FAMILIARIASIS
         * 8.TUBERCULOSIS
         * 9.SCHISTOMIASIS
         * 
         * ADDED BY LAKHI
         */


        /*
         * PROGRAM
         * MATERNAL CARE
         * ADDED BY LAKHI
         */

        #region Table Creation for Maternal Care
        /*SQL CODE TO ADD DATA IN TABLE ADDED LAKHI*/
        SqlConnection connMaternal = new SqlConnection(data.Dataconnection);
        List<string> dataMaternal = new List<string>();
        connMaternal.Open();

        SqlCommand cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID = " +
            "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)", connMaternal);
        cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = "Maternal Care";
        SqlDataReader indicatorReader = cmdTxt.ExecuteReader();
        while (indicatorReader.Read())
        {
            dataMaternal.Add(indicatorReader.GetString(0));
        }

        /*Create Header*/
        TableRow tableRowMaternal = new TableRow();
        TableCell tableCellMaternal = new TableCell();
        Label lblMaternal_1 = new Label();
        lblMaternal_1.ID = "lbl_Maternal";
        lblMaternal_1.Text = "Maternal Care";
        lblMaternal_1.ForeColor = System.Drawing.Color.Green;
        tableCellMaternal.Attributes["align"] = "Center";
        lblMaternal_1.Font.Bold = true;
        lblMaternal_1.Font.Size = FontUnit.Large;
        tableCellMaternal.Controls.Add(lblMaternal_1);
        TableCell tableCellMaternal2 = new TableCell();
        tableCellMaternal2.Attributes["align"] = "Center";
        Label lblMaternal_2 = new Label();
        lblMaternal_2.ID = "lblMaternalNo";
        lblMaternal_2.ForeColor = System.Drawing.Color.Green;
        lblMaternal_2.Text = "No";
        lblMaternal_2.Font.Bold = true;
        lblMaternal_2.Font.Size = FontUnit.Large;
        tableCellMaternal2.Controls.Add(lblMaternal_2);
        tableRowMaternal.Cells.Add(tableCellMaternal);
        tableRowMaternal.Cells.Add(tableCellMaternal2);
        //End
        tblMaternal.Controls.Add(tableRowMaternal);

        for (int i = 0; i < data.CountIndicatorPerProgram("Maternal Care"); i++)
        {
            // Create row 1
            TableRow tr_Maternal = new TableRow();

            // Create cell 1
            TableCell tc_Maternal = new TableCell();
            tc_Maternal.Width = Unit.Pixel(564);

            //Create a indicatorMaternal control dynamically
            Label indicatorMaternal = new Label();
            indicatorMaternal.ID = "lblMaternalIndicator" + i.ToString();
            indicatorMaternal.Text = dataMaternal[i].ToString();
            // Add control to the table cell
            tc_Maternal.Controls.Add(indicatorMaternal);

            // Create column 2
            TableCell tc_Maternal2 = new TableCell();
            tc_Maternal2.Width = Unit.Pixel(162);
            tc_Maternal2.Attributes["align"] = "Center";
            TextBox txtMaternal = new TextBox();
            txtMaternal.ID = "txtMaternalNo_" + i.ToString();
            txtMaternal.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtMaternal.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtMaternal.Attributes["onpaste"] = "return false";
            txtMaternal.Text = "0";

            RequiredFieldValidator rfvMaternal = new RequiredFieldValidator();
            rfvMaternal.ID = "rfvMaternalNo_" + i.ToString();
            rfvMaternal.Display = ValidatorDisplay.Dynamic;
            rfvMaternal.ControlToValidate = txtMaternal.ID;
            rfvMaternal.ErrorMessage = "*";
            rfvMaternal.Font.Size = FontUnit.Small;
            // Add control to the table cell
            tc_Maternal2.Controls.Add(txtMaternal);
            tc_Maternal2.Controls.Add(rfvMaternal);


            // Add cell to the row
            tr_Maternal.Cells.Add(tc_Maternal);
            tr_Maternal.Cells.Add(tc_Maternal2);

            // Add row to the table.
            tblMaternal.Rows.Add(tr_Maternal);
        }
    #endregion

        /*
         * PROGRAM
         * CHILD CARE
         * ADDED BY LAKHI
         */

        #region Table Creation for Child Care

        /*SQL CODE TO ADD DATA IN TABLE ADDED LAKHI*/

        SqlConnection connChildCare = new SqlConnection(data.Dataconnection);
        List<string> ChildCareData = new List<string>();
        connChildCare.Open();

        SqlCommand cc_cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID = " +
            "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)", connChildCare);
        cc_cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = "Child Care";
        SqlDataReader ChildCareIndicatorReader = cc_cmdTxt.ExecuteReader();
        while (ChildCareIndicatorReader.Read())
        {
            ChildCareData.Add(ChildCareIndicatorReader.GetString(0));
        }

        /*Create Header*/
        TableRow tableRowChildCare = new TableRow();
        TableCell tableCellChildCare = new TableCell();
        Label lblChildCare1 = new Label();
        lblChildCare1.ID = "lbl_ChildCare";
        lblChildCare1.Text = "Child Care";
        lblChildCare1.ForeColor = System.Drawing.Color.Green;
        tableCellChildCare.Attributes["align"] = "Center";
        lblChildCare1.Font.Bold = true;
        lblChildCare1.Font.Size = FontUnit.Large;
        tableCellChildCare.Controls.Add(lblChildCare1);
        TableCell tableCellChildCare2 = new TableCell();
        tableCellChildCare2.Attributes["align"] = "Center";
        Label lblChildCare2 = new Label();
        lblChildCare2.ID = "lblChildCareMale";
        lblChildCare2.Text = "Male";
        lblChildCare2.ForeColor = System.Drawing.Color.Green;
        lblChildCare2.Font.Bold = true;
        lblChildCare2.Font.Size = FontUnit.Large;
        tableCellChildCare2.Controls.Add(lblChildCare2);
        TableCell tableCellChildCare3 = new TableCell();
        tableCellChildCare3.Attributes["align"] = "Center";
        Label lblChildCare3 = new Label();
        lblChildCare3.ID = "lblChildCareFemale";
        lblChildCare3.Text = "Female";
        lblChildCare3.ForeColor = System.Drawing.Color.Green;
        lblChildCare3.Font.Bold = true;
        lblChildCare3.Font.Size = FontUnit.Large;
        tableCellChildCare3.Controls.Add(lblChildCare3);
        tableRowChildCare.Cells.Add(tableCellChildCare);
        tableRowChildCare.Cells.Add(tableCellChildCare2);
        tableRowChildCare.Cells.Add(tableCellChildCare3);
        //End
        tblDynamic.Controls.Add(tableRowChildCare);

        for (int i = 0; i < data.CountIndicatorPerProgram("Child Care"); i++)
        {
            // Create row 1
            TableRow tr_ChildCare = new TableRow();

            // Create cell 1
            TableCell td_ChildCare1 = new TableCell();
            td_ChildCare1.Width = Unit.Pixel(564);

            //Create a label control dynamically
            Label lblChildCareIndicator = new Label();
            lblChildCareIndicator.ID = "lblChildCareIndicator" + i.ToString();
            lblChildCareIndicator.Text = ChildCareData[i].ToString();
            // Add control to the table cell
            td_ChildCare1.Controls.Add(lblChildCareIndicator);

            // Create column 2 Male
            TableCell td_ChildCare2 = new TableCell();
            td_ChildCare2.Width = Unit.Pixel(162);
            td_ChildCare2.Attributes["align"] = "Center";
            TextBox txtChildCare_Male = new TextBox();
            txtChildCare_Male.ID = "txtChildCareMale_" + i.ToString();
            txtChildCare_Male.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtChildCare_Male.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtChildCare_Male.Attributes["onpaste"] = "return false";
            txtChildCare_Male.Text = "0";
            RequiredFieldValidator rfvChildCare1 = new RequiredFieldValidator();
            rfvChildCare1.ID = "rfvChildCareMale_" + i.ToString();
            rfvChildCare1.Display = ValidatorDisplay.Dynamic;
            rfvChildCare1.ControlToValidate = txtChildCare_Male.ID;
            rfvChildCare1.ErrorMessage = "*";
            rfvChildCare1.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td_ChildCare2.Controls.Add(txtChildCare_Male);
            td_ChildCare2.Controls.Add(rfvChildCare1);

            // Create column 3 Female
            TableCell td_ChildCare3 = new TableCell();
            td_ChildCare3.Width = Unit.Pixel(162);
            td_ChildCare3.Attributes["align"] = "Center";
            TextBox txtChildCare_Female = new TextBox();
            txtChildCare_Female.ID = "txtChildCareFemale_" + i.ToString();
            txtChildCare_Female.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtChildCare_Female.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtChildCare_Female.Attributes["onpaste"] = "return false";
            txtChildCare_Female.Text= "0";
            RequiredFieldValidator rfvChildCare2 = new RequiredFieldValidator();
            rfvChildCare2.ID = "rfvChildCareFemale_" + i.ToString();
            rfvChildCare2.Display = ValidatorDisplay.Dynamic;
            rfvChildCare2.ControlToValidate = txtChildCare_Female.ID;
            rfvChildCare2.ErrorMessage = "*";
            rfvChildCare2.Font.Size = FontUnit.Small;
            td_ChildCare3.Controls.Add(txtChildCare_Female);
            td_ChildCare3.Controls.Add(rfvChildCare2);

            // Add cell to the row
            tr_ChildCare.Cells.Add(td_ChildCare1);
            tr_ChildCare.Cells.Add(td_ChildCare2);
            tr_ChildCare.Cells.Add(td_ChildCare3);

            // Add row to the table.
            tblDynamic.Rows.Add(tr_ChildCare);
        }
        #endregion 

        /*
         * PROGRAM
         * DENTAL CARE
         * ADDED BY LAKHI
         */

        #region Table Creation for Dental Care
         /*SQL CODE TO ADD DATA IN TABLE ADDED LAKHI*/
        SqlConnection connDentalCare = new SqlConnection(data.Dataconnection);
        List<string> DentalCareData = new List<string>();
        connDentalCare.Open();

        SqlCommand dc_cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID = " +
            "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)", connDentalCare);
        dc_cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = "Dental Care";
        SqlDataReader dentalCareIndicatorReader = dc_cmdTxt.ExecuteReader();
        while (dentalCareIndicatorReader.Read())
        {
            DentalCareData.Add(dentalCareIndicatorReader.GetString(0));
        }

        /*Create Header*/
        TableRow tableRowDentalCare = new TableRow();
        TableCell tableCellDentalCare = new TableCell();
        Label lblDentalCare1 = new Label();
        lblDentalCare1.ID = "lbl_DentalCare";
        lblDentalCare1.Text = "Dental Care";
        lblDentalCare1.ForeColor = System.Drawing.Color.Green;
        tableCellDentalCare.Attributes["align"] = "Center";
        lblDentalCare1.Font.Bold = true;
        lblDentalCare1.Font.Size = FontUnit.Large;
        tableCellDentalCare.Controls.Add(lblDentalCare1);
        TableCell tableCellDentalCare2 = new TableCell();
        tableCellDentalCare2.Attributes["align"] = "Center";
        Label lblDentalCare2 = new Label();
        lblDentalCare2.ID = "lblDentalCareMale";
        lblDentalCare2.Text = "Male";
        lblDentalCare2.ForeColor = System.Drawing.Color.Green;
        lblDentalCare2.Font.Bold = true;
        lblDentalCare2.Font.Size = FontUnit.Large;
        tableCellDentalCare2.Controls.Add(lblDentalCare2);
        TableCell tableCellDentalCare3 = new TableCell();
        tableCellDentalCare3.Attributes["align"] = "Center";
        Label lblDentalCare3 = new Label();
        lblDentalCare3.ID = "lblDentalCareFemale";
        lblDentalCare3.Text = "Female";
        lblDentalCare3.ForeColor = System.Drawing.Color.Green;
        lblDentalCare3.Font.Bold = true;
        lblDentalCare3.Font.Size = FontUnit.Large;
        tableCellDentalCare3.Controls.Add(lblDentalCare3);
        tableRowDentalCare.Cells.Add(tableCellDentalCare);
        tableRowDentalCare.Cells.Add(tableCellDentalCare2);
        tableRowDentalCare.Cells.Add(tableCellDentalCare3);
        //End
        tblDynamic.Controls.Add(tableRowDentalCare);

        for (int i = 0; i < data.CountIndicatorPerProgram("Dental Care"); i++)
        {
            // Create row 1
            TableRow tr_DentalCare = new TableRow();

            // Create cell 1
            TableCell td_DentalCare = new TableCell();
            td_DentalCare.Width = Unit.Pixel(564);

            //Create a label control dynamically
            Label lblDentalIndicator = new Label();
            lblDentalIndicator.ID = "lblDentalCareIndicator" + i.ToString();
            lblDentalIndicator.Text = DentalCareData[i].ToString();
            // Add control to the table cell
            td_DentalCare.Controls.Add(lblDentalIndicator);

            // Create column 2 Male
            TableCell td_DentalCare2 = new TableCell();
            td_DentalCare2.Width = Unit.Pixel(162);
            td_DentalCare2.Attributes["align"] = "Center";
            TextBox txtDentalCareMale = new TextBox();
            txtDentalCareMale.ID = "txtDentalCareMale_" + i.ToString();
            txtDentalCareMale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtDentalCareMale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtDentalCareMale.Attributes["onpaste"] = "return false";
            txtDentalCareMale.Text = "0";
            RequiredFieldValidator rfvDentalCareMale = new RequiredFieldValidator();
            rfvDentalCareMale.ID = "rfvDentalCareMale_" + i.ToString();
            rfvDentalCareMale.Display = ValidatorDisplay.Dynamic;
            rfvDentalCareMale.ControlToValidate = txtDentalCareMale.ID;
            rfvDentalCareMale.ErrorMessage = "*";
            rfvDentalCareMale.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td_DentalCare2.Controls.Add(txtDentalCareMale);
            td_DentalCare2.Controls.Add(rfvDentalCareMale);

            // Create column 3 Female
            TableCell td_DentalCare3 = new TableCell();
            td_DentalCare3.Width = Unit.Pixel(162);
            td_DentalCare3.Attributes["align"] = "Center";
            TextBox txtDentalCareFemale = new TextBox();
            txtDentalCareFemale.ID = "txtDentalCareFemale_" + i.ToString();
            txtDentalCareFemale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtDentalCareFemale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtDentalCareFemale.Attributes["onpaste"] = "return false";
            txtDentalCareFemale.Text = "0";
            RequiredFieldValidator rfvDentalCareFemale = new RequiredFieldValidator();
            rfvDentalCareFemale.ID = "rfvDentalCareFemale" + i.ToString();
            rfvDentalCareFemale.Display = ValidatorDisplay.Dynamic;
            rfvDentalCareFemale.ControlToValidate = txtDentalCareFemale.ID;
            rfvDentalCareFemale.ErrorMessage = "*";
            rfvDentalCareFemale.Font.Size = FontUnit.Small;
            td_DentalCare3.Controls.Add(txtDentalCareFemale);
            td_DentalCare3.Controls.Add(rfvDentalCareFemale);

            // Add cell to the row
            tr_DentalCare.Cells.Add(td_DentalCare);
            tr_DentalCare.Cells.Add(td_DentalCare2);
            tr_DentalCare.Cells.Add(td_DentalCare3);

            // Add row to the table.
            tblDynamic.Rows.Add(tr_DentalCare);
        }
        #endregion

        /*
         * PROGRAM
         * MALARIA
         * ADDED BY LAKHI
         */

        #region Table Creation for Malaria
        /*SQL CODE TO ADD DATA IN TABLE ADDED LAKHI*/
        SqlConnection connMalaria = new SqlConnection(data.Dataconnection);
        List<string> MalariaData = new List<string>();
        connMalaria.Open();

        SqlCommand malaria_cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID = " +
            "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)", connMalaria);
        malaria_cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = "Malaria";
        SqlDataReader malariaIndicatorReader = malaria_cmdTxt.ExecuteReader();
        while (malariaIndicatorReader.Read())
        {
            MalariaData.Add(malariaIndicatorReader.GetString(0));
        }

        /*Create Header*/
        TableRow tableRowMalaria = new TableRow();
        TableCell tableCellMalaria = new TableCell();
        Label lblMalaria = new Label();
        lblMalaria.ID = "lbl_Malaria";
        lblMalaria.Text = "Malaria";
        lblMalaria.ForeColor = System.Drawing.Color.Green;
        tableCellMalaria.Attributes["align"] = "Center";
        lblMalaria.Font.Bold = true;
        lblMalaria.Font.Size = FontUnit.Large;
        tableCellMalaria.Controls.Add(lblMalaria);

        TableCell tableCellMalariaPregnant = new TableCell();
        tableCellMalariaPregnant.Attributes["align"] = "Center";
        Label lblMalariaPregnant = new Label();
        lblMalariaPregnant.ID = "lblMalariaMale";
        lblMalariaPregnant.Text = "Male";
        lblMalariaPregnant.ForeColor = System.Drawing.Color.Green;
        lblMalariaPregnant.Font.Bold = true;
        lblMalariaPregnant.Font.Size = FontUnit.Large;
        tableCellMalariaPregnant.Controls.Add(lblMalariaPregnant);
        
        TableCell tableCellMalaria2 = new TableCell();
        tableCellMalaria2.Attributes["align"] = "Center";
        Label lblMalariaMale = new Label();
        lblMalariaMale.ID = "lblMalariaMale";
        lblMalariaMale.Text = "Male";
        lblMalariaMale.ForeColor = System.Drawing.Color.Green;
        lblMalariaMale.Font.Bold = true;
        lblMalariaMale.Font.Size = FontUnit.Large;
        tableCellMalaria2.Controls.Add(lblMalariaMale);

        TableCell tableCellMalaria3 = new TableCell();
        tableCellMalaria3.Attributes["align"] = "Center";
        Label lblMalariaFemale = new Label();
        lblMalariaFemale.ID = "lblMalariaFemale";
        lblMalariaFemale.Text = "Female";
        lblMalariaFemale.Font.Bold = true;
        lblMalariaFemale.ForeColor = System.Drawing.Color.Green;
        lblMalariaFemale.Font.Size = FontUnit.Large;
        tableCellMalaria3.Controls.Add(lblMalariaFemale);
        tableRowMalaria.Cells.Add(tableCellMalaria);
        tableRowMalaria.Cells.Add(tableCellMalaria2);
        tableRowMalaria.Cells.Add(tableCellMalaria3);
        //End
        tblMalaria.Controls.Add(tableRowMalaria);

        for (int i = 0; i < data.CountIndicatorPerProgram("Malaria"); i++)
        {
            // Create row 1
            TableRow tr_Malaria = new TableRow();

            // Create cell 1
            TableCell td_Malaria = new TableCell();
            td_Malaria.Width = Unit.Pixel(564);

            //Create a label control dynamically
            Label lblMalariaIndicator = new Label();
            lblMalariaIndicator.ID = "lblMalariaIndicator" + i.ToString();
            lblMalariaIndicator.Text = MalariaData[i].ToString();
            // Add control to the table cell
            td_Malaria.Controls.Add(lblMalariaIndicator);
            
            //
            // Create column Pregnant
            TableCell tdMalariaPregnant = new TableCell();
            tdMalariaPregnant.Width = Unit.Pixel(162);
            tdMalariaPregnant.Attributes["align"] = "Center";
            TextBox txtMalariaPregnant = new TextBox();
            txtMalariaPregnant.ID = "txtMalariaPregnant_" + i.ToString();
            txtMalariaPregnant.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtMalariaPregnant.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtMalariaPregnant.Attributes["onpaste"] = "return false";
            txtMalariaPregnant.Text = "0";
            // Add control to the table cell
            RequiredFieldValidator rfvMalariaPregnant = new RequiredFieldValidator();
            rfvMalariaPregnant.ID = "rfvMalariaPregnant_" + i.ToString();
            rfvMalariaPregnant.Display = ValidatorDisplay.Dynamic;
            rfvMalariaPregnant.ControlToValidate = txtMalariaPregnant.ID;
            rfvMalariaPregnant.ErrorMessage = "*";
            rfvMalariaPregnant.Font.Size = FontUnit.Small;
            // Add control to the table cell
            tdMalariaPregnant.Controls.Add(txtMalariaPregnant);
            tdMalariaPregnant.Controls.Add(rfvMalariaPregnant);

            //

            // Create column 2 Male
            TableCell tdMalariaMale = new TableCell();
            tdMalariaMale.Width = Unit.Pixel(162);
            tdMalariaMale.Attributes["align"] = "Center";
            TextBox txtMalariaMale = new TextBox();
            txtMalariaMale.ID = "txtMalariaMale_" + i.ToString();
            txtMalariaMale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtMalariaMale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtMalariaMale.Attributes["onpaste"] = "return false";
            txtMalariaMale.Text = "0";
            // Add control to the table cell
            RequiredFieldValidator rfvMalariaMale = new RequiredFieldValidator();
            rfvMalariaMale.ID = "rfvMalariaMale_" + i.ToString();
            rfvMalariaMale.Display = ValidatorDisplay.Dynamic;
            rfvMalariaMale.ControlToValidate = txtMalariaMale.ID;
            rfvMalariaMale.ErrorMessage = "*";
            rfvMalariaMale.Font.Size = FontUnit.Small;
            // Add control to the table cell
            tdMalariaMale.Controls.Add(txtMalariaMale);
            tdMalariaMale.Controls.Add(rfvMalariaMale);

            // Create column 3 Female
            TableCell tdMalariaFemale = new TableCell();
            tdMalariaFemale.Width = Unit.Pixel(162);
            tdMalariaFemale.Attributes["align"] = "Center";
            TextBox txtMalariaFemale = new TextBox();
            txtMalariaFemale.ID = "txtMalariaFemale_" + i.ToString();
            txtMalariaFemale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtMalariaFemale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtMalariaFemale.Attributes["onpaste"] = "return false";
            txtMalariaFemale.Text = "0";
            RequiredFieldValidator rfvMalariaMaleMalariaFemale = new RequiredFieldValidator();
            rfvMalariaMaleMalariaFemale.ID = "rfvMalariaFemale_" + i.ToString();
            rfvMalariaMaleMalariaFemale.Display = ValidatorDisplay.Dynamic;
            rfvMalariaMaleMalariaFemale.ControlToValidate = txtMalariaFemale.ID;
            rfvMalariaMaleMalariaFemale.ErrorMessage = "*";
            rfvMalariaMaleMalariaFemale.Font.Size = FontUnit.Small;
            // Add control to the table cell
            tdMalariaFemale.Controls.Add(txtMalariaFemale);
            tdMalariaFemale.Controls.Add(rfvMalariaMaleMalariaFemale);

            // Add cell to the row
            tr_Malaria.Cells.Add(td_Malaria);
            tr_Malaria.Cells.Add(tdMalariaMale);
            tr_Malaria.Cells.Add(tdMalariaFemale);

            // Add row to the table.
            tblMalaria.Rows.Add(tr_Malaria);
        }
        #endregion

        /*
         * PROGRAM
         * LEPROSY
         * ADDED BY LAKHI
         */

        #region Table Creation for Leprosy
        /*SQL CODE TO ADD DATA IN TABLE ADDED LAKHI*/
        SqlConnection connLeprosy = new SqlConnection(data.Dataconnection);
        List<string> LeprosyData = new List<string>();
        connLeprosy.Open();

        SqlCommand leprosy_cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID = " +
            "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)", connLeprosy);
        leprosy_cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = "Leprosy";
        SqlDataReader leprosyIndicatorReader = leprosy_cmdTxt.ExecuteReader();
        while (leprosyIndicatorReader.Read())
        {
            LeprosyData.Add(leprosyIndicatorReader.GetString(0));
        }

        /*Create Header*/
        TableRow tableRowLeprosy = new TableRow();
        TableCell tableCellLeprosy = new TableCell();
        Label lblLeprosy = new Label();
        lblLeprosy.ID = "lblLeprosy";
        lblLeprosy.Text = "Leprosy";
        tableCellLeprosy.Attributes["align"] = "Center";
        lblLeprosy.Font.Bold = true;
        lblLeprosy.ForeColor = System.Drawing.Color.Green;
        lblLeprosy.Font.Size = FontUnit.Large;
        tableCellLeprosy.Controls.Add(lblLeprosy);
        TableCell tableCellLeprosy2 = new TableCell();
        tableCellLeprosy2.Attributes["align"] = "Center";
        Label lblLeprosyMale = new Label();
        lblLeprosyMale.ID = "lblLeprosyMale";
        lblLeprosyMale.Text = "Male";
        lblLeprosyMale.Font.Bold = true;
        lblLeprosyMale.ForeColor = System.Drawing.Color.Green;
        lblLeprosyMale.Font.Size = FontUnit.Large;
        tableCellLeprosy2.Controls.Add(lblLeprosyMale);
        TableCell tableCellLeprosy3 = new TableCell();
        tableCellLeprosy3.Attributes["align"] = "Center";
        Label lblLeprosyFemale = new Label();
        lblLeprosyFemale.ID = "lblLeprosyFemale";
        lblLeprosyFemale.Text = "Female";
        lblLeprosyFemale.ForeColor = System.Drawing.Color.Green;
        lblLeprosyFemale.Font.Bold = true;
        lblLeprosyFemale.Font.Size = FontUnit.Large;
        tableCellLeprosy3.Controls.Add(lblLeprosyFemale);
        tableRowLeprosy.Cells.Add(tableCellLeprosy);
        tableRowLeprosy.Cells.Add(tableCellLeprosy2);
        tableRowLeprosy.Cells.Add(tableCellLeprosy3);
        //End
        tblDynamic.Controls.Add(tableRowLeprosy);

        for (int i = 0; i < data.CountIndicatorPerProgram("Leprosy"); i++)
        {
            // Create row 1
            TableRow tr_Leprosy = new TableRow();

            // Create cell 1
            TableCell td_Leprosy1 = new TableCell();
            td_Leprosy1.Width = Unit.Pixel(564);

            //Create a label control dynamically
            Label lblLeprosyIndicator = new Label();
            lblLeprosyIndicator.ID = "lblLeprosyIndicator" + i.ToString();
            lblLeprosyIndicator.Text = LeprosyData[i].ToString();
            // Add control to the table cell
            td_Leprosy1.Controls.Add(lblLeprosyIndicator);

            // Create column 2 Male
            TableCell td_Leprosy_LeprosyMale = new TableCell();
            td_Leprosy_LeprosyMale.Width = Unit.Pixel(162);
            td_Leprosy_LeprosyMale.Attributes["align"] = "Center";
            TextBox txtLeprosyMale = new TextBox();
            txtLeprosyMale.ID = "txtLeprosyMale_" + i.ToString();
            txtLeprosyMale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtLeprosyMale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtLeprosyMale.Attributes["onpaste"] = "return false";
            txtLeprosyMale.Text= "0";
            // Add control to the table cell
            RequiredFieldValidator rfvLeprosyMale = new RequiredFieldValidator();
            rfvLeprosyMale.ID = "rfvLeprosyMale_" + i.ToString();
            rfvLeprosyMale.Display = ValidatorDisplay.Dynamic;
            rfvLeprosyMale.ControlToValidate = txtLeprosyMale.ID;
            rfvLeprosyMale.ErrorMessage = "*";
            rfvLeprosyMale.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td_Leprosy_LeprosyMale.Controls.Add(txtLeprosyMale);
            td_Leprosy_LeprosyMale.Controls.Add(rfvLeprosyMale);

            // Create column 3 Female
            TableCell td_Leprosy_LeprosyFemale = new TableCell();
            td_Leprosy_LeprosyFemale.Width = Unit.Pixel(162);
            td_Leprosy_LeprosyFemale.Attributes["align"] = "Center";
            TextBox txtLeprosyFemale = new TextBox();
            txtLeprosyFemale.ID = "txtLeprosyFemale_" + i.ToString();
            txtLeprosyFemale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtLeprosyFemale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtLeprosyFemale.Attributes["onpaste"] = "return false";
            txtLeprosyFemale.Text = "0";
            RequiredFieldValidator rfvLeprosyMaleLeprosyFemale = new RequiredFieldValidator();
            rfvLeprosyMaleLeprosyFemale.ID = "rfvLeprosyFeMale_" + i.ToString();
            rfvLeprosyMaleLeprosyFemale.Display = ValidatorDisplay.Dynamic;
            rfvLeprosyMaleLeprosyFemale.ControlToValidate = txtLeprosyFemale.ID;
            rfvLeprosyMaleLeprosyFemale.ErrorMessage = "*";
            rfvLeprosyMaleLeprosyFemale.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td_Leprosy_LeprosyFemale.Controls.Add(txtLeprosyFemale);
            td_Leprosy_LeprosyFemale.Controls.Add(rfvLeprosyMaleLeprosyFemale);

            // Add cell to the row
            tr_Leprosy.Cells.Add(td_Leprosy1);
            tr_Leprosy.Cells.Add(td_Leprosy_LeprosyMale);
            tr_Leprosy.Cells.Add(td_Leprosy_LeprosyFemale);

            // Add row to the table.
            tblDynamic.Rows.Add(tr_Leprosy);
        }
        #endregion


        /*
         * PROGRAM
         * FILARIASIS
         * ADDED BY LAKHI
         */

        #region Table Creation for Filariasis
        /*SQL CODE TO ADD DATA IN TABLE ADDED LAKHI*/
        SqlConnection connFilariasis = new SqlConnection(data.Dataconnection);
        List<string> indicatorData = new List<string>();
        connFilariasis.Open();

        SqlCommand filariasis_cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID = " +
            "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)", connFilariasis);
        filariasis_cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = "Filariasis";
        SqlDataReader filariasisIndicatorReader = filariasis_cmdTxt.ExecuteReader();
        while (filariasisIndicatorReader.Read())
        {
            indicatorData.Add(filariasisIndicatorReader.GetString(0));
        }

        /*Create Header*/
        TableRow tableRowFilariasis = new TableRow();
        TableCell tableCellFilariasis = new TableCell();
        Label lblFilariasis = new Label();
        lblFilariasis.ID = "lblFilariasis";
        lblFilariasis.Text = "Filariasis";
        tableCellFilariasis.Attributes["align"] = "Center";
        lblFilariasis.Font.Bold = true;
        lblFilariasis.ForeColor = System.Drawing.Color.Green;
        lblFilariasis.Font.Size = FontUnit.Large;
        tableCellFilariasis.Controls.Add(lblFilariasis);
        TableCell tableCellFilariasis2 = new TableCell();
        tableCellFilariasis2.Attributes["align"] = "Center";
        Label lblFilariasisMale = new Label();
        lblFilariasisMale.ID = "lblFilariasisMale";
        lblFilariasisMale.Text = "Male";
        lblFilariasisMale.ForeColor = System.Drawing.Color.Green;
        lblFilariasisMale.Font.Bold = true;
        lblFilariasisMale.Font.Size = FontUnit.Large;
        tableCellFilariasis2.Controls.Add(lblFilariasisMale);
        TableCell tableCellFilariasis3 = new TableCell();
        tableCellFilariasis3.Attributes["align"] = "Center";
        Label lblFilariasisFemale = new Label();
        lblFilariasisFemale.ID = "lblFilariasisFemale";
        lblFilariasisFemale.Text = "Female";
        lblFilariasisFemale.ForeColor = System.Drawing.Color.Green;
        lblFilariasisFemale.Font.Bold = true;
        lblFilariasisFemale.Font.Size = FontUnit.Large;
        tableCellFilariasis3.Controls.Add(lblFilariasisFemale);
        tableRowFilariasis.Cells.Add(tableCellFilariasis);
        tableRowFilariasis.Cells.Add(tableCellFilariasis2);
        tableRowFilariasis.Cells.Add(tableCellFilariasis3);
        //End
        tblDynamic.Controls.Add(tableRowFilariasis);

        for (int i = 0; i < data.CountIndicatorPerProgram("Filariasis"); i++)
        {
            // Create row 1
            TableRow tr_Filariasis = new TableRow();

            // Create cell 1
            TableCell td_Filariasis1 = new TableCell();
            td_Filariasis1.Width = Unit.Pixel(564);

            //Create a label control dynamically
            Label lblFilariasisIndicator = new Label();
            lblFilariasisIndicator.ID = "lblFilariasisIndicator" + i.ToString();
            lblFilariasisIndicator.Text = indicatorData[i].ToString();
            // Add control to the table cell
            td_Filariasis1.Controls.Add(lblFilariasisIndicator);

            // Create column 2 Male
            TableCell td_FilariasisMale = new TableCell();
            td_FilariasisMale.Width = Unit.Pixel(162);
            td_FilariasisMale.Attributes["align"] = "Center";
            TextBox txtFilariasisMale = new TextBox();
            txtFilariasisMale.ID = "txtFilariasisMale_" + i.ToString();
            txtFilariasisMale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtFilariasisMale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtFilariasisMale.Attributes["onpaste"] = "return false";
            txtFilariasisMale.Text = "0";
            RequiredFieldValidator rfvFilariasisMale = new RequiredFieldValidator();
            rfvFilariasisMale.ID = "rfvFilariasisMale_" + i.ToString();
            rfvFilariasisMale.Display = ValidatorDisplay.Dynamic;
            rfvFilariasisMale.ControlToValidate = txtFilariasisMale.ID;
            rfvFilariasisMale.ErrorMessage = "*";
            rfvFilariasisMale.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td_FilariasisMale.Controls.Add(txtFilariasisMale);
            td_FilariasisMale.Controls.Add(rfvFilariasisMale);

            // Create column 3 Female
            TableCell td_FilariasisFemale = new TableCell();
            td_FilariasisFemale.Width = Unit.Pixel(162);
            td_FilariasisFemale.Attributes["align"] = "Center";
            TextBox txtFilariasisFemale = new TextBox();
            txtFilariasisFemale.ID = "txtFilariasisFemale_" + i.ToString();
            txtFilariasisFemale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtFilariasisFemale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtFilariasisFemale.Attributes["onpaste"] = "return false";
            txtFilariasisFemale.Text = "0";
            RequiredFieldValidator rfvFilariasisMaleFilariasisFemale = new RequiredFieldValidator();
            rfvFilariasisMaleFilariasisFemale.ID = "rfvFilariasisFemale_" + i.ToString();
            rfvFilariasisMaleFilariasisFemale.Display = ValidatorDisplay.Dynamic;
            rfvFilariasisMaleFilariasisFemale.ControlToValidate = txtFilariasisFemale.ID;
            rfvFilariasisMaleFilariasisFemale.ErrorMessage = "*";
            rfvFilariasisMaleFilariasisFemale.Font.Size = FontUnit.Small;
            td_FilariasisFemale.Controls.Add(txtFilariasisFemale);
            td_FilariasisFemale.Controls.Add(rfvFilariasisMaleFilariasisFemale);

            // Add cell to the row
            tr_Filariasis.Cells.Add(td_Filariasis1);
            tr_Filariasis.Cells.Add(td_FilariasisMale);
            tr_Filariasis.Cells.Add(td_FilariasisFemale);

            // Add row to the table.
            tblDynamic.Rows.Add(tr_Filariasis);
        }
        #endregion

        /*
         * PROGRAM
         * TUBERCULOSIS
         * ADDED BY LAKHI
         */

        #region Table Creation for Tuberculosis
        /*SQL CODE TO ADD DATA IN TABLE ADDED LAKHI*/
        SqlConnection connTuberculosis = new SqlConnection(data.Dataconnection);
        List<string> TuberculosisData = new List<string>();
        connTuberculosis.Open();

        SqlCommand tuberculosis_cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID = " +
            "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)", connTuberculosis);
        tuberculosis_cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = "Tuberculosis";
        SqlDataReader tuberculosisIndicatorReader = tuberculosis_cmdTxt.ExecuteReader();
        while (tuberculosisIndicatorReader.Read())
        {
            TuberculosisData.Add(tuberculosisIndicatorReader.GetString(0));
        }

        /*Create Header*/
        TableRow tableRowTuberculosis = new TableRow();
        TableCell tableCellTuberculosis = new TableCell();
        Label lblTuberculosis = new Label();
        lblTuberculosis.ID = "lblTuberculosis";
        lblTuberculosis.Text = "Tuberculosis";
        tableCellTuberculosis.Attributes["align"] = "Center";
        lblTuberculosis.Font.Bold = true;
        lblTuberculosis.ForeColor = System.Drawing.Color.Green;
        lblTuberculosis.Font.Size = FontUnit.Large;
        tableCellTuberculosis.Controls.Add(lblTuberculosis);
        TableCell tableCellTuberculosis2 = new TableCell();
        tableCellTuberculosis2.Attributes["align"] = "Center";
        Label lblTuberculosisMale = new Label();
        lblTuberculosisMale.ID = "lblTuberculosisMale";
        lblTuberculosisMale.Text = "Male";
        lblTuberculosisMale.Font.Bold = true;
        lblTuberculosisMale.ForeColor = System.Drawing.Color.Green;
        lblTuberculosisMale.Font.Size = FontUnit.Large;
        tableCellTuberculosis2.Controls.Add(lblTuberculosisMale);
        TableCell tableCellTuberculosis3 = new TableCell();
        tableCellTuberculosis3.Attributes["align"] = "Center";
        Label lblTuberculosisFemale = new Label();
        lblTuberculosisFemale.ID = "lblTuberculosisFemale";
        lblTuberculosisFemale.Text = "Female";
        lblTuberculosisFemale.ForeColor = System.Drawing.Color.Green;
        lblTuberculosisFemale.Font.Bold = true;
        lblTuberculosisFemale.Font.Size = FontUnit.Large;
        tableCellTuberculosis3.Controls.Add(lblTuberculosisFemale);
        tableRowTuberculosis.Cells.Add(tableCellTuberculosis);
        tableRowTuberculosis.Cells.Add(tableCellTuberculosis2);
        tableRowTuberculosis.Cells.Add(tableCellTuberculosis3);
        //End
        tblDynamic.Controls.Add(tableRowTuberculosis);

        for (int i = 0; i < data.CountIndicatorPerProgram("Tuberculosis"); i++)
        {
            // Create row 1
            TableRow tr_Tuberculosis = new TableRow();

            // Create cell 1
            TableCell td_Tuberculosis1 = new TableCell();
            td_Tuberculosis1.Width = Unit.Pixel(564);

            //Create a label control dynamically
            Label lblTuberculosisIndicator = new Label();
            lblTuberculosisIndicator.ID = "lblTuberculosisIndicator" + i.ToString();
            lblTuberculosisIndicator.Text = TuberculosisData[i].ToString();
            // Add control to the table cell
            td_Tuberculosis1.Controls.Add(lblTuberculosisIndicator);

            // Create column 2 Male
            TableCell td_TuberculosisMale = new TableCell();
            td_TuberculosisMale.Width = Unit.Pixel(162);
            td_TuberculosisMale.Attributes["align"] = "Center";
            TextBox txtTuberculosisMale = new TextBox();
            txtTuberculosisMale.ID = "txtTuberculosisMale_" + i.ToString();
            txtTuberculosisMale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtTuberculosisMale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtTuberculosisMale.Attributes["onpaste"] = "return false";
            txtTuberculosisMale.Text = "0";
            // Add control to the table cell
            RequiredFieldValidator rfvTuberculosisMale = new RequiredFieldValidator();
            rfvTuberculosisMale.ID = "rfvTuberculosisMale_" + i.ToString();
            rfvTuberculosisMale.Display = ValidatorDisplay.Dynamic;
            rfvTuberculosisMale.ControlToValidate = txtTuberculosisMale.ID;
            rfvTuberculosisMale.ErrorMessage = "*";
            rfvTuberculosisMale.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td_TuberculosisMale.Controls.Add(txtTuberculosisMale);
            td_TuberculosisMale.Controls.Add(rfvTuberculosisMale);

            // Create column 3 Female
            TableCell td_TuberculosisFemale = new TableCell();
            td_TuberculosisFemale.Width = Unit.Pixel(162);
            td_TuberculosisFemale.Attributes["align"] = "Center";
            TextBox txtTuberculosisFemale = new TextBox();
            txtTuberculosisFemale.ID = "txtTuberculosisFemale_" + i.ToString();
            txtTuberculosisFemale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtTuberculosisFemale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtTuberculosisFemale.Attributes["onpaste"] = "return false";
            txtTuberculosisFemale.Text = "0";
            RequiredFieldValidator rfvTuberculosisMaleTuberculosisFemale = new RequiredFieldValidator();
            rfvTuberculosisMaleTuberculosisFemale.ID = "rfvTuberculosisFemale_" + i.ToString();
            rfvTuberculosisMaleTuberculosisFemale.Display = ValidatorDisplay.Dynamic;
            rfvTuberculosisMaleTuberculosisFemale.ControlToValidate = txtTuberculosisFemale.ID;
            rfvTuberculosisMaleTuberculosisFemale.ErrorMessage = "*";
            rfvTuberculosisMaleTuberculosisFemale.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td_TuberculosisFemale.Controls.Add(txtTuberculosisFemale);
            td_TuberculosisFemale.Controls.Add(rfvTuberculosisMaleTuberculosisFemale);

            // Add cell to the row
            tr_Tuberculosis.Cells.Add(td_Tuberculosis1);
            tr_Tuberculosis.Cells.Add(td_TuberculosisMale);
            tr_Tuberculosis.Cells.Add(td_TuberculosisFemale);

            // Add row to the table.
            tblDynamic.Rows.Add(tr_Tuberculosis);
        }
        #endregion

        /*
         * PROGRAM
         * SCHISTOMIASIS
         * ADDED BY LAKHI
         */

        #region Table Creation for Schistomiasis
        /*SQL CODE TO ADD DATA IN TABLE ADDED LAKHI*/
        SqlConnection connSchistomiasis = new SqlConnection(data.Dataconnection);
        List<string> SchistomiasisData = new List<string>();
        connSchistomiasis.Open();

        SqlCommand schistomiasis_cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID = " +
            "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)", connSchistomiasis);
        schistomiasis_cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = "Schistomiasis";
        SqlDataReader schistomiasisIndicatorReader = schistomiasis_cmdTxt.ExecuteReader();
        while (schistomiasisIndicatorReader.Read())
        {
            SchistomiasisData.Add(schistomiasisIndicatorReader.GetString(0));
        }

        /*Create Header*/
        TableRow tableRowSchistomiasis = new TableRow();
        TableCell tableCellSchistomiasis = new TableCell();
        Label lblSchistomiasis = new Label();
        lblSchistomiasis.ID = "lblSchistomiasis";
        lblSchistomiasis.Text = "Schistomiasis";
        tableCellSchistomiasis.Attributes["align"] = "Center";
        lblSchistomiasis.Font.Bold = true;
        lblSchistomiasis.ForeColor = System.Drawing.Color.Green;
        lblSchistomiasis.Font.Size = FontUnit.Large;
        tableCellSchistomiasis.Controls.Add(lblSchistomiasis);
        TableCell tableCellSchistomiasis2 = new TableCell();
        tableCellSchistomiasis2.Attributes["align"] = "Center";
        Label lblSchistomiasisMale = new Label();
        lblSchistomiasisMale.ID = "lblSchistomiasisMale";
        lblSchistomiasisMale.Text = "Male";
        lblSchistomiasisMale.Font.Bold = true;
        lblSchistomiasisMale.ForeColor = System.Drawing.Color.Green;
        lblSchistomiasisMale.Font.Size = FontUnit.Large;
        tableCellSchistomiasis2.Controls.Add(lblSchistomiasisMale);
        TableCell tableCellSchistomiasis3 = new TableCell();
        tableCellSchistomiasis3.Attributes["align"] = "Center";
        Label lblSchistomiasisFemale = new Label();
        lblSchistomiasisFemale.ID = "lblSchistomiasisFemale";
        lblSchistomiasisFemale.Text = "Female";
        lblSchistomiasisFemale.ForeColor = System.Drawing.Color.Green;
        lblSchistomiasisFemale.Font.Bold = true;
        lblSchistomiasisFemale.Font.Size = FontUnit.Large;
        tableCellSchistomiasis3.Controls.Add(lblSchistomiasisFemale);
        tableRowSchistomiasis.Cells.Add(tableCellSchistomiasis);
        tableRowSchistomiasis.Cells.Add(tableCellSchistomiasis2);
        tableRowSchistomiasis.Cells.Add(tableCellSchistomiasis3);
        //End
        tblDynamic.Controls.Add(tableRowSchistomiasis);

        for (int i = 0; i < data.CountIndicatorPerProgram("Schistomiasis"); i++)
        {
            // Create row 1
            TableRow tr_Schistomiasis = new TableRow();

            // Create cell 1
            TableCell td_Schistomiasis1 = new TableCell();
            td_Schistomiasis1.Width = Unit.Pixel(564);

            //Create a label control dynamically
            Label lblSchistomiasisIndicator = new Label();
            lblSchistomiasisIndicator.ID = "lblSchistomiasisIndicator" + i.ToString();
            lblSchistomiasisIndicator.Text = SchistomiasisData[i].ToString();
            // Add control to the table cell
            td_Schistomiasis1.Controls.Add(lblSchistomiasisIndicator);

            // Create column 2 Male
            TableCell td_Schistomiasis_SchistomiasisMale = new TableCell();
            td_Schistomiasis_SchistomiasisMale.Width = Unit.Pixel(162);
            td_Schistomiasis_SchistomiasisMale.Attributes["align"] = "Center";
            TextBox txtSchistomiasisMale = new TextBox();
            txtSchistomiasisMale.ID = "txtSchistomiasisMale_" + i.ToString();
            txtSchistomiasisMale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtSchistomiasisMale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtSchistomiasisMale.Attributes["onpaste"] = "return false";
            txtSchistomiasisMale.Text = "0";
            // Add control to the table cell
            RequiredFieldValidator rfvSchistomiasisMale = new RequiredFieldValidator();
            rfvSchistomiasisMale.ID = "rfvSchistomiasisMale_" + i.ToString();
            rfvSchistomiasisMale.Display = ValidatorDisplay.Dynamic;
            rfvSchistomiasisMale.ControlToValidate = txtSchistomiasisMale.ID;
            rfvSchistomiasisMale.ErrorMessage = "*";
            rfvSchistomiasisMale.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td_Schistomiasis_SchistomiasisMale.Controls.Add(txtSchistomiasisMale);
            td_Schistomiasis_SchistomiasisMale.Controls.Add(rfvSchistomiasisMale);

            // Create column 3 Female
            TableCell td_Schistomiasis_SchistomiasisFemale = new TableCell();
            td_Schistomiasis_SchistomiasisFemale.Width = Unit.Pixel(162);
            td_Schistomiasis_SchistomiasisFemale.Attributes["align"] = "Center";
            TextBox txtSchistomiasisFemale = new TextBox();
            txtSchistomiasisFemale.ID = "txtSchistomiasisFemale_" + i.ToString();
            txtSchistomiasisFemale.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtSchistomiasisFemale.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtSchistomiasisFemale.Attributes["onpaste"] = "return false";
            txtSchistomiasisFemale.Text = "0";
            RequiredFieldValidator rfvSchistomiasisMaleSchistomiasisFemale = new RequiredFieldValidator();
            rfvSchistomiasisMaleSchistomiasisFemale.ID = "rfvSchistomiasisFemale_" + i.ToString();
            rfvSchistomiasisMaleSchistomiasisFemale.Display = ValidatorDisplay.Dynamic;
            rfvSchistomiasisMaleSchistomiasisFemale.ControlToValidate = txtSchistomiasisFemale.ID;
            rfvSchistomiasisMaleSchistomiasisFemale.ErrorMessage = "*";
            rfvSchistomiasisMaleSchistomiasisFemale.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td_Schistomiasis_SchistomiasisFemale.Controls.Add(txtSchistomiasisFemale);
            td_Schistomiasis_SchistomiasisFemale.Controls.Add(rfvSchistomiasisMaleSchistomiasisFemale);

            // Add cell to the row
            tr_Schistomiasis.Cells.Add(td_Schistomiasis1);
            tr_Schistomiasis.Cells.Add(td_Schistomiasis_SchistomiasisMale);
            tr_Schistomiasis.Cells.Add(td_Schistomiasis_SchistomiasisFemale);

            // Add row to the table.
            tblDynamic.Rows.Add(tr_Schistomiasis);
        }
        #endregion

        /*
         * PROGRAM
         * FAMILY PLANNING
         * ADDED BY LAKHI
         */

        #region Table Creation for Family Planning
        /*SQL CODE TO ADD DATA IN TABLE ADDED LAKHI*/
        SqlConnection connFP = new SqlConnection(data.Dataconnection);
        List<string> familyPlanningData = new List<string>();
        connFP.Open();

        SqlCommand fp_cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID = " +
            "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)", connFP);
        fp_cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = "Family Planning";
        SqlDataReader familyPlanningIndicatorReader = fp_cmdTxt.ExecuteReader();
        while (familyPlanningIndicatorReader.Read())
        {
            familyPlanningData.Add(familyPlanningIndicatorReader.GetString(0));
        }

        /*Create Header*/
        TableRow tableRowFamilyPlanning = new TableRow();
        TableCell tableCellFamilyPlanning = new TableCell();
        Label lblFamilyPlanning = new Label();
        lblFamilyPlanning.ID = "lblFamilyPlanning";
        lblFamilyPlanning.Text = "Family Planning";
        tableCellFamilyPlanning.Attributes["align"] = "Center";
        lblFamilyPlanning.Font.Bold = true;
        lblFamilyPlanning.ForeColor = System.Drawing.Color.Green;
        lblFamilyPlanning.Font.Size = FontUnit.Large;
        tableCellFamilyPlanning.Controls.Add(lblFamilyPlanning);
        TableCell tableCellFamilyPlanning2 = new TableCell();
        tableCellFamilyPlanning2.Attributes["align"] = "Center";
        Label lblFamilyPlanningStartUser = new Label();
        lblFamilyPlanningStartUser.ID = "lblFamilyPlanningStartUser";
        lblFamilyPlanningStartUser.Text = "Start User";
        lblFamilyPlanningStartUser.Font.Bold = true;
        lblFamilyPlanningStartUser.ForeColor = System.Drawing.Color.Green;
        lblFamilyPlanningStartUser.Font.Size = FontUnit.Large;
        tableCellFamilyPlanning2.Controls.Add(lblFamilyPlanningStartUser);
        TableCell tableCellFamilyPlanning3 = new TableCell();
        tableCellFamilyPlanning3.Attributes["align"] = "Center";
        Label lblFamilyPlanningNew = new Label();
        lblFamilyPlanningNew.ID = "lblFamilyPlanningNew";
        lblFamilyPlanningNew.Text = "New";
        lblFamilyPlanningNew.ForeColor = System.Drawing.Color.Green;
        lblFamilyPlanningNew.Font.Bold = true;
        lblFamilyPlanningNew.Font.Size = FontUnit.Large;
        tableCellFamilyPlanning3.Controls.Add(lblFamilyPlanningNew);
        TableCell tableCellFamilyPlanning4 = new TableCell();
        tableCellFamilyPlanning4.Attributes["align"] = "Center";
        Label lblFamilyPlanningOthers = new Label();
        lblFamilyPlanningOthers.ID = "lblFamilyPlanningOthers";
        lblFamilyPlanningOthers.Text = "Others";
        lblFamilyPlanningOthers.Font.Bold = true;
        lblFamilyPlanningOthers.ForeColor = System.Drawing.Color.Green;
        lblFamilyPlanningOthers.Font.Size = FontUnit.Large;
        tableCellFamilyPlanning4.Controls.Add(lblFamilyPlanningOthers);
        TableCell tableCellFamilyPlanning5 = new TableCell();
        tableCellFamilyPlanning5.Attributes["align"] = "Center";
        Label lblFamilyPlanningDropOut = new Label();
        lblFamilyPlanningDropOut.ID = "lblFamilyPlanningDropOut";
        lblFamilyPlanningDropOut.Text = "Drop Out";
        lblFamilyPlanningDropOut.Font.Bold = true;
        lblFamilyPlanningDropOut.ForeColor = System.Drawing.Color.Green;
        lblFamilyPlanningDropOut.Font.Size = FontUnit.Large;
        tableCellFamilyPlanning5.Controls.Add(lblFamilyPlanningDropOut);
        TableCell tableCellFamilyPlanning6 = new TableCell();
        tableCellFamilyPlanning6.Attributes["align"] = "Center";
        Label lblFamilyPlanningEndUser = new Label();
        lblFamilyPlanningEndUser.ID = "lblFamilyPlanningEndUser";
        lblFamilyPlanningEndUser.Text = "End User";
        lblFamilyPlanningEndUser.Font.Bold = true;
        lblFamilyPlanningEndUser.ForeColor = System.Drawing.Color.Green;
        lblFamilyPlanningEndUser.Font.Size = FontUnit.Large;
        tableCellFamilyPlanning6.Controls.Add(lblFamilyPlanningEndUser);

        tableRowFamilyPlanning.Cells.Add(tableCellFamilyPlanning);
        tableRowFamilyPlanning.Cells.Add(tableCellFamilyPlanning2);
        tableRowFamilyPlanning.Cells.Add(tableCellFamilyPlanning3);
        tableRowFamilyPlanning.Cells.Add(tableCellFamilyPlanning4);
        tableRowFamilyPlanning.Cells.Add(tableCellFamilyPlanning5);
        tableRowFamilyPlanning.Cells.Add(tableCellFamilyPlanning6);
        //End
        tblFamilyPlanning.Controls.Add(tableRowFamilyPlanning);

        for (int i = 0; i < data.CountIndicatorPerProgram("Family Planning"); i++)
        {
            // Create row 1
            TableRow tr_FamilyPlanning = new TableRow();

            // Create cell 1
            TableCell td_FamilyPlanningIndicator = new TableCell();
            td_FamilyPlanningIndicator.Width = Unit.Pixel(564);

            //Create a label control dynamically
            Label lblFamilyPlanningIndicator = new Label();
            lblFamilyPlanningIndicator.ID = "lblFamilyPlanningIndicator" + i.ToString();
            lblFamilyPlanningIndicator.Text = familyPlanningData[i].ToString();
            // Add control to the table cell
            td_FamilyPlanningIndicator.Controls.Add(lblFamilyPlanningIndicator);

            // Create column 2 Start User
            TableCell td_FamilyPlanning_FamilyPlanningStartUser = new TableCell();
            td_FamilyPlanning_FamilyPlanningStartUser.Width = Unit.Pixel(162);
            td_FamilyPlanning_FamilyPlanningStartUser.Attributes["align"] = "Center";
            TextBox txtFamilyPlanningStartUser = new TextBox();
            txtFamilyPlanningStartUser.ID = "txtFamilyPlanningStartUser_" + i.ToString();
            txtFamilyPlanningStartUser.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtFamilyPlanningStartUser.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtFamilyPlanningStartUser.Attributes["onpaste"] = "return false";
            txtFamilyPlanningStartUser.Width = Unit.Pixel(45);
            txtFamilyPlanningStartUser.Text = "0";
            RequiredFieldValidator rfvFamilyPlanningStartUser = new RequiredFieldValidator();
            rfvFamilyPlanningStartUser.ID = "rfvFamilyPlanningStartUser_" + i.ToString();
            rfvFamilyPlanningStartUser.Display = ValidatorDisplay.Dynamic;
            rfvFamilyPlanningStartUser.ControlToValidate = txtFamilyPlanningStartUser.ID;
            rfvFamilyPlanningStartUser.ErrorMessage = "*";
            rfvFamilyPlanningStartUser.Font.Size = FontUnit.Small;
            // Add control to the table cell
            td_FamilyPlanning_FamilyPlanningStartUser.Controls.Add(txtFamilyPlanningStartUser);
            td_FamilyPlanning_FamilyPlanningStartUser.Controls.Add(rfvFamilyPlanningStartUser);

            // Create column 3 New
            TableCell td_FamilyPlanning_FamilyPlanningNew = new TableCell();
            td_FamilyPlanning_FamilyPlanningNew.Width = Unit.Pixel(120);
            td_FamilyPlanning_FamilyPlanningNew.Attributes["align"] = "Center";
            TextBox txtFamilyPlanningNew = new TextBox();
            txtFamilyPlanningNew.ID = "txtFamilyPlanningNew_" + i.ToString();
            txtFamilyPlanningNew.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtFamilyPlanningNew.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtFamilyPlanningNew.Attributes["onpaste"] = "return false";
            txtFamilyPlanningNew.Width = Unit.Pixel(45);
            txtFamilyPlanningNew.Text = "0";
            RequiredFieldValidator rfvFamilyPlanningNew = new RequiredFieldValidator();
            rfvFamilyPlanningNew.ID = "rfvFamilyPlanningNew_" + i.ToString();
            rfvFamilyPlanningNew.Display = ValidatorDisplay.Dynamic;
            rfvFamilyPlanningNew.ControlToValidate = txtFamilyPlanningNew.ID;
            rfvFamilyPlanningNew.ErrorMessage = "*";
            rfvFamilyPlanningNew.Font.Size = FontUnit.Small;
            td_FamilyPlanning_FamilyPlanningNew.Controls.Add(txtFamilyPlanningNew);
            td_FamilyPlanning_FamilyPlanningNew.Controls.Add(rfvFamilyPlanningNew);

            // Create column 4 Others
            TableCell td_FamilyPlanning_FamilyPlanningOthers = new TableCell();
            td_FamilyPlanning_FamilyPlanningOthers.Width = Unit.Pixel(120);
            td_FamilyPlanning_FamilyPlanningOthers.Attributes["align"] = "Center";
            TextBox txtFamilyPlanningOthers = new TextBox();
            txtFamilyPlanningOthers.ID = "txtFamilyPlanningOthers_" + i.ToString();
            txtFamilyPlanningOthers.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtFamilyPlanningOthers.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtFamilyPlanningOthers.Attributes["onpaste"] = "return false";
            txtFamilyPlanningOthers.Width = Unit.Pixel(45);
            txtFamilyPlanningOthers.Text = "0";
            RequiredFieldValidator rfvFamilyPlanningOthers = new RequiredFieldValidator();
            rfvFamilyPlanningOthers.ID = "rfvFamilyPlanningOthers_" + i.ToString();
            rfvFamilyPlanningOthers.Display = ValidatorDisplay.Dynamic;
            rfvFamilyPlanningOthers.ControlToValidate = txtFamilyPlanningOthers.ID;
            rfvFamilyPlanningOthers.ErrorMessage = "*";
            rfvFamilyPlanningOthers.Font.Size = FontUnit.Small;
            td_FamilyPlanning_FamilyPlanningOthers.Controls.Add(txtFamilyPlanningOthers);
            td_FamilyPlanning_FamilyPlanningOthers.Controls.Add(rfvFamilyPlanningOthers);

            // Create column 5 DropOut
            TableCell td_FamilyPlanning_FamilyPlanningDropOut = new TableCell();
            td_FamilyPlanning_FamilyPlanningDropOut.Width = Unit.Pixel(120);
            td_FamilyPlanning_FamilyPlanningDropOut.Attributes["align"] = "Center";
            TextBox txtFamilyPlanningDropOut = new TextBox();
            txtFamilyPlanningDropOut.ID = "txtFamilyPlanningDropOut_" + i.ToString();
            txtFamilyPlanningDropOut.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtFamilyPlanningDropOut.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtFamilyPlanningDropOut.Attributes["onpaste"] = "return false";
            txtFamilyPlanningDropOut.Width = Unit.Pixel(45);
            txtFamilyPlanningDropOut.Text = "0";
            RequiredFieldValidator rfvFamilyPlanningDropOut = new RequiredFieldValidator();
            rfvFamilyPlanningDropOut.ID = "rfvFamilyPlanningDropOut" + i.ToString();
            rfvFamilyPlanningDropOut.Display = ValidatorDisplay.Dynamic;
            rfvFamilyPlanningDropOut.ControlToValidate = txtFamilyPlanningDropOut.ID;
            rfvFamilyPlanningDropOut.ErrorMessage = "*";
            rfvFamilyPlanningDropOut.Font.Size = FontUnit.Small;
            td_FamilyPlanning_FamilyPlanningDropOut.Controls.Add(txtFamilyPlanningDropOut);
            td_FamilyPlanning_FamilyPlanningDropOut.Controls.Add(rfvFamilyPlanningDropOut);

            // Create column 6 End User
            TableCell td_FamilyPlanning_FamilyPlanningEndUser = new TableCell();
            td_FamilyPlanning_FamilyPlanningEndUser.Width = Unit.Pixel(120);
            td_FamilyPlanning_FamilyPlanningEndUser.Attributes["align"] = "Center";
            TextBox txtFamilyPlanningEndUser = new TextBox();
            txtFamilyPlanningEndUser.ID = "txtFamilyPlanningEndUser_" + i.ToString();
            txtFamilyPlanningEndUser.Attributes["onkeydown"] = "return isNumeric(event.keyCode);";
            txtFamilyPlanningEndUser.Attributes["onkeyup"] = "keyUP(event.keyCode)";
            txtFamilyPlanningEndUser.Attributes["onpaste"] = "return false";
            txtFamilyPlanningEndUser.Width = Unit.Pixel(45);
            txtFamilyPlanningEndUser.Text = "0";
            RequiredFieldValidator rfvFamilyPlanningEndUser = new RequiredFieldValidator();
            rfvFamilyPlanningEndUser.ID = "rfvFamilyPlanningEndUser_" + i.ToString();
            rfvFamilyPlanningEndUser.Display = ValidatorDisplay.Dynamic;
            rfvFamilyPlanningEndUser.ControlToValidate = txtFamilyPlanningEndUser.ID;
            rfvFamilyPlanningEndUser.ErrorMessage = "*";
            rfvFamilyPlanningEndUser.Font.Size = FontUnit.Small;
            td_FamilyPlanning_FamilyPlanningEndUser.Controls.Add(txtFamilyPlanningEndUser);
            td_FamilyPlanning_FamilyPlanningEndUser.Controls.Add(rfvFamilyPlanningEndUser);

            // Add cell to the row
            tr_FamilyPlanning.Cells.Add(td_FamilyPlanningIndicator);
            tr_FamilyPlanning.Cells.Add(td_FamilyPlanning_FamilyPlanningStartUser);
            tr_FamilyPlanning.Cells.Add(td_FamilyPlanning_FamilyPlanningNew);
            tr_FamilyPlanning.Cells.Add(td_FamilyPlanning_FamilyPlanningOthers);
            tr_FamilyPlanning.Cells.Add(td_FamilyPlanning_FamilyPlanningDropOut);
            tr_FamilyPlanning.Cells.Add(td_FamilyPlanning_FamilyPlanningEndUser);

            // Add row to the table.
            tblFamilyPlanning.Rows.Add(tr_FamilyPlanning);
        }
        #endregion

        /*
         * END 1/12/2011
         */
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string noPerIndicator = "";
        //string indicatorData = "";
        //string pregnant = "";
        //string male = "";
        //string female = "";
        //string startUser = "";
        //string endUser = "";
        //string _new = "";
        //string others = "";
        //string dropOut = "";

        data = new DataAccess();
        mc = new MonthConverter();

        if (data.HasDataForTheYear(year,monthName, data.GetBarangayID(barangay)))
            Response.Write("<script type='text/javascript'>" + "alert(\"Month " + lbl_month.Text + " and Year " +
            year + " exists in the database. Please Try other Month and Year.\");</script>");
        else
        {
            string noPerIndicator = "";
            string indicatorData = "";
            string pregnant = "";
            string male = "";
            string female = "";
            string startUser = "";
            string endUser = "";
            string _new = "";
            string others = "";
            string dropOut = "";
        //Maternal Care ----------------------------------------------------------------------->
        for (int c = 0; c < data.CountIndicatorPerProgram("Maternal Care"); c++)
        {
            TextBox tempNo = tblMaternal.FindControl("txtMaternalNo_" + c.ToString()) as TextBox;
            noPerIndicator = tempNo.Text;
            Label tempIndicator = tblMaternal.FindControl("lblMaternalIndicator" + c.ToString()) as Label;
            indicatorData = tempIndicator.Text;

            data.InsertMaternalCareReport(indicatorData, Int32.Parse(noPerIndicator),
                data.GetBarangayID(lbl_Barangay.Text), month, year);
        }   
        
        ////Dental Care ------------------------------------------------------------------------->
        //for (int h = 0; h < data.CountIndicatorPerProgram("Dental Care"); h++)
        //{
        //    TextBox tempMale = tblDynamic.FindControl("txtDentalCareMale_" + h.ToString()) as TextBox;
        //    male = tempMale.Text;
        //    TextBox tempFemale = tblDynamic.FindControl("txtDentalCareFemale_" + h.ToString()) as TextBox;
        //    female = tempFemale.Text;
        //    Label tempIndicator = tblDynamic.FindControl("lblDentalCareIndicator" + h.ToString()) as Label;
        //    indicatorData = tempIndicator.Text;

        //    data.InsertDentalCareReport(indicatorData, Int32.Parse(male),Int32.Parse(female),
        //        data.GetBarangayID(lbl_Barangay.Text), month, year);
        //}

        ////Child Care ------------------------------------_------------------------------------->
        //for (int r = 0; r < data.CountIndicatorPerProgram("Dental Care"); r++)
        //{
        //    TextBox tempMale = tblDynamic.FindControl("txtChildCareMale_" + r.ToString()) as TextBox;
        //    male = tempMale.Text;
        //    TextBox tempFemale = tblDynamic.FindControl("txtChildCareFemale_" + r.ToString()) as TextBox;
        //    female = tempFemale.Text;
        //    Label tempIndicator = tblDynamic.FindControl("lblChildCareIndicator" + r.ToString()) as Label;
        //    indicatorData = tempIndicator.Text;

        //    data.InsertChildReport(indicatorData, Int32.Parse(male), Int32.Parse(female),
        //        data.GetBarangayID(lbl_Barangay.Text), month, year);
        //}

        ////Filariasis ------------------------------------_------------------------------------->
        //for (int i = 0; i < data.CountIndicatorPerProgram("Filariasis"); i++)
        //{
        //    TextBox tempMale = tblDynamic.FindControl("txtFilariasisMale_" + i.ToString()) as TextBox;
        //    male = tempMale.Text;
        //    TextBox tempFemale = tblDynamic.FindControl("txtFilariasisFemale_" + i.ToString()) as TextBox;
        //    female = tempFemale.Text;
        //    Label tempIndicator = tblDynamic.FindControl("lblFilariasisIndicator" + i.ToString()) as Label;
        //    indicatorData = tempIndicator.Text;

        //    data.InsertFilariasisReport(indicatorData, Int32.Parse(male), Int32.Parse(female),
        //        data.GetBarangayID(lbl_Barangay.Text), month, year);
        //}

        ////Leprosy ------------------------------------_----------------------------------------->
        //for (int z = 0; z < data.CountIndicatorPerProgram("Leprosy"); z++)
        //{
        //    TextBox tempMale = tblDynamic.FindControl("txtLeprosyMale_" + z.ToString()) as TextBox;
        //    male = tempMale.Text;
        //    TextBox tempFemale = tblDynamic.FindControl("txtLeprosyFemale_" + z.ToString()) as TextBox;
        //    female = tempFemale.Text;
        //    Label tempIndicator = tblDynamic.FindControl("lblLeprosyIndicator" + z.ToString()) as Label;
        //    indicatorData = tempIndicator.Text;

        //    data.InsertLeprosyReport(indicatorData, Int32.Parse(male), Int32.Parse(female),
        //        data.GetBarangayID(lbl_Barangay.Text), month, year);
        //}

        ////Malaria ------------------------------------_----------------------------------------->
        //for (int z = 0; z < data.CountIndicatorPerProgram("Malaria"); z++)
        //{
        //    TextBox tempPregnant = tblMalaria.FindControl("txtMalariaPregnant_" + z.ToString()) as TextBox;
        //    pregnant = tempPregnant.Text;
        //    TextBox tempMale = tblMalaria.FindControl("txtMalariaMale_" + z.ToString()) as TextBox;
        //    male = tempMale.Text;
        //    TextBox tempFemale = tblMalaria.FindControl("txtMalariaFemale_" + z.ToString()) as TextBox;
        //    female = tempFemale.Text;
        //    Label tempIndicator = tblMalaria.FindControl("lblMalariaIndicator" + z.ToString()) as Label;
        //    indicatorData = tempIndicator.Text;

        //    data.InsertMalariaReport(indicatorData,Int32.Parse(pregnant), Int32.Parse(male), Int32.Parse(female),
        //        data.GetBarangayID(lbl_Barangay.Text), month, year);
        //}

        ////Schisto ------------------------------------_----------------------------------------->
        //for (int i = 0; i < data.CountIndicatorPerProgram("Schistomiasis"); i++)
        //{
        //    TextBox tempMale = tblDynamic.FindControl("txtSchistomiasisMale_" + i.ToString()) as TextBox;
        //    male = tempMale.Text;
        //    TextBox tempFemale = tblDynamic.FindControl("txtSchistomiasisFemale_" + i.ToString()) as TextBox;
        //    female = tempFemale.Text;
        //    Label tempIndicator = tblDynamic.FindControl("lblSchistomiasisIndicator" + i.ToString()) as Label;
        //    indicatorData = tempIndicator.Text;

        //    data.InsertSchisReport(indicatorData, Int32.Parse(male), Int32.Parse(female),
        //        data.GetBarangayID(lbl_Barangay.Text), month, year);
        //}

        ////Tuberculosis ---------------------------------------------------------------------------->
        //for (int i = 0; i < data.CountIndicatorPerProgram("Tuberculosis"); i++)
        //{
        //    TextBox tempMale = tblDynamic.FindControl("txtTuberculosisMale_" + i.ToString()) as TextBox;
        //    male = tempMale.Text;
        //    TextBox tempFemale = tblDynamic.FindControl("txtTuberculosisFemale_" + i.ToString()) as TextBox;
        //    female = tempFemale.Text;
        //    Label tempIndicator = tblDynamic.FindControl("lblTuberculosisIndicator" + i.ToString()) as Label;
        //    indicatorData = tempIndicator.Text;

        //    data.InsertTbReport(indicatorData, Int32.Parse(male), Int32.Parse(female),
        //        data.GetBarangayID(lbl_Barangay.Text), month, year);
        //}

        ////Family Planning ---------------------------------------------------------------------------->
        //for (int i = 0; i < data.CountIndicatorPerProgram("Family Planning"); i++)
        //{
        //    TextBox temp1 = tblFamilyPlanning.FindControl("txtFamilyPlanningStartUser_" + i.ToString()) as TextBox;
        //    startUser  = temp1.Text;
        //    TextBox temp2 = tblFamilyPlanning.FindControl("txtFamilyPlanningNew_" + i.ToString()) as TextBox;
        //    _new = temp2.Text;
        //    TextBox temp3 = tblFamilyPlanning.FindControl("txtFamilyPlanningOthers_" + i.ToString()) as TextBox;
        //    others = temp3.Text;
        //    TextBox temp4 = tblFamilyPlanning.FindControl("txtFamilyPlanningDropOut_" + i.ToString()) as TextBox;
        //    dropOut = temp4.Text;
        //    TextBox temp5 = tblFamilyPlanning.FindControl("txtFamilyPlanningEndUser_" + i.ToString()) as TextBox;
        //    endUser = temp5.Text;
        //    Label tempIndicator = tblFamilyPlanning.FindControl("lblFamilyPlanningIndicator" + i.ToString()) as Label;
        //    indicatorData = tempIndicator.Text;

        //    data.InsertFPReport(indicatorData, Int32.Parse(startUser), Int32.Parse(_new), Int32.Parse(others),
        //        Int32.Parse(dropOut), Int32.Parse(endUser),data.GetBarangayID(lbl_Barangay.Text), month, year);
        //}   

        Response.Write("<script type='text/javascript'>" + "alert(\"Inserted Successfully\");</script>");
            
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Reports/Templates/xAllProgram.aspx?&month=" + Server.UrlEncode(monthName) +
                            "&year=" + Server.UrlEncode(year.ToString()) +
                            "&barangay=" + Server.UrlEncode(barangay) +
                            "&population=" + Server.UrlEncode(population.ToString()));
    }
}