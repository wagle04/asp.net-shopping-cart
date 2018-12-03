using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class user_delete_cart : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='G:\projects\asp.net shopping cart\shopping cart\shopping cart\App_Data\shopping.mdf';Integrated Security=True");
    string s, t, product_name, product_desc, product_price, product_qty, product_images;
    int id, count = 0;
    int product_id;
    int qty;
    string[] aa = new string[6];
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["id"].ToString());

        DataTable dt = new DataTable();
        dt.Rows.Clear();
        dt.Columns.AddRange(new DataColumn[7] { new DataColumn("product_name"), new DataColumn("product_desc"), new DataColumn("product_price"), new DataColumn("product_qty"), new DataColumn("product_images"), new DataColumn("id"), new DataColumn("product_id") });

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
                dt.Rows.Add(aa[0], aa[1], aa[2], aa[3], aa[4], i.ToString(),aa[5]);
            }
        }


        count = 0;
        foreach(DataRow dr in dt.Rows)
        {
            if (count == id)
            {
                product_id = Convert.ToInt32(dr["product_id"]);
                qty = Convert.ToInt32(dr["product_qty"]);

            }
            count = count + 1;
        }
        count = 0;
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update product set product_qty=product_qty+" + qty + "where id=" + product_id;
        cmd.ExecuteNonQuery();
        con.Close();


        dt.Rows.RemoveAt(id);

        Response.Cookies["a"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["a"].Values.Clear();

        foreach (DataRow dr in dt.Rows)
        {
            product_name = dr["product_name"].ToString();
            product_desc = dr["product_desc"].ToString();
            product_price = dr["product_price"].ToString();
            product_qty = dr["product_qty"].ToString();
            product_images = dr["product_images"].ToString();
            product_id = Convert.ToInt32(dr["product_id"]);
            count = count + 1;

            if (count==1)
            {
                Response.Cookies["a"].Value = product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_images.ToString()+ "," + product_id.ToString();
                Response.Cookies["a"].Expires = DateTime.Now.AddDays(1);
            }
            else
            {
                Response.Cookies["a"].Value = Request.Cookies["a"].Value + "|" + product_name.ToString() + "," + product_desc.ToString() + "," + product_price.ToString() + "," + product_qty.ToString() + "," + product_images.ToString() + "," + product_id.ToString();
                Response.Cookies["a"].Expires = DateTime.Now.AddDays(1);

            }
        }
        Response.Redirect("view_cart.aspx");
    }
}