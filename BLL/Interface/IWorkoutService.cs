using BLL.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IWorkoutService
    {
        Task<WorkoutModel> Get(int workoutId);
        Task<WorkoutModel> Add(WorkoutModel workoutModel);
        Task<WorkoutModel> Set(WorkoutModel workoutModel);
        Task<bool> Delete(int workoutID);


    }
}
