using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;

/// <summary>
/// Summary description for Extender
/// </summary>
public static class Extender
{
    public static Control FindControlR(Control root, string id)
    {
        System.Web.UI.Control controlFound;
        if (root.ID == id) return root;
        
        controlFound = root.FindControl(id);
        
       
        foreach (Control child in root.Controls)
        {
            controlFound = FindControlR(child, id);
            if (controlFound != null)
            {
                return controlFound;
            }
        }
        return null; 
    }
}