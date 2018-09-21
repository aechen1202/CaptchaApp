using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CaptchaApp.AppClass
{
    public class CaptchaClass
    {
        public Bitmap CreateCaptcha(string text, string fontName, string backgroundImagePath, int width, int height)
        {
            var backImage = new Bitmap(backgroundImagePath);
            //如果原图过小 就以原图大小为主
            if (backImage.Width < width || backImage.Height < height)
            {
                throw new Exception("结果尺寸不得小于採样大小的图片");
            }
            //随机取一个位置 并且按造欲需求的大小裁切
            //请注意随机採样范围 记得为 图片宽度-欲取的宽度 高度也是 ，不然会发生裁切超过范围
            backImage =
            backImage.Clone(
            new Rectangle(new Random().Next(0, backImage.Width - width),
            new Random().Next(0, backImage.Height - height), width, height), backImage.PixelFormat);

            Graphics graphics = Graphics.FromImage(backImage);

            //合成的文字为黑色

            Brush br = new SolidBrush(Color.Black);

            //将字体画上图片

            //字体的大小 为 宽度/字数
            graphics.DrawString(text, new Font(new FontFamily(fontName), (float)width / (text.Length)), br, new PointF(-10, -10));
            
            return backImage;

        }
    }
}
