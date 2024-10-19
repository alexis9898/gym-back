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
    public class SetRepository: ISetRepository
    {
        private readonly AppDataContext _context;

        public SetRepository(AppDataContext context)
        {
            this._context = context;
        }

        public Task<Set> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Dictionary<int, Set>> GetSetsOfWorkoutExercise(int WorkoutExerciseId)
        {
            return await _context.Sets.Where(x=>x.WorkoutExerciseId == WorkoutExerciseId).ToDictionaryAsync(x=>x.Id,y=>y);
        }

        public async Task<Set> Add(Set set)
        {
            _context.Sets.Add(set);
            await _context.SaveChangesAsync();
            return set;
        }

        public async Task Set(Set set)
        {
            _context.Sets.Update(set);
            await _context.SaveChangesAsync();
            return;
        }
        public async Task Delete(Set set)
        {
            _context.Sets.Remove(set);
            await _context.SaveChangesAsync();
            return;
        }

    }
}
