using Newtonsoft.Json.Linq;
using System;
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
            int x = crandom.Next(10);
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            string key = Sha256(x.ToString());
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
            string ropuf=ropufSb1.ToString()+ropufSb2.ToString();
            Label1.Text = ropuf.Length.ToString();
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
    }
}