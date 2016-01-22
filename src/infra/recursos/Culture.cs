using System.Globalization;
using System.Threading;

namespace br.com.klinderrh.social.infra.recursos
{
    public static class Culture
    {
        public static void ChangeCultureInfo(string culture)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }
    }
}