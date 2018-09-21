using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaptchaApp.AppClass;

namespace CaptchaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string strBkImagePath = System.Configuration.ConfigurationSettings.AppSettings.Get("BkImagePath");
            
            //Train
            string[] arrTrainStr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "9", "9" };
            for (int i = 0; i <=999; i++)
            {
                foreach (var str in arrTrainStr)
                {
                    string CaptchaImagePath = System.Configuration.ConfigurationSettings.AppSettings.Get("CaptchaTrainImagePath") + str + System.Guid.NewGuid().ToString() + ".jpg";
                    CaptchaClass CaptchaClass = new CaptchaClass();
                    var result = CaptchaClass.CreateCaptcha(str, "Arial", strBkImagePath, 50, 50);
                    result.Save(CaptchaImagePath);
                    result.Dispose();
                }
            }

            //Test
            string[] arrTestStr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            for (int i = 0; i <= 99; i++)
            {
                foreach (var str in arrTestStr)
                {
                    string CaptchaImagePath = System.Configuration.ConfigurationSettings.AppSettings.Get("CaptchaTestImagePath") + str + System.Guid.NewGuid().ToString() + ".jpg";
                    CaptchaClass CaptchaClass = new CaptchaClass();
                    var result = CaptchaClass.CreateCaptcha(str, "Arial", strBkImagePath, 50, 50);
                    result.Save(CaptchaImagePath);
                    result.Dispose();
                }
            }

        }
    }
}
