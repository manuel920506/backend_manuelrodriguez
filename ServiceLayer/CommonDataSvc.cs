using DataAccessLayer.Interfaces;
using ModelLayer; 
using ServiceLayer.Interfaces; 

namespace Services {
    public class CommonDataSvc : ICommonDataSvc {
        private readonly ICommonData commonData;
        public CommonDataSvc(ICommonData commonData) {
            this.commonData = commonData;
        }
        public async Task<CommonData[]> GetCommonDataByDescriptionLikeMode(string searchTerm) {
            return await this.commonData.GetCommonDataByDescriptionLikeMode(searchTerm);
        }

        public async Task<CommonData> GetCommonDataByCode(string code) {
            return await this.commonData.GetCommonDataByCode(code);
        }
    }
}
