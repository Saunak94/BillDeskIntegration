namespace BillDesk
{
    public class DataEntryModel
    {
        public string BDTraceid {get; set;}
        public string BDTimestamp { get; set; }
        public string Client { get; set; }
        public string ClientSercet { get; set; }
        public string SHA256Id { get; set; }
        public string BaseUrl { get; set; }
        public string SourceId { get; set; }
        public string CustomerId { get; set; }
    }
}
