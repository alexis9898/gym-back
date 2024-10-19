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
    public class ExerciseMuscleRepository : IExerciseMuscleRepository
    {
        private readonly AppDataContext _context;

        public ExerciseMuscleRepository(AppDataContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<int,Exercise>> GetExerciseOfMuscle(int muscleId)
        {
            return await _context.ExerciseMuscle.Where(x=>x.MuscleId == muscleId)
                .Include(x=>x.Exercise)
                .ToDictionaryAsync(x=>x.ExerciseId,v=>v.Exercise);
        }

        public async Task<ExerciseMuscle> Get(int exerciseId, int muscleId)
        {
            return await _context.ExerciseMuscle.Where(x=>x.ExerciseId==exerciseId && x.MuscleId==muscleId).FirstOrDefaultAsync();
        }

        public async Task<ExerciseMuscle> Add(ExerciseMuscle exerciseMuscle)
        {
            _context.ExerciseMuscle.Add(exerciseMuscle);
            await _context.SaveChangesAsync();
            return exerciseMuscle;
        }

        public async Task Set(ExerciseMuscle exerciseMuscle)
        {
            _context.ExerciseMuscle.Update(exerciseMuscle);
            await _context.SaveChangesAsync();
            return ;
        }
        public async Task Delete(ExerciseMuscle exerciseMuscle)
        {
            _context.ExerciseMuscle.Remove(exerciseMuscle);
            await _context.SaveChangesAsync();
            return ;
        }
    }
}
