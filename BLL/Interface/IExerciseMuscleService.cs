using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Service;

namespace BLL.Interface
{
    public interface IExerciseMuscleService
    {
        Task<List<ExerciseModel>> AddExercisesMuscle(List<ExerciseModel> exercises, int muscleId);
        Task<bool> Delete(int exerciseId, int muscleId);
        Task<ExerciseModel> Add(int exerciseId, int muscleId);
    }
}
