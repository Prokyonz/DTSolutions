using static DiamondTrade.API.Models.Enum.Enum;

namespace DiamondTrade.API.Models.Request
{
    public class ApproveRejectRequest
    {
        public ReportType ReportType { get; set; }
        public string Id { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
    }
}
