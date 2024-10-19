using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IWorkoutMuscleService
    {
        Task<List<MuscleModel>> AddDeleteMuscleWorkout(List<MuscleModel> muscles , int workoutId);
        Task<bool> Delete(int workoutId, int muscleId);
        Task<MuscleModel> Add(int workoutId, int muscleId);
    }
}
