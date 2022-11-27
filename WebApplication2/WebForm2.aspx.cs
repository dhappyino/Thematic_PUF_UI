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
using System.Drawing.Drawing2D;
using System.Reflection.Emit;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        public string c0 = "";
        public string result = "";
        public string temp = "";
        public string Responsehash = "";
        public string hsmr = "";
        public string sing = "";
        public string id = "";
        public string k = "QQ";
        public string k1 = " ";
        public string kn = "";
        public string h = "RR";
        public string h1 = "RR";
        public string h2 = "RR";
        public string rph = "RR";
        public string ph1 = "RR";
        public string ph2 = "RR";
        public int g = 0;
        public string url = "http://203.64.84.240:8545";
        
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Page.IsPostBack)
            //{
            if (Session["id"] != null && g == 0)
            {
                //id = Server.UrlDecode(HttpContext.Current.Request.Cookies["cookieName"].Value);
                id = Session["id"].ToString();
                Label1.Text = id.ToString();
                //HttpCookie cookie1 = new HttpCookie("cookieName", "");
                //cookie1.Expires = DateTime.Now;
                //cookie1.Value = Server.UrlEncode(id);
                //Response.Cookies.Add(cookie1);
                g++;
            }
            else
            {
                Label1.Text = "error";
            }

            string sql = "SELECT SingID FROM Sing_Table WHERE UserID = @Name;"; //查詢是否註冊過
            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Project2;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters["@Name"].Value = id.ToString();

                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    Button1.Visible = false;
                    Button2.Visible = true;
                    //Label1.Text = "已簽章過!,請等候3秒鐘喲~~~~~~~~~";//已簽章過

                }
                else
                {
                    Button1.Visible = true;
                    Button2.Visible = false;
                    //Label1.Text = "尚未簽章過!---------------";//尚未簽章過
                }
                conn.Close();
            }
            //}



        }



        public void Button1_Click1(object sender, EventArgs e)
        {
            string sql12 = "SELECT * FROM dbo.Rc_Table WHERE UserID = @Name;"; //查詢是否註冊過
            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Project2;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(sql12, conn);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters["@Name"].Value = id.ToString();

                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    if (Reader.Read())
                    {
                        c0 = Reader["C0"].ToString();
                        rph = Convert.ToString(Reader["BlockChain_Hex"]);
                    }
                   
                    conn.Close();

                }
                conn.Close();

            }


            string key = Sha256(c0.ToString());
            byte[] f = ConvertHexStringToByteArray(key);
            //string c=Convert.ToString(Convert.ToInt32(key.ToString(), 16), 2);
            StringBuilder Sb = new StringBuilder();
            foreach (byte b12 in f)
            {
                string decimalString = Convert.ToString(b12);
                int decimalValue = Int32.Parse(decimalString);
                int bitcount = 0;
                while (decimalValue != 0)
                {
                    bitcount++;
                    Sb.Append((decimalValue % 2).ToString());
                    decimalValue = decimalValue / 2;
                }
                if (bitcount != 8)
                {
                    for (int i = 0; i < 8 - bitcount; i++)
                    {
                        Sb.Append('0');
                    }
                }
                //List<string> t = new List<string>();
                //t.Add(Convert.ToString(b));
                //Sb.Append(t[0]);
            }
            string hex = Sb.ToString();
            int stringLength = hex.Length - 1;
            StringBuilder Sc = new StringBuilder();
            for (int i = stringLength; i > -1; i--)
            {
                Sc.Append(hex[i]);
            }
            string hexfall = Sc.ToString();
            //Label1.Text = stringLength.ToString();
            //Label1.Text = hex;

            int[] array = new int[1024];
            int[] array1 = new int[256];
            int[] array2 = new int[256];
            int[] array3 = new int[256];
            int[] array4 = new int[256];
            Random myObject = new Random();
            for (int i = 0; i < 1024; i++)
            {
                array[i] = myObject.Next(10, 99);
            }

            for (int i = 0; i < 256; i++)
            {
                array1[i] = array[i];
                array2[i] = array[i + 256];
                array3[i] = array[i + 512];
                array4[i] = array[i + 768];
            }
            int[] mux1 = new int[256];
            int[] mux2 = new int[256];

            for (int i = 0; i < 256; i++)
            {
                if (hexfall[i] == 1)                //比大
                {
                    if (array1[i] >= array2[i])
                        mux1[i] = array1[i];
                    else
                        mux1[i] = array2[i];
                    if (array3[i] >= array4[i])
                        mux2[i] = array3[i];
                    else
                        mux2[i] = array4[i];
                }
                else                            //比小
                {
                    if (array1[i] <= array2[i])
                        mux1[i] = array1[i];
                    else
                        mux1[i] = array2[i];
                    if (array3[i] <= array4[i])
                        mux2[i] = array3[i];
                    else
                        mux2[i] = array4[i];
                }
            }


            StringBuilder alllastSb = new StringBuilder();
            for (int i = 0; i < 256; i++)
            {
                if (mux1[i] > mux2[i])
                    alllastSb.Append('1');
                else
                    alllastSb.Append('0');
            }
            string alllast = alllastSb.ToString();


            string transtring = alllast.Substring(0, 8);
            int exchange_displacement = Convert.ToInt32(transtring, 2);

            StringBuilder ropufSb2 = new StringBuilder();
            StringBuilder ropufSb1 = new StringBuilder();
            int n = 0;
            for (int i = 0; i < 256; i++)
            {
                if (i + exchange_displacement < 256)
                {
                    ropufSb2.Append(alllast[i]);
                }
                else
                {
                    ropufSb1.Append(alllast[i]);
                }
            }
            string k0 = ropufSb1.ToString() + ropufSb2.ToString();
            //Label1.Text = k0.Length.ToString();
            k1 = k0;






            if (FileUpload1.HasFile)
            {
                String fileName = FileUpload1.FileName;  //-- User上傳的檔名（不包含 Client端的路徑！）


                String savePath = @"C:\Users\乖乖\Desktop";

                savePath += fileName;
                //-- 重點！！必須包含 Server端的「目錄」與「檔名」，才能使用 .SaveAs()方法！
                FileUpload1.SaveAs(savePath);
                StreamReader r1 = new StreamReader(savePath);
                string t = r1.ReadToEnd();
                //FileUploadStatus.Text = t;

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
                    //hashData.Text = sOutput.ToString();
                    hsmr = sOutput.ToString();
                    return sOutput.ToString();
                }

            }
            else
            {
                Label1.Text = "請先挑選檔案之後，再來上傳";
            }

            string sd;
            byte[] ts;
            byte[] th;

            sd = hsmr + id.ToString() + k1 + rph;
            ts = ASCIIEncoding.ASCII.GetBytes(sd);
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
                sing = sOutput.ToString();
                LSing.Text = "簽章:"+sing;
                return sOutput.ToString();
            }



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
                    //Label2.Text = responseStr.ToString();
                }

            }

            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(url);
            rq.Method = "POST";
            rq.ContentType = "application/json";

            StreamReader rr = new StreamReader("C:\\Users\\乖乖\\Desktop\\Thematic_PUF_UI.git\\WebApplication2\\JSON_Data\\sentTransaction.json");
            string js = rr.ReadToEnd();
            JObject j = JObject.Parse(js);
            temp = id.ToString() + "-" + rph + "-" + sing;
            byte[] b = System.Text.Encoding.UTF8.GetBytes(temp);//按照指定編碼將string編程字節數組
            string six = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字節變為16進制字符
            {
                six += Convert.ToString(b[i], 16);
            }
            
            j["params"][0]["data"] = "0x"+six;
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
                    //Label3.Text = rps.ToString();
                    h = rps.ToString();
                }

            }

            JObject job1 = JObject.Parse(h);
            h1 = job1["result"].ToString();
            hash1.Text = "第一個hashcode:" + h1;

            HttpWebRequest rq2 = (HttpWebRequest)WebRequest.Create(url);
            rq2.Method = "POST";
            rq2.ContentType = "application/json";

            StreamReader rr2 = new StreamReader("C:\\Users\\乖乖\\Desktop\\Thematic_PUF_UI.git\\WebApplication2\\JSON_Data\\sentTransaction.json");
            string js2 = rr2.ReadToEnd();
            JObject j2 = JObject.Parse(js2);
            temp = id.ToString() + "-" + h1 + "-" + k1;
            byte[] b2 = System.Text.Encoding.UTF8.GetBytes(temp);//按照指定編碼將string編程字節數組
            string six2 = string.Empty;
            for (int i = 0; i < b2.Length; i++)//逐字節變為16進制字符
            {
                six2 += Convert.ToString(b2[i], 16);
            }
            j2["id"] = id;
            j2["params"][0]["data"] = "0x"+six2;
            js2 = j2.ToString();

            byte[] ba2 = Encoding.UTF8.GetBytes(js2);//要發送的字串轉為byte[]

            using (Stream rs2 = rq2.GetRequestStream())
            {
                rs2.Write(ba2, 0, ba2.Length);
            }



            //發出Request
            string rps2 = " ";
            using (WebResponse response = rq2.GetResponse())
            {

                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    rps2 = reader.ReadToEnd();
                    //Label3.Text = rps2.ToString();
                    h = rps2.ToString();
                }

            }



            JObject job = JObject.Parse(h);
            h2 = job["result"].ToString();
            hash2.Text = "第二個hashcode:" + h2;
            //js = job.ToString();

            string sql = "INSERT INTO dbo.Sing_Table (UserID,Block_Hex1,Block_Hex2,EMR,c,Hex_R) VALUES ('" + id.ToString() + "', '" + h1 + "','" + h2 + "','" + hsmr + "','" + c0 + "','" + Sha256(k1) + "');";//查詢是否註冊過
            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Project2;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                //cmd.Parameters["@Name"].Value = id;

                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                //if (Reader.HasRows) {
                //    Label1.Text = "已註冊過資料!,請等候3秒鐘喲~~~~~~~~~";//已註冊過
                //}

                conn.Close();

            }
            GridView1.DataBind();

        }

        public void Button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM (SELECT *,ROW_NUMBER() OVER(ORDER BY Timestamp DESC) SN FROM Sing_Table WHERE UserID = @Name) R WHERE R.sn = 1"; //註冊過
            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Project2;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters["@Name"].Value = id;

                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        ph2 = Convert.ToString(Reader["Block_Hex2"]);

                        HttpWebRequest rq0 = (HttpWebRequest)WebRequest.Create(url);
                        rq0.Method = "POST";
                        rq0.ContentType = "application/json";

                        StreamReader rr0 = new StreamReader("C:\\Users\\乖乖\\Desktop\\Thematic_PUF_UI.git\\WebApplication2\\JSON_Data\\getbyhash.json");
                        string js0 = rr0.ReadToEnd();
                        JObject j0 = JObject.Parse(js0);

                        j0["params"][0] = ph2;
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
                        temp=System.Text.Encoding.UTF8.GetString(b);

                        string[] sArray = temp.Split(new char[1] {'-'});//分別以!還有~y作為分隔符號
                        k = sArray[2];
                        

                        string key = Sha256(k.ToString());
                        byte[] f = ConvertHexStringToByteArray(key);
                        //string c=Convert.ToString(Convert.ToInt32(key.ToString(), 16), 2);
                        StringBuilder Sb = new StringBuilder();
                        foreach (byte b0 in f)
                        {
                            string decimalString = Convert.ToString(b0);
                            int decimalValue = Int32.Parse(decimalString);
                            int bitcount = 0;
                            while (decimalValue != 0)
                            {
                                bitcount++;
                                Sb.Append((decimalValue % 2).ToString());
                                decimalValue = decimalValue / 2;
                            }
                            if (bitcount != 8)
                            {
                                for (int i = 0; i < 8 - bitcount; i++)
                                {
                                    Sb.Append('0');
                                }
                            }
                            //List<string> t = new List<string>();
                            //t.Add(Convert.ToString(b));
                            //Sb.Append(t[0]);
                        }
                        string hex = Sb.ToString();
                        int stringLength = hex.Length - 1;
                        StringBuilder Sc = new StringBuilder();
                        for (int i = stringLength; i > -1; i--)
                        {
                            Sc.Append(hex[i]);
                        }
                        string hexfall = Sc.ToString();
                        //Label1.Text = stringLength.ToString();
                        //Label1.Text = hex;

                        int[] array = new int[1024];
                        int[] array1 = new int[256];
                        int[] array2 = new int[256];
                        int[] array3 = new int[256];
                        int[] array4 = new int[256];
                        Random myObject = new Random();
                        for (int i = 0; i < 1024; i++)
                        {
                            array[i] = myObject.Next(10, 99);
                        }

                        for (int i = 0; i < 256; i++)
                        {
                            array1[i] = array[i];
                            array2[i] = array[i + 256];
                            array3[i] = array[i + 512];
                            array4[i] = array[i + 768];
                        }
                        int[] mux1 = new int[256];
                        int[] mux2 = new int[256];

                        for (int i = 0; i < 256; i++)
                        {
                            if (hexfall[i] == 1)                //比大
                            {
                                if (array1[i] >= array2[i])
                                    mux1[i] = array1[i];
                                else
                                    mux1[i] = array2[i];
                                if (array3[i] >= array4[i])
                                    mux2[i] = array3[i];
                                else
                                    mux2[i] = array4[i];
                            }
                            else                            //比小
                            {
                                if (array1[i] <= array2[i])
                                    mux1[i] = array1[i];
                                else
                                    mux1[i] = array2[i];
                                if (array3[i] <= array4[i])
                                    mux2[i] = array3[i];
                                else
                                    mux2[i] = array4[i];
                            }
                        }


                        StringBuilder alllastSb = new StringBuilder();
                        for (int i = 0; i < 256; i++)
                        {
                            if (mux1[i] > mux2[i])
                                alllastSb.Append('1');
                            else
                                alllastSb.Append('0');
                        }
                        string alllast = alllastSb.ToString();


                        string transtring = alllast.Substring(0, 8);
                        int exchange_displacement = Convert.ToInt32(transtring, 2);

                        StringBuilder ropufSb2 = new StringBuilder();
                        StringBuilder ropufSb1 = new StringBuilder();
                        int n = 0;
                        for (int i = 0; i < 256; i++)
                        {
                            if (i + exchange_displacement < 256)
                            {
                                ropufSb2.Append(alllast[i]);
                            }
                            else
                            {
                                ropufSb1.Append(alllast[i]);
                            }
                        }
                        string k0 = ropufSb1.ToString() + ropufSb2.ToString();
                        //Label1.Text = k0.Length.ToString();
                        k1 = k0;
                    }
                }
                conn.Close();


            }
            if (FileUpload1.HasFile)
            {
                String fileName = FileUpload1.FileName;  //-- User上傳的檔名（不包含 Client端的路徑！）


                String savePath = @"C:\Users\乖乖\Desktop";

                savePath += fileName;
                //-- 重點！！必須包含 Server端的「目錄」與「檔名」，才能使用 .SaveAs()方法！
                FileUpload1.SaveAs(savePath);
                StreamReader r1 = new StreamReader(savePath);
                string t = r1.ReadToEnd();
                //FileUploadStatus.Text = t;

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
                    //hashData.Text = sOutput.ToString();
                    hsmr = sOutput.ToString();
                    return sOutput.ToString();
                }

            }
            else
            {
                Label1.Text = "請先挑選檔案之後，再來上傳";
            }

            string sd;
            byte[] ts;
            byte[] th;

            sd = hsmr + id.ToString() + k1 + ph2;
            ts = ASCIIEncoding.ASCII.GetBytes(sd);
            th = new MD5CryptoServiceProvider().ComputeHash(ts);
            //Label2.Text ="sing:"+ th.ToString();
            bats(th);
            string bats(byte[] arrInput)
            {
                int i;
                StringBuilder sOutput = new StringBuilder(arrInput.Length);
                for (i = 0; i < arrInput.Length; i++)
                {
                    sOutput.Append(arrInput[i].ToString("X2"));
                }
                
                sing = sOutput.ToString();
                LSing.Text = "簽章:"+sing;
                return sOutput.ToString();
            }



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
                    //Label2.Text = responseStr.ToString();
                }

            }

            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(url);
            rq.Method = "POST";
            rq.ContentType = "application/json";
            //var postData =
            //    new //要傳遞的參數Sample
            //    {
            //        jsonrpc = "2.0",
            //        mathood = "personal_listAccounts",
            //        params = "",
            //        id=1

            //    };
            StreamReader rr = new StreamReader("C:\\Users\\乖乖\\Desktop\\Thematic_PUF_UI.git\\WebApplication2\\JSON_Data\\sentTransaction.json");
            string js = rr.ReadToEnd();
            JObject j = JObject.Parse(js);

            temp = id.ToString() + "-" + ph2 + "-" + sing;
            byte[] b1 = System.Text.Encoding.UTF8.GetBytes(temp);//按照指定編碼將string編程字節數組
            string six = string.Empty;
            for (int i = 0; i < b1.Length; i++)//逐字節變為16進制字符
            {
                six += Convert.ToString(b1[i], 16);
            }

            j["params"][0]["data"] = "0x" + six;
            js = j.ToString();

            //j["id"] = id;
            //j["params"][0]["data"] = "0x" + sing;
            //js = j.ToString();

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
                    //Label3.Text = rps.ToString();
                    Responsehash = rps.ToString();
                }

            }

            JObject job = JObject.Parse(Responsehash);
            h1 = job["result"].ToString();
            //js = job.ToString();
            hash1.Text = "第一個hashcode:" + h1;


            HttpWebRequest rq2 = (HttpWebRequest)WebRequest.Create(url);
            rq2.Method = "POST";
            rq2.ContentType = "application/json";

            StreamReader rr2 = new StreamReader("C:\\Users\\乖乖\\Desktop\\Thematic_PUF_UI.git\\WebApplication2\\JSON_Data\\sentTransaction.json");
            string js2 = rr2.ReadToEnd();
            JObject j2 = JObject.Parse(js2);
            temp = id.ToString() + "-" + h1 + "-" + k1;
            byte[] b2 = System.Text.Encoding.UTF8.GetBytes(temp);//按照指定編碼將string編程字節數組
            string six2 = string.Empty;
            for (int i = 0; i < b2.Length; i++)//逐字節變為16進制字符
            {
                six2 += Convert.ToString(b2[i], 16);
            }
            j2["id"] = id;
            j2["params"][0]["data"] = "0x" + six2;
            js2 = j2.ToString();

            byte[] ba2 = Encoding.UTF8.GetBytes(js2);//要發送的字串轉為byte[]

            using (Stream rs2 = rq2.GetRequestStream())
            {
                rs2.Write(ba2, 0, ba2.Length);
            }



            //發出Request
            string rps2 = " ";
            using (WebResponse response = rq2.GetResponse())
            {

                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    rps2 = reader.ReadToEnd();
                    //Label3.Text = rps2.ToString();
                    h = rps2.ToString();
                }

            }



            JObject job3 = JObject.Parse(h);
            h2 = job3["result"].ToString();
            hash2.Text = "第二個hashcode:" + h2;

            string sql2 = "INSERT INTO dbo.Sing_Table (UserID,Block_Hex1,Block_Hex2,EMR,c,Hex_R) VALUES ('" + id.ToString() + "', '" + h1 + "','" + h2 + "','" + hsmr + "','" + k + "','" + Sha256(k1) + "');";//查詢是否註冊過
            using (SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Project2;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(sql2, conn);
                //cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                //cmd.Parameters["@Name"].Value = id;

                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                //if (Reader.HasRows) {
                //    Label1.Text = "已註冊過資料!,請等候3秒鐘喲~~~~~~~~~";//已註冊過
                //}
                conn.Close();
            }
            GridView1.DataBind();
        }
        public static string Sha256(string str)
        {
            byte[] sha256Bytes = Encoding.UTF8.GetBytes(str);
            SHA256Managed sha256 = new SHA256Managed();
            byte[] bytes = sha256.ComputeHash(sha256Bytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }

        //protected void Unnamed1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("WebForm3.aspx", true);
        //}
    }

}
