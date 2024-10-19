using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IWorkoutMuscleRepository
    {
        Task<Dictionary<int, Muscle>> GetMusclesOfWorkout(int workoutId);
        Task<WorkoutMuscle> Get(int workoutId, int muscleId);
        Task<WorkoutMuscle> Add(WorkoutMuscle workoutMuscle);
        Task Set(WorkoutMuscle workoutMuscle);
        Task Delete(WorkoutMuscle workoutMuscle);
    }
}
