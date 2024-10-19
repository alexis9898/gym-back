using BLL.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IMuscleService
    {
        Task<List<MuscleModel>> GetAll();
        Task<MuscleModel> Get(int id);
        Task<MuscleModel> Add(MuscleModel muscleModel);
        Task<MuscleModel> Set(MuscleModel muscleModel);
        Task<bool> Delete(int id);
    }
}
