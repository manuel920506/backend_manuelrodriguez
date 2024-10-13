using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ModelLayer {
    [DataContract]
    public class BaseEntity: EntityKeyInt {
        public DateTime From { get; set; } 
        public DateTime? To { get; set; } 
        public bool IsRemote { get; set; }
    }
}
