﻿using DataAccessLayer.Interfaces; 
using ModelLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer {
    public class LearningExperiences: ILearningExperiences {
        private readonly ApplicationDbContext _context;
        public LearningExperiences(ApplicationDbContext context) { 
            this._context = context;
        }
        public async Task<LearningExperience[]> GetAllLearningExperiences() {
            try {
                return await this._context.LearningExperiences 
                    .Include(le => le.Address).OrderByDescending(le => le.From).ToArrayAsync();  
            } catch (Exception ex) { 
                Console.WriteLine("Unexpected error: " + ex.Message);
                throw;
            }
        }
    }
}
