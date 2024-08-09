namespace Repository.Entities.Model
{
    public class CacheKeyGenerator
    {
        public string CompanyId { get; set; }
        public string FinancialYearId { get; set; }
        public string UserId { get; set; }
        public bool IsCacheEnabled { get; set; }
    }
}
