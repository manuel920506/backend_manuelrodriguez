using DataAccessLayer.Interfaces; 
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer {
    public class Skill: ISkill {
        private readonly ApplicationDbContext _context;
        public Skill(ApplicationDbContext context) { 
            this._context = context;
        }
        public async Task<ModelLayer.Skill[]> GetAllSkills() {
            try {
                return await this._context.Skills.OrderByDescending(s => s.Weight).ToArrayAsync();  
            } catch (Exception ex) { 
                Console.WriteLine("Unexpected error: " + ex.Message);
                throw;
            }
        }
    }
}
