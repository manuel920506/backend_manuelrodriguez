using ModelLayer.Enums; 
using System.Runtime.Serialization; 

namespace ModelLayer.Queries {
    public class BaseItemQuery {
        public int Id { get; set; }
        /// <summary> 
        /// </summary> 
        public string? Description { get; set; } 
    }
}
