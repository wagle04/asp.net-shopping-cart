using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_view_cart : System.Web.UI.Page
{
    string s;
     string t;
    string[] aa = new string[5];

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[5] { new DataColumn("product_name"), new DataColumn("product_desc"), new DataColumn("product_price"), new DataColumn("product_qty"), new DataColumn("product_images") });

        if (Request.Cookies["a"] != null)
        {
            s = Convert.ToString(Request.Cookies["a"].Value);

            string[] strArr = s.Split('|');

            for (int i = 0; i < strArr.Length; i++)
            {
                t = Convert.ToString(strArr[i].ToString());
                string[] strArr1 = t.Split(',');

                for (int j = 0; j < strArr1.Length; j++)
                {
                    aa[j] = strArr1[j].ToString();

                }
                dt.Rows.Add(aa[0], aa[1], aa[2], aa[3], aa[4]);
            }
        }
        d1.DataSource = dt;
        d1.DataBind();
    }

}