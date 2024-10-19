using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IExerciseMuscleRepository
    {
        //Task<List<ExerciseMuscle>> GetAll();
        Task<Dictionary<int, Exercise>> GetExerciseOfMuscle(int muscleId);
        Task<ExerciseMuscle> Get(int exerciseId, int muscleId);
        Task<ExerciseMuscle> Add(ExerciseMuscle exerciseMuscle);
        Task Set(ExerciseMuscle exerciseMuscle);
        Task Delete(ExerciseMuscle exerciseMuscle);
    }
}
