using System;

namespace Mohammed_Albeltagi_employees
{
    class Helper
    {
        internal static DateTime ConvertToDateTime(string strDate)
        {
            int year = int.Parse(strDate.Split('-')[0]);
            int month = int.Parse(strDate.Split('-')[1]);
            int day = int.Parse(strDate.Split('-')[2]);

            return new DateTime(
                year, 
                month, 
                day);
        }
    }
}
