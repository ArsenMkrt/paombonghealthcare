
/* ACKNOWLEDGMENTS 2011
 * 
 * INSPIRED BY CHRIZZI.. - SuperDevLester
 * Gerald Magno inspired by his greatness
 *
 * TECHNICAL ADVISER
 * 1. Elcid Serrano
 * 
 * TEAM LEAD
 * 1. Gerald Aldana Magno
 * 
 * FRONT END DEVELOPER
 * 1. Gerald Aldana Magno
 * 
 * BACK END DEVELOPERS
 * 1. Gerald Aldana Magno
 * 2. Lakhi Lester T. Calantoc
 * 
 * BUSINESS ANALYST/SOFTWARE QUALITY ASSURANCE
 * 1. Kendrick Bacani
 * 2. Lakhi Lester T. Calantoc
 * 3. Gerald Aldana Magno
 * 
 */

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

/// <Paombong Healthcare Information System>
/// For Municipality of Paombong
/// Developers
///     ~Lakhi Lester Calantoc
///     ~Gerald Aldana Magno
/// Business Analyst
///     ~Kendrick Bacani
/// <This is an open source Healthcare Information System>
/// </Paombong Healthcare Information System>

public class DataAccess
{

    private SqlConnection connection = 
        new SqlConnection(ConfigurationManager.ConnectionStrings["CategoryConnectionString"].ConnectionString);

    public SqlConnection Connection
    {
        get { return connection; }
        set { connection = value; }
    }

    public DataAccess() {}

    public void ConnectToDatabase()
    {
        connection.Open();
    }
    public void CloseDatabase()
    {
        connection.Close();
    }
}
