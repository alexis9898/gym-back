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
    public class WorkoutMuscleRepository: IWorkoutMuscleRepository
    {
        private readonly AppDataContext _context;

        public WorkoutMuscleRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<int, Muscle>> GetMusclesOfWorkout(int workoutId)
        {
            return await _context.WorkoutMuscles.Where(x=>x.WorkoutId==workoutId).ToDictionaryAsync(x=>x.MuscleId,y=>y.Muscle);
        }

        public async Task<WorkoutMuscle> Get(int workoutId, int muscleId)
        {
            return await _context.WorkoutMuscles.Where(x=>x.WorkoutId==workoutId && x.MuscleId==muscleId).FirstOrDefaultAsync();
        }

        public async Task<WorkoutMuscle> Add(WorkoutMuscle workoutMuscle)
        {
            _context.WorkoutMuscles.Add(workoutMuscle);
            _context.SaveChanges();
            return workoutMuscle;
        }

        public async Task Set(WorkoutMuscle workoutMuscle)
        {
            _context.WorkoutMuscles.Update(workoutMuscle);
            _context.SaveChanges();
            return;
        }

        public async Task Delete(WorkoutMuscle workoutMuscle)
        {
            _context.WorkoutMuscles.Remove(workoutMuscle);
            _context.SaveChanges();
            return;
        }
    }
}
