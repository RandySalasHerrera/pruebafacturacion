using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EPublico.Core.Extensions {
  public static class QueryableExtensions {
    public static IQueryable<T> Paginate<T> (
      this IQueryable<T> source,
      IPaginationInfo pagination) {
      return source
        // .Skip ((pagination.PageNumber - 1) * pagination.PageSize)
        .Skip (pagination.SkipCount)
        .Take (pagination.PageSize);

    }
  }

  public static class IEnumerableExtensions {
    public static IEnumerable<T> Paginate<T> (
      this IEnumerable<T> source,
      IPaginationInfo pagination) {
      return source
        // .Skip ((pagination.PageNumber - 1) * pagination.PageSize)
        .Skip (pagination.SkipCount)
        .Take (pagination.PageSize);

    }
  }

  public interface IPaginationInfo {
    int SkipCount { get; }
    int PageSize { get; }
    string Sorting { get; }
  }

  public abstract class QueryArgsBase : IPaginationInfo {
    public int SkipCount { get; set; } = 0;
    public int PageSize { get; set; } = 20;

    public string Sorting { get; set; }

  }

  public class PaginateArgs : QueryArgsBase {
    
  }

  public class PaginateArgsWithFilter : QueryArgsBase {
    public string Filter { get; set; }
  }

  // public class CCListFilters : QueryArgsBase {

  //   [MaxLength (6)]
  //   public string Bins { get; set; }

  //   [MaxLength (100)]
  //   public string Zips { get; set; }

  //   [DisplayFormat (ConvertEmptyStringToNull = true)]
  //   public string BaseId { get; set; }

  //   [DisplayFormat (ConvertEmptyStringToNull = true)]
  //   public string BankName { get; set; }

  //   [DisplayFormat (ConvertEmptyStringToNull = true)]
  //   public int? CardType { get; set; }

  //   [DisplayFormat (ConvertEmptyStringToNull = true)]
  //   public int? CardRank { get; set; }

  //   [DisplayFormat (ConvertEmptyStringToNull = true)]
  //   public int? CardBrand { get; set; }

  //   public bool SSN { get; set; } = false;

  //   public bool DOB { get; set; } = false;
  //   public bool MMN { get; set; } = false;
  //   public bool VBV { get; set; } = false;

  //   public bool Email { get; set; } = false;
  //   public bool LastSSN { get; set; } = false;
  //   public bool Phone { get; set; } = false;
  //   public bool Refound { get; set; } = false;
  //   public bool NoRefund { get; set; } = false;
  //   public bool Discount { get; set; } = false;

  //   [DisplayFormat (ConvertEmptyStringToNull = true)]
  //   public int? CountryId { get; set; }

  //   [DisplayFormat (ConvertEmptyStringToNull = true)]
  //   public int? StateId { get; set; }

  //   [DisplayFormat (ConvertEmptyStringToNull = true)]
  //   public int? CityId { get; set; }

  //   [DisplayFormat (ConvertEmptyStringToNull = true)]
  //   public string Address { get; set; }

  //   [DisplayFormat (ConvertEmptyStringToNull = true)]
  //   public int? ExpireMonth { get; set; }

  //   [DisplayFormat (ConvertEmptyStringToNull = true)]
  //   public int? ExpireYear { get; set; }

  // }

}