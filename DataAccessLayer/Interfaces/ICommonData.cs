
namespace DataAccessLayer.Interfaces {
    public interface ICommonData {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        Task<ModelLayer.CommonData[]> GetCommonDataByDescriptionLikeMode(string searchTerm);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<ModelLayer.CommonData> GetCommonDataByCode(string code);
    }
}
