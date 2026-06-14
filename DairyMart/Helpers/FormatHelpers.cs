using System.Globalization;

namespace DairyMart.Helpers
{
    public static class FormatHelper
    {
        public static string KeRupiah(int nominal)
        {
            return nominal.ToString("C0", CultureInfo.GetCultureInfo("id-ID"));
        }
    }
}