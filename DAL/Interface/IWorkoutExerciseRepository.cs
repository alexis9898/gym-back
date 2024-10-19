using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;

namespace DAL.Interface
{
    public interface IWorkoutExerciseRepository
    {
        Task<WorkoutExercise> Get(int id);
        Task<WorkoutExercise> Add(WorkoutExercise workoutExercise);
        Task Set(WorkoutExercise  workoutExercise);
        Task Delete(WorkoutExercise workoutExercise);
        //Task<List<WorkoutExercise>> GetExerciseOfWorkout(int workoutId);
        Task SaveChangesAsync();
        Task<Dictionary<int, WorkoutExercise>> GetExerciseOfWorkout(int workoutId);




    }
}
