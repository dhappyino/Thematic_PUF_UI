using Newtonsoft.Json.Linq;
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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            string str = TextBox1.Text.ToString();
            string s1=StringToHexString(str, System.Text.Encoding.UTF8);
            Label1.Text = s1;
            string s2 = HexStringToString(s1, System.Text.Encoding.UTF8);
            Label2.Text = s2;
        }

        private string StringToHexString(string s, Encoding encode)
        {
            byte[] b = encode.GetBytes(s);//按照指定編碼將string編程字節數組
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字節變為16進制字符
            {
                result += Convert.ToString(b[i], 16);
            }
            return result;
        }

        private string HexStringToString(string hs, Encoding encode)
        {
            string strTemp = "";
            byte[] b = new byte[hs.Length / 2];
            for (int i = 0; i < hs.Length / 2; i++)
            {
                strTemp = hs.Substring(i * 2, 2);
                b[i] = Convert.ToByte(strTemp, 16);
            }
            //按照指定編碼將字節數組變為字符串
            return encode.GetString(b);
        }
    }
}