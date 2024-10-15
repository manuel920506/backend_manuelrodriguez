using DataAccessLayer.Interfaces;
using ModelLayer.Queries;
using ModelLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer {
    public class LearningExperiences: ILearningExperiences {
        private readonly ApplicationDbContext _context;
        public LearningExperiences(ApplicationDbContext context) { 
            this._context = context;
        }
        public async Task<LearningExperience[]> GetAllLearningExperiences(LearningExperienceListQuery query) {
            try {
                return await this._context.LearningExperiences 
                    .Include(le => le.Address).OrderByDescending(le => le.From).ToArrayAsync(); 
            } catch (InvalidOperationException ex) {
                // Log dell'eccezione
                Console.WriteLine("Invalid operation: " + ex.Message);
                throw;
            } catch (DbUpdateException ex) {
                // Log dell'eccezione
                Console.WriteLine("Database update error: " + ex.Message);
                throw;
            } catch (Exception ex) {
                // Log dell'eccezione
                Console.WriteLine("Unexpected error: " + ex.Message);
                throw;
            }
        }
    }
}
