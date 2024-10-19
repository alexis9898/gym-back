using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IExerciseService
    {
        Task<List<ExerciseModel>> GetAll();
        Task<List<ExerciseModel>> AddList(List<ExerciseModel> exerciseModels);
        Task<ExerciseModel> Add(ExerciseModel exerciseModel);
        Task<ExerciseModel> Get(int id);


    }
}
