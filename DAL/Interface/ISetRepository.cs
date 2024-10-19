using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ISetRepository
    {
        Task<Dictionary<int, Set>> GetSetsOfWorkoutExercise(int WorkoutExerciseId);
        Task<Set> Get(int id);
        Task<Set> Add(Set set );
        Task Set(Set set);
        Task Delete(Set set);
    }
}
