﻿using Newtonsoft.Json.Linq;
using System;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using System.Net;

namespace WebApplication2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            
          
            Random crandom = new Random();
            int c0 = crandom.Next(10);
            string key = Sha256(c0.ToString());
            byte[] f = ConvertHexStringToByteArray(key);
            //string c=Convert.ToString(Convert.ToInt32(key.ToString(), 16), 2);
            StringBuilder Sb = new StringBuilder();
            foreach (byte b in f)
            {
                string decimalString = Convert.ToString(b);
                int decimalValue=Int32.Parse(decimalString);
                int bitcount = 0;
                while (decimalValue != 0)
                {
                    bitcount++;
                    Sb.Append((decimalValue % 2).ToString());
                    decimalValue = decimalValue / 2;
                }
                if (bitcount != 8)
                {
                    for(int i=0;i<8- bitcount; i++)
                    {
                        Sb.Append('0');
                    }
                }
                //List<string> t = new List<string>();
                //t.Add(Convert.ToString(b));
                //Sb.Append(t[0]);
            }
            string hex = Sb.ToString();
            int stringLength = hex.Length-1;
            StringBuilder Sc = new StringBuilder();
            for (int i = stringLength; i > -1; i--) 
            {
                Sc.Append(hex[i]);
            }
            string hexfall = Sc.ToString();
            Label1.Text = stringLength.ToString();
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
                    if(array3[i] >= array4[i])
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
            string alllast=alllastSb.ToString();


            string transtring = alllast.Substring(0, 8);
            int exchange_displacement = Convert.ToInt32(transtring, 2);

            StringBuilder ropufSb2 = new StringBuilder();
            StringBuilder ropufSb1 = new StringBuilder();
            int n = 0;
            for (int i = 0;i< 256; i++)
            {
                if(i + exchange_displacement < 256)
                {
                    ropufSb2.Append(alllast[i]);
                }
                else
                {
                    ropufSb1.Append(alllast[i]);
                }
            }
            string k0=ropufSb1.ToString()+ropufSb2.ToString();
            Label1.Text = k0.Length.ToString();


            string newName = TextBox1.Text.ToString();
            Object newProdID = 0;
            string sql = "SELECT User_ID FROM dbo.UserInfo WHERE User_ID = @Name;";                                   //查詢是否註冊過
            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=Project_DB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                cmd.Parameters["@Name"].Value = newName;
                try
                {
                    conn.Open();
                    SqlDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        Label1.Text = "已註冊過資料!,請等候3秒鐘喲~~~~~~~~~";//已註冊過

                    }
                    else
                    {
                        conn.Close();
                        SqlCommand cmd1 = new SqlCommand(sql, conn);
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        sql = "INSERT INTO dbo.UserInfo (User_ID, BlockchainID) VALUES ('"+ newName +"', '0x4002f065a9d36dde4ef064018d42d08d26e871a2');";
                        //+ "INSERT INTO dbo.RC_Table (User_ID, C0, Hex_R0) VALUES (@Name, @c0, @R0);"     //未註冊過，新增資料
                        //cmd1.Parameters.Add("@Name1", SqlDbType.NVarChar);
                        //cmd1.Parameters["@Name1"].Value = newName;
                        try
                        {
                            conn.Open();
                            cmd1 = new SqlCommand(sql, conn);
                            adapter.InsertCommand = new SqlCommand(sql, conn);
                            adapter.InsertCommand.ExecuteNonQuery();
                            cmd1.Dispose();
                            conn.Close();

                            sql = "INSERT INTO dbo.RC_Table (User_ID, C0 , Hex_R0) VALUES ('"+ newName + "', '"+ c0 + "' ,'"+ Sha256(k0) + "');";
                            conn.Open();
                            cmd1 = new SqlCommand(sql, conn);
                            adapter.InsertCommand = new SqlCommand(sql, conn);
                            adapter.InsertCommand.ExecuteNonQuery();
                            cmd1.Dispose();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            newProdID = null;
                            Console.WriteLine(ex.Message);
                        }
                        
                        if (newProdID != null)
                        {
                            RC_Post_To_BlockChain(newName, c0, Sha256(k0));
                        }
                        else
                        {
                            Label1.Text = "新增失敗!";
                        }
                    }


                    HttpCookie MyCookie = new HttpCookie("UserInfo"); //新增 Cookie 名稱為 UserInfo
                    MyCookie.Values["id"] = TextBox1.Text; //設定 Cookie 的值
                    MyCookie.Values["PUFcode"] = TextBox1.Text;

                    Response.Cookies.Add(MyCookie);


                    Server.Transfer("WebForm2.aspx", true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
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
            StreamReader r = new StreamReader("C:\\Users\\乖乖\\Desktop\\WebApplication2\\WebApplication2\\json.json");
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
        }

        public static string Sha256(string str)
        {
            byte[] sha256Bytes = Encoding.UTF8.GetBytes(str);
            SHA256Managed sha256 = new SHA256Managed();
            byte[] bytes = sha256.ComputeHash(sha256Bytes);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
        public static string hashfunction(string str, int id, int hash, string str2)
        {
            string allstr = str + id.ToString() + str2 + hash.ToString();
            byte[] sha256Bytes = Encoding.UTF8.GetBytes(allstr);
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

        public static void RC_Post_To_BlockChain(string UID, int C, string Hex_K)
        {
            
        }

        protected void b2_Click(object sender, EventArgs e)
        {
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}