namespace ControllerLayer.DTOs {
    public class BaseEntityDTO : EntityKeyIntDTO {
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public bool IsRemote { get; set; }
    }
}
