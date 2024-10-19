using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ISetService
    {
        Task<List<SetModel>> AddDeleteSet(List<SetModel> setModels, int workoutExerciseId);  //add/set/delete
        Task<SetModel> Add(SetModel setModel);
    }
}
