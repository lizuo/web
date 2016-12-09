using System;
using BLL;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 航班延误预测系统
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnYuce_Click(object sender, EventArgs e)
        {
            ResultBLL bll = new ResultBLL();
            long start = Environment.TickCount;
            DataSet ds = bll.GetResult1(DateTime.Parse(txtDate.Text),
                txtFlightno.Text, txtDepAir.Text, txtArrAir.Text);
            long end = Environment.TickCount;
            string result = "|";
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                result += " " + ds.Tables[0].Rows[0][i].ToString() + " |";
            }
            Page.ClientScript.RegisterStartupScript(GetType(), "", 
                "alert('"+result+"\\n共花费了"+(end - start)+"毫秒')", true);
        }
    }
}