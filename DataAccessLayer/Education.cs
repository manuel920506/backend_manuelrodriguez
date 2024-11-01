using DataAccessLayer.Interfaces; 
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer {
    public class Education : IEducation {
        private readonly ApplicationDbContext _context;
        public Education(ApplicationDbContext context) { 
            this._context = context;
        }
        public async Task<ModelLayer.Education[]> GetAllEducations() {
            try {
                return await this._context.Educations.OrderByDescending(e => e.From).ToArrayAsync();  
            } catch (Exception ex) { 
                Console.WriteLine("Unexpected error: " + ex.Message);
                throw;
            }
        }
    }
}
