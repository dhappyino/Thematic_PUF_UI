using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class getbyhashForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            StreamReader r = new StreamReader("C:\\Users\\乖乖\\Desktop\\WebApplication2\\WebApplication2\\getbyhash.json");
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
                    Label1.Text = responseStr.ToString();
                }

            }


            //輸出Server端回傳字串
        }
    }
}