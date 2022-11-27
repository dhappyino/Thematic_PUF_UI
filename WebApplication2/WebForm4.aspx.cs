using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Net;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Reflection.Emit;

namespace WebApplication2
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {

            string hemr = "";
            string id = "";
            string h1 = "";
            string h2 = "";
            string ph = "";
            string result = "";
            string temp = "";
            string Responsehash = "";
            string k = "";
            string sing = "";
            string resing = "";
            string url = "http://203.64.84.240:8545";

            try
            {
                if (FileUpload1.HasFile)
                {
                    String fileName = FileUpload1.FileName;  //-- User上傳的檔名（不包含 Client端的路徑！）


                    String savePath = @"C:\Users\乖乖\Desktop";

                    savePath += fileName;
                    //-- 重點！！必須包含 Server端的「目錄」與「檔名」，才能使用 .SaveAs()方法！
                    FileUpload1.SaveAs(savePath);
                    StreamReader r1 = new StreamReader(savePath);
                    string t = r1.ReadToEnd();
                    //Label1.Text = t;

                    string sSourceData;
                    byte[] tmpSource;
                    byte[] tmpHash;

                    sSourceData = t;
                    tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
                    tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                    //Label2.Text = tmpHash.ToString();
                    ByteArrayToString(tmpHash);
                    string ByteArrayToString(byte[] arrInput)
                    {
                        int i;
                        StringBuilder sOutput = new StringBuilder(arrInput.Length);
                        for (i = 0; i < arrInput.Length; i++)
                        {
                            sOutput.Append(arrInput[i].ToString("X2"));
                        }
                        //Label2.Text = sOutput.ToString();
                        hemr = sOutput.ToString();
                        return sOutput.ToString();
                    }

                    r1.Close();
                }
                else
                {
                    Label1.Text = "請先挑選檔案之後，再來上傳";
                }
            }
            catch (Exception ex)
            {
                Label3.Text = "File ERROR";
                Console.WriteLine(ex.Message);
            }


            id = TextBox1.Text;

            try
            {
                string sql12 = "SELECT * FROM dbo.Sing_Table WHERE UserID = @id AND EMR = @emr;"; //查詢是否註冊過
                using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Project2;Integrated Security=True"))
                {
                    SqlCommand cmd = new SqlCommand(sql12, conn);
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar);
                    cmd.Parameters["@id"].Value = id.ToString();
                    cmd.Parameters.Add("@emr", SqlDbType.NVarChar);
                    cmd.Parameters["@emr"].Value = hemr.ToString();

                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();

                    if (Reader.HasRows)
                    {
                        if (Reader.Read())
                        {
                            h1 = Reader["Block_Hex1"].ToString();
                            h2 = Convert.ToString(Reader["Block_Hex2"]);

                            HttpWebRequest rq0 = (HttpWebRequest)WebRequest.Create(url);
                            rq0.Method = "POST";
                            rq0.ContentType = "application/json";

                            StreamReader rr0 = new StreamReader("C:\\Users\\乖乖\\Desktop\\Thematic_PUF_UI.git\\WebApplication2\\JSON_Data\\getbyhash.json");
                            string js0 = rr0.ReadToEnd();
                            JObject j0 = JObject.Parse(js0);

                            j0["params"][0] = h1;
                            js0 = j0.ToString();
                            //var jsonObj = Json.Decode(r);
                            // string postBody = JsonConvert.SerializeObject(postData);//將匿名物件序列化為json字串
                            byte[] ba0 = Encoding.UTF8.GetBytes(js0);//要發送的字串轉為byte[]

                            using (Stream rs = rq0.GetRequestStream())
                            {
                                rs.Write(ba0, 0, ba0.Length);
                            }

                            //發出Request
                            string rps0 = "";
                            using (WebResponse response = rq0.GetResponse())
                            {

                                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                                {
                                    rps0 = reader.ReadToEnd();
                                    //Label3.Text = rps0.ToString();
                                    Responsehash = rps0.ToString();
                                }

                            }

                            JObject job0 = JObject.Parse(Responsehash);

                            result = job0["result"]["input"].ToString();
                            temp = result.Substring(2);
                            string strTemp = "";
                            byte[] b = new byte[temp.Length / 2];
                            for (int i = 0; i < temp.Length / 2; i++)
                            {
                                strTemp = temp.Substring(i * 2, 2);
                                b[i] = Convert.ToByte(strTemp, 16);
                            }
                            //按照指定編碼將字節數組變為字符串
                            temp = System.Text.Encoding.UTF8.GetString(b);

                            string[] sArray = temp.Split(new char[1] { '-' });//分別以!還有~y作為分隔符號
                            sing = sArray[2];
                            ph = sArray[1];


                            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(url);
                            rq.Method = "POST";
                            rq.ContentType = "application/json";

                            StreamReader rr = new StreamReader("C:\\Users\\乖乖\\Desktop\\Thematic_PUF_UI.git\\WebApplication2\\JSON_Data\\getbyhash.json");
                            string js = rr.ReadToEnd();
                            JObject j = JObject.Parse(js);

                            j["params"][0] = h2;
                            js = j.ToString();
                            //var jsonObj = Json.Decode(r);
                            // string postBody = JsonConvert.SerializeObject(postData);//將匿名物件序列化為json字串
                            byte[] ba = Encoding.UTF8.GetBytes(js);//要發送的字串轉為byte[]

                            using (Stream rs = rq.GetRequestStream())
                            {
                                rs.Write(ba, 0, ba.Length);
                            }

                            //發出Request
                            string rps = "";
                            using (WebResponse response = rq.GetResponse())
                            {

                                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                                {
                                    rps = reader.ReadToEnd();
                                    //Label3.Text = rps0.ToString();
                                    Responsehash = rps.ToString();
                                }

                            }

                            JObject job = JObject.Parse(Responsehash);

                            result = job["result"]["input"].ToString();
                            temp = result.Substring(2);
                            string strTemp1 = "";
                            byte[] b1 = new byte[temp.Length / 2];
                            for (int i = 0; i < temp.Length / 2; i++)
                            {
                                strTemp1 = temp.Substring(i * 2, 2);
                                b1[i] = Convert.ToByte(strTemp1, 16);
                            }
                            //按照指定編碼將字節數組變為字符串
                            temp = System.Text.Encoding.UTF8.GetString(b1);

                            string[] sArray1 = temp.Split(new char[1] { '-' });//分別以!還有~y作為分隔符號
                            k = sArray1[2];

                            byte[] ts;
                            byte[] th;
                            temp = hemr + id.ToString() + k + ph;
                            ts = ASCIIEncoding.ASCII.GetBytes(temp);
                            th = new MD5CryptoServiceProvider().ComputeHash(ts);
                            //Label2.Text = th.ToString();
                            bats(th);
                            string bats(byte[] arrInput)
                            {
                                int i;
                                StringBuilder sOutput = new StringBuilder(arrInput.Length);
                                for (i = 0; i < arrInput.Length; i++)
                                {
                                    sOutput.Append(arrInput[i].ToString("X2"));
                                }
                                //allhsah.Text = sOutput.ToString();
                                resing = sOutput.ToString();
                                return sOutput.ToString();
                            }

                            if (string.Equals(sing, resing))
                            {

                                Label3.Text = "成功";
                            }
                            else
                            {
                                Label3.Text = "失敗";
                            }
                        }
                        conn.Close();
                    }
                    else
                    {
                        Label3.Text = "尚未註冊之ID或是未簽章過的檔案!";
                    }
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                Label3.Text = "SQL ERROR";
                Console.WriteLine(ex.Message);
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("WebForm3.aspx", true);

        //}
    }
}