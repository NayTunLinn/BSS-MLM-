using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing;
using System.IO;

namespace BSSCommon
{
    public class Utility
    {

        /*By  Franco & Michael*/

        public static void PrintError(string error)
        {
            string dateTime = System.DateTime.Now.ToString();
            error = dateTime + "\nWe are very sorry for inconvenience. Please kindly send this error message to us.\n\tph:09\n\temail:\n\tfacebook: \n\nERROR{\n" + error + "\n}\n";
            error += "-------------------------------------------------------------------------------------------\n";

            StreamWriter sw = new StreamWriter(@"C:\Users\Michael\Desktop\REMS Error.txt", true);
            sw.Write(error);
            sw.Close();
        }

        public static Image ConvertByteArrayToImage(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            if (data.Length == 0) return null;
            return Image.FromStream(ms);
        }

        public static byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                //img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        public static string PasswordEncrypt(string data)
        {
            MD5CryptoServiceProvider pro = new MD5CryptoServiceProvider();
            UTF8Encoding utf = new UTF8Encoding();
            byte[] b = pro.ComputeHash(utf.GetBytes(data));

            return Convert.ToBase64String(b);
        }

        public static string BurmeseNumber(char[] num)
        {
            String[] burmese_num = { "၀", "၁", "၂", "၃", "၄", "၅", "၆", "၇", "၈", "၉" };
            string transalate_string = "";
            int j;

            for (int i = 0; i < num.Length; i++)
            {
                j = Convert.ToInt32(char.ToString(num[i]));
                transalate_string += burmese_num[j];
            }
            return transalate_string;
        }

        public static void AllClear(Control ctrl)
        {
            for (int i = 0; i <= ctrl.Controls.Count - 1; i++)
            {

                if (ctrl.Controls[i] is TextBox)
                {
                    (ctrl.Controls[i] as TextBox).Clear();
                }
             
                if (ctrl.Controls[i] is ComboBox)
                {
                    
                    //(ctrl.Controls[i] as ComboBox).SelectedIndex = 0;
                }
                if (ctrl.Controls[i] is NumericUpDown)
                {
                    (ctrl.Controls[i] as NumericUpDown).Value = 0;
                }
                if (ctrl.Controls[i] is RadioButton)
                {
                    (ctrl.Controls[i] as RadioButton).Checked = false;
                    if ((ctrl.Controls[i] as RadioButton).Name == "rdoMale")
                    {
                        (ctrl.Controls[i] as RadioButton).Checked = true;
                    }
                }

            }
        }
        public static string RemoveChar(string text, char character)
        {
            char[] txt = text.ToCharArray();
            text = string.Empty;

            for (int i = 0; i < txt.Length; i++)
            {
                if (!txt[i].Equals(character))
                {
                    text += txt[i];
                }
            }
            return text;
        }

        public static void Tab(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                e.Handled = true;
            }
        }

        public static void CenterMyControl(Control ctrl)
        {
            ctrl.Left = (ctrl.Parent.Width - ctrl.Width) / 2;
           // lblTitle.Left = (this.ClientSize.Width - lblTitle.Width) / 2;
        }

        public static void ToolTipControl(string text, Control control)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.Show(text, control, 3000);
        }
    }
}
