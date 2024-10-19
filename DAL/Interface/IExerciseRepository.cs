using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAll();
        Task<Exercise> Get(int id);
        Task<Exercise> Add(Exercise exercise);
        Task Set(Exercise exercise);
        Task Delete(Exercise exercise);
    }
}
