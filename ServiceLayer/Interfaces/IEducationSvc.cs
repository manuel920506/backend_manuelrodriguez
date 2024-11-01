using ModelLayer; 

namespace ServiceLayer.Interfaces {
    public interface IEducationSvc {
        Task<Education[]> GetAllEducations();
    }
}
