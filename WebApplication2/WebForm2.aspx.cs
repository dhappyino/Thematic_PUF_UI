using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                var useerid = Request.Cookies["UserInfo"].Values["id"];
                var PUFcode = Request.Cookies["UserInfo"].Values["PUFcode"];
                Label1.Text = useerid;
                Label2.Text = PUFcode;
            }




                //if (Session["TextBox1"] == null)
                //{
                //    Response.Write("<Script language='JavaScript'>alert('登入時間過期');</Script>");
                //    Server.Transfer("WebForm1.aspx", true);

                //}
                //else
                //{
                //    string id;
                //    byte[] tmpSource;
                //    byte[] tmpHash;
                //    Label1.Text = Session["TextBox1"].ToString();
                //    id = Label1.Text;
                //    Response.Write("<Script language='JavaScript'>alert('" + id + "');</Script>");
                //    tmpHash = new SHA256CryptoServiceProvider().ComputeHash(id);
                //    Response.Write("<Script language='JavaScript'>alert('" + tmpHash + "');</Script>");
                //}
                if (!Page.IsPostBack)
            {
                //if (Session["TextBox1"] != null)
                //{
                //    //Response.Write("test1 =" + Session["TextBox1"]);
                //}
                //else
                //{
                //    //警告視窗
                //    Response.Write("error ");
                //}

                //a = (String)Session["TextBox1"];
                //if (Request.Cookies[a]["username"] != null)
                //{
                //    TextBox1.Text = Server.UrlDecode(Request.Cookies[a]["username"]);
                //    TextBox2.Text = Server.UrlDecode(Request.Cookies[a]["phone"]);
                //}
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Server.Transfer("WebForm1.aspx", true);
        }
    }
}