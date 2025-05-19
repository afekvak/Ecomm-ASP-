using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecomm
{
    public class GlobFunc
    {
        public static string randomString(int length)//מייצרת מחרוזת אקראית באורך שנבחר
        {
            string st = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";//המחרוזת שממנה נבחרות האותיות
            string RetVal = "";//מכילה את המחרוזת הסופית
            Random rnd = new Random();//אובייקט רנדומלי שמייצר מספרים אקראיים
            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(st.Length);
                RetVal += st[index];//מוסיפה את האות האקראית שנבחרה למחרוזת הסופית
            }
            return RetVal;//מחזירה את המחרוזת הסופית
        }

    }
}