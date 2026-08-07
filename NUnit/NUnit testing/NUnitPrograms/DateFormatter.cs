using System;

namespace NUnitPrograms
{
    public class DateFormatter
    {
        public string FormatDate(string inputDate)
        {
            DateTime date = DateTime.ParseExact(
                inputDate,
                "yyyy-MM-dd",
                null);

            return date.ToString("dd-MM-yyyy");
        }
    }
}