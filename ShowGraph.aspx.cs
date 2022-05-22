using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowGraph : System.Web.UI.Page
{
    GeneralClass.Program Program = new GeneralClass.Program();
    protected void Page_Load(object sender, EventArgs e)
    {        
        int[] arrValues1 = { 16, 10, 12, 18, 23, 26, 27, 28, 30, 34, 37, 45, 55, 45, 55, 45, 55, 45, 55 };
        string[] arrLabels1 = { "11/7", "12/7", "13/7", "14/7", "15/7", "16/7", "17/7", "18/7", "19/7", "20/7", "21/7", "22/7", "23/7", "24/7", "26/7", "27/7", "28/7", "29/7", "30/7" };

        barGraph.BuildChartHTML(arrValues1, arrLabels1, arrValues1, arrValues1, arrValues1);
    }
}
