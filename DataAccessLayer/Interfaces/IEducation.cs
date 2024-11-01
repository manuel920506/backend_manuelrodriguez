namespace DataAccessLayer.Interfaces {
    public interface IEducation {
        Task<ModelLayer.Education[]> GetAllEducations();
    }
}
