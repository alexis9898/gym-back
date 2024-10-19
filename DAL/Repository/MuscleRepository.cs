using DAL.Data;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class MuscleRepository : IMuscleRepository
    {
        private readonly AppDataContext _context;

        public MuscleRepository(AppDataContext context)
        {
            _context = context;
        }
        public async Task<Muscle> Get(int id)
        {
            return await _context.Muscles.Where(x=>x.Id == id)
                .Include(x=>x.Exercise)
                .FirstOrDefaultAsync();    
        }

        public async Task<List<Muscle>> GetAll()
        {
            return await _context.Muscles
                .Include(x=>x.Exercise)
                .ToListAsync();
        }
        public async Task<Muscle> Add(Muscle muscle)
        {
            _context.Muscles.Add(muscle);
            await _context.SaveChangesAsync();
            return muscle;
        }
        public async Task Set(Muscle muscle)
        {
            _context.Muscles.Update(muscle);
            await _context.SaveChangesAsync();
            return ;
        }
        public async Task Delete(Muscle muscle)
        {
            _context.Muscles.Remove(muscle);
            await _context.SaveChangesAsync();
            return ;
        }
    }
}
