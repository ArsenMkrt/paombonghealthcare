using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]

public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

       
    }

    private DataAccess data;

    [WebMethod]
    public string[] GetLastNames(string prefixText)
    {
        int count = 0;
        string[] items = null;
        DataTable dt = null;
        try
        {
          string sql = "SELECT DISTINCT PtLname FROM Patients WHERE PtLname LIKE @prefixText";
         // string sql = "SELECT Distinct PtLname + ',' + PtFname + ' ' + PtMname AS PtFullName FROM Patients WHERE PtLname LIKE @prefixText";


            data = new DataAccess();
            data.ConnectToDatabase();

            SqlDataAdapter da = new SqlDataAdapter(sql, data.Connection);
            da.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = "%" + prefixText + "%";
            dt = new DataTable();
            da.Fill(dt);
            count = (dt.Rows.Count == 0 ? 1 : dt.Rows.Count);
            items = new string[count];
            if (dt.Rows.Count == 0)
            {
                string v = "No match Found";
                items.SetValue(v, 0);
            }
            else
            {
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    items.SetValue(dr["PtFullName"].ToString(), i);
                    i++;
                }
            }
        }
        catch (Exception ex)
        {

        }
        //finally
        //{
        //    data.CloseDatabase();
        //}
        return items;
    }

}





