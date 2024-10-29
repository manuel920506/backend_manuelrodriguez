using DataAccessLayer.Interfaces; 
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer {
    public class CommonData : ICommonData {
        private readonly ApplicationDbContext _context;
        public CommonData(ApplicationDbContext context) { 
            this._context = context;
        }
        public async Task<ModelLayer.CommonData[]> GetCommonDataByDescriptionLikeMode(string searchTerm) {
            try {
                var results = await this._context.CommonData
                .Where(s => s.Description.Contains(searchTerm))
                .ToArrayAsync();
                return results;  
            } catch (Exception ex) { 
                Console.WriteLine("Unexpected error: " + ex.Message);
                throw;
            }
        }

        public async Task<ModelLayer.CommonData> GetCommonDataByCode(string code) {
            try {
                var result = await this._context.CommonData
                .Where(s => s.Code == code)
                .FirstOrDefaultAsync();
                return result;
            } catch (Exception ex) {
                Console.WriteLine("Unexpected error: " + ex.Message);
                throw;
            }
        }
    }
}
