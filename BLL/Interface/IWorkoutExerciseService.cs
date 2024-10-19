using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IWorkoutExerciseService
    {
        Task<List<WorkoutExerciseModel>> AddDeleteWorkoutExercises(List<WorkoutExerciseModel> workoutExerciseModels, int workoutId);  //add/set/delete
        Task<bool> Delete(int id);
        Task<WorkoutExerciseModel> Add(WorkoutExerciseModel workoutExerciseModel);
    }
}
