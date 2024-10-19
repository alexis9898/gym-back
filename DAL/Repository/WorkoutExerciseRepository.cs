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
    public class WorkoutExerciseRepository : IWorkoutExerciseRepository
    {
        private readonly AppDataContext _context;

        public WorkoutExerciseRepository(AppDataContext context)
        {
            _context = context;
        }

        // public async Task<List<WorkoutExercise>> GetExerciseOfWorkout(int workoutId)
        public async Task<WorkoutExercise> Get(int id)
        {
            var workout = await _context.WorkoutExercise.Where(w => w.Id==id).FirstOrDefaultAsync();
            return workout;
        }
        public async Task<Dictionary<int, WorkoutExercise>> GetExerciseOfWorkout(int workoutId)
        {
            //var workouts = await _context.WorkoutExercise.Where(w => w.WorkoutId == workoutId).Include(w=>w.Workout).ToListAsync();
            var workouts = await _context.WorkoutExercise.Where(w => w.WorkoutId == workoutId).ToDictionaryAsync(w=>w.Id,v=>v);
            return workouts;
        }
        public async Task<WorkoutExercise> Add(WorkoutExercise workoutExercise)
        {
            _context.WorkoutExercise.Add(workoutExercise);
            await SaveChangesAsync();
            return workoutExercise;
        }

        public async Task Set(WorkoutExercise workoutExercise)
        {
            _context.Entry(workoutExercise).State = EntityState.Detached;
            _context.WorkoutExercise.Update(workoutExercise);
            await SaveChangesAsync();
            return;
        }

        public async Task Delete(WorkoutExercise workoutExercise)
        {
            _context.WorkoutExercise.Remove(workoutExercise);
            await SaveChangesAsync();
            return;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
            return;
        }



    }
}
