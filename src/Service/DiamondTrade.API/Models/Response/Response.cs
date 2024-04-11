namespace DiamondTrade.API.Models.Response
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
