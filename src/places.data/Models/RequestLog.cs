namespace places.data
{
    public class RequestLog
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public required string RequestData { get; set; }
        public required string ResponseData { get; set; }
    }
}
