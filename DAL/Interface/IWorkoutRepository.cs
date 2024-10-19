using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IWorkoutRepository
    {
        Task<Workout> GetWithInfo(int Id);
        Task<Workout> Get(int Id);
        Task<Workout> Add(Workout workout);
        Task Set(Workout workout);
        Task Delete(Workout workout); 

    }
}
