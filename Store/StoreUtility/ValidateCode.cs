using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;

namespace StoreUtility
{
    public class ValidateCode
    {
        private HttpContext context;
        public ValidateCode(HttpContext context)
        {
            this.context = context;
        }

        Random rd = new Random();
        public string GetCode(int length)
        {
            StringBuilder sb = new StringBuilder();
            char[] chs = new char[] { '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int cIndex = 0;
            for (int i = 0; i < length; i++)
            {
                cIndex = rd.Next(0, chs.Length);
                sb.Append(chs[cIndex]);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="validate"></param>
        public void CreateValidateImage(string validateCode, int width, int height)
        {
            //如果验证码字符串长度等于零，直接返回，不再生成图片
            if (validateCode.Length == 0)
            {
                return;
            }
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            Font f24 = new Font("黑体", 24, FontStyle.Bold);
            Brush br = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, width, height), Color.DarkGreen, Color.Red, 1.2f, true);
            //文字下面的干扰线
            for (int i = 0; i < 50; i++)
            {
                int x1 = rd.Next(i, width - 2);
                int y1 = rd.Next(1, height - 2);
                int x2 = x1 + 2;
                int y2 = y1 + 2;
                g.DrawLine(Pens.SkyBlue, x1, y1, x2, y2);
            }
            g.DrawString(validateCode, f24, br, 2, 0);
            //文字上面的干扰线
            for (int i = 0; i < 50; i++)
            {
                int x1 = rd.Next(i, width - 2);
                int y1 = rd.Next(1, height - 2);
                int x2 = x1 - 2;
                int y2 = y1 - 2;
                g.DrawLine(Pens.Aqua, x1, y1, x2, y2);
            }
            g.DrawRectangle(Pens.Black, 0, 0, width - 2, height - 2);
            //验证码写到cookie，不需要长久保存
            HttpCookie vCodeCookie = new HttpCookie("vCode", validateCode);
            context.Response.Cookies.Add(vCodeCookie);

            this.context.Response.ContentType = "image/jpeg";
            bmp.Save(this.context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
