using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ModelLayer.Queries {
    /// <summary/>
    [DataContract]
    public class LearningExperienceListQuery : BaseListQuery{   
        public string? Description { get; set; }
    }
}
