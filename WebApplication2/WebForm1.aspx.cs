using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie hc = new HttpCookie("1");
            HttpCookie hc1 = new HttpCookie("2");
            HttpCookie hc2 = new HttpCookie("3");
            HttpCookie hc3 = new HttpCookie("4");
            HttpCookie hc4 = new HttpCookie("5");
            //hc.Expires = System.DateTime.Now.AddDays(7);//設定在瀏覽器的有效期限
            hc["username"] = Server.UrlEncode("王曉明");
            hc1["username"] = Server.UrlEncode("陳曉明");
            hc2["username"] = Server.UrlEncode("黃曉明");
            hc3["username"] = Server.UrlEncode("江先生");
            hc4["username"] = Server.UrlEncode("馬小姐");
            hc["phone"] = "0123";
            hc1["phone"] = "01234";
            hc2["phone"] = "01235";
            hc3["phone"] = "01236";
            hc4["phone"] = "01237";
            Response.Cookies.Add(hc);
            Response.Cookies.Add(hc1);
            Response.Cookies.Add(hc2);
            Response.Cookies.Add(hc3);
            Response.Cookies.Add(hc4);
            //string[] stringArray = new string[5] { "123", "456", "789", "000", "012" };
            //string[] stringArray1 = new string[5] { "111","222","333","444","555"};
            //if (Session["TextBox1"] != null)
            //{
            //    Response.Write("test1 ="+Session["test1"]);
            //}
            //if (TextBox1.Text==Session["TextBox1"] && TextBox2.Text == Session["test6"])
            //{
            //    Label1.Text="pppp帳號密碼錯誤!!";
            //}
            //else
            //{
            //    Label1.Text="帳號密碼錯誤!!";
            //}

            //Response.Write("<br> SessionID = " + Session.SessionID);
            //Response.Write("<br> Session有幾個物件？  " + Session.Count.ToString());
            //Response.Write("<br> Session的模式（Mode）？  " + Session.Mode.ToString());
            //Response.Write("<br> 採用無Cookie狀態嗎？  " + Session.IsCookieless.ToString());
            //Response.Write("<br> 是否為新建立的 Session？  " + Session.IsNewSession.ToString());
            //Response.Write("<br> 是否「唯讀」？  " + Session.IsReadOnly.ToString());
            Response.Write("<br> Session的生命週期（分鐘） = " + Session.Timeout.ToString());
            //Response.Write("<br> Session有幾個索引鍵 = " + Session.Keys.Count.ToString());
            // regenerateExpiredSessionID
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] user = new string[5] { "1", "2", "3", "4", "5" };
            string[] password = new string[5] { "111", "222", "333", "444", "555" };
            for (int i = 0; i < 5; i++)
            {
                if (TextBox1.Text == user[i] && TextBox2.Text == password[i])
                {
                    //Label1.Text = "帳號密碼!!!!!!";
                    Session["TextBox1"] = TextBox1.Text;
                    Session["TextBox2"] = TextBox2.Text;
                    Session["TextBox3"] = DateTime.Now;
                    //Server.Transfer("WebForm2.aspx", true);
                    break;
                }
                else
                {
                    Label1.Text = "帳號密碼錯誤!!";
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string url = "http://203.64.84.240:8545";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            //var postData =
            //    new //要傳遞的參數Sample
            //    {
            //        jsonrpc = "2.0",
            //        mathood = "personal_listAccounts",
            //        params = "",
            //        id=1

            //    };
            StreamReader r = new StreamReader("C:\\Users\\乖乖\\Desktop\\Thematic_PUF_UI.git\\WebApplication2\\JSON_Data\\unlock.json");
            string json = r.ReadToEnd();
            //var jsonObj = Json.Decode(r);
            // string postBody = JsonConvert.SerializeObject(postData);//將匿名物件序列化為json字串
            byte[] byteArray = Encoding.UTF8.GetBytes(json);//要發送的字串轉為byte[]

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(byteArray, 0, byteArray.Length);
            }



            //發出Request
            string responseStr = "";
            using (WebResponse response = request.GetResponse())
            {

                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = reader.ReadToEnd();
                    Label1.Text=responseStr.ToString();
                }

            }


            //輸出Server端回傳字串
            
        }
    }

}