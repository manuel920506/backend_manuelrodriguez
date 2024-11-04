
namespace ModelLayer {
    public class UserActivityLog : EntityKeyInt { 
        public string UserId { get; set; }
        public string Description { get; set; }
        public string IpAddress { get; set; }
        public string DeviceType { get; set; }
        public string Location { get; set; } 
        public DateTime Timestamp { get; set; }
    }
}
