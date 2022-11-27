using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                var useerid = Request.Cookies["UserInfo"].Values["id"];
                var PUFcode = Request.Cookies["UserInfo"].Values["PUFcode"];
                //Label1.Text = useerid;
                //Label2.Text = PUFcode;
            }
            string sql = "SELECT uid FROM dbo.gg WHERE uid = @Name;"; //查詢是否註冊過
            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=singdb;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                //cmd.Parameters["@Name"].Value = useerid;
                try
                {
                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {


                        //Label1.Text = "已註冊過資料!,請等候3秒鐘喲~~~~~~~~~";//已註冊過

                    }
                    else
                    {
                        conn.Close();
                        SqlCommand cmd1 = new SqlCommand(sql, conn);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        //sql = "INSERT INTO dbo.gg (uid,h1) VALUES ('" + k + "', '0x4002f065a9d36dde4ef064018d42d08d26e871a2');";

                        try
                        {
                            conn.Open();
                            cmd1 = new SqlCommand(sql, conn);
                            adapter.InsertCommand = new SqlCommand(sql, conn);
                            adapter.InsertCommand.ExecuteNonQuery();
                            cmd1.Dispose();
                            conn.Close();

                            //sql = "INSERT INTO dbo.gg (uid, k , h1,) VALUES ('" + useerid + "', '" + k + "','" + h + "');";
                            conn.Open();
                            cmd1 = new SqlCommand(sql, conn);
                            adapter.InsertCommand = new SqlCommand(sql, conn);
                            adapter.InsertCommand.ExecuteNonQuery();
                            cmd1.Dispose();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            object newProdID = null;
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
        protected void Panel(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload1.HasFile)
        //    {
        //        String fileName = FileUpload1.FileName;  //-- User上傳的檔名（不包含 Client端的路徑！）


        //        String savePath = @"C:\Users\USER\OneDrive\桌面";

        //        savePath += fileName;
        //        //-- 重點！！必須包含 Server端的「目錄」與「檔名」，才能使用 .SaveAs()方法！
        //        FileUpload1.SaveAs(savePath);
        //        StreamReader r1 = new StreamReader(savePath);
        //        string t = r1.ReadToEnd();
        //        FileUploadStatus.Text = t;

        //        string sSourceData;
        //        byte[] tmpSource;
        //        byte[] tmpHash;

        //        sSourceData = t;
        //        tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
        //        tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        //        Label2.Text = tmpHash.ToString();
        //        ByteArrayToString(tmpHash);
        //        string ByteArrayToString(byte[] arrInput)
        //        {
        //            int i;
        //            StringBuilder sOutput = new StringBuilder(arrInput.Length);
        //            for (i = 0; i < arrInput.Length; i++)
        //            {
        //                sOutput.Append(arrInput[i].ToString("X2"));
        //            }
        //            hashData.Text = sOutput.ToString();
        //            hsmr = sOutput.ToString();
        //            return sOutput.ToString();
        //        }

        //    }
        //    else
        //    {
        //        Label1.Text = "請先挑選檔案之後，再來上傳";
        //    }

        //    string sd;
        //    byte[] ts;
        //    byte[] th;

        //    sd = hsmr + id.ToString() + k + h;
        //    ts = ASCIIEncoding.ASCII.GetBytes(sd);
        //    th = new MD5CryptoServiceProvider().ComputeHash(ts);
        //    Label2.Text = th.ToString();
        //    bats(th);
        //    string bats(byte[] arrInput)
        //    {
        //        int i;
        //        StringBuilder sOutput = new StringBuilder(arrInput.Length);
        //        for (i = 0; i < arrInput.Length; i++)
        //        {
        //            sOutput.Append(arrInput[i].ToString("X2"));
        //        }
        //        allhsah.Text = sOutput.ToString();

        //        return sOutput.ToString();
        //    }

        //    string url = "http://203.64.84.240:8545";

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Method = "POST";
        //    request.ContentType = "application/json";
        //    //var postData =
        //    //    new //要傳遞的參數Sample
        //    //    {
        //    //        jsonrpc = "2.0",
        //    //        mathood = "personal_listAccounts",
        //    //        params = "",
        //    //        id=1

        //    //    };
        //    StreamReader r = new StreamReader("C:\\Users\\USER\\OneDrive\\桌面\\學校\\專題\\Test1\\Test1\\unluck.json");
        //    string json = r.ReadToEnd();
        //    //var jsonObj = Json.Decode(r);
        //    // string postBody = JsonConvert.SerializeObject(postData);//將匿名物件序列化為json字串
        //    byte[] byteArray = Encoding.UTF8.GetBytes(json);//要發送的字串轉為byte[]

        //    using (Stream reqStream = request.GetRequestStream())
        //    {
        //        reqStream.Write(byteArray, 0, byteArray.Length);
        //    }



        //    //發出Request
        //    string responseStr = "";
        //    using (WebResponse response = request.GetResponse())
        //    {

        //        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
        //        {
        //            responseStr = reader.ReadToEnd();
        //            Label2.Text = responseStr.ToString();
        //        }

        //    }

        //    HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(url);
        //    rq.Method = "POST";
        //    rq.ContentType = "application/json";
        //    //var postData =
        //    //    new //要傳遞的參數Sample
        //    //    {
        //    //        jsonrpc = "2.0",
        //    //        mathood = "personal_listAccounts",
        //    //        params = "",
        //    //        id=1

        //    //    };
        //    StreamReader rr = new StreamReader("C:\\Users\\USER\\OneDrive\\桌面\\學校\\專題\\Test1\\Test1\\tr.json");
        //    string js = rr.ReadToEnd();
        //    //var jsonObj = Json.Decode(r);
        //    // string postBody = JsonConvert.SerializeObject(postData);//將匿名物件序列化為json字串
        //    byte[] ba = Encoding.UTF8.GetBytes(js);//要發送的字串轉為byte[]

        //    using (Stream rs = rq.GetRequestStream())
        //    {
        //        rs.Write(ba, 0, ba.Length);
        //    }



        //    //發出Request
        //    string rps = "";
        //    using (WebResponse response = rq.GetResponse())
        //    {

        //        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
        //        {
        //            rps = reader.ReadToEnd();
        //            Label3.Text = rps.ToString();
        //        }

        //    }





        //}
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
    //    if (!Page.IsPostBack)
    //{
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


