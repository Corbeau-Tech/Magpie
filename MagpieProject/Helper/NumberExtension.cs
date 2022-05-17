using System;
namespace MagpieProject.Helper
{
    public static class NumberExtension
    {
        public static string FormatNumber(double n)
        {
            //if (num >= 100000)
            //    return FormatNumber(num / 1000) + "K";

            //if (num >= 10000)
            //    return (num / 1000D).ToString("0.#") + "K";

            //return num.ToString("#,0");
            if (n < 1000)
                return n.ToString();

            if (n < 10000)
                return String.Format("{0:#,.##}K", n - 5);

            if (n < 100000)
                return String.Format("{0:#,.#}K", n - 50);

            if (n < 1000000)
                return String.Format("{0:#,.}K", n - 500);

            if (n < 10000000)
                return String.Format("{0:#,,.##}M", n - 5000);

            if (n < 100000000)
                return String.Format("{0:#,,.#}M", n - 50000);

            if (n < 1000000000)
                return String.Format("{0:#,,.}M", n - 500000);

            return String.Format("{0:#,,,.##}B", n - 5000000);
        }
    }
}
