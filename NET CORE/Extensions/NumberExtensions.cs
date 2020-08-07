namespace EPublico.Core.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsNull(this int? n)
        {
          if(n == null)
            return true;

          return n.HasValue ? false : true;
        }

        public static bool IsNull(this decimal? d)
        {
          if(d == null)
            return true;

          return d.HasValue ? true : false;
        }

         public static decimal getValue(this decimal? d, decimal defaultVal = 0)
        {
          if(d == null)
            return defaultVal;

          return d.HasValue ? d.Value : defaultVal;
        }
    }
}
